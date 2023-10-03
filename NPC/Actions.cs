
namespace Adventure
{
    class Actions
    {
        int height = Console.WindowHeight - 1;
        int width = Console.WindowWidth - 5;

        public bool Encounter(NPC hero, NPC enemy)
        {
            if (hero.position[0] == enemy.position[0] && hero.position[1] == enemy.position[1])
            {
                Console.WriteLine($"You have encountered {enemy.GetName(enemy)} ");
                return true;
            }
            return false;
        }

        public void Battle(NPC hero, NPC enemy)
        {
            Console.WriteLine("Battle Start");

        }

        public bool Move(NPC hero, string player)
        {
            bool end = true;
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
                    Console.SetCursorPosition(50, 0);
                    Console.WriteLine($"({hero.position[0]}, {hero.position[1]})");
                    Console.SetCursorPosition(hero.position[0], hero.position[1]);
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

            // Keep player position within the bounds of the Terminal window
            hero.position[0] = (hero.position[0] < 0) ? 0 : (hero.position[0] >= width ? width : hero.position[0]);
            hero.position[1] = (hero.position[1] < 0) ? 0 : (hero.position[1] >= height ? height : hero.position[1]);

            // Draw the player at the new location
            Console.SetCursorPosition(hero.position[0], hero.position[1]);
            Console.Write(player);
            return end;
        }
    }
}
