using System.Collections.Generic;

namespace CardDeck2010
{    
    class Card
    {
       int value;
       char suit;
       public static IList<char> allSuits = new List<char> { 'D', 'S', 'C', 'H' };
      
        /// <summary>
        /// Class constructor. Creates a new Card with values for Value and Suit.
        /// </summary>
        /// <param name="newValue">Integer value of the Card between 1 and 13.</param>
        /// <param name="newSuit">Char representation of the Card Suit, one of A,S,H,C.</param>
       public Card(int newValue, char newSuit)
       {
           this.SetValue(newValue);
           this.SetSuit(newSuit);
       }

        /// <summary>
        /// Sets the numeric value of the current card.
        /// </summary>
        /// <param name="valueToSet">An int between 1 and 13, inclusive.</param>
        /// <returns>True if valid input, otherwise False.</returns>
        public bool SetValue(int valueToSet)
         {
           if (valueToSet > 13 || valueToSet < 1) return false;
           
           value = valueToSet;
           return true;
         }

        /// <summary>
        /// Getter for card value.
        /// </summary>
        /// <returns>The numeric value of the card.</returns>
       public int GetValue()
        {
            return value;
        }

        /// <summary>
        /// Sets the suit of the card.
        /// </summary>
        /// <param name="suitToSet">char representation of the suit, H, S, C, D</param>
        /// <returns>True for valid suits, otherwise False.</returns>
       public bool SetSuit(char suitToSet)
        {
           if (!allSuits.Contains(suitToSet)) return false;
       
           suit = suitToSet;
           return true;
        }

        /// <summary>
        /// Getter for card suit.
        /// </summary>
        /// <returns>The char representing the suit of the card, D, H, S, C</returns>
       public char GetSuit()
        {
            return suit;
        }

       /// <summary>
       /// Hides default ToString() method.
       /// </summary>
       /// <returns>Suit:Value</returns>
       public new string ToString()
       {
          return '[' + GetSuit().ToString() + ':' + GetValue().ToString() + ']';
       }
    }
}
