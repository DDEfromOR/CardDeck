using System;
using NUnit.Framework;

namespace CardDeck2010
{
   [TestFixture]
   class CardTests
   {
      [Test]
      public void CardConstructorTest()
      {
         /*
          * Tests happy path for creating a new card.
          */
         Card testCard = new Card(1, 'H');
         Assert.AreEqual(testCard.GetSuit(), 'H');
         Assert.AreEqual(testCard.GetValue(), 1);
      }

      [Test]
      public void CardCompare()
      {
         /*
          * Tests the card compare function against manually created cards.
          */
         Card twoOfHearts = new Card(2, 'H');
         Card anotherTwoOfHearts = new Card(2, 'H');
         Card threeOfHearts = new Card(3, 'H');
         Card twoOfClubs = new Card(2, 'C');

         Assert.True(twoOfHearts.Compare(anotherTwoOfHearts));
         Assert.False(twoOfHearts.Compare(twoOfClubs));
         Assert.False(twoOfHearts.Compare(threeOfHearts));
      }

      [Test]
      public void CardConstructorSentBadSuit()
      {
         /*
          * Tests the grumpy path related to an illegal suit being used
          * when creating a new card.
          */
         try
         {
            Card testCard = new Card(1, 'A');
         }
         catch (Exception)
         {
            Assert.Pass();
         }
         Assert.Fail("An exception should have been thrown and caught before reaching this point.");
      }

      [Test]
      public void CardConstructorSentBadValue()
      {
         /*
          * Tests the grumpy path related to an illegal card value
          * being used when creating a new card.
          */
         try
         {
            Card testCard = new Card(15, 'H');
         }
         catch (Exception)
         {
            Assert.Pass();
         }
         Assert.Fail("An exception should have been thrown and caught before reaching this point.");
      }

      [Test]
      public void CardSuitProperlySetTest()
      {
         /*
          * Simple test to make sure GetSuit() returns
          * the expected suit from a newly created card.
          */
         Card testCard = new Card(5, 'D');
         Assert.AreEqual('D', testCard.GetSuit());
      }

      [Test]
      public void CardValueProperlySetTest()
      {
         /*
          * Simple test to make sure GetValue() returns
          * the expected value from a newly created card.
          */
         Card testCard = new Card(5, 'D');
         Assert.AreEqual(5, testCard.GetValue());
      }


   }
}

