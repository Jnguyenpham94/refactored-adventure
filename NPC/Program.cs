namespace Adventure
{
    class Program
    {
        static void Main(string[] args)
        {

            // polymorphism = Greek word that means to "have many forms"
            //                Objects can be identified by more than one type
            //                Ex. A Dog is also: Canine, Animal, Organism

            Player hero = new("Hiro", "O", "Hero", 100, 100, 100, 5, new List<string> { "sword", "shield", "chainmail" }, new int[] {0, 0});
            Villager fisherman = new("Bob", "Smith", "fisherman", 5, 5, 5, 2, new List<string> {"fishing pole"}, new int[] { 0, 0 });

            Enemy goblin = new("Gob", "Greenskin", "The Slow", 10, 3, 4, 2, new List<string> { "goblin sword", "goblin shield" }, new int[] { 0, 0 });
            Enemy demon = new("Gyoubu", "Oni", "Demon", 30, 10, 10, 3, new List<string> {"bloody heart" }, new int[] { 0, 0 });

            NPC[] characters = { hero, fisherman, demon };

            foreach (NPC peeps in characters)
            {
                peeps.DisplayStats();
                peeps.Inventory();
            }

            bool end = true;
            string? command;
            Console.WriteLine("THE ADVENTURE BEGINS");
            do
            {
                Console.WriteLine($"({hero.position[0]}, {hero.position[1]})");
                command = Console.ReadLine();
                switch(command)
                {
                    case "1": //right
                        hero.position[0] += 1;
                        break; 
                    case "2": //left
                        hero.position[0] -= 1;
                        break;
                    case "3": //forward
                        hero.position[1] += 1;
                        break;
                    case "4": //backward
                        hero.position[1] -= 1;
                        break;
                    case "end":
                        end = false;
                        break;
                    default:
                        Console.WriteLine();
                        break;
                }
                if (hero.position[0] == demon.position[0] && hero.position[1] == demon.position[1])
                {
                    Console.WriteLine($"You have encountered ");
                }

            } while (hero.HP > 0 && end);

        }
    }
}
    