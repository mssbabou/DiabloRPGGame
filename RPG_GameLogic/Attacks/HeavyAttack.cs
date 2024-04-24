namespace RPG_GameLogic.Attacks
{
    internal class HeavyAttack : BaseAttack
    {
        public override float BaseDamage { get; } = 10;
        public override float CritChance { get; } = 0.50f;
        public override float CritMultiplier { get; } = 3.0f;
    }
}