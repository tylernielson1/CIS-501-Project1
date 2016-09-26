using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class CardDeck
    {
        private PlayingCard[] deck = new PlayingCard[53];
        private int topIndex;

        public CardDeck()
        {
            PlayingCard tempCard = new PlayingCard();
            int tempCount = 0;
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 13; j++)
                {
                    //TODO: Deal cards correctly
                }
            }
        }

        private PlayingCard Draw()
        {
            PlayingCard temp = new PlayingCard();
            temp = deck[topIndex];
            deck[topIndex] = null;
            topIndex--;
            return temp;
        }

        private void Shuffle()
        {//http://rosettacode.org/wiki/Knuth_shuffle
            Random r = new Random();
            for (int i = 0; i < deck.Length; i++)
            {
                int j = r.Next(i, deck.Length);
                PlayingCard temp = deck[i];
                deck[i] = deck[j];
                deck[j] = temp;
            }
        }

        private void ReturnCard(PlayingCard card)
        {
            topIndex++;
            deck[topIndex] = card;
        }
    }
}
