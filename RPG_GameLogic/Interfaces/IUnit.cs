using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_GameLogic.Elements;
using RPG_GameLogic.Units;

namespace RPG_GameLogic.Interfaces
{
    public interface IUnit
    {
        ElementType Type { get; set; }
        string Name { get; }
        string Description { get; }
        int MaxHealth { get; }
        int CurrentHealth { get; set; }
        bool IsAlive { get; set; }
        void TakeDamage(int damage);
        void Attack(IAttack attack, IUnit unit);
        void Die();
    }
}
