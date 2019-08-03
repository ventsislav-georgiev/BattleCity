namespace BattleCity.Core.Entities.Tanks
{
    internal interface ITank : IEntity
    {
        void Fire();

        int Lives { get; set; }
        int Health { get; set; }
        int MaxProjectiles { get; set; }
        int ProjectileSpeed { get; set; }
        TankRank Type { get; set; }

        event FireEventHandler FireEvent;
    }
}