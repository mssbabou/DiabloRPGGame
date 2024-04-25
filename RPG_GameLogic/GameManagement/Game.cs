using System;
using System.Threading.Tasks;
using RPG_GameLogic.Interfaces;
using RPG_GameLogic.Factories;
using RPG_GameLogic.Units;
using System.Threading;

namespace RPG_GameLogic.GameManagement
{
    public class Game
    {
        private IUnit player;
        private IUnit opponent;

        private IFactory<IUnit> unitFactory;
        private IFactory<IAttack> attackFactory;
        private RandomAttackFactory randomAttackFactory;

        private readonly object lockObject = new();

        public Game()
        {
            unitFactory = new UnitFactory();
            attackFactory = new AttackFactory();
            randomAttackFactory = new RandomAttackFactory();

            GameConsole.Initialize();

            player = new Player();
        }

        public async Task Start()
        {
            Console.Clear();
            string opponentString = GameConsole.SelectOptions("Choose your opponent!", ["FireEnemy", "WaterEnemy", "EarthEnemy", "AirEnemy"]);
            opponent = unitFactory.Create(opponentString);

            // Start player and opponent tasks
            var playerTask = Task.Run(() => PlayerTurn());
            var opponentTask = Task.Run(() => OpponentTurn());

            await Task.WhenAny(playerTask, opponentTask);

            if (player.IsAlive)
                Console.WriteLine(player.Name + " wins!");
            else
                Console.WriteLine(opponent.Name + " wins!");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private void PlayerTurn()
        {
            while (true)
            {
                lock (lockObject)
                {
                    if (!player.IsAlive || !opponent.IsAlive) break;

                    string playerAttackString = GameConsole.SelectOptions(GameConsole.GetFightHeader(player, opponent), ["Light", "Heavy", "Ranged"]);
                    IAttack playerAttack = attackFactory.Create(playerAttackString);
                    player.Attack(playerAttack, opponent);
                }

                Thread.Sleep(2000);
            }
        }

        private void OpponentTurn()
        {
            while (true)
            {
                lock (lockObject)
                {
                    if (!player.IsAlive || !opponent.IsAlive) break;

                    IAttack enemyAttack = randomAttackFactory.Create();
                    opponent.Attack(enemyAttack, player);
                }

                Thread.Sleep(2000);
            }
        }
    }
}