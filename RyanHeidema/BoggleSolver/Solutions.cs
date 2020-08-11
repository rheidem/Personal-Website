using System;
using System.Collections;
using System.Collections.Generic;

namespace BoggleSolverCSharp
{
    public class WordComparator : IComparer<Word>
    {       
        public int Compare(Word w1, Word w2)
        {
            if (w1.Score.CompareTo(w2.Score) != 0)
            {
                return w1.Score.CompareTo(w2.Score);
            }
            else
            {
                return w1.Text.CompareTo(w2.Text);
            }
        }
    }

    public class Solutions
    {
        public int TotalScore { get; set; }

        public SortedSet<Word> WordsSet;

        public Solutions()
        {
            TotalScore = 0;
            WordsSet = new SortedSet<Word>(new WordComparator());
        }

        // Adds a new word into wordsList and updates totalScore
        public void Add(string text)
        {
            Word Temp = new Word(text);
            WordsSet.Add(Temp);
            TotalScore += Temp.Score;
        }

        // Returns true if wordsList contains the string text
        public bool Contains(string text)
        {
            return WordsSet.Contains(new Word(text));
        }

        // Sort the wordsList according to Comp c and print to cout
        public void Print()
        {
            foreach(Word w in WordsSet) {
                if (w.Score == 1)
                {
                    Console.WriteLine($"{w.Text}: {w.Score} point");
                }
                else
                {
                    Console.WriteLine($"{w.Text}: {w.Score} points");
                }
            }
        }
    }
}
