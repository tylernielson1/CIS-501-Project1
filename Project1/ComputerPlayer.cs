using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Project1
{
    class ComputerPlayer : Player
    {
        public ComputerPlayer(string n, int p)
        {
            IsUser = false;
            Name = n;
            Hand = new PlayingCard[(53 / p) + 2];
            topIndex = -1;
        }
        private string MakeCardIndices()
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < NumCardsInHand; i++)
            {
                sb.Append(i + " ");
            }
            return sb.ToString();
        }

        public override void Deal(PlayingCard card)
        {
#if DEBUG
            card.FaceUp = true;
#else
            card.FaceUp = false;
#endif
            topIndex++;
            Hand[topIndex] = card;
        }
    }
}
