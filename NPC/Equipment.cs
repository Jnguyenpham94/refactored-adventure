using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPC
{
    class Equipment
    {
        private string name { get; set; }
        private int damage { get; set; }
        
        public Equipment(string name, int damage) 
        {
            this.name = name;
            this.damage = damage;
        }
    }
}
