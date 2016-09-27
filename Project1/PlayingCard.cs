using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Project1
{
    class PlayingCard
    {
        public enum CardSuit
        {
            Club=1,
            Heart,
            Diamond,
            Spade,
            OldMaid
        };
        static readonly string[] suits = { "C", "H", "D", "S", "O" };
        static readonly string[] ranks = {"M", "A", "2", "3", "4", "5", "6", "7", "8", "9", "0", "J", "Q", "K" };

        private int _rank;
        private bool _faceUp;
        private CardSuit _suit;

        public PlayingCard(int r, int s, bool f)
        {
            _rank = r;
            _suit = (CardSuit)s;
            _faceUp = f;
        }

        public int Rank
        {
            get
            {
                return _rank;
            }
        }

        public CardSuit Suit
        {
            get
            {
                return _suit;
            }
        }

        public bool FaceUp
        {
            get
            {
                return _faceUp;
            }
            set
            {
                _faceUp = value;
            }
        }


        public override string ToString()
        {
            if(this._faceUp)
            {
                string temp = suits[(int)_suit - 1] + ranks[_rank];
                return temp;
            }
            else
            {
                return "XX";
            }
        }
    }
}
