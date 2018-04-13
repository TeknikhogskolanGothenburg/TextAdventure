using System;
/*
    GameDict is a dict that has a Tuple of int's as it's key. They represent the current pos
             The value part is a Tuple where the first value is a function that takes a Tiles object as it's
             only argument. This function is called to print the Tiles info.
             The second item of the value tuple is a Tiles object representing a single game tile.
*/
using GameDict = System.Collections.Generic.Dictionary<System.Tuple<int, int>, System.Tuple<System.Action<GameItems.Tiles>, GameItems.Tiles>>;
/*
     ActionDict is a dict that has a char as it's key. This char represents the users input. 
                The value part is a function taking a tuple of int's as it's first argument.
                This tuple represents the current pos.
                The second argument to this function is a game tile, representing the current tile.
                The function returns a new tuple representing the new position
 */
using ActionDict = System.Collections.Generic.Dictionary<char, System.Func<System.Tuple<int, int>, GameItems.Tiles, System.Tuple<int, int>>>;
using GameItems;
using System.Collections.Generic;

namespace TextAdventureVer2
{
    class Program
    {
        static void ColorPrinter(Tiles tile)
        {
            if (tile.death)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(tile.msg);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(tile.msg);
                Console.ForegroundColor = ConsoleColor.Yellow;
                var directions = String.Join(", ", tile.paths.ToArray());
                Console.Write("Possible paths are: ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(directions);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void NormalPrinter(Tiles tile)
        {
            Console.WriteLine(tile.msg);
            if(!tile.death)
            {
                var directions = String.Join(", ", tile.paths.ToArray());
                Console.WriteLine("Possible paths are: " + directions);
            }
        }

        static void Main(string[] args)
        {
            GameDict GameMap = new GameDict();
            Action<Tiles> func = ColorPrinter;

            GameMap[new Tuple<int, int>(0, 0)] = new Tuple<Action<Tiles>, Tiles>(func, new Tiles { msg = "It seems you have reached a corner of the world.", paths = new List<char> { 'S', 'E' }, death = false });
            GameMap[new Tuple<int, int>(1, 0)] = new Tuple<Action<Tiles>, Tiles>(func, new Tiles { msg = "You are standing in intersection in the path.", paths = new List<char> { 'W', 'E', 'S' }, death = false });
            GameMap[new Tuple<int, int>(2, 0)] = new Tuple<Action<Tiles>, Tiles>(func, new Tiles { msg = "You fall into a lava pit and are now dead. \nBetter luck next time", paths = new List<char> { 'E' }, death = true });
            GameMap[new Tuple<int, int>(3, 0)] = new Tuple<Action<Tiles>, Tiles>(func, new Tiles { msg = "The path bends.", paths = new List<char> { 'S', 'E' }, death = false });
            GameMap[new Tuple<int, int>(4, 0)] = new Tuple<Action<Tiles>, Tiles>(func, new Tiles { msg = "The path bends again.", paths = new List<char> { 'S', 'W' }, death = false });
            GameMap[new Tuple<int, int>(0, 1)] = new Tuple<Action<Tiles>, Tiles>(func, new Tiles { msg = "This is a dull place, nothing special here.", paths = new List<char> { 'N', 'S', 'E' }, death = false });
            GameMap[new Tuple<int, int>(1, 1)] = new Tuple<Action<Tiles>, Tiles>(func, new Tiles { msg = "Everything is possible here.", paths = new List<char> { 'N', 'S', 'E', 'W' }, death = false });
            GameMap[new Tuple<int, int>(2, 1)] = new Tuple<Action<Tiles>, Tiles>(func, new Tiles { msg = "You only have two options here, either go back or continue on.", paths = new List<char> { 'W', 'E' }, death = false });
            GameMap[new Tuple<int, int>(3, 1)] = new Tuple<Action<Tiles>, Tiles>(func, new Tiles { msg = "Interesting, an intersection.", paths = new List<char> { 'N', 'S', 'E', 'W' }, death = false });
            GameMap[new Tuple<int, int>(4, 1)] = new Tuple<Action<Tiles>, Tiles>(func, new Tiles { msg = "Ah, a bend in the path.", paths = new List<char> { 'N', 'W' }, death = false });
            GameMap[new Tuple<int, int>(0, 2)] = new Tuple<Action<Tiles>, Tiles>(func, new Tiles { msg = "Oh dear! Ah deep hole in the ground. You fall to your death! \nBetter luck next time.", paths = new List<char> { 'N', 'S' }, death = true });
            GameMap[new Tuple<int, int>(1, 2)] = new Tuple<Action<Tiles>, Tiles>(func, new Tiles { msg = "Hmm I can see exactly nothing.", paths = new List<char> { 'N', 'S' }, death = false });
            GameMap[new Tuple<int, int>(2, 2)] = new Tuple<Action<Tiles>, Tiles>(func, new Tiles { msg = "You reach an opening with a pond. \nSome ducks are swimming calmful in it. A little stream is leaving the pond to the south.", paths = new List<char> { 'E' }, death = false });
            GameMap[new Tuple<int, int>(3, 2)] = new Tuple<Action<Tiles>, Tiles>(func, new Tiles { msg = "Crossroads.", paths = new List<char> { 'N', 'S', 'E', 'W' }, death = false });
            GameMap[new Tuple<int, int>(4, 2)] = new Tuple<Action<Tiles>, Tiles>(func, new Tiles { msg = "West or south? West or south? These are your only options.", paths = new List<char> { 'S', 'W' }, death = false });
            GameMap[new Tuple<int, int>(0, 3)] = new Tuple<Action<Tiles>, Tiles>(func, new Tiles { msg = "Oh nice...", paths = new List<char> { 'N', 'S', 'E' }, death = false });
            GameMap[new Tuple<int, int>(1, 3)] = new Tuple<Action<Tiles>, Tiles>(func, new Tiles { msg = "Are you kidding? Yet an other crossroad?", paths = new List<char> { 'N', 'S', 'E', 'W' }, death = false });
            GameMap[new Tuple<int, int>(2, 3)] = new Tuple<Action<Tiles>, Tiles>(func, new Tiles { msg = "A stream is running from North to South. There is a bridge crossing the stream.", paths = new List<char> { 'W', 'E' }, death = false });
            GameMap[new Tuple<int, int>(3, 3)] = new Tuple<Action<Tiles>, Tiles>(func, new Tiles { msg = "Up, down, left or right. Haha this is fun.", paths = new List<char> { 'N', 'S', 'E', 'W' }, death = false });
            GameMap[new Tuple<int, int>(4, 3)] = new Tuple<Action<Tiles>, Tiles>(func, new Tiles { msg = "A strange smell comes from the south.", paths = new List<char> { 'S', 'W', 'E' }, death = false });
            GameMap[new Tuple<int, int>(0, 4)] = new Tuple<Action<Tiles>, Tiles>(func, new Tiles { msg = "You are cornered.", paths = new List<char> { 'N', 'E' }, death = false });
            GameMap[new Tuple<int, int>(1, 4)] = new Tuple<Action<Tiles>, Tiles>(func, new Tiles { msg = "You hear some birds singing.", paths = new List<char> { 'N', 'W', 'E' }, death = false });
            GameMap[new Tuple<int, int>(2, 4)] = new Tuple<Action<Tiles>, Tiles>(func, new Tiles { msg = "Dead end. A stream running from North to South is blocking your path and you can't see any obvious way to cross it. ", paths = new List<char> { 'W' }, death = false });
            GameMap[new Tuple<int, int>(3, 4)] = new Tuple<Action<Tiles>, Tiles>(func, new Tiles { msg = "Beautiful flowers surround your path. A disgusting fragrance comes from the East.", paths = new List<char> { 'N', 'E' }, death = false });
            GameMap[new Tuple<int, int>(4, 4)] = new Tuple<Action<Tiles>, Tiles>(func, new Tiles { msg = "You have reached an ugly old stinking tower with no obvious way in.", paths = new List<char> { 'N', 'W' }, death = false });

            ActionDict Actions = new ActionDict
            {
                { 'N', (p, t) => t.paths.Contains('N') ? new Tuple<int, int>(p.Item1, p.Item2 -1) : p },
                { 'S', (p, t) => t.paths.Contains('S') ? new Tuple<int, int>(p.Item1, p.Item2 +1) : p },
                { 'W', (p, t) => t.paths.Contains('W') ? new Tuple<int, int>(p.Item1 -1, p.Item2) : p },
                { 'E', (p, t) => t.paths.Contains('E') ? new Tuple<int, int>(p.Item1 +1, p.Item2) : p },
                { 'Q', (p, t) => new Tuple<int, int>(-1, -1)},
            };

            Tuple<int, int> pos = new Tuple<int, int>(1, 1);

            while (pos.Item1 >= 0 && pos.Item2 >= 0)
            {
                var tile_function = GameMap[pos].Item1;
                var current_tile = GameMap[pos].Item2;

                tile_function(current_tile);
                if(current_tile.death)
                {
                    break;
                }
                Console.Write("Where to next? ");
                var input = Console.ReadKey().KeyChar;
                input = input.ToString().ToUpper()[0];
                Console.WriteLine("\n");
                if(!Actions.ContainsKey(input))
                {
                    Console.WriteLine("\nSorry I don't know how to do that. Try again...");
                    continue;
                }

                pos = Actions[input](pos, current_tile);
            }

            Console.WriteLine("\n\nGame Over");
        }
    }
}
