using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoggleSolverCSharp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RyanHeidema.Pages.Projects
{
    public class charList {
        public char let00 { get; set; }
        public char let01 { get; set; }
        public char let02 { get; set; }
        public char let03 { get; set; }
        public char let10 { get; set; }
        public char let11 { get; set; }
        public char let12 { get; set; }
        public char let13 { get; set; }
        public char let20 { get; set; }
        public char let21 { get; set; }
        public char let22 { get; set; }
        public char let23 { get; set; }
        public char let30 { get; set; }
        public char let31 { get; set; }
        public char let32 { get; set; }
        public char let33 { get; set; }

        public List<char> toList() 
        {
            List<char> letters = new List<char>();
            letters.Capacity = 16;

            // Add the letters
            letters.Add(let00);
            letters.Add(let01);
            letters.Add(let02);
            letters.Add(let03);

            letters.Add(let10);
            letters.Add(let11);
            letters.Add(let12);
            letters.Add(let13);

            letters.Add(let20);
            letters.Add(let21);
            letters.Add(let22);
            letters.Add(let23);

            letters.Add(let30);
            letters.Add(let31);
            letters.Add(let32);
            letters.Add(let33);

            return letters;
        }
    }
    public class IndexModel : PageModel
    {
        [BindProperty]
        public charList charList { get; set; }

        [BindProperty]
        public int minSize { get; set; }

        public int totalScore { get; set; }

        public List<Word> Words { get; set; }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            List<char> letters = charList.toList();

            foreach(char c in letters) 
            {
                if(!char.IsLetter(c))
                {
                    return Page();
                }
            }

            Board b1 = new Board(minSize, letters);
            Solutions s1 = b1.Solve("dictionary.txt");

            totalScore = s1.TotalScore;
            Words = s1.Output();

            return Page();
        }
    }
}