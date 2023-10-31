using Newtonsoft.Json;

namespace ConsoleRPG
{
    class Program
    {
        static public string saveFileDirectoryPath = default;
        static readonly private string saveFileName = "saveFile.json";
        static public bool IsExitGameTriggered = false;
        static public Player Player = default;

        static void SetSavePath()
        {
            do
            {
                Console.Write("\nInsert save file directory path to load/save progress, [x - to exit]: ");
                saveFileDirectoryPath = Console.ReadLine();

                if (saveFileDirectoryPath == "x")
                {
                    IsExitGameTriggered = true;
                }
            } while (!Directory.Exists(saveFileDirectoryPath) && !IsExitGameTriggered);
        }

        static void NewGame()
        {
            Console.Write("\nInsert character name: ");
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
                    Console.WriteLine("\nInvalid Path...");
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
                Console.WriteLine("\n***** MENU ***** ");
                Console.WriteLine("1 - New Game ");
                Console.WriteLine("2 - Load Game ");
                Console.WriteLine("x - Exit");

                Console.Write("Choice: ");
                string userPickedOption = Console.ReadLine();

                switch (userPickedOption.ToLower())
                {
                    case "1":
                        NewGame();
                        GameFlow();
                        break;
                    case "2":
                        LoadGame();
                        GameFlow();
                        break;
                    case "x":
                        LoadGame();
                        IsExitGameTriggered = true;
                        break;
                    default:
                        Console.WriteLine("\nInvalid option choice...");
                        break;
                }

            } while (!IsExitGameTriggered);
        }

        static void GameFlow()
        {

            bool GoBackToMenu = false;
            Console.WriteLine("\n***** Game *****");

            do
            {
                Console.WriteLine("What do you want to do?: ");
                Console.WriteLine("1 - Fight creatures");
                Console.WriteLine("2 - Learn skills");
                Console.WriteLine("3 - Improve skills");
                Console.WriteLine("x - Go back to menu");

                Console.Write("Choice: ");
                string userChoice = Console.ReadLine().ToLower();

                switch (userChoice)
                {
                    case "1":
                        Player.FightCreatures();
                        break;
                    case "2":
                        Console.Write("\nType name of statistic: ");
                        Player.LearnSkills(Console.ReadLine());
                        break;
                    case "3":
                        Console.Write("\nType name of statistic: ");
                        Player.ImproveSkills(Console.ReadLine());
                        break;
                    case "x":
                        GoBackToMenu = true;
                        break;
                    default:
                        break;
                }

            } while (!GoBackToMenu);

            SaveGame();
        }

        static int Main(string[] args)
        {
            SetSavePath();

            if (!IsExitGameTriggered) DisplayMenu();

            if (Player != null) SaveGame();

            return 0;
        }
    }
}