using System;
using System.Collections.Generic;

namespace BattleCity.Core.Entities.Items
{
    internal static class ItemsHolder
    {
        internal class Item
        {
            public char[,] Symbols { get; private set; }
            public ConsoleColor Color { get; private set; }
            public EntityAffection Affection { get; protected set; }

            public Item(char[,] symbols, ConsoleColor color, EntityAffection affection = null)
            {
                this.Symbols = symbols;
                this.Color = color;
                this.Affection = affection;
            }
        }

        public static readonly Dictionary<ItemType, Item> Items = new Dictionary<ItemType, Item>()
        {
            {
                ItemType.Nothing,
                new Item(
                    symbols: new char[,]
                    {
                        {
                            ' '
                        }
                    },
                    color: System.ConsoleColor.Black,
                    affection: new EntityAffection()
                )
            },
            {
                ItemType.Wall,
                new Item(
                    symbols: new char[,]
                    {
                        {
                            '='
                        }
                    },
                    color: System.ConsoleColor.Red,
                    affection: new EntityAffection()
                    .AddAffect(EntityType.Player, new[] { EntityAffectionType.Nothing })
                    .AddAffect(EntityType.AI, new[] { EntityAffectionType.Nothing })
                    .AddAffect(EntityType.Item, new [] { EntityAffectionType.Destroy })
                )
            },
            {
                ItemType.IronWall,
                new Item(
                    symbols: new char[,]
                    {
                        {
                            '#'
                        }
                    },
                    color: System.ConsoleColor.White,
                    affection: new EntityAffection()
                    .AddAffect(EntityType.Player, new[] { EntityAffectionType.Nothing })
                    .AddAffect(EntityType.AI, new[] { EntityAffectionType.Nothing })
                    .AddAffect(EntityType.Item, new [] { EntityAffectionType.Destroy })
                )
            },
            {
                ItemType.Forrest,
                new Item(
                    symbols: new char[,]
                    {
                        {
                            '▓'
                        }
                    },
                    color: System.ConsoleColor.Green,
                    affection: new EntityAffection()
                    .AddAffect(EntityType.Player, new[] { EntityAffectionType.Hide })
                    .AddAffect(EntityType.AI, new[] { EntityAffectionType.Hide })
                    .AddAffect(EntityType.Item, new [] { EntityAffectionType.Hide })
                )
            },
            {
                ItemType.Water,
                new Item(
                    symbols: new char[,]
                    {
                        {
                            '░'
                        }
                    },
                    color: System.ConsoleColor.Blue,
                    affection: new EntityAffection()
                    .AddAffect(EntityType.Player, new[] { EntityAffectionType.Fast })
                    .AddAffect(EntityType.AI, new[] { EntityAffectionType.Fast })
                )
            },
            {
                ItemType.IronCeil,
                new Item(
                    symbols: new char[,]
                    {
                        {
                            '='
                        }
                    },
                    color: System.ConsoleColor.White,
                    affection: new EntityAffection()
                    .AddAffect(EntityType.Player, new[] { EntityAffectionType.Hide })
                    .AddAffect(EntityType.AI, new[] { EntityAffectionType.Hide })
                    .AddAffect(EntityType.Item, new [] { EntityAffectionType.Hide })
                )
            },
            {
                ItemType.AISpawnPoint,
                new Item(
                    symbols: new char[,]
                    {
                        {
                            '@'
                        }
                    },
                    color: System.ConsoleColor.White,
                    affection: new EntityAffection()
                )
            },
            {
                ItemType.PlayerSpawnPoint,
                new Item(
                    symbols: new char[,]
                    {
                        {
                            '@'
                        }
                    },
                    color: System.ConsoleColor.White,
                    affection: new EntityAffection()
                )
            },
            {
                ItemType.BaseFlag,
                new Item(
                    symbols: new char[,]
                    {
                        {
                            'F'
                        }
                    },
                    color: System.ConsoleColor.DarkGray,
                    affection: new EntityAffection()
                    .AddAffect(EntityType.Player, new[] { EntityAffectionType.Nothing })
                    .AddAffect(EntityType.AI, new[] { EntityAffectionType.Nothing })
                    .AddAffect(EntityType.Item, new [] { EntityAffectionType.Destroy })
                )
            },
            {
                ItemType.Tank,
                new Item(
                    symbols: new char[,]
                    {
                        {
                            'T'
                        }
                    },
                    color: System.ConsoleColor.Red,
                    affection: new EntityAffection()
                    .AddAffect(EntityType.Player, new[] { EntityAffectionType.Nothing })
                    .AddAffect(EntityType.AI, new[] { EntityAffectionType.Nothing })
                    .AddAffect(EntityType.Item, new [] { EntityAffectionType.Destroy })
                )
            },
            {
                ItemType.Star,
                new Item(
                    symbols: new char[,]
                    {
                        {
                            'S'
                        }
                    },
                    color: System.ConsoleColor.Yellow,
                    affection: new EntityAffection()
                    .AddAffect(EntityType.Player, new[] { EntityAffectionType.Rank })
                    .AddAffect(EntityType.AI, new[] { EntityAffectionType.Rank })
                    .AddAffect(EntityType.Item, new [] { EntityAffectionType.Destroy })
                )
            },
            {
                ItemType.Clock,
                new Item(
                    symbols: new char[,]
                    {
                        {
                            'C'
                        }
                    },
                    color: System.ConsoleColor.DarkGray,
                    affection: new EntityAffection()
                    .AddAffect(EntityType.Player, new[] { EntityAffectionType.Fast })
                    .AddAffect(EntityType.AI, new[] { EntityAffectionType.Fast })
                    .AddAffect(EntityType.Item, new [] { EntityAffectionType.Destroy })
                )
            },
            {
                ItemType.Shovel,
                new Item(
                    symbols: new char[,]
                    {
                        {
                            '?'
                        }
                    },
                    color: System.ConsoleColor.White,
                    affection: new EntityAffection()
                    .AddAffect(EntityType.Player, new[] { EntityAffectionType.Safe })
                    .AddAffect(EntityType.Item, new [] { EntityAffectionType.Destroy })
                )
            },
            {
                ItemType.Bomb,
                new Item(
                    symbols: new char[,]
                    {
                        {
                            'B'
                        }
                    },
                    color: System.ConsoleColor.Red,
                    affection: new EntityAffection()
                    .AddAffect(EntityType.Player, new[] { EntityAffectionType.DestroyEnemies })
                    .AddAffect(EntityType.Item, new [] { EntityAffectionType.Destroy })
                )
            },
            {
                ItemType.Helmet,
                new Item(
                    symbols: new char[,]
                    {
                        {
                            '^'
                        }
                    },
                    color: System.ConsoleColor.Red,
                    affection: new EntityAffection()
                    .AddAffect(EntityType.Player, new[] { EntityAffectionType.Shield })
                    .AddAffect(EntityType.AI, new[] { EntityAffectionType.Shield })
                    .AddAffect(EntityType.Item, new [] { EntityAffectionType.Destroy })
                )
            },
            {
                ItemType.Projectile,
                new Item(
                    symbols: new char[,]
                    {
                        {
                            'o'
                        }
                    },
                    color: System.ConsoleColor.Red,
                    affection: new EntityAffection()
                    .AddAffect(EntityType.Player, new[] { EntityAffectionType.Destroy })
                    .AddAffect(EntityType.AI, new[] { EntityAffectionType.Destroy })
                    .AddAffect(EntityType.Item, new[] { EntityAffectionType.Destroy })
                )
            },
            {
                ItemType.TankPosition,
                new Item(
                    symbols: new char[,]
                    {
                        {
                            ' '
                        }
                    },
                    color: System.ConsoleColor.Black,
                    affection: new EntityAffection()
                    .AddAffect(EntityType.Player, new[] { EntityAffectionType.Nothing })
                    .AddAffect(EntityType.AI, new[] { EntityAffectionType.Nothing })
                    .AddAffect(EntityType.Item, new [] { EntityAffectionType.Destroy })
                )
            },
        };
    }
}