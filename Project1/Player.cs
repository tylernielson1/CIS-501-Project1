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
        private PlayingCard[] hand;
        public int topIndex;
        private string name;
        private CardDeck deck;
        private bool isUser;

        private static PlayingCard[] temp = new PlayingCard[14];

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
            get
            {
                int temp = 0;
                for (int i = 0; i < hand.Length; i++)
                {
                    if (hand[i] != null) temp++;
                }
                return temp;
            }
        }

        public void Shuffle()
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

        public void DiscardAllPairs()
        {
            for (int i = 0; i < hand.Length; i++)
            {
                int index = (int)hand[i].Rank;
                if (temp[index] != null)
                {
                    CardDeck.ReturnCard(temp[index]);
                    temp[index] = null;
                    CardDeck.ReturnCard(hand[i]);
                    hand[i] = null;
                }
                else
                {
                    temp[index] = hand[i];
                    hand[i] = null;
                }
            }
            int hold = 0;
            for(int i = 0; i < temp.Length; i++)
            {
                if(temp[i] != null)
                {
                    hand[hold] = temp[i];
                    hold++;
                    temp[i] = null;
                }
            }
            topIndex = hold;
        }

        public abstract void Deal(PlayingCard card);

        public PlayingCard PickCardAt(int i)
        {//Picks a card from the player's hand and returns the card picked.
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

        public void AddCard(PlayingCard card)
        {//Adds a card to the player's hand after selecting it from another player.
            bool duplicate = false;
            for(int i = 0; i <= topIndex; i++)
            {
                if(hand[i].Rank == card.Rank)
                {
                    if(topIndex == i)
                    {//If duplicate is final card in hand.
                        CardDeck.ReturnCard(hand[topIndex]);
                        hand[topIndex] = null;
                        topIndex--;
                    }
                    else
                    {//If dupicate is not final card in hand.
                        CardDeck.ReturnCard(hand[i]);
                        hand[i] = hand[topIndex];
                        hand[topIndex] = null;
                        topIndex--;
                    }
                    duplicate = true;
                    break;
                }
            }
            if(!duplicate)
            {//Adds the card if a duplicate is not found.
                topIndex++;
                hand[topIndex] = card;
            }
        }

        public override string ToString()
        {//Creates a string representing the player's hand.
            StringBuilder sb = new StringBuilder();
            if(this.IsUser)
            {
                sb.Append(name + " : ");
            }
            else
            {
                sb.Append(name + " : ");
            }
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
        {//Returns the player's hand to the deck.
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
