
namespace Adventure
{
    class NPC
    {
        private string fName { get; set; }
        private string lName { get; set; }
        private string title { get; set; }
        public int HP { get; set; }
        private int str { get; set; }
        private int def { get; set; }
        private int moves { get; set; }
        private List<string> inventory { get; set; }
        public int[] position { get; set; }


        public NPC(string fName, string lName, string title, int HP, int str, int def, int moves, List<string> inventory, int[] position)
        {
            this.fName = fName;
            this.lName = lName;
            this.title = title;
            this.HP = HP;
            this.str = str;
            this.def = def;
            this.moves = moves;
            this.inventory = inventory;
            this.position = position;
        }


        public virtual void Go()
        {

        }

        public virtual void Inventory()
        {
            Console.WriteLine($"The {title}'s inventory: ");
            foreach (string item in inventory)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        public virtual void DisplayStats()
        {
            Console.WriteLine($"{fName} {lName} the {title}");
            Console.WriteLine($"HP: {HP} STR: {str} DEF: {def} moves: {moves}");
        }


    }
    class Player : NPC
    {

        public Player(string fName, string lName, string title, int HP, int str, int def, int moves, List<string> inventory, int[] position) : base(fName, lName, title, HP, str, def, moves, inventory, position)
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

        public override void DisplayStats()
        {
            base .DisplayStats();
        }
    }
    class Villager : NPC
    {
        public Villager(string fName, string lName, string title, int HP, int str, int def, int moves, List<string> inventory, int[] position) : base(fName, lName, title, HP, str, def, moves, inventory, position)
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
        public Enemy(string fName, string lName, string title, int HP, int str, int def, int moves, List<string> inventory, int[] position) : base(fName, lName, title, HP, str, def, moves, inventory, position)
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

        public override void DisplayStats()
        {
            base.DisplayStats();
        }
    }
}
