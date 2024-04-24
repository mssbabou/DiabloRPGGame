using RPG_GameLogic.Elements;
using RPG_GameLogic.Interfaces;


namespace RPG_GameLogic.Attacks
{
    internal class BaseAttack : IAttack
    {
        public virtual float BaseDamage { get; } = 15;
        public virtual float CritChance { get; } = 0.20f;
        public virtual float CritMultiplier { get; } = 1.35f;
        private static readonly Random rnd = new();

        public virtual void Attack(IUnit source, IUnit target)
        {
            int damage = (int)CalculateDamage(Element.GetMultiplier(source.Type, target.Type));
            target.TakeDamage(damage);
            Console.WriteLine($"{source.Name} attacked {target.Name} for {damage} damage.");
        }

        public virtual float CalculateDamage(float multiplier = 0)
        {
            bool crit = rnd.NextSingle() < CritChance;
            return crit ? BaseDamage * CritMultiplier * multiplier: BaseDamage * multiplier;
        }
    }
}