using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Adventure
{
    class Program
    {
        static void Main(string[] args)
        {

            // polymorphism = Greek word that means to "have many forms"
            //                Objects can be identified by more than one type
            //                Ex. A Dog is also: Canine, Animal, Organism

            Player hero = new("Hiro", "O", "Hero", 100, 100, 100, 5, new List<string> { "sword", "shield", "chainmail" });
            Villager fisherman = new("Bob", "Smith", "fisherman", 5, 5, 5, 2, new List<string> {"fishing pole"});
            Enemy demon = new("Gyobu", "Oni", "Demon", 20, 10, 10, 3, new List<string> {"bloody heart" });

            NPC[] characters = { hero, fisherman, demon };

            foreach (NPC peeps in characters)
            {
                peeps.DisplayStats();
                peeps.Inventory();
            }

        }
    }
}
    