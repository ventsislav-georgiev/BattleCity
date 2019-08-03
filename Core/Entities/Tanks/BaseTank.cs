using System;
using System.Threading;
using System.Threading.Tasks;
using BattleCity.Core.Entities.Items;
using BattleCity.Core.ScreenText;

namespace BattleCity.Core.Entities.Tanks
{
    internal delegate bool FireEventHandler(Item item);

    internal abstract class BaseTank<TTank> : BaseEntity<TTank>
        where TTank : ITank
    {
        private CancellationToken cancellationToken = Game.CancellationTokenSource.Token;

        public event EventHandler LifeUp;

        public event FireEventHandler FireEvent;

        public override bool IsHidden { get => false; set {} }
        public virtual bool OnLifeUp()
        {
            this.InvokeEvent(this.LifeUp);
            return true;
        }

        public virtual bool OnFire(Item projectile)
        {
            if (this.FireEvent != null)
            {
                return this.FireEvent(projectile);
            }
            return true;
        }

        public override bool OnDestroy()
        {
            this.Lives--;
            if (this is Player)
            {
                if (this.Lives == 0)
                {
                    GameOver.EndScreen();
                    return true;
                }
                else
                {
                    this.IsDestroyed = false;
                    this.Direction = Entities.Direction.Up;
                }
            }
            else if (this is AI)
            {
                if (this.Lives == 0)
                {
                    (this as AI).OnAIDownEvent();
                }
                else
                {
                    this.IsDestroyed = false;
                }
            }
            return base.OnDestroy();
        }

        protected static readonly char[,] TankRank1 = new char[,]
        {
            {
                 ' ', '*', '*'
            },
            {
                '*', '*', '*'
            },
            {
                ' ', '*', '*'
            }
        };

        protected static readonly char[,] TankRank2 = new char[,]
        {
            {
                 ' ', '¤', '¤'
            },
            {
                '¤', '¤', '¤'
            },
            {
                ' ', '¤', '¤'
            }
        };

        protected static readonly char[,] TankRank3 = new char[,]
        {
            {
                 ' ', '≡', '≡'
            },
            {
                '≡', '≡', '≡'
            },
            {
                ' ', '≡', '≡'
            }
        };

        protected static readonly char[,] TankRank4 = new char[,]
        {
            {
                 ' ', '\u2588', '\u2588'
            },
            {
                '\u2588', '\u2588', '\u2588'
            },
            {
                ' ', '\u2588', '\u2588'
            }
        };

        public TankRank Type { get; set; }
        public int Lives { get; set; }
        public int Health { get; set; }
        public int MaxProjectiles { get; set; }
        public int ProjectileSpeed { get; set; }
        public bool CanLevelUp { get; private set; }

        public TankRank Rank { get; set; }

        public BaseTank(ConsoleColor color, EntityAffection affection, TankRank rank)
            : base(TankRank1, color, affection)
        {
            this.Rank = rank;
            switch (rank)
            {
                case TankRank.Rank1:
                    this.Symbols = TankRank1;
                    this.Lives = 1;
                    break;

                case TankRank.Rank2:
                    this.Symbols = TankRank2;
                    this.Lives = 2;
                    break;

                case TankRank.Rank3:
                    this.Symbols = TankRank3;
                    this.Lives = 3;
                    break;

                case TankRank.Rank4:
                    this.Symbols = TankRank4;
                    this.Lives = 4;
                    break;
            }

            this.Health = 1;
            this.MaxProjectiles = 1;
            this.ProjectileSpeed = 1;

            this.AddAffection(EntityType.Item, new[] { EntityAffectionType.Destroy })
                .AddAction(EntityAffectionType.Life, (entity) =>
                {
                    this.Lives++;
                    return true;
                })
                .AddAction(EntityAffectionType.Hide, (entity) =>
                {
                    this.IsHidden = true;
                    return true;
                });
        }

        public void Fire()
        {
            var position = this.GetDirectionPosition();
            Task.Run(() =>
            {
                var projectile = new Item(ItemType.Projectile, position);
                projectile.IsHidden = true;
                //switch (this.Direction)
                //{
                //	case Direction.Up:
                //		position.Y -= 1;
                //		break;

                //	case Direction.Left:
                //		position.X -= 1;
                //		break;

                //	case Direction.Down:
                //		position.Y += 1;
                //		break;

                //	case Direction.Right:
                //		position.X += 1;
                //		break;
                //}

                projectile.Position = position;
                projectile.Direction = this.Direction;

                if (OnFire(projectile))
                {
                    const int period = 50;
                    Task.Run(() =>
                    {
                        while (!cancellationToken.IsCancellationRequested)
                        {
                            if (!projectile.IsDestroyed)
                            {
                                projectile.Move(projectile.Direction);
                            }
                            else
                            {
                                break;
                            }
                            Thread.Sleep(period);
                        }
                    });
                }
            });
        }
    }
}