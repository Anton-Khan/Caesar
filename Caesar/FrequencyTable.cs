using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Caesar
{
    class FrequencyTable
    {
        
        public Dictionary<Char, int> CreateTableByText(string text)
        {
            Dictionary<char, int> frTable = new Dictionary<char, int>();
            foreach (var alpha in Alphabet.MyAlphabet)
            {
                frTable.Add(alpha, 0);
            }
            foreach (var item in text)
            {
                var alpha = Char.ToUpper(item);
                if (Alphabet.MyAlphabet.Contains(alpha))
                {
                    frTable[alpha] += 1;
                }
            }
            return frTable;
        }

        public String ConvertTableToString(Dictionary<Char, int> table)
        {
            string result_string = "";
            foreach (var key in table.Keys)
            {
                result_string += key + "<>" + table[key]+ ", "; 
            }
            return result_string;
        }

        public String ConvertListToString(List<KeyValuePair<Char, int>> list)
        {
            string result_string = "";
            foreach (var kvp in list)
            {
                result_string += kvp.Key + "<>" + kvp.Value + ", ";
            }
            return result_string;
        }

        public List<KeyValuePair<char, int>> ConvertToSortedByFrequencyList(Dictionary<Char, int> table)
        {
            var frList = table.ToList<KeyValuePair<Char, int>>();
            frList.Sort(KVPcompareByValue);
            return frList;
        }

        public int KVPcompareByValue(KeyValuePair<Char, int> x, KeyValuePair<Char, int> y) 
        {
            if (x.Value > y.Value)
                return 1;
            else if (x.Value == y.Value)
                return 0;
            else
                return -1;       
        }
    }
}
