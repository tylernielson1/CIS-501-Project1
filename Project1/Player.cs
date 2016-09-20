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
        {
            //Knuth's Algorithm
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
