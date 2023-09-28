using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
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
