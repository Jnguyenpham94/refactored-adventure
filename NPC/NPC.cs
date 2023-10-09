
namespace Adventure
{
    class Equipment
    {
        private string name;
        public string Name 
        { get { return name; }
          set { name = value; } 
        }
        private int damage;
        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        public Equipment(string name, int damage)
        {
            this.name = name;
            this.damage = damage;
        }

    }

    class NPC
    {
        private string fName;
        public string FName
        {
            get { return $"{fName}"; }
            set { fName = value; }
        }

        private string lName;
        public string LName
        {
            get { return $"{lName}"; }
            set { lName = value; }
        }
        private string title;
        public string Title
        {
            get { return $"{title}"; }
            set { title = value; }
        }
        private int Hp;
        public int HP
        {
            get { return Hp; }
            set { Hp = value; }
        }
        private int str;
        public int Str
        {
            get { return str; }
            set { str = value; }
        }
        private int def { get; set; }
        public int Def
        {
            get { return def; }
            set { def = value; }
        }
        private int moves { get; set; }
        private List<string> inventory;
        public List<string> backpack 
        { get { return inventory; } 
          set { inventory = value; }
        }
        public Equipment equipment { get; set; }
        public int[] position { get; set; }

        protected static int origRow = 0;
        protected static int origCol = 0;

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
            this.Hp = HP;
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
            WriteAt($"{fName} {lName} the {title}", 0, 0);
            WriteAt($"HP: {Hp} STR: {str} DEF: {def} moves: {moves}", 0, 1);
        }

        public string GetFullName(NPC person)
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
        private List<string> inventory { get; set; }

        public Villager(string fName, string lName, string title, int HP, int str, int def, int moves, List<string> inventory, Equipment equipment, int[] position) : base(fName, lName, title, HP, str, def, moves, inventory, equipment, position)
        {
            this.inventory = inventory;
        }

        public override void Go()
        {
            Console.WriteLine("The villager is moving!");
        }

        public override void Inventory()
        {
            base.Inventory();
        }

        public string ShopInventory(NPC trader)
        {
            Console.Clear();
            WriteAt($"The {Title}'s inventory: ", 0, 0);
            int number = 1;
            int count = 25;
            foreach (string item in inventory)
            {
                WriteAt($"{number++}. {item}", 0, count++);
            }
            Console.WriteLine();
            //TODO: menu input switch statements
            string? input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.Clear();
                    return trader.backpack[0];
                case "2":
                    Console.Clear();
                    return trader.backpack[1];
                case "3":
                    Console.Clear();
                    return trader.backpack[2];
                default:
                    Console.WriteLine("Goodbye");
                    return "0";
            }
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
