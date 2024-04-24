namespace RPG_GameLogic.Attacks
{
    internal class RangedAttack : BaseAttack
    {
        public override float BaseDamage { get; } = 4;
        public override float CritChance { get; } = 0.30f;
        public override float CritMultiplier { get; } = 10f;
    }
}