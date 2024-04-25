namespace RPG_GameLogic.Elements
{
    public static class Element
    {
        public static float BadAttackMultiplier { get; } = 0.8f;
        public static float GoodAttackMultiplier { get; } = 1.2f;

        public static float GetMultiplier(ElementType attacker, ElementType defender)
        {
            if (attacker == ElementType.Fire && defender == ElementType.Water)
            {
                return BadAttackMultiplier;
            }
            else if (attacker == ElementType.Water && defender == ElementType.Fire)
            {
                return GoodAttackMultiplier;
            }
            else if (attacker == ElementType.Earth && defender == ElementType.Air)
            {
                return BadAttackMultiplier;
            }
            else if (attacker == ElementType.Air && defender == ElementType.Earth)
            {
                return GoodAttackMultiplier;
            }
            else
            {
                return 1.0f;
            }
        }
    }

    public enum ElementType
    {
        Fire,
        Water,
        Earth,
        Air,
        None
    }
}