﻿using System;
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
                Console.WriteLine($"\nUpdated points level cannot be less than 0, passed value - {updatedStatPoints}");
            }

            foreach (var stat in Statistics)
            {
                if (stat.Name == statName)
                {
                    stat.Points = updatedStatPoints;
                    Console.WriteLine($"\nPlayer [{statName}] updated to [{updatedStatPoints}]");
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

        private Statistic GetStatistic(string statName) => Statistics.FirstOrDefault(stat => stat.Name == statName);

        public void PrintPlayerInfo()
        {
            Console.WriteLine($"\nName: {Name}");
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
            int BattleIndex = (int)Math.Round(new Random().NextDouble());

            bool PlayerWonBattle = BattleIndex == 1 ? true : false;

            if (PlayerWonBattle)
            {
                LevelUp();
                Console.WriteLine("\nYou won the battle!");
            }
            else Console.WriteLine("\nYou defeated...");

        }
        public void LearnSkills(string statName)
        {
            CreateNewStatistic(statName);
            Console.WriteLine($"\nYou learned new skill - {statName} (level: {GetStatistic(statName).Points})");
        }

        public void ImproveSkills(string statName)
        {
            Statistic statToUpdate = Statistics.FirstOrDefault(stat => statName == stat.Name);
            if (statToUpdate != null)
            {
                statToUpdate.LevelUpStatistic();
                Console.WriteLine($"\nYou updated statistic - {statToUpdate.Name} (level: {statToUpdate.Points}");
            }
            else Console.WriteLine($"\nThere is no such statistic like '{statName}'...");
        }


    }
}
