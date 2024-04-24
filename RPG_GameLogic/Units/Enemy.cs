using RPG_GameLogic.Elements;
using RPG_GameLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_GameLogic.Units
{
    internal class Enemy : BaseUnit
    {
        public override ElementType Type { get; set; } = ElementType.None;
        
        public override string Name => "Enemy";

        public override string Description => "Very Bad";

        public override int MaxHealth => 100;
    }
}
