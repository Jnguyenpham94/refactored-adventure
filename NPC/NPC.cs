
namespace Adventure
{
    class Equipment
    {
        private string name { get; set; }
        public int damage { get; set; }

        public Equipment(string name, int damage)
        {
            this.name = name;
            this.damage = damage;
        }

    }

    class NPC
    {
        private string fName { get; set; }
        private string lName { get; set; }
        private string title { get; set; }
        public int HP { get; set; }
        public int str { get; set; }
        public int def { get; set; }
        private int moves { get; set; }
        private List<string> inventory { get; set; }
        public Equipment equipment { get; set; }
        public int[] position { get; set; }

        protected static int origRow;
        protected static int origCol;

        //prints to console the string at the (x, y) values 
        protected virtual void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(origCol + x, origRow + y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }


        public NPC(string fName, string lName, string title, int HP, int str, int def, int moves, List<string> inventory, Equipment equipment, int[] position)
        {
            this.fName = fName;
            this.lName = lName;
            this.title = title;
            this.HP = HP;
            this.str = str;
            this.def = def;
            this.moves = moves;
            this.inventory = inventory;
            this.equipment = equipment;
            this.position = position;
        }


        public virtual void Go()
        {

        }

        public virtual void Inventory()
        {
            Console.Clear();
            WriteAt($"The {title}'s inventory: ", 0, 0);
            int count = 1;
            foreach (string item in inventory)
            {
                WriteAt(item, 0, count++);
            }
            Console.WriteLine();
        }

        public virtual void DisplayStats()
        {
            Console.Clear();
            WriteAt($"{fName} {lName} the {title}", 0, 0);
            WriteAt($"HP: {HP} STR: {str} DEF: {def} moves: {moves}", 0, 1);
        }

        public string GetName(NPC person)
        {
            return $"{person.fName} {person.lName} the {person.title}";
        }

    }

    class Player : NPC
    {

        public Player(string fName, string lName, string title, int HP, int str, int def, int moves, List<string> inventory, Equipment equipment, int[] position) : base(fName, lName, title, HP, str, def, moves, inventory, equipment, position)
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
        public Villager(string fName, string lName, string title, int HP, int str, int def, int moves, List<string> inventory, Equipment equipment, int[] position) : base(fName, lName, title, HP, str, def, moves, inventory, equipment, position)
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
        public Enemy(string fName, string lName, string title, int HP, int str, int def, int moves, List<string> inventory, Equipment equipment, int[] position) : base(fName, lName, title, HP, str, def, moves, inventory, equipment, position)
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
