using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Joker
        };

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
                _faceUp = this.FaceUp;
            }
        }


        public override string ToString()
        {
            if(this._faceUp)
            {
                
            }
            else
            {
                return "XX";
            }
        }
    }
}
