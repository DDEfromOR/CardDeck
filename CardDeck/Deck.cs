﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace CardDeck2010
{
   /// <summary>
   /// A Deck contains a set of 52 Cards, with no duplicates.
   /// Must be able to be sorted and shuffled.
   /// </summary>
   class Deck
   {
      private IList<Card> cards;

      /// <summary>
      /// Class constructor. Creates a Deck containing 52 instances of Card,
      /// each with a unique combination of Value and Suit, with restraints of
      /// 1-13 and H,D,S,C.
      /// </summary>
      public Deck()
      {
         cards = new List<Card>();
         SetupCards();
      }

      /// <summary>
      /// Initializes the set of Cards to contain a typical set of 52 suit/value combinations.
      /// </summary>
      private void SetupCards()
      {
         const int suitSize = 13;
         foreach (char suit in Card.allSuits)
         {
            for (int i = 1; i <= suitSize; i++)
            {
               Card newCard = new Card(i, suit);
               AddCard(newCard);
            }
         }
      }

      /// <summary>
      /// Adds a new Card to the Deck if the Deck does not already contain a Card
      /// with the same Value and Suit.
      /// </summary>
      /// <param name="cardToAdd">A Card to add to the Deck.</param>
      private void AddCard(Card cardToAdd)
      {
         if (cards == null || ContainsCard(cardToAdd))
         {
            return;
         }
         cards.Add(cardToAdd);
      }

      /// <summary>
      /// Removes the first occurence of a specific Card from the Deck. 
      /// It also provides some future support for a dealing mechanism. 
      /// Exposed for testability. 
      /// </summary>
      /// <param name="cardToRemove">A Card to search the Deck for and remove if found.</param>
      public void RemoveCard(Card cardToRemove)
      {
         foreach (var card in cards.Where(card => card.Compare(cardToRemove)))
         {
            cards.Remove(card);
            return;
         }
      }

      /// <summary>
      /// Overload to sort the current deck. Passes 'this' to AscendingSort(Deck).
      /// </summary>
      /// <returns>The results of AscendingSort(this).</returns>
      public void AscendingSort()
      {
         cards = AscendingSort(this).cards;
      }

      /// <summary>
      /// Returns a brand new Deck to replace the passed in Deck. (New Decks are created with their Cards in ascending order.)
      /// </summary>
      /// <param name="deckToSort">A deck to replace with a new, sorted deck.</param>
      /// <returns>A deck with cards arranged in Ascending order (CDHS, 1-13).</returns>
      public static Deck AscendingSort(Deck deckToSort)
      {
         /*
          * This is a tad bit cheeky, but for the current
          * implementation and requirements a sorted Deck will 
          * be identical to a freshly constructed deck, minus
          * any cards that have been removed.
          * 
          * This may need a re-work to support classes derived
          * from this Deck class, but it would be difficult to 
          * implement an algorithm that would account for all
          * possible derivations without knowledge of them
          * beforehand.
        */
         Deck masterDeck = new Deck();

         if (deckToSort.cards.Count == masterDeck.cards.Count)
         {
            return masterDeck;
         }

         Deck freshDeck = new Deck();

         foreach (Card aCard in masterDeck.cards.Where(aCard => !deckToSort.ContainsCard(aCard)))
         {
            freshDeck.RemoveCard(aCard);
         }
         return freshDeck;
      }

      /// <summary>
      /// Overload to search the current deck for a card.
      /// </summary>
      /// <param name="cardToFind">A card to find in the current deck.</param>
      /// <returns>True if the card is found in the deck, otherwise false.</returns>
      public bool ContainsCard(Card cardToFind)
      {
         return ContainsCard(cardToFind, this);
      }

      /// <summary>
      /// Checks to see if a specific card is in the deck.
      /// </summary>
      /// <param name="cardToFind">The card to look for.</param>
      /// <param name="deckToSearch">The deck to look through.</param>
      /// <returns>True if the card is found in the deck, otherwise false.</returns>
      public static bool ContainsCard(Card cardToFind, Deck deckToSearch)
      {
         return deckToSearch.cards.Any(card => card.Compare(cardToFind));
      }

      /// <summary>
      /// Overload to shuffle the current deck. Passes 'this' to Shuffle(Deck).
      /// </summary>
      /// <returns>The results of Shuffle(this).</returns>
      public void Shuffle()
      {
         cards = Shuffle(this).cards;
      }

      /// <summary>
      /// Implements a Fisher-Yates Shuffle to "randomize" the order of the 52 cards contained within the Deck.
      /// To introduce a better aspect of randomness the shuffle is run a random number of times, based on a
      /// value generated by a more complex random number generator geared to create larger values.
      /// </summary>
      /// <param name="deckToShuffle">A Deck</param>
      /// <returns>A Deck with cards in a randomized order.</returns>
      public static Deck Shuffle(Deck deckToShuffle)
      {
         Random rng = new Random();
         Card[] arrayOfCards = deckToShuffle.cards.ToArray();
         int length = arrayOfCards.Length;
         int stopFlag = GetRandomInt();

         while (stopFlag > 0)
         {
            for (int i = 0; i < length; i++)
            {
               int target = i + (int)(rng.NextDouble() * (length - i));
               Card temp = arrayOfCards[target];
               arrayOfCards[target] = arrayOfCards[i];
               arrayOfCards[i] = temp;
            }
            stopFlag--;
         }
         deckToShuffle.cards = arrayOfCards.ToList();
         return deckToShuffle;
      }

      /// <summary>
      /// Uses CryptoServiceProvider to supply an acceptably random value.
      /// The value is modded by 1000 to make it a little more appropriately sized,
      /// and sanitized to ensure a positive result. 
      /// This method was introduced after unit testing helped reveal a lack of randomness
      /// in the shuffle algorithm, which was leading to predictable card orders.
      /// </summary>
      /// <returns>A positive int of random value.</returns>
      private static int GetRandomInt()
      {
         RNGCryptoServiceProvider csp = new RNGCryptoServiceProvider();
         byte[] randomBytes = new byte[4];
         csp.GetBytes(randomBytes);
         int result = BitConverter.ToInt32(randomBytes, 0) % 1000;
         return result < 1 ? result * -1 : result;
      }

      /// <summary>
      /// Hides default ToString to add some customization to output.
      /// </summary>
      /// <returns>String of cards formatted as "Suit:Value Suit:Value" for deck, 
      /// or 'The deck is empty!' in the case of an empty deck.</returns>
      public new string ToString()
      {
         return cards == null ? "The deck is empty!" : cards.Aggregate("", (current, card) => current +
            ' ' + card.ToString());
      }
   }
}
