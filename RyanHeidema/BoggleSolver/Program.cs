using System;
using System.Collections.Generic;

namespace BoggleSolverCSharp
{
    class Program
    {
        //public List<char> GenerateBoard()
        //{
        //    List<char> board = new List<char>
        //    {
        //        Capacity = 16  // 4x4 board
        //    };

        //    Random r = new Random();

        //    // get 16 random letters
        //    for (int i = 0; i < 16; ++i)
        //    {
        //        board.Add((char)(97 + r.Next(0, 26)));
        //    }

        //    return board;
        //}

        //void PrintBoard(List<char> board)
        //{
        //    for(int i = 0; i< board.Count; ++i)
        //    {
        //        Console.Write($" {board[i]}");
        //        if(i % 4 == 3)
        //        {
        //            Console.WriteLine();
        //        }
        //    }
        //}

        static void Main(string[] args)
        {
            // --------------------- MAIN ------------------------

            // set default minimum word size to 3
            int minSize = 3;

            // Initialize the board with random letters
            List<char> letters = new List<char>()
            {
                Capacity = 16  // 4x4 board
            };

            Random r = new Random();

            // get 16 random letters
            for (int i = 0; i < 16; ++i)
            {
                letters.Add((char)(97 + r.Next(0, 26)));
            }

            Console.WriteLine("***** BOARD *****");
            Console.WriteLine();

            // Print the board
            for (int i = 0; i < letters.Count; ++i)
            {
                Console.Write($" {letters[i]}");
                if (i % 4 == 3)
                {
                    Console.WriteLine();
                }
            }

            Console.WriteLine("\n\n");

            Board b1 = new Board(minSize, letters);
            Solutions s1 = b1.Solve("dictionary.txt");

            Console.WriteLine("***** SOLUTIONS *****");
            Console.WriteLine();
            Console.WriteLine($"Total Points: {s1.TotalScore}");
            Console.WriteLine();
            s1.Print();


            // ----------------------------------------------------
        }
    }
}
