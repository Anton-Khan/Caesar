using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Caesar
{
    public class Cryptographer
    {
        private int Step;

        public Cryptographer(int step)
        {
            Step = step; 
        }

        public Cryptographer()
        {
            Step = 1;
        }
        public String Encode(string text)
        {
            string new_string = "";
            foreach (var item in text)
            {
                if (Alphabet.MyAlphabet.Contains(Char.ToUpper(item)))
                {
                    int current_index = Alphabet.MyAlphabet.IndexOf(Char.ToUpper(item));
                    int new_index = (current_index + Step) % Alphabet.MyAlphabet.Count;
                    char new_letter;
                    if (new_index >= 0)
                    {
                        new_letter = Alphabet.MyAlphabet[new_index];
                    }
                    else
                    {
                        new_letter = Alphabet.MyAlphabet[Alphabet.MyAlphabet.Count + new_index];
                    }
                    if (Char.IsLower(item))
                    {
                        new_string += Char.ToLower(new_letter);
                    }
                    else
                    {
                        new_string += new_letter;
                    }
                    
                    
                }
                else
                {
                    new_string += item;
                }       
            }
            return new_string;
        }

        public string Decode(string text)
        {
            string new_string = "";
            foreach (var item in text)
            {
                if (Alphabet.MyAlphabet.Contains(Char.ToUpper(item)))
                {
                    int current_index = Alphabet.MyAlphabet.IndexOf(Char.ToUpper(item));
                    int new_index = (current_index - Step) % Alphabet.MyAlphabet.Count;
                    char new_letter;
                    if (new_index >= 0)
                    {
                        new_letter = Alphabet.MyAlphabet[new_index];
                    }
                    else
                    {
                        new_letter = Alphabet.MyAlphabet[Alphabet.MyAlphabet.Count + new_index];
                    }
                    if (Char.IsLower(item))
                    {
                        new_string += Char.ToLower(new_letter);
                    }
                    else
                    {
                        new_string += new_letter;
                    }
                }
                else
                {
                    new_string += item;
                }
            }
            return new_string;
        }

        public static string CalculateStep(List<KeyValuePair<Char, int>> source, List<KeyValuePair<Char, int>> example)
        {
            Dictionary<int, int> stepDistribution = new Dictionary<int, int>();

            for (int i = source.Count - 1; i > 0; i--)
            {
                int source_index = Alphabet.MyAlphabet.IndexOf(Char.ToUpper(source[i].Key));
                int example_index = Alphabet.MyAlphabet.IndexOf(Char.ToUpper(example[i].Key));
                int difference = Math.Abs(source_index - example_index);
                if (stepDistribution.ContainsKey(difference))
                {
                    stepDistribution[difference] += 1;
                }
                else
                {
                    stepDistribution.Add(difference, 1);
                }
            }

            return ConvertDictToString(stepDistribution);

        }

        private static String ConvertDictToString(Dictionary<int, int> dict)
        {
            string result_string = "";
            foreach (var key in dict.Keys)
            {
                result_string += key + " ->" + dict[key] + "\n";
            }
            return result_string;
        }

    }
}
