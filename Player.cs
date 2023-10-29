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
        public int Level { get; }
        public List<Statistic> Statistics {  get; set;} 
        public Player(string name, List<Statistic> statistics)
        {
            Name = name;
            Level = 0;
            Statistics = statistics;
        }

        public void PrintPlayerInfo ()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Level: {Level}");
            Console.WriteLine("Statistics:");
            foreach (Statistic stat in Statistics)
            {
                Console.WriteLine($"\t{stat.Name}: {stat.Points}");
            }
        }

        /// <summary>
        /// Update point for given statistic
        /// </summary>
        /// <param name="statName"></param>
        /// <param name="updatedStatPoints"></param>
        public void UpdatePlayerStatistic(string statName, int updatedStatPoints)
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
        
        /// <summary>
        /// Creates new statistics with given init points.
        /// </summary>
        /// <param name="statName"></param>
        /// <param name="points"></param>
        public void CreateNewStatistic(string statName, int points)
        {
            Statistics.Add(new Statistic(statName, points));
        }

        /// <summary>
        /// Deletes statistic from player's statistics.
        /// </summary>
        /// <param name="statName"></param>
        public void DeleteStatistic(string statName)
        {
            Statistic statisticToRemove = Statistics.FirstOrDefault(stat => stat.Name == statName);
            Statistics.Remove(statisticToRemove);
        }
    }
}
