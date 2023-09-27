using System;

namespace Adventure
{
    class Program
    {
        static void Main(string[] args)
        {

            // polymorphism = Greek word that means to "have many forms"
            //                Objects can be identified by more than one type
            //                Ex. A Dog is also: Canine, Animal, Organism

            Car car = new Car(4, "steel");
            Bicycle bicycle = new Bicycle("aluminum");
            Boat boat = new Boat("carbon fiber");

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
        private int fname { get; set; }
        private int lname { get; set; }
        private string frame { get; set; }

        public NPC(int fname, string lname)
        {
            this.fname = fname;
            this.frame = lname;
        }


        public virtual void Go()
        {

        }

        public virtual void Inventory()
        {
            Console.WriteLine($"{fname} {lname} inventory: ");
        }
    }
    class Car : NPC
    {

        public Car(int wheels, string frame) : base(wheels, frame)
        {
        }

        public override void Go()
        {
            Console.WriteLine("The car is moving!");
        }

        public override void Inventory()
        {
            base.Inventory();
        }
    }
    class Bicycle : NPC
    {
        public Bicycle(string frame, int wheels = 2) : base(wheels, frame)
        {
        }

        public override void Go()
        {
            Console.WriteLine("The bicycle is moving!");
        }

        public override void Inventory()
        {
            base.Inventory();
        }
    }
    class Boat : NPC
    {
        public Boat(string frame, int wheels = 0) : base(wheels, frame)
        {

        }

        public override void Go()
        {
            Console.WriteLine("The boat is moving!");
        }

        public override void Inventory()
        {
            base.Inventory();
        }
    }
}