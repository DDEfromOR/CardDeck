using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDeck
{
    /// <summary>
    /// A Deck contains a set of 52 Cards, with no duplicates.
    /// Must be able to be sorted and shuffled.
    /// </summary>
    class Deck
    {
        public IList<Card> cards;
        
        public Deck()
        {
            int suitSize = 13;
            foreach (char suit in Card.allSuits)
            {
                for (int i = 1; i < suitSize; i++)
                {
                    Card newCard = new Card(i, suit);
                    this.AddCard(newCard);
                }
            }
        }

        public bool AddCard(Card cardToAdd)
        {
            if (!cards.Contains(cardToAdd))
            {
                cards.Add(cardToAdd);
                return true;
            }

            return false;            
        }

        public bool RemoveCard(Card cardToRemove)
        {
            if (cards.Contains(cardToRemove))
            {
                cards.Remove(cardToRemove);
                return true;
            }

            return false;
        }


        public Deck AscendingSort()
        {
            return AscendingSort(this);
        }
        /// <summary>
        /// Returns a brand new Deck to replace the passed in Deck. (New Decks are created with their Cards in ascending order.)
        /// </summary>
        /// <param name="deckToSort">A deck to replace with a new, sorted deck.</param>
        /// <returns>A deck with cards arranged in Ascending order (DSCH, 1-13).</returns>
        public static Deck AscendingSort(Deck deckToSort)
        {
            //TODO: Unit test to ensure multiple random decks passed in all exit in the same order.
            return new Deck();
        }

        /// <summary>
        /// 2.	Write a method, function, or procedure that randomly shuffles a standard deck of 52 playing cards.
        /// </summary>
        /// <param name="deckToShuffle"></param>
        public Deck Shuffle()
        {
            //TODO: Unit test to show randomized results.
            return Shuffle(this);
        }
        public static Deck Shuffle(Deck deckToShuffle)
        {
            return deckToShuffle;
        }
    }
}
