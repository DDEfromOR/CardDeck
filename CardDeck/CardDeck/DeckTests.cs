using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CardDeck
{
    class DeckTests
    {
      [Test]
      public void DeckConstructorTest()
      {
         Deck myDeck = new Deck();
         Console.Out.WriteLine(myDeck.ToString());
      }
    }
}
