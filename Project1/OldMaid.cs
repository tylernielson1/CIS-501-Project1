using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Project1
{
    class OldMaid
    {
        public CardDeck deck;
        public List<Player> currentPlayers = new List<Player>();
        public int numPlayers;
        public Player[] allPlayers;
        ConsoleTerminal ct = new ConsoleTerminal();

        public void MyProgram()
        {
            deck = new CardDeck();
            int computerPlayers = ct.GetInt("Input number of computer players (Between 2 and 5) : ", 2, 5);
            numPlayers = computerPlayers + 1;
            allPlayers = new Player[numPlayers];

            HumanPlayer human = new HumanPlayer("hooman", numPlayers);
            allPlayers[0] = human;
            for(int i = 1; i < allPlayers.Length; i++)
            {
                ComputerPlayer comp = new ComputerPlayer("puter" + i, numPlayers);
                allPlayers[i] = comp;
            }

            //TODO loop de loop
            ScatterPlayers();
            for(int i = 0; i < allPlayers.Length; i++)
            {
                currentPlayers.Add(allPlayers[i]);
            }
            deck.Shuffle();
            DealCards();
            ct.DisplayLine("**** After the deal ****");
            ShowHands();
            DiscardDupes();
            ShuffleHands();
            ct.DisplayLine("**** After discarding pairs and shuffling each hand ****");
            ShowHands();
            ct.DisplayLine("");
            ct.Wait();
            bool stop;
            int drawer = 0;
            int drawee = 0;
            do
            {
                stop = OneTurn(ref drawer, ref drawee);
            } while (!stop);




        }


        private void ScatterPlayers()
        {//http://rosettacode.org/wiki/Knuth_shuffle
            Random r = new Random();
            for(int i = 0; i < allPlayers.Length; i++)
            {
                int temp = r.Next(i, allPlayers.Length);
                Player p = allPlayers[i];
                allPlayers[i] = allPlayers[temp];
                allPlayers[temp] = p;
            }
        }

        private void DealCards()
        {
            int count = 0;
            while (count < 53)
            {
                foreach(Player p in currentPlayers)
                {
                    if(count != 53)
                    {
                        p.Deal(deck.Draw());
                    }
                    count++;
                }
            }
        }

        private void ShowHands()
        {
            foreach(Player p in currentPlayers)
            {
                ct.DisplayLine(p.ToString());
            }
        }

        private void DiscardDupes()
        {
            foreach(Player p in currentPlayers)
            {
                p.DiscardAllPairs();
            }
        }

        private void ShuffleHands()
        {
            foreach(Player p in currentPlayers)
            {
                p.Shuffle();
            }
        }

        private bool OneTurn(ref int drawer, ref int drawee)
        {
            bool stop = false;
            drawee = (drawer + 1) % currentPlayers.Count;
            if(currentPlayers[drawer].IsUser)
            {
                ct.DisplayLine("******** Now User's Turn *********");
                ct.DisplayLine(currentPlayers[drawer].ToString());
                ct.DisplayLine(currentPlayers[drawee].ToString());
                if(!currentPlayers[drawee].IsUser)
                {//oh god why. this disgusts me.
                    ComputerPlayer temp = (ComputerPlayer)currentPlayers[drawee];
                    ct.DisplayLine(temp.MakeCardIndices());
                }
            }



            drawer++;
            if (drawer > currentPlayers.Count - 1)
            {
                drawer = 0;
            }
        }
    }
}
