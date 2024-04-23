using RPG_GameLogic.GameManagement;

namespace RPG_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new();
            game.Start();
        }
    }
}