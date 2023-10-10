using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public class Equipment
    {
        private string name;
        public string Name
        {
            get { return name; }
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
}
