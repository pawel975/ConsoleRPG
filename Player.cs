using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    class Player
    {
        public string Name { get; }
        public int Level { get; set; }
        public List<Statistic> Statistics { get; set; }
        public Player(string name, List<Statistic> statistics)
        {
            Name = name;
            Level = 0;
            Statistics = statistics;
        }

        private void LevelUp() => Level++;

        private void UpdatePlayerStatistic(string statName, int updatedStatPoints)
        {
            if (updatedStatPoints < 0)
            {
                Console.WriteLine($"Updated points level cannot be less than 0, passed value - {updatedStatPoints}");
            }

            foreach (var stat in Statistics)
            {
                if (stat.Name == statName)
                {
                    stat.Points = updatedStatPoints;
                    Console.WriteLine($"Player [{statName}] updated to [{updatedStatPoints}]");
                }
            }
        }

        private void CreateNewStatistic(string statName)
        {
            Statistics.Add(new Statistic(statName));
        }

        private void DeleteStatistic(string statName)
        {
            Statistic statisticToRemove = Statistics.FirstOrDefault(stat => stat.Name == statName);
            Statistics.Remove(statisticToRemove);
        }

        public void PrintPlayerInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Level: {Level}");
            Console.WriteLine("Statistics:");
            foreach (Statistic stat in Statistics)
            {
                Console.WriteLine($"\t{stat.Name}: {stat.Points}");
            }
        }
        public void FightCreatures()
        {
            // Generates 0 or 1 randomly
            int BattleIndex = (int)Math.Floor(new Random().NextDouble());

            bool PlayerWonBattle = BattleIndex == 1 ? true : false;

            if (PlayerWonBattle)
            {
                LevelUp();
                Console.WriteLine(BattleIndex);
                Console.WriteLine("You won the battle!");
            }
            else
            {
                Console.WriteLine(BattleIndex);
                Console.WriteLine("You defeated...");
            }


        }
        public void LearnSkills(string statName) => CreateNewStatistic(statName);

        public void ImproveSkills(string statName)
        {
            Statistic statToUpdate = Statistics.FirstOrDefault(stat => statName == stat.Name);
            statToUpdate.LevelUpStatistic();
        }


    }
}
