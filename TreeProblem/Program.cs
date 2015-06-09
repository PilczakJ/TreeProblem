using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number of levels");
            string input = Console.ReadLine();
            int levels;
            Int32.TryParse(input, out levels);
            Tree t = new Tree(levels);
            Console.WriteLine("\nTree:");
            t.PrintTree(t.Root);

            
        }
    }
}
