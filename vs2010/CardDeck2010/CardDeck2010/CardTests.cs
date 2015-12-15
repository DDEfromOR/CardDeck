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
         Assert.DoesNotThrow(CreateCardForTest(1, 'H'));
      }

      private static TestDelegate CreateCardForTest(int testValue, char testSuit)
      {
         Card testCard = new Card(testValue, testSuit);
         return null;
      }
   }
}

