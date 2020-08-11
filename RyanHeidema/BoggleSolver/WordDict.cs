using System;
using System.Collections.Generic;
using System.IO;

namespace BoggleSolverCSharp
{
    public class WordDict
    {
        // Minimum length of words acceptable as answers
        public int MinWordSize { get; set; }

        public Dictionary<string, List<string>> Dict;

        public WordDict(int min_in)
        {
            MinWordSize = min_in;
            Dict = new Dictionary<string, List<string>>();
        }

        // Load the words in and process into the dict
        public void Load(string textfile)
        {
            string word;
            StreamReader reader = new StreamReader(textfile);

            while (!reader.EndOfStream)
            {
                word = reader.ReadLine();
                // If string's length is in acceptable size range
                if (word.Length >= MinWordSize && word.Length <= 16)
                {

                    // Look for prefix in the dict
                    string prefix = word.Substring(0, MinWordSize);

                    // if not found, create vector and add to the dict
                    if(Dict.ContainsKey(prefix))
                    {
                        // if found, add to value in u_map
                        Dict[prefix].Add(word);
                    }
                    else
                    {
                        // if not found, create vector and add to the dict
                        List<string> l = new List<string>{ word };
                        Dict.Add(prefix, l);
                    }
                }
            }
        }

        // Returns whether or not the dict contains a word
        public bool Contains(string input)
        {
            // If the length of the input is less than min size, return false
            if (input.Length < MinWordSize)
            {
                return false;
            }

            // Search dict for prefix
            string prefix = input.Substring(0, MinWordSize);
            if (!Dict.ContainsKey(prefix))
            {
                return false; // if not found, return false
            }
            else
            {
                List<string> l = Dict[prefix];

                // Looks through u_map's value for the string, returning if found
                if (l.Contains(input))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        // Returns true if you should keep searching
        public bool KeepGoing(string input)
        {
            // Always keep going if length is less than the minimum size
            if (input.Length < MinWordSize)
            {
                return true;
            }

            // Ask dict if the prefix is found
            string prefix = input.Substring(0, MinWordSize);
            if (!Dict.ContainsKey(prefix))
            {
                return false;
            }
            else
            {
                List<string> l =Dict[prefix];
                foreach(string s in l)
                {
                    // if word in v starts with prefix of 'input' return true
                    if (s.Length >= input.Length)
                    {
                        if (s.Substring(0, input.Length) == input)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
        }
    }
}
