using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDeck
{    
    class Card
    {
       int value;
       char suit;
       public static IList<char> allSuits = new List<char> { 'D', 'S', 'C', 'H' };
      
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
            if (valueToSet <= 13 && valueToSet >= 1)
            {
                value = valueToSet;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 
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
            if (allSuits.Contains(suitToSet))
            {
                suit = suitToSet;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Getter for card suit.
        /// </summary>
        /// <returns>The char representing the suit of the card, D, H, S, C</returns>
       public char GetSuit()
        {
            return suit;
        }
    }
}
