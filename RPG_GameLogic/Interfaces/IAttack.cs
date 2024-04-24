using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_GameLogic.Interfaces
{
    public interface IAttack
    {
        float BaseDamage { get; }
        float CritChance { get; }
        float CritMultiplier { get; }

        void Attack(IUnit source, IUnit target);
        float CalculateDamage(float multiplier);
    }
}
