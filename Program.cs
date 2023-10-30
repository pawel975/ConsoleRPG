using Newtonsoft.Json;

namespace ConsoleRPG
{
    class Program
    {
        static public string saveFileDirectoryPath = default;
        static readonly private string saveFileName = "saveFile.json";
        static public bool GameActive = false;
        static public bool IsExitGameTriggered = false;
        static public Player Player = default;

        static void SetSavePath()
        {
            do
            {
                Console.Write("Insert save file directory path to load/save progress, [x - to exit]: ");
                saveFileDirectoryPath = Console.ReadLine();

                if (saveFileDirectoryPath == "x")
                {
                    IsExitGameTriggered = true;
                }
            } while (!Directory.Exists(saveFileDirectoryPath) && !IsExitGameTriggered);
        }

        static void NewGame()
        {
            Console.Write("Insert character name: ");
            string name = Console.ReadLine();

            Player = new Player(name, new List<Statistic>());
        }

        static void LoadGame()
        {
            string serializedProgress = default;
            string pressedKey = default;

            do
            {
                try
                {
                    serializedProgress = File.ReadAllText($"{saveFileDirectoryPath}/{saveFileName}");
                    Player = JsonConvert.DeserializeObject<Player>(serializedProgress);

                }
                catch
                {
                    Console.WriteLine("Invalid Path... \n");
                }
            } while (serializedProgress == default || pressedKey == "x");
        }

        static void SaveGame()
        {
            var serializedProgress = JsonConvert.SerializeObject(Player);
            File.WriteAllText($"{saveFileDirectoryPath}/{saveFileName}", serializedProgress);
        }

        static void DisplayMenu()
        {
            do
            {
                Console.WriteLine("***** MENU ***** ");
                Console.WriteLine("1 - New Game ");
                Console.WriteLine("2 - Load Game ");
                Console.WriteLine("X - Exit");

                string userPickedOption = Console.ReadLine();

                switch (userPickedOption.ToLower())
                {
                    case "1":
                        NewGame();
                        GameActive = true;
                        break;
                    case "2":
                        LoadGame();
                        GameActive = true;
                        break;
                    case "x":
                        LoadGame();
                        IsExitGameTriggered = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option choice...");
                        break;
                }

            } while (!IsExitGameTriggered);
        }

        static void GameFlow()
        {

            bool GoBackToMenu = false;
            Console.WriteLine("***** Game *****");

            do
            {
                Console.WriteLine("What do you want to do?: ");
                Console.WriteLine("1 - Fight creatures");
                Console.WriteLine("2 - Learn skills");
                Console.WriteLine("3 - Improve skills");
                Console.WriteLine("x - Go back to menu");

                string userChoice = Console.ReadLine().ToLower();

                switch (userChoice)
                {
                    case "1":
                        Player.FightCreatures();
                        break;
                    case "2":
                        Console.Write("Type name of statistic: ");
                        string statName = Console.ReadLine();
                        Player.LearnSkills(statName);
                        break;
                    case "3":
                        Player.ImproveSkills();
                        break;
                    case "x":
                        GoBackToMenu = true;
                        break;
                    default:
                        break;
                }

            } while (!GoBackToMenu);
        }

        static int Main(string[] args)
        {
            SetSavePath();

            if (!IsExitGameTriggered) DisplayMenu();

            if (player != null) SaveGame();

            return 0;
        }
    }
}