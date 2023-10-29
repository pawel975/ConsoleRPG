using Newtonsoft.Json;

namespace ConsoleRPG
{
    class Program
    {
        static public string saveFileDirectoryPath = default;
        static readonly private string saveFileName = "saveFile.json";
        static public bool GameActive = true;
        static public bool IsGameExit = false;
        // Init player instance
        static public Player player = default;

        static void LoadGame()
        {
            string serializedProgress = default;
            string pressedKey = default;

            do
            {
                try
                {
                    serializedProgress = File.ReadAllText($"{saveFileDirectoryPath}/{saveFileName}");
                    player = JsonConvert.DeserializeObject<Player>(serializedProgress);

                }
                catch
                {
                    Console.WriteLine("Invalid Path... \n");
                    Console.WriteLine("Do you want to e[x]it? or [c]ontinue?: ");
                    pressedKey = Console.ReadLine().ToLower();

                }
            } while (serializedProgress == default || pressedKey == "x");
        }

        static void SaveGame()
        {
            var serializedProgress = JsonConvert.SerializeObject(player);
            File.WriteAllText($"{saveFileDirectoryPath}/{saveFileName}", serializedProgress);

        }

        static void NewGame()
        {
            Console.Write("Insert character name: ");
            string name = Console.ReadLine();

            player = new Player(name, new List<Statistic>());
        }

        static int Main(string[] args)
        {
            do
            {
                Console.Write("Insert save file directory path to load/save progress, [x - to exit]: ");
                saveFileDirectoryPath = Console.ReadLine();

                if (saveFileDirectoryPath == "x")
                {
                    return 0;
                }
            } while (!Directory.Exists(saveFileDirectoryPath));

            do
            {
                Console.WriteLine("Choose action: ");
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
                        IsGameExit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option choice...");
                        break;
                }

            } while (!GameActive || IsGameExit);

            //TODO: Game until player choose [x]
            do
            {

            } while (IsGameExit);

            return 0;
        }
    }
}