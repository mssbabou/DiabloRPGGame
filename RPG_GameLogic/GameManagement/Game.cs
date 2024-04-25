using RPG_GameLogic.Attacks;
using RPG_GameLogic.Factories;
using RPG_GameLogic.Interfaces;
using RPG_GameLogic.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_GameLogic.GameManagement
{
    public class Game
    {
        private IUnit player;
        private IUnit opponent;

        private UnitFactory unitFactory;
        private AttackFactory attackFactory;
        private RandomAttackFactory randomAttackFactory;
        
        public Game()
        {
            unitFactory = new UnitFactory();
            attackFactory = new AttackFactory();
            randomAttackFactory = new RandomAttackFactory();

            GameConsole.Initialize();

            player = new Player();
        }

        public void Start()
        {
            Console.Clear();
            string opponentString = GameConsole.SelectOptions("Choose your opponent!", ["FireEnemy", "WaterEnemy", "EarthEnemy", "AirEnemy"]);
            opponent = unitFactory.Create(opponentString);

            while (player.IsAlive && opponent.IsAlive)
            {
                Console.Clear();
                string header =  $"{player.Name}: {player.CurrentHealth}hp \n{opponent.Name}: {opponent.CurrentHealth}hp \n\nChoose your attack!";
                string playerAttackString = GameConsole.SelectOptions(header, ["Light", "Heavy", "Ranged"]);
                IAttack playerAttack = attackFactory.Create(playerAttackString);
                player.Attack(playerAttack, opponent);

                if(!opponent.IsAlive) break;

                Thread.Sleep(1000);

                IAttack enemyAttack = randomAttackFactory.Create();
                opponent.Attack(enemyAttack, player);

                if(!player.IsAlive) break;

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

            if (player.IsAlive)
                Console.WriteLine(player.Name + " wins!");
            else
                Console.WriteLine(opponent.Name + " wins!");
        }
    }
}
