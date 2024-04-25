using RPG_GameLogic.Factories;
using RPG_GameLogic.Interfaces;

namespace RPG_GameLogic.GameManagement
{
    public class GameConsole
    {
        public static void Initialize()
        {
            Console.Clear();
            Console.WriteLine("Welcome to");
            Console.WriteLine(@"
  _____  _____   _____      _____          __  __ ______ 
 |  __ \|  __ \ / ____|    / ____|   /\   |  \/  |  ____|
 | |__) | |__) | |  __    | |  __   /  \  | \  / | |__   
 |  _  /|  ___/| | |_ |   | | |_ | / /\ \ | |\/| |  __|  
 | | \ \| |    | |__| |   | |__| |/ ____ \| |  | | |____ 
 |_|  \_\_|     \_____|    \_____/_/    \_\_|  |_|______|
 
 
 ");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public static string SelectOptions(string header, string[] options)
        {
            Console.Clear();
            Console.WriteLine(header + " (Select With ArrowKeys)");

            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }

            int selectedIndex = 0;
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                Console.Clear();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = (selectedIndex - 1 + options.Length) % options.Length;
                        break;
                    case ConsoleKey.DownArrow:
                        selectedIndex = (selectedIndex + 1) % options.Length;
                        break;
                    case ConsoleKey.Enter:
                        return options[selectedIndex];
                }

                Console.SetCursorPosition(0, 0);
                Console.WriteLine(header + " (Select With ArrowKeys)");
                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine($"{i + 1}. {options[i]}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"{i + 1}. {options[i]}");
                    }
                }
            }
        }

        public static void UpdateHealth(IUnit player, IUnit opponent)
        {
            Console.WriteLine($"{player.Name} Health: : {player.CurrentHealth}");
            Console.WriteLine($"{opponent.Name} Health: {opponent.CurrentHealth}");
        }

        public static string GetFightHeader(IUnit player, IUnit opponent)
        {
            return $"{player.Name}: {player.CurrentHealth}hp \n{opponent.Name}: {opponent.CurrentHealth}hp \n\nChoose your attack!";
        }
    }
}