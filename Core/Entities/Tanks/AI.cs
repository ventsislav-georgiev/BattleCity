using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BattleCity.Core.CommonTypes;

namespace BattleCity.Core.Entities.Tanks
{
    internal class AI : BaseTank<AI>, ITank
    {
        private CancellationToken cancellationToken = Game.CancellationTokenSource.Token;

        public delegate Queue<Direction> RequestPath(object sender, Point position, bool requestPathToFlag);

        public delegate void AIDown();

        public event RequestPath RequestPathEvent;

        public event AIDown AIDownEvent;

        public void OnRequestPathEvent()
        {
            if (!cancellationToken.IsCancellationRequested && RequestPathEvent != null && !this.IsDestroyed)
            {
                var entity = this as IEntity;
                var pathToPlayer = RequestPathEvent(entity, this.Position, false);
                var pathToFlag = RequestPathEvent(entity, this.Position, true);

                //if (pathToFlag.Count > pathToPlayer.Count)
                //{
                //    this.FollowOrders(pathToPlayer);
                //}
                //else
                //{
                //    this.FollowOrders(pathToFlag);
                //}
                this.FollowOrders(pathToPlayer);
            }
        }

        public void OnAIDownEvent()
        {
            if (this.AIDownEvent != null)
            {
                this.AIDownEvent();
            }
        }

        public EntityType EntityType
        {
            get
            {
                return Entities.EntityType.AI;
            }
        }

        public AI(TankRank rank)
            : base(ConsoleColor.DarkGray, new EntityAffection(EntityType.AI), rank)
        {
            this.Direction = Direction.Down;
        }

        private void FollowOrders(Queue<Direction> orders)
        {
            int counter = 0;
            Point previousPosition = this.Position;

            Task.Run(() =>
            {
                while (!cancellationToken.IsCancellationRequested && Game.IsGameLevelRunning && orders.Any() && !this.IsDestroyed)
                {
                    Direction currentOrder = orders.Dequeue();
                    if (orders.Any())
                    {
                        if (GetPosition(orders.Peek()) == this.Position)
                        {
                            orders.Dequeue();
                        }
                    }
                    if (orders.Any())
                    {
                        if (orders.Peek() != currentOrder)
                        {
                            this.Move(currentOrder);
                        }
                    }

                    this.Move(currentOrder);
                    if (counter % 10 == 0 && counter != 0)
                    {
                        this.Fire();
                    }
                    counter++;
                    Thread.Sleep(100);
                }
                this.OnRequestPathEvent();
            });
        }
    }
}