using System;
using System.Linq;
using System.Collections.Generic;

namespace Zadanie_rekrutacyjne_1
{
    internal class Program
    {
        public static bool Solution(string input)
        {
            Stack<char> brackets = new Stack<char>();
            Dictionary<char, char> bracketsPairs = new Dictionary<char, char>()
            {
                { '(' , ')' },
                { '<' , '>' },
                { '{' , '}' },
                { '[' , ']' },
            };

            try
            {
                foreach(var mark in input)
                {
                    if (bracketsPairs.Keys.Contains(mark))
                        brackets.Push(mark);
                    else if (bracketsPairs.Values.Contains(mark))
                    {
                        if (mark == bracketsPairs[brackets.First()])
                        {
                            brackets.Pop();
                        }
                        else
                            return false;
                    }
                    else continue;

                }

            }
            catch
            {
                return false;
            }
            return brackets.Count() == 0 ? true : false ;
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj string:");
            string expression = Console.ReadLine();
            Console.WriteLine(Solution(expression));
        }
    }
}
// Poprawne rozmieszczenie nawiasów:
//
// <[()]>{}[<({ })>] [[]] ((()))

// Niepoprawne rozmieszczenie:
//      1.}
//      2.[
//      3. >(
//      4. ())