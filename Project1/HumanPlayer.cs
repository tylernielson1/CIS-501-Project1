using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Project1
{
    class HumanPlayer : Player
    {
        public HumanPlayer(string n, int p)
        {
            IsUser = true;
            Name = n;
            topIndex = -1;
            Hand = new PlayingCard[(53 / p) + 2];
        }
        public override void Deal(PlayingCard card)
        {
            card.FaceUp = true;
            topIndex++;
            Hand[topIndex] = card;
        }
    }
}
