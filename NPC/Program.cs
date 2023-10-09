
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
            string merchant = playerStates[1];
            string enemy = enemyStates[0];

            Actions act = new();

            Player hero = new("Hiro", "O", "Hero", 1000, 100, 50, 5, new List<string> { "HP potion"}, new Equipment("katana", 30), new int[] {0, 1});
            Villager fisherman = new("Bob", "Smith", "The fisherman", 5, 5, 5, 2, new List<string> {"fishing pole"}, new Equipment("fishing pole", 2), new int[] { 0, 0 });
            Villager trader = new("Joe", "Goldman", "The merchant", 5, 5, 5, 2, new List<string> { "Pen", "HP potion", "HP potion" }, new Equipment("fishing pole", 2), new int[] { 5, 5 });

            Enemy goblin = new("Gob", "Greenskin", "The Slow", 10, 3, 4, 2, new List<string> { "goblin sword", "goblin shield" }, new Equipment("goblin sword", 10), new int[] { 20, 20 });
            Enemy demon = new("Gyoubu", "Oni", "The Demon", 300, 50, 35, 3, new List<string> {"bloody heart" }, new Equipment("Demon saber", 20), new int[] { 10, 10 });
            Enemy skeleton = new("Bones", "Boney", "The Skeleton Warrior", 25, 10, 20, 3, new List<string> { "Ragged Shield"}, new Equipment("Rusty sword", 10), new int[] { 10, 10 });

            Console.WriteLine("THE ADVENTURE BEGINS");
            //initialize characters on console
            Console.SetCursorPosition(demon.position[0], demon.position[1]);
            Console.Write(enemy);

            Console.SetCursorPosition(trader.position[0], trader.position[1]);
            Console.Write(merchant);

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
                if (act.BattleEncounter(hero, demon))
                {
                    act.Battle(hero, demon);
                }
                if (act.MerchantEncounter(hero, trader))
                {
                    hero.backpack.Add(act.Shop(hero, trader));
                    hero.position[0]++;
                    //TODO: reinitialize stuff on screen
                }

            } while (hero.HP > 0 && end);

        }
    }
}
    