using System;
using NUnit.Framework;


namespace CardDeck2010
{
   [TestFixture]
    class DeckTests
    {
      [Test]
      public void DeckConstructorTest()
      {
         /*
          * Tests to make sure new Decks are created with sets of Cards in the order we expect.
          * The constant freshDeck is a literal string representation of a Deck in ascending order.
          */
         const string freshDeck = " [C:1] [C:2] [C:3] [C:4] [C:5] [C:6] [C:7] [C:8] [C:9] [C:10] [C:11] [C:12] [C:13] [D:1] [D:2] [D:3] [D:4] [D:5] [D:6] [D:7] [D:8] [D:9] [D:10] [D:11] [D:12] [D:13] [H:1] [H:2] [H:3] [H:4] [H:5] [H:6] [H:7] [H:8] [H:9] [H:10] [H:11] [H:12] [H:13] [S:1] [S:2] [S:3] [S:4] [S:5] [S:6] [S:7] [S:8] [S:9] [S:10] [S:11] [S:12] [S:13]";

         Deck myDeck = new Deck();
         Console.Out.WriteLine(myDeck.ToString());
         Assert.AreEqual(freshDeck, myDeck.ToString());
      }

      [Test]
      public void DeckSortTest()
      {
         /*
          * I've defined an 'ascending sort' of a deck as being ordered first by suit,
          * in the order of C, D, H, S, and then by value 1-13. For convenience sake
          * new decks are greated with cards in this order by default, so instead of 
          * doing the work of sorting a shuffled deck back to its original state,
          * the sort method simply tosses out the existing cards and replaces with 
          * with a nice, new, ordered pack unless the sorting deck is missing cards.
          */
         Deck myDeck1 = new Deck();
         Deck myDeck2 = new Deck();
         myDeck2.Shuffle();
         Assert.AreNotEqual(myDeck1.ToString(), myDeck2.ToString());
         myDeck2.AscendingSort();
         Assert.AreEqual(myDeck1.ToString(), myDeck2.ToString());
      }

      [Test]
      public void ContainsCard()
      {
         /*
          * Confirms cards can be found in a fresh deck and
          * properly cannot be found after being removed. 
          */ 
         Deck myDeck = new Deck();
         Card twoOfHearts = new Card(2, 'H');
         Card threeOfHearts = new Card(3, 'H');
         Card twoOfClubs = new Card(2, 'C');

         Assert.True(myDeck.ContainsCard(twoOfHearts));
         Assert.True(myDeck.ContainsCard(threeOfHearts));
         Assert.True(myDeck.ContainsCard(twoOfClubs));

         myDeck.RemoveCard(twoOfHearts);
         myDeck.RemoveCard(threeOfHearts);

         Assert.False(myDeck.ContainsCard(twoOfHearts));
         Assert.False(myDeck.ContainsCard(threeOfHearts));
         Assert.True(myDeck.ContainsCard(twoOfClubs));
      }

      [Test]
      public void SortDoesNotRestoreMissingCards()
      {
         /*
          * Confirms sorting a deck with missing cards doesn't
          * shuffle the missing cards back into the deck, or add blank
          * cards in the places they would have occupied. 
          */ 
         Deck myDeck1 = new Deck();
         Deck myDeck2 = new Deck();
         Assert.AreEqual(myDeck1.ToString().Length, myDeck2.ToString().Length);

         Card fourOfDiamonds = new Card(4, 'D');
         Card threeOfSpades = new Card(3, 'S');
         Card twoOfHearts = new Card(2, 'H');

         myDeck1.RemoveCard(fourOfDiamonds);
         myDeck1.RemoveCard(threeOfSpades);
         myDeck1.RemoveCard(twoOfHearts);

         Assert.False(myDeck1.ContainsCard(fourOfDiamonds));
         Assert.False(myDeck1.ContainsCard(threeOfSpades));
         Assert.False(myDeck1.ContainsCard(twoOfHearts));
         Assert.Greater(myDeck2.ToString().Length, myDeck1.ToString().Length);
      }

      [Test]
      public void BasicDeckShuffleTest()
      {
         /*
          * Bare minimum test for Shuffle, which tests to make sure a shuffled
          * deck is not in the same order as a fresh deck.
          */
         Deck myDeck1 = new Deck();
         Deck myDeck2 = new Deck();
         myDeck2.Shuffle();
         Assert.AreNotEqual(myDeck1.ToString(), myDeck2.ToString());
      }

      [Test]
      public void MultipleDeckShuffleTest()
      {
         /*
          * A little bit better test for Shuffle, which tests to make sure 
          * multiple shuffled decks do not end up in the same order. (Which,
          * of course, is a possible outcome, but should be extremely unlikely!)
          */
         Deck myDeck1 = new Deck();
         Deck myDeck2 = new Deck();
         myDeck1.Shuffle();
         myDeck2.Shuffle();
         Assert.AreNotEqual(myDeck1.ToString(), myDeck2.ToString());
      }

      [Test]
      public void StaticShuffleTest()
      {
         /* 
          * The Shuffle method of Deck is static, so explicitly testing
          * it functions properly when used via a static call.
          */
         Deck myDeck1 = new Deck();
         Deck myDeck2 = new Deck();
         Assert.AreEqual(myDeck1.ToString(), myDeck2.ToString());

         myDeck1 = Deck.Shuffle(myDeck1);
         Assert.AreNotEqual(myDeck1.ToString(), myDeck2.ToString());
      }

      [Test]
      public void StaticSortTest()
      {
         /* 
          * The sort method of Deck is static, so explicitly testing
          * it functions properly when used via a static call.
          */
         Deck myDeck1 = new Deck();
         Deck myDeck2 = new Deck();
         Assert.AreEqual(myDeck1.ToString(), myDeck2.ToString());

         myDeck1 = Deck.Shuffle(myDeck1);
         Assert.AreNotEqual(myDeck1.ToString(), myDeck2.ToString());

         myDeck1 = Deck.AscendingSort(myDeck1);
         Assert.AreEqual(myDeck1.ToString(), myDeck2.ToString());
      }
    }
}
