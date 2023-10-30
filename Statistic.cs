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
        public int Points { get; set; } = 1;
        public Statistic(string name)
        {
            Name = name;
        }

        public void LevelUpStatistic() => Points++;

        public void UpdateStatistic(int levelToSet) => Points = levelToSet;
    }
}
