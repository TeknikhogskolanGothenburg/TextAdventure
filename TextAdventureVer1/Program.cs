using System;
using System.Collections.Generic;

namespace TextAdventureVer1
{
    class Program
    {
        static void Main(string[] args)
        {
            var pos = new Tuple<int, int>(0, 0);
            char input;
            do
            {
                List<char> paths = new List<char>();
                if (pos.Item1 == 0 && pos.Item2 == 0)
                {
                    Console.WriteLine("Wow, a bend in the road. Possible paths are: E, S");
                    paths = new List<char> { 'E', 'S' };
                }
                else if (pos.Item1 == 0 && pos.Item2 == 1)
                {
                    Console.WriteLine("Oh, a bend again. Possible paths are: E, N");
                    paths = new List<char> { 'E', 'N' };
                }
                else if (pos.Item1 == 1 && pos.Item2 == 0)
                {
                    Console.WriteLine("A bend!!! Is that all there is? Possible paths are: W, S");
                    paths = new List<char> { 'W', 'S' };
                }
                else if (pos.Item1 == 1 && pos.Item2 == 1)
                {
                    Console.WriteLine("OK yeah, a bend. I hate bends. Possible paths are: W, N");
                    paths = new List<char> { 'W', 'N' };
                }

                Console.Write("Where to next? ");
                input = Console.ReadKey().KeyChar;
                input = input.ToString().ToUpper()[0];

                if(paths.Contains(input))
                {
                    switch (input)
                    {
                        case 'N':
                            pos = new Tuple<int, int>(pos.Item1, pos.Item2 - 1);
                            break;
                        case 'S':
                            pos = new Tuple<int, int>(pos.Item1, pos.Item2 + 1);
                            break;
                        case 'W':
                            pos = new Tuple<int, int>(pos.Item1 - 1, pos.Item2);
                            break;
                        case 'E':
                            pos = new Tuple<int, int>(pos.Item1 + 1, pos.Item2);
                            break;
                    }
                }
                Console.WriteLine("\n");

            } while (input != 'Q');

            Console.WriteLine("\n\nGame Over");
        }
    }
}
