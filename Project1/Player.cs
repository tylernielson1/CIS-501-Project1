using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Player
    {
        private PlayingCard[] hand = new PlayingCard[53]; //TODO: change hand size.
        private int topIndex;
        private string Name;
        private CardDeck deck;

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

        public virtual void Deal(PlayingCard card)
        {

        }

        private PlayingCard PickCardAt(int i)
        {

        }

        private void AddCard(PlayingCard card)
        {

        }

        public override string ToString()
        {
            
        }

        private void ReturnHandToDeck()
        {

        }
    }
}
