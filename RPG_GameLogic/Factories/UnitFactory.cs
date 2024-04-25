using RPG_GameLogic.Interfaces;
using RPG_GameLogic.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_GameLogic.Factories
{
    internal class UnitFactory : IFactory<IUnit>
    {
        public IUnit Create(string type)
        {
            switch (type.ToLower())
            {
                case "fireenemy":
                    return new Enemy() {Type = Elements.ElementType.Fire};
                case "waterenemy":
                    return new Enemy() {Type = Elements.ElementType.Water};
                case "earthenemy":
                    return new Enemy() {Type = Elements.ElementType.Earth};
                case "airenemy":
                    return new Enemy() {Type = Elements.ElementType.Air};
                default:
                    throw new ArgumentException("Invalid unit type");
            }
        }
    }
}
