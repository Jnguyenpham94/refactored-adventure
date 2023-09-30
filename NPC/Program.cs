using System.Numerics;

namespace Adventure
{
    class Program
    {
        static void Main(string[] args)
        {

            // polymorphism = Greek word that means to "have many forms"
            //                Objects can be identified by more than one type
            //                Ex. A Dog is also: Canine, Animal, Organism

            int height = Console.WindowHeight - 1;
            int width = Console.WindowWidth - 5;

            // Available player and food strings
            string[] states = { "('-')", "(^-^)", "(X_X)" };

            // Current player string displayed in the Console
            string player = states[0];

            Player hero = new("Hiro", "O", "Hero", 100, 100, 100, 5, new List<string> { "sword", "shield", "chainmail" }, new int[] {0, 0});
            Villager fisherman = new("Bob", "Smith", "fisherman", 5, 5, 5, 2, new List<string> {"fishing pole"}, new int[] { 0, 0 });

            Enemy goblin = new("Gob", "Greenskin", "The Slow", 10, 3, 4, 2, new List<string> { "goblin sword", "goblin shield" }, new int[] { 0, 0 });
            Enemy demon = new("Gyoubu", "Oni", "Demon", 30, 10, 10, 3, new List<string> {"bloody heart" }, new int[] { 0, 0 });

            NPC[] characters = { hero, fisherman, demon };

            //foreach (NPC peeps in characters)
            //{
            //    peeps.DisplayStats();
            //    peeps.Inventory();
            //}

            bool end = true;

            Console.WriteLine("THE ADVENTURE BEGINS");
            do
            {
                int lastX = hero.position[0];
                int lastY = hero.position[1];
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        hero.position[1] -= 1;
                        break;
                    case ConsoleKey.DownArrow:
                        hero.position[1] += 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        hero.position[0] -= 1;
                        break;
                    case ConsoleKey.RightArrow:
                        hero.position[0] += 1;
                        break;
                    case ConsoleKey.Escape:
                        end = false;
                        break;
                    case ConsoleKey.P: //show current position
                        Console.WriteLine($"({hero.position[0]}, {hero.position[1]})");
                        break;
                    case ConsoleKey.I:
                        hero.Inventory();
                        break;
                    case ConsoleKey.S:
                        hero.DisplayStats();
                        break;
                    default:
                        Console.WriteLine("Illegal button detected!!!");
                        end = false;
                        break;
                }

                //Clear the characters at the previous position
                Console.SetCursorPosition(lastX, lastY);
                for (int i = 0; i < player.Length; i++)
                {
                    Console.Write(" ");
                }

                if (hero.position[0] == demon.position[0] && hero.position[1] == demon.position[1])
                {
                    Console.WriteLine($"You have encountered ");
                }

                // Keep player position within the bounds of the Terminal window
                hero.position[0] = (hero.position[0] < 0) ? 0 : (hero.position[0] >= width ? width : hero.position[0]);
                hero.position[1] = (hero.position[1] < 0) ? 0 : (hero.position[1] >= height ? height : hero.position[1]);

                // Draw the player at the new location
                Console.SetCursorPosition(hero.position[0], hero.position[1]);
                Console.Write(player);

            } while (hero.HP > 0 && end);

        }
    }
}
    