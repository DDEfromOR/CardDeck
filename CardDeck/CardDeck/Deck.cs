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
        
        /// <summary>
        /// Class constructor. Creates a Deck containing 52 instances of Card,
        /// each with a unique combination of Value and Suit, with restraints of
        /// 1-13 and H,D,S,C.
        /// </summary>
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

        /// <summary>
        /// Adds a new Card to the Deck if the Deck does not already contain a Card
        /// with the same Value and Suit.
        /// </summary>
        /// <param name="cardToAdd">A Card to add to the Deck.</param>
        /// <returns>True if the new Card was unique and added to the deck, otherwise False.</returns>
        public bool AddCard(Card cardToAdd)
        {
            if (!cards.Contains(cardToAdd))
            {
                cards.Add(cardToAdd);
                return true;
            }

            return false;            
        }

        /// <summary>
        /// Removes an existing Card from the Deck.
        /// </summary>
        /// <param name="cardToRemove">A Card to search the Deck for and remove if found.</param>
        /// <returns>True if found and removed, otherwise False.</returns>
        public bool RemoveCard(Card cardToRemove)
        {
            if (cards.Contains(cardToRemove))
            {
                cards.Remove(cardToRemove);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Overload to sort the current deck. Passes 'this' to AscendingSort(Deck).
        /// </summary>
        /// <returns>The results of AscendingSort(this).</returns>
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
        /// Overload to shuffle the current deck. Passes 'this' to Shuffle(Deck).
        /// </summary>
        /// <returns>The results of Shuffle(this).</returns>
        public Deck Shuffle()
        {
            //TODO: Unit test to show randomized results.
            return Shuffle(this);
        }

        /// <summary>
        /// Randomizes the order of the 52 cards contained within the Deck.
        /// </summary>
        /// <param name="deckToShuffle">A Deck</param>
        /// <returns>A Deck with cards in a randomized order.</returns>
        public static Deck Shuffle(Deck deckToShuffle)
        {
            return deckToShuffle;
        }
    }
}
