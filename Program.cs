using Newtonsoft.Json;

namespace ConsoleRPG
{
    class Program
    {
        // Init player instance
        static public Player player = default;
        static void LoadGame()
        {
            Console.Write("Insert save file path to load progress");
            string saveFilePath = Console.ReadLine();

            string serializedSaveFile = default;
            string pressedKey = default;

            do
            {
                try
                {
                    serializedSaveFile = File.ReadAllText($"{saveFilePath}/saveFile.json");
                    player = JsonConvert.DeserializeObject<Player>(serializedSaveFile);

                }
                catch
                {
                    Console.WriteLine("Invalid Path... \n");
                    Console.WriteLine("Do you want to e[x]it? or [c]ontinue?: ");
                    pressedKey = Console.ReadLine().ToLower();

                }
            } while (serializedSaveFile == default || pressedKey == "x");
        }

        static void Main(string[] args)
        {

        }
    }
}