using System;
using System.Collections.Generic;
using BattleCity.Core.CommonTypes;

namespace BattleCity.Core.Entities
{
    internal interface IEntity
    {
        event EventHandler MoveEvent;

        event EventHandler DestroyEvent;

        int ID { get; set; }
        EntityType EntityType { get; }
        char[,] Symbols { get; }
        Point Position { get; set; }
        ConsoleColor Color { get; }
        Direction Direction { get; set; }

        bool IsDestroyed { get; set; }
        bool IsHidden { get; set; }
        bool CanBeDestroyed { get; }

        Dictionary<EntityAffectionType, Func<IEntity, bool>> AffectActions { get; set; }
        Dictionary<EntityType, IList<EntityAffectionType>> AffectedTypes { get; set; }

        void Write();

        void Clear();

        void Move(Direction direction);

        Point GetPosition(Direction direction);

        Point GetDirectionPosition();

        void Move(ConsoleKey key);

        bool OnDestroy();

        IEntity AddAction(EntityAffectionType affectionType, Func<IEntity, bool> onAffection);

        bool ApplyAffection(IEntity entity);

        IEntity AddAffection(EntityType entityType, IList<EntityAffectionType> entityAffections);

        Point[] GetPositionOnLayout();
    }
}