using System;
using System.Collections.Generic;

namespace BattleCity.Core.Entities
{
    internal class EntityAffection
    {
        private static readonly object _locker = new object();
        public EntityType EntityType { get; set; }

        public Dictionary<EntityAffectionType, Func<IEntity, bool>> AffectActions { get; set; }
        public Dictionary<EntityType, IList<EntityAffectionType>> AffectedTypes { get; set; }

        public EntityAffection(EntityType? entityType = null)
        {
            if (entityType.HasValue)
            {
                this.EntityType = entityType.Value;
            }
            this.AffectActions = new Dictionary<EntityAffectionType, Func<IEntity, bool>>();
            this.AffectedTypes = new Dictionary<EntityType, IList<EntityAffectionType>>();
        }

        public EntityAffection AddAction(EntityAffectionType affectionType, Func<IEntity, bool> onAffection)
        {
            if (!this.AffectActions.ContainsKey(affectionType))
            {
                this.AffectActions.Add(affectionType, onAffection);
            }
            return this;
        }

        public EntityAffection AddAffect(EntityType entityType, IList<EntityAffectionType> entityAffections)
        {
            this.AffectedTypes.Add(entityType, entityAffections);
            return this;
        }
    }
}