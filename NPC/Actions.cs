
using System;
using static Adventure.globals;

namespace Adventure
{
    class Actions : Program
    {
        int height = Console.WindowHeight - 1;
        int width = Console.WindowWidth - 5;
        protected static int origRow;
        protected static int origCol;
        int lineCount = 1;
        Random rnd = new Random();

        public bool BattleEncounter(NPC hero, NPC enemy)
        {
            if (hero.position[0] == enemy.position[0] && hero.position[1] == enemy.position[1])
            {
                WriteAt($"You have encountered {enemy.GetFullName(enemy)} ", width/2, height/2);
                return true;
            }
            return false;
        }

        public bool MerchantEncounter(Player hero, Villager trader)
        {
            if (hero.position[0] == trader.position[0] && hero.position[1] == trader.position[1])
            {
                WriteAt($"You have encountered {trader.GetFullName(trader)} ", width / 2, height / 2);
                WriteAt($"What are you Buying? {trader.GetFullName(trader)} ", 1, lineCount++);
                return true;
            }
            return false;
        }

        public string Shop(Player hero, Villager trader)
        {
            return trader.ShopInventory(trader);
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
        {//TODO: clear battle log. After a timer or button press...
            Console.WriteLine("Battle Start");
            do
            {
                enemy.HP = Attack(hero, enemy);
                if (enemy.HP >= 0)
                {
                    hero.HP = Attack(enemy, hero);
                }
            } while (hero.HP >= 0 && enemy.HP >= 0);
            WriteAt(hero.HP >= 0 ? $"{hero.GetFullName(hero)} has WON" : $"You Lost to {enemy.GetFullName(enemy)}", 0, lineCount++);
            lineCount = 1;
        }

        private int Attack(NPC attack, NPC defend)
        {
            //(base damage(1) + npc weapon damage) - (attacker str - defender def) 
            int damage = 1 + attack.equipment.Damage + (attack.Str - defend.Def);
            defend.HP -= damage;
            if(damage <= 0)
            {
                damage = 1;
            }
            WriteAt($"{attack.FName} attacked {defend.FName} with {attack.equipment.Name} for {damage}", 0, lineCount++);
            WriteAt($"{defend.FName} has {defend.HP}", 0, lineCount++);
            return defend.HP;
        }

        public void UseItemHP(NPC player)
        {
            if (player.HP < 1000)
            {
                player.HP += 100;
                if(player.HP > 1000)
                {
                    player.HP = 1000;
                }
                Console.WriteLine("HP potion use: +100 HP");
                player.backpack.Remove("HP potion");
            }
            else
            {
                Console.WriteLine("HP full");
            }
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
                    Console.WriteLine("Game Over");
                    end = false;
                    break;
                case ConsoleKey.P: //show current position
                    Console.SetCursorPosition(50, 0);
                    Console.WriteLine($"({hero.position[0]}, {hero.position[1]})");
                    Console.SetCursorPosition(hero.position[0], hero.position[1]);
                    break;
                case ConsoleKey.I: //view player inventory
                    hero.Inventory();
                    break;
                case ConsoleKey.S:
                    hero.DisplayStats();
                    break;
                case ConsoleKey.C:
                    Console.Clear();
                    WriteAt("Cleared screen", 0, 0);
                    break;
                case ConsoleKey.M:// spawn an enemy at random location
                    int x = rnd.Next(40);
                    int y = rnd.Next(40);
                    Enemy demon = new("Gyoubu", "Oni", "The Demon", 300, 50, 35, 3, new List<string> { "bloody heart" }, new Equipment("Demon saber", 20), new int[] { x, y });
                    CreateNPC(demon, enemy);
                    break;
                //TODO: inventory usage HERE!!! probably numbers
                case ConsoleKey.NumPad1:
                    UseItemHP(hero);
                    break;
                //default:
                //    Console.WriteLine("Illegal button detected!!!");
                //    end = false;
                //    break;
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
