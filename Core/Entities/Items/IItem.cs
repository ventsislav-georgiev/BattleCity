namespace BattleCity.Core.Entities.Items
{
    internal interface IItem : IEntity
    {
        ItemType Type { get; }
    }
}