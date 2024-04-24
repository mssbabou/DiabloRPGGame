using RPG_GameLogic.Elements;
using RPG_GameLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_GameLogic.Units
{
    internal class Player : BaseUnit
    {
        public override ElementType Type => ElementType.Water;
        public override string Name => "Player";

        public override string Description => "Very Good";

        public override int MaxHealth => 100;
    }
}
