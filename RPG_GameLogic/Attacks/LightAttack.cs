namespace RPG_GameLogic.Attacks
{
    internal class LightAttack : BaseAttack
    {
        public override float BaseDamage { get; } = 15;
        public override float CritChance { get; } = 0.20f;
        public override float CritMultiplier { get; } = 1.35f;
    }
}
