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
       char suite;

        public bool SetValue(int valueToSet)
        {
            if (valueToSet <= 13 && valueToSet >= 1)
            {
                value = valueToSet;
                return true;
            }
            return false;
        }
        public int GetValue()
        {
            return value;
        }

        public bool SetSuite(char suiteToSet)
        {
            IList<char> allSuites = new List<char>{'D', 'S', 'C', 'H'};
            if (allSuites.Contains(suiteToSet))
            {
                suite = suiteToSet;
                return true;
            }
            return false;
        }
    }
}
