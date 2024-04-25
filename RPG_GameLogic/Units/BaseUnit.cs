using RPG_GameLogic.Elements;
using RPG_GameLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_GameLogic.Units
{
    internal class BaseUnit : IUnit
    {
        public virtual ElementType Type { get; set; } = ElementType.None;
        public virtual string Name => "";

        public virtual string Description => "";

        public virtual int MaxHealth => 100;

        public virtual int CurrentHealth { get; set; }
        public virtual bool IsAlive { get; set; } = true;

        public BaseUnit()
        {
            CurrentHealth = MaxHealth;
        }

        public virtual void Attack(IAttack attack, IUnit target)
        {
            attack.Attack(this, target);
        }

        public virtual void Die()
        {
            Console.WriteLine($"{Name} has died.");
            IsAlive = false;
        }

        public virtual void TakeDamage(int damage)
        {
            CurrentHealth -= damage;

            if (CurrentHealth <= 0)
                Die();
        }
    }
}