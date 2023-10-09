
using System.Diagnostics;
using System;

namespace Adventure
{
    class Program
    {

        // Available player and food strings
        static string[] playerStates = { "('-')", "(^-^)", "(X_X)" };
        static string[] enemyStates = { "(<_>)" };

        // Current player string displayed in the Console
        static string player = playerStates[0];
        static string merchant = playerStates[1];
        static string enemy = enemyStates[0];
        static void Main(string[] args)
        {
            //// setting the window size
            //Console.SetWindowSize(100, 100);

            //// setting buffer size of console
            //Console.SetBufferSize(200, 200);
            Console.CursorVisible = true;

            Actions act = new();

            Player hero = new("Hiro", "O", "Hero", 1000, 100, 50, 5, new List<string> { "HP potion"}, new Equipment("katana", 30), new int[] {0, 1});
            Villager fisherman = new("Bob", "Smith", "The fisherman", 5, 5, 5, 2, new List<string> {"fishing pole"}, new Equipment("fishing pole", 2), new int[] { 0, 0 });
            Villager trader = new("Joe", "Goldman", "The merchant", 5, 5, 5, 2, new List<string> { "Pen", "HP potion", "HP potion" }, new Equipment("fishing pole", 2), new int[] { 5, 5 });

            Enemy goblin = new("Gob", "Greenskin", "The Slow", 10, 3, 4, 2, new List<string> { "goblin sword", "goblin shield" }, new Equipment("goblin sword", 10), new int[] { 20, 20 });
            Enemy demon = new("Gyoubu", "Oni", "The Demon", 300, 50, 35, 3, new List<string> {"bloody heart" }, new Equipment("Demon saber", 20), new int[] { 10, 10 });
            Enemy skeleton = new("Bones", "Boney", "The Skeleton Warrior", 25, 10, 20, 3, new List<string> { "Ragged Shield"}, new Equipment("Rusty sword", 10), new int[] { 10, 10 });

            Console.WriteLine("THE ADVENTURE BEGINS");
            //initialize characters on console
            CreateNPCs(demon, enemy);
            CreateNPCs(trader, merchant);
            CreateNPCs(hero, player);

            NPC[] characters = { hero, fisherman, demon };

            bool end = true;
            do
            {
                end = act.Move(hero, player);
                if (act.BattleEncounter(hero, demon))
                {
                    act.Battle(hero, demon);
                }
                if (act.MerchantEncounter(hero, trader))
                {
                    hero.backpack.Add(act.Shop(hero, trader));
                    hero.position[1]++;
                    CreateNPCs(demon, enemy);
                    CreateNPCs(trader, merchant);
                    CreateNPCs(hero, player);
                }

            } while (hero.HP > 0 && end);

        }

        private static void CreateNPCs(NPC npc, string type)
        {
            Console.SetCursorPosition(npc.position[0], npc.position[1]);
            Console.Write(type);
        }
    }
}
    