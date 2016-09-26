using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Project1
{
    abstract class Player
    {
        private PlayingCard[] hand; //TODO: change hand size.
        public int topIndex;
        private string name;
        private CardDeck deck;
        private bool isUser;

        private static PlayingCard[] temp = new PlayingCard[15];

        public bool IsUser
        {
            get
            {
                return isUser;
            }
            set
            {
                isUser = value;
            }
        }

        public PlayingCard[] Hand
        {
            get
            {
                return hand;
            }
            set
            {
                hand = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int NumCardsInHand
        {
            get { return hand.Length; }
        }

        private void Shuffle()
        {//http://rosettacode.org/wiki/Knuth_shuffle
            Random r = new Random();
            for (int i = 0; i < hand.Length; i++)
            {
                int j = r.Next(i, hand.Length);
                PlayingCard temp = hand[i];
                hand[i] = hand[j];
                hand[j] = temp;
            }
        }

        private void DiscardAllPairs()
        {

        }

        public abstract void Deal(PlayingCard card);

        private PlayingCard PickCardAt(int i)
        {
            if (i >= 0 && i <= topIndex)
            {
                PlayingCard temp = hand[i];
                hand[i] = hand[topIndex];
                hand[topIndex] = null;
                topIndex--;
                return temp;
            }
            else
            {
                throw new IndexOutOfRangeException("Your choice is not in the range of valid numbers");
            }
        }

        private void AddCard(PlayingCard card)
        {
            bool duplicate = false;
            for(int i = 0; i <= topIndex; i++)
            {
                if(hand[i].Rank == card.Rank)
                {

                }
            }
            if(!duplicate)
            {
                topIndex++;
                hand[topIndex] = card;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(PlayingCard c in hand)
            {
                if(c != null)
                {
                    sb.Append(c.ToString() + " ");
                }
            }
            return sb.ToString();
        }

        private void ReturnHandToDeck()
        {
            for(int i = 0; i < hand.Length; i++)
            {
                if(hand[i] != null)
                {
                    CardDeck.ReturnCard(hand[i]);
                    hand[i] = null;
                }
            }
        }
    }
}
