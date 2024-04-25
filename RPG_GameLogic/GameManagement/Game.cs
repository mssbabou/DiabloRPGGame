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
            Console.WriteLine("Choose your opponent!");
            opponent = GameConsole.GetFactoryType(unitFactory);

            Console.Clear();
            Console.WriteLine(player.Name + " vs " + opponent.Name);
            while (player.IsAlive && opponent.IsAlive)
            {
                Console.WriteLine("Choose your attack!");
                IAttack playerAttack = GameConsole.GetFactoryType(attackFactory);
                player.Attack(playerAttack, opponent);

                if(!opponent.IsAlive) break;

                Thread.Sleep(1000);

                IAttack enemyAttack = randomAttackFactory.Create();
                opponent.Attack(enemyAttack, player);

                if(!player.IsAlive) break;

                Thread.Sleep(1000);
            }

            if (player.IsAlive)
                Console.WriteLine(player.Name + " wins!");
            else
                Console.WriteLine(opponent.Name + " wins!");
        }
    }
}
