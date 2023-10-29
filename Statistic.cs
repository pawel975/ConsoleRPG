using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    class Statistic
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public Statistic(string name, int points)
        {
            Name = name;
            Points = points;
        }
    }
}
