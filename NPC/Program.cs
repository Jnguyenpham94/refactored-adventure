using NPC;
using System.Numerics;

namespace Adventure
{
    class Program
    {
        static void Main(string[] args)
        {
            //// setting the window size
            //Console.SetWindowSize(100, 100);

            //// setting buffer size of console
            //Console.SetBufferSize(200, 200);

            // Available player and food strings
            string[] playerStates = { "('-')", "(^-^)", "(X_X)" };
            string[] enemyStates = { "(<_>)" };
            Console.CursorVisible = true;

            // Current player string displayed in the Console
            string player = playerStates[0];
            string enemy = enemyStates[0];

            Actions act = new();

            Player hero = new("Hiro", "O", "Hero", 100, 100, 100, 5, new List<string> { "HP potion"}, new Equipment("katana", 30), new int[] {0, 1});
            Villager fisherman = new("Bob", "Smith", "The fisherman", 5, 5, 5, 2, new List<string> {"fishing pole"}, new Equipment("fishing pole", 2), new int[] { 0, 0 });

            Enemy goblin = new("Gob", "Greenskin", "The Slow", 10, 3, 4, 2, new List<string> { "goblin sword", "goblin shield" }, new Equipment("goblin sword", 10), new int[] { 20, 20 });
            Enemy demon = new("Gyoubu", "Oni", "The Demon", 30, 10, 10, 3, new List<string> {"bloody heart" }, new Equipment("Demon saber", 20), new int[] { 10, 10 });

            Console.WriteLine("THE ADVENTURE BEGINS");
            //initialize characters on console
            Console.SetCursorPosition(demon.position[0], demon.position[1]);
            Console.Write(enemy);

            Console.SetCursorPosition(hero.position[0], hero.position[1]);
            Console.Write(player);  

            NPC[] characters = { hero, fisherman, demon };

            //foreach (NPC peeps in characters)
            //{
            //    peeps.DisplayStats();
            //    peeps.Inventory();
            //}

            bool end = true;
            do
            {
                end = act.Move(hero, player);
                if (act.Encounter(hero, demon))
                {
                    act.Battle(hero, demon);
                     //battle stuff here?
                }

            } while (hero.HP > 0 && end);

        }
    }
}
    