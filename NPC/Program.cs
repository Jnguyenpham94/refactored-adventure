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
            Console.CursorVisible = true;

            // Current player string displayed in the Console
            string player = playerStates[0];

            Actions act = new();

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
                end = act.Move(hero, player);

                if (hero.position[0] == demon.position[0] && hero.position[1] == demon.position[1])
                {
                    Console.WriteLine($"You have encountered ");
                }

            } while (hero.HP > 0 && end);

        }
    }
}
    