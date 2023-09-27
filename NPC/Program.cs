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

            Player car = new("Hiro", "O", "Hero", new List<string> {"sword", "shield", "chainmail" });
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
    class NPC
    {
        private string fName { get; set; }
        private string lName { get; set; }
        private string title { get; set; }
        private List<string> inventory { get; set; }

        public NPC(string fName, string lName, string title, List<string> inventory)
        {
            this.fName = fName;
            this.lName = lName;
            this.title = title;
            this.inventory = inventory;
        }


        public virtual void Go()
        {

        }

        public virtual void Inventory()
        {
            
        }

        public virtual void Display(List<string> stuff)
        {

        }

        public virtual void Stats()
        {
            Console.WriteLine();
        }
    }
    class Player : NPC
    {

        public Player(string fName, string lName, string title, List<string> inventory) : base(fName, lName, title, inventory)
        {
        }

        public override void Go()
        {
            Console.WriteLine("The player is moving!");
        }

        public override void Inventory()
        {
            base.Inventory();
        }

        public override void Display(List<string> stuff)
        {
            foreach (var item in stuff)
            {
                Console.WriteLine(item);
            }
        }
    }
    class Villager : NPC
    {
        public Villager(string fName, string lName, string title, List<string> inventory) : base(fName, lName, title, inventory)
        {
        }

        public override void Go()
        {
            Console.WriteLine("The villager is moving!");
        }

        public override void Inventory()
        {
            base.Inventory();
        }
    }
    class Enemy : NPC
    {
        public Enemy(string fName, string lName, string title, List<string> inventory) : base(fName, lName, title, inventory)
        {

        }

        public override void Go()
        {
            Console.WriteLine("The enemy is moving");
        }

        public override void Inventory()
        {
            base.Inventory();
        }
    }
}