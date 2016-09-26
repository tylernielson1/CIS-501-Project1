using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Project1
{
    class CardDeck
    {
        public static PlayingCard[] deck = new PlayingCard[53];
        public static int topIndex;

        public CardDeck()
        {
            int tempCount = 0;
            for(int i = 1; i < 5; i++)
            {
                for(int j = 0; j < 13; j++)
                {
                    deck[tempCount] =  new PlayingCard(j, i, false);
                    tempCount++;
                }
            }
            deck[tempCount] = new PlayingCard(13, 5, false);
        }

        private PlayingCard Draw()
        {
            PlayingCard temp;
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

        public static void ReturnCard(PlayingCard card)
        {
            topIndex++;
            deck[topIndex] = card;
        }
    }
}
