﻿

namespace Adventure
{
    class Actions
    {
        int height = Console.WindowHeight - 1;
        int width = Console.WindowWidth - 5;
        protected static int origRow;
        protected static int origCol;

        public bool Encounter(NPC hero, NPC enemy)
        {
            if (hero.position[0] == enemy.position[0] && hero.position[1] == enemy.position[1])
            {
                WriteAt($"You have encountered {enemy.GetName(enemy)} ", width/2, height/2);
                return true;
            }
            return false;
        }

        //prints to console the string at the (x, y) values 
        protected static void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(origCol + x, origRow + y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        public void Battle(NPC hero, NPC enemy)
        {
            Console.WriteLine("Battle Start");
            do
            {
                enemy.HP = Attack(hero, enemy);
                if (enemy.HP >= 0)
                {
                    hero.HP = Attack(enemy, hero);
                }
            } while (hero.HP >= 0 && enemy.HP >= 0);
            WriteAt(hero.HP >= 0 ? $"{hero.GetName(hero)} has WON" : $"You Lost to {enemy.GetName(enemy)}", 0, 1);
        }

        private int Attack(NPC attack, NPC defend)
        {
            //(base damage(1) + npc weapon damage) - (attacker str - defender def) 
            int damage = 1 + attack.equipment.damage + (attack.str - defend.def);
            defend.HP -= damage;
            WriteAt($"{attack.GetName(attack)} attacked {defend.GetName(defend)} for {damage}", 0, 1);
            WriteAt($"{defend.GetName(defend)} has {defend.HP}", 0, 2);
            return defend.HP;
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
