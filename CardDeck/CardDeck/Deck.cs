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

        /// <summary>
        /// Write a method, function, or procedure that sorts a standard deck of 52 playing cards in ascending order.
        /// You are free to determine what the term “ascending order” means for a deck of cards, but be ready to discuss your choice during the interview.
        /// INPUT: Standard Deck of 52 Cards.
        /// OUTPUT: Sorted Deck of 52 Cards, in Ascending Order.
        /// </summary>
        public Deck AscendingSort()
        {
            return AscendingSort(this);
        }
        public static Deck AscendingSort(Deck deckToSort)
        {
            //TODO: Unit test to ensure multiple random decks passed in all exit in the same order.
            return deckToSort;
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
