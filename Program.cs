using Newtonsoft.Json;

namespace ConsoleRPG
{
    class Program
    {
        static public string saveFileDirectoryPath = default;
        static readonly private string saveFileName = "saveFile.json";
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

        static void Main(string[] args)
        {
            Console.Write("Insert save file directory path to load/save progress");
            saveFileDirectoryPath = Console.ReadLine();

        }
    }
}