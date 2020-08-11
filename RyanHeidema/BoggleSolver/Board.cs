using System;
using System.Collections.Generic;
using System.Text;

namespace BoggleSolverCSharp
{
    public class Board
    {
        public int MinWordSize { get; set; }

        public List<List<char>> letters { get; set; }

        public Board(int min_in, List<char> letters_in)
        {
            MinWordSize = min_in;

            // resize the 2D letters vector for a 4x4 board
            letters = new List<List<char>>
            {
                Capacity = 4
            };

            for(int i = 0; i < 4; ++i)
            {
                List<char> temp = new List<char>() { '.', '.', '.', '.' };
                letters.Add(temp);
            }

            // fill in the letters vector with incoming letters
            int index = 0;
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    letters[i][j] = letters_in[index++];
                }
            }
        }

        // Recursive helper
        public void SolveHelper(ref WordDict dict, ref Solutions solns, int row, int col, string current)
        {
            if (dict.KeepGoing(current))
            {

                // Get the new character and add on to the current path
                char newChar = letters[row][col];
                StringBuilder newPath = new StringBuilder();
                newPath.Append(current);
                newPath.Append(newChar);

                if (newPath.Length >= MinWordSize)
                {
                    // If the word is in the Dictionary and not in the Solutions, add to Solutions
                    if (dict.Contains(newPath.ToString()) && !solns.Contains(newPath.ToString()))
                    {
                        solns.Add(newPath.ToString());
                    }
                }

                // Check surrounding squares that have not yet been looked at
                for (int vert = -1; vert <= 1; vert++)
                {
                    for (int hor = -1; hor <= 1; hor++)
                    {
                        if (row + vert >= 0 && row + vert < 4 && col + hor >= 0 && col + hor < 4 &&
                           !(vert == 0 && hor == 0) && letters[row + vert][col + hor] != '*')
                        {

                            // Put new letter in the solution path
                            letters[row][col] = '*';

                            SolveHelper(ref dict, ref solns, row + vert, col + hor, newPath.ToString());

                            // Effectively take new letter out of solution path
                            letters[row][col] = newChar;
                        }
                    }
                }
            }
        }

        // Solves the game and returns the solutions
        public Solutions Solve(string textfile)
        {
            // Create a Dictionary and load in the words
            WordDict d = new WordDict(MinWordSize);
            d.Load(textfile);

            Solutions s = new Solutions();

            // For each square on the board, solve
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    SolveHelper(ref d, ref s, i, j, "");
                }
            }

            // return the solutions
            return s;
        }
    }
}
