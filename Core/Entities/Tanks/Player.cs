using System;

namespace BattleCity.Core.Entities.Tanks
{
    internal class Player : BaseTank<Player>, ITank
    {
        public EntityType EntityType
        {
            get
            {
                return Entities.EntityType.Player;
            }
        }

        public Player(TankRank rank)
            : base(ConsoleColor.Yellow, new EntityAffection(EntityType.Player), rank)
        {
            this.Direction = Direction.Up;
            this.Lives = 3;
        }
    }
}