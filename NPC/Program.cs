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

            Player car = new("Hiro", "O", "Hero", new List<string> { "sword", "shield", "chainmail" });
            Villager bicycle = new("Bob", "Smith", "fisherman", new List<string> { });
            Enemy boat = new("Gyobu", "Oni", "Demon", new List<string> { });

            NPC[] vehicles = { car, bicycle, boat };

            foreach (NPC vehicle in vehicles)
            {
                vehicle.Go();
                vehicle.Inventory();
            }

        }
    }
}
    