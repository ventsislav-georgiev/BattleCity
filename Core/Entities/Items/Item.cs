using BattleCity.Core.CommonTypes;

namespace BattleCity.Core.Entities.Items
{
    internal class Item : BaseEntity<Item>, IItem
    {
        public int ID { get; set; }

        private ItemType _itemType;

        public EntityType EntityType
        {
            get
            {
                return Entities.EntityType.Item;
            }
        }

        public ItemType Type
        {
            get
            {
                return this._itemType;
            }
        }

        public Item(ItemType itemType, Point position)
            : base(ItemsHolder.Items[itemType].Symbols, ItemsHolder.Items[itemType].Color, GetAffection(itemType))
        {
            this._itemType = itemType;
            this.Position = new Point(position);
            this.CanBeDestroyed = this.CanEntityBeDestroyed();
        }

        public override void Write()
        {
            if (this.Type != ItemType.TankPosition)
            {
                base.Write();
            }
        }

        public bool CanEntityBeDestroyed()
        {
            switch ((this as Item).Type)
            {
                case ItemType.Water:
                case ItemType.IronWall:
                case ItemType.IronCeil:
                case ItemType.Forrest:
                case ItemType.AISpawnPoint:
                case ItemType.PlayerSpawnPoint:
                    {
                        return false;
                    }
                default:
                    return true;
            }
        }

        private static EntityAffection GetAffection(ItemType itemType)
        {
            var affection = ItemsHolder.Items[itemType].Affection;
            affection.EntityType = EntityType.Item;
            return affection;
        }
    }
}