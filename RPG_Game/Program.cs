using RPG_GameLogic.GameManagement;

namespace RPG_Game
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Game game = new();
            await game.Start();
        }
    }
}