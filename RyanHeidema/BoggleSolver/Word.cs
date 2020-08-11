using System;
namespace BoggleSolverCSharp
{
    public class Word
    {
        public string Text { get; set; }
        public int Score { get; set; }

        public Word(string text_in)
        {
            Text = text_in;

            // Assign a score to the word based on its length
            int len = Text.Length;

            if (len < 5)
            {
                Score = 1;
            }
            else if (len == 5)
            {
                Score = 2;
            }
            else if (len == 6)
            {
                Score = 3;
            }
            else if (len == 7)
            {
                Score = 5;
            }
            else
            {
                Score = 11;
            }
        }
    }
}
