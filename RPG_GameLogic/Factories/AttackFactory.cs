using RPG_GameLogic.Interfaces;
using RPG_GameLogic.Attacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_GameLogic.Factories
{
    public class AttackFactory : IFactory<IAttack>
    {
        public IAttack Create(string type)
        {
            switch (type.ToLower())
            {
                case "light":
                    return new LightAttack();
                case "heavy":
                    return new HeavyAttack();
                case "ranged":
                    return new RangedAttack();
                default:
                    throw new ArgumentException("Invalid attack type");
            }
        }
    }

    public class RandomAttackFactory
    {
        public IAttack Create()
        {
            Random random = new();
            int attackType = random.Next(0, 3);

            switch (attackType)
            {
                case 0:
                    return new LightAttack();
                case 1:
                    return new HeavyAttack();
                case 2:
                    return new RangedAttack();
                default:
                    throw new ArgumentException("Invalid attack type");
            }
        }
    }
}
