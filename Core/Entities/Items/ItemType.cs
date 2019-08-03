namespace BattleCity.Core.Entities.Items
{
    internal enum ItemType : int
    {
        // Basic

        Nothing,
        Wall,
        IronWall,
        Forrest,
        Water,
        IronCeil,
        AISpawnPoint,
        PlayerSpawnPoint,
        BaseFlag,
        Projectile,

        // Optional

        Tank,               // adds +1 to player lifes 'T'
        Star,               // adds +1 to player level (bonus fire power) 'S'
        Clock,              // freezes enemy tanks for a period of time 'C'
        Shovel,             // surronds flag with unbreakable wall for a period of time '?'
        Bomb,               // destroys all enemy tanks '*'
        Helmet,             // adds shield to player for a period of time '^'

        // Aditional
        TankPosition
    }
}