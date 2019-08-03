using System;
using System.Collections.Generic;
using BattleCity.Core.Entities.Items;

namespace BattleCity.Core.Entities
{
    internal class BaseEntityAffection<TEntity> : ConsoleEntity<TEntity>
        where TEntity : IEntity
    {
        private static readonly object _locker = new object();

        public Dictionary<EntityAffectionType, Func<IEntity, bool>> AffectActions { get; set; }
        public Dictionary<EntityType, IList<EntityAffectionType>> AffectedTypes { get; set; }

        public BaseEntityAffection()
        {
            this.AffectActions = new Dictionary<EntityAffectionType, Func<IEntity, bool>>();
            this.AffectedTypes = new Dictionary<EntityType, IList<EntityAffectionType>>();
        }

        public IEntity AddAction(EntityAffectionType affectionType, Func<IEntity, bool> onAffection)
        {
            if (!this.AffectActions.ContainsKey(affectionType))
            {
                this.AffectActions.Add(affectionType, onAffection);
            }
            return this as IEntity;
        }

        public IEntity AddAffection(EntityType entityType, IList<EntityAffectionType> entityAffections)
        {
            this.AffectedTypes.Add(entityType, entityAffections);
            return this as IEntity;
        }

        public bool ApplyAffection(IEntity entity)
        {
            lock (_locker)
            {
                var _this = this as IEntity;

                bool executeAction = true;
                IList<EntityAffectionType> entityAffections = null;
                if (entity.AffectedTypes.TryGetValue(_this.EntityType, out entityAffections))
                {
                    foreach (var affection in entityAffections)
                    {
                        Func<IEntity, bool> action = null;
                        if (this.AffectActions.TryGetValue(affection, out action))
                        {
                            bool result = action(entity);
                            if (executeAction)
                            {
                                executeAction = result;
                            }
                        }
                    }
                }

                // Check if it is item that doesn't have affection to Tank
                if (_this.EntityType != EntityType.Item && entity.EntityType == Entities.EntityType.Item)
                {
                    switch ((entity as Item).Type)
                    {
                        case ItemType.Nothing:
                        case ItemType.Wall:
                        case ItemType.IronWall:
                        case ItemType.Forrest:
                        case ItemType.Water:
                        case ItemType.IronCeil:
                        case ItemType.AISpawnPoint:
                        case ItemType.PlayerSpawnPoint:
                        case ItemType.BaseFlag:
                        case ItemType.TankPosition:
                            return executeAction;
                    }
                }

                if (this.AffectedTypes.TryGetValue(entity.EntityType, out entityAffections))
                {
                    foreach (var affection in entityAffections)
                    {
                        Func<IEntity, bool> action = null;
                        if (entity.AffectActions.TryGetValue(affection, out action))
                        {
                            action(_this);
                        }
                    }
                    return true;
                }
                return executeAction;
            }
        }
    }
}