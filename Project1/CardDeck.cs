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

        private CardDeck(PlayingCard[] d, int t)
        {
            deck = d;
            topIndex = t;
        }

        private PlayingCard Draw()
        {

        }

        private void Shuffle()
        {
            //Knuth's Algorithm
        }

        private void ReturnCard(PlayingCard card)
        {

        }
    }
}
