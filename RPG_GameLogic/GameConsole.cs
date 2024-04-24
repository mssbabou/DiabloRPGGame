using RPG_GameLogic.Factories;
using RPG_GameLogic.Interfaces;

namespace RPG_GameLogic.GameManagement
{
    public class GameConsole
    {
        public static void Initialize()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the game!");
        }

        public static T GetFactoryInput<T>(IFactory<T> factory)
        {
            while(true)
            {
                Console.Write($"Enter: ");
                string? type = Console.ReadLine();
                try
                {
                    return factory.Create(type);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("Invalid type");
                }
            }
        }
    }   
}