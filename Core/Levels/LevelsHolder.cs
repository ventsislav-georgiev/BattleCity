using System.Collections.Generic;
using BattleCity.Core.Entities.Items;
using BattleCity.Core.Entities.Tanks;

namespace BattleCity.Core.Levels
{
    internal static class LevelsHolder
    {
        internal class Level
        {
            public int[,] Layout { get; private set; }
            public Dictionary<TankRank, int> TankType { get; private set; }

            public Level(int[,] layout, Dictionary<TankRank, int> tankType)
            {
                this.Layout = layout;
                this.TankType = tankType;
            }
        }

        public static readonly Dictionary<LevelType, Level> Levels = new Dictionary<LevelType, Level>();

        static LevelsHolder()
        {
            var n = (int)ItemType.Nothing;
            var x = (int)ItemType.Wall;
            var y = (int)ItemType.IronWall;
            var z = (int)ItemType.Forrest;
            var u = (int)ItemType.Water;
            var q = (int)ItemType.IronCeil;
            var r = (int)ItemType.AISpawnPoint;
            var s = (int)ItemType.PlayerSpawnPoint;
            var t = (int)ItemType.BaseFlag;

            Levels.Add(LevelType._01,
                new Level(new int[,]{
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, r },
                    { 0, x, 0, x, 0, x, 0, x, 0, x, 0, x, 0 },
                    { 0, x, 0, x, 0, x, 0, x, 0, x, 0, x, 0 },
                    { 0, x, 0, x, 0, x, y, x, 0, x, 0, x, 0 },
                    { 0, x, 0, x, 0, x, 0, x, 0, x, 0, x, 0 },
                    { 0, x, 0, x, 0, 0, 0, 0, 0, x, 0, x, 0 },
                    { x, 0, 0, 0, 0, x, 0, x, 0, 0, 0, 0, x },
                    { y, 0, x, x, 0, 0, 0, 0, 0, x, x, 0, y },
                    { 0, 0, 0, 0, 0, x, x, x, 0, 0, 0, 0, 0 },
                    { 0, x, 0, x, 0, x, 0, x, 0, x, 0, x, 0 },
                    { 0, x, 0, x, 0, 0, 0, 0, 0, x, 0, x, 0 },
                    { 0, x, 0, x, 0, x, x, x, 0, x, 0, x, 0 },
                    { 0, 0, 0, 0, s, x, t, x, 0, 0, 0, 0, 0 }
                }, new Dictionary<TankRank, int>() {
                    { TankRank.Rank1, 4 },
                    { TankRank.Rank2, 0 },
                    { TankRank.Rank3, 0 },
                    { TankRank.Rank4, 0 },
                }));
            Levels.Add(LevelType._02,
                new Level(new int[,]{
                    { 0, 0, 0, y, 0, 0, 0, y, 0, 0, 0, 0, r },
                    { 0, x, 0, y, 0, 0, 0, x, 0, x, 0, x, 0 },
                    { 0, x, 0, 0, 0, 0, x, x, 0, x, y, x, 0 },
                    { 0, 0, 0, x, 0, 0, 0, 0, 0, y, 0, 0, 0 },
                    { z, 0, 0, x, 0, 0, y, 0, 0, x, z, x, y },
                    { z, z, 0, 0, 0, x, 0, 0, y, x, z, 0, 0 },
                    { 0, x, x, x, z, z, z, y, 0, 0, z, x, 0 },
                    { 0, 0, x, y, z, x, 0, x, 0, x, 0, x, 0 },
                    { y, x, 0, y, 0, x, 0, x, 0, 0, 0, x, 0 },
                    { 0, x, 0, x, 0, x, x, x, 0, x, y, x, 0 },
                    { 0, x, 0, x, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, x, 0, 0, 0, x, x, x, 0, x, 0, x, 0 },
                    { 0, x, 0, x, s, x, t, x, 0, x, x, x, 0 }
                }, new Dictionary<TankRank, int>() {
                    { TankRank.Rank1, 4 },
                    { TankRank.Rank2, 4 },
                    { TankRank.Rank3, 0 },
                    { TankRank.Rank4, 0 },
                }));
            Levels.Add(LevelType._03,
                new Level(new int[,]{
                    { 0, 0, 0, 0, x, 0, 0, 0, x, 0, 0, 0, r },
                    { 0, z, z, z, x, 0, 0, 0, 0, 0, y, y, y },
                    { x, z, z, z, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { z, z, z, z, 0, 0, 0, x, 0, x, x, x, 0 },
                    { z, z, z, z, x, x, x, x, 0, x, 0, x, 0 },
                    { z, z, z, z, 0, 0, x, 0, 0, 0, 0, x, 0 },
                    { 0, z, 0, 0, 0, 0, y, y, y, 0, 0, z, 0 },
                    { 0, x, 0, x, 0, 0, 0, 0, 0, z, z, z, z },
                    { x, x, 0, x, x, x, x, x, x, z, z, z, z },
                    { 0, 0, 0, 0, 0, x, 0, 0, 0, z, z, z, z },
                    { x, 0, 0, y, 0, 0, 0, 0, x, z, z, z, 0 },
                    { x, x, 0, y, 0, x, x, x, 0, z, z, z, 0 },
                    { y, x, x, 0, s, x, t, x, 0, x, 0, 0, 0 }
                }, new Dictionary<TankRank, int>() {
                    { TankRank.Rank1, 4 },
                    { TankRank.Rank2, 6 },
                    { TankRank.Rank3, 0 },
                    { TankRank.Rank4, 0 },
                }));
            Levels.Add(LevelType._04,
                new Level(new int[,]{
                    { 0, z, z, 0, 0, 0, 0, 0, 0, 0, 0, z, r },
                    { z, z, 0, 0, x, x, x, x, x, 0, 0, 0, z },
                    { z, 0, 0, x, x, x, x, x, x, x, x, 0, y },
                    { y, 0, 0, x, x, x, x, x, x, x, x, x, 0 },
                    { 0, 0, x, x, 0, 0, 0, 0, x, x, 0, x, 0 },
                    { u, 0, x, 0, y, 0, y, 0, x, x, 0, 0, 0 },
                    { 0, 0, x, 0, 0, 0, 0, 0, x, x, 0, u, u },
                    { 0, x, x, x, x, x, x, x, x, x, 0, 0, 0 },
                    { 0, x, x, x, x, x, x, x, x, x, x, 0, 0 },
                    { 0, 0, 0, x, x, x, x, x, x, 0, 0, 0, 0 },
                    { 0, x, 0, 0, 0, x, 0, 0, 0, x, x, 0, z },
                    { z, 0, x, x, 0, x, x, x, x, x, 0, z, z },
                    { y, z, 0, 0, s, x, t, x, 0, 0, z, z, y }
                }, new Dictionary<TankRank, int>() {
                    { TankRank.Rank1, 2 },
                    { TankRank.Rank2, 5 },
                    { TankRank.Rank3, 1 },
                    { TankRank.Rank4, 0 }
                }));
            Levels.Add(LevelType._05,
                new Level(new int[,]{
                    { 0, 0, 0, 0, x, x, 0, 0, 0, 0, 0, 0, r },
                    { y, 0, x, 0, x, 0, 0, 0, y, y, y, 0, 0 },
                    { y, 0, x, 0, 0, 0, x, 0, 0, 0, 0, 0, 0 },
                    { x, 0, x, x, x, 0, x, x, 0, u, u, 0, u },
                    { x, 0, 0, 0, x, 0, 0, 0, 0, u, 0, 0, 0 },
                    { 0, 0, x, 0, u, u, 0, u, u, u, 0, x, x },
                    { x, x, 0, 0, u, x, 0, x, x, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, u, 0, 0, 0, 0, 0, y, y, 0 },
                    { u, u, u, 0, u, 0, y, 0, x, 0, y, 0, 0 },
                    { 0, 0, 0, x, x, 0, 0, 0, 0, 0, y, x, x },
                    { 0, 0, 0, 0, x, x, x, x, x, x, 0, 0, 0 },
                    { x, x, x, 0, 0, x, x, x, 0, x, x, 0, 0 },
                    { x, 0, 0, 0, s, x, t, x, 0, 0, 0, 0, 0 }
                }, new Dictionary<TankRank, int>() {
                    { TankRank.Rank1, 8 },
                    { TankRank.Rank2, 5 },
                    { TankRank.Rank3, 5 },
                    { TankRank.Rank4, 0 }
                }));
            Levels.Add(LevelType._06,
                new Level(new int[,]{
                    { 0, 0, 0, 0, 0, x, 0, x, z, z, 0, 0, r },
                    { 0, x, y, 0, x, 0, 0, 0, x, z, x, x, z },
                    { 0, x, y, 0, x, 0, x, 0, x, z, x, x, z },
                    { 0, x, 0, 0, x, 0, y, 0, x, z, 0, x, z },
                    { 0, 0, 0, x, y, 0, x, 0, x, y, 0, z, z },
                    { x, x, 0, 0, 0, z, x, z, 0, 0, 0, x, x },
                    { 0, 0, 0, 0, x, z, z, z, x, 0, 0, 0, 0 },
                    { y, x, x, 0, 0, z, z, z, 0, x, x, x, y },
                    { y, y, y, 0, x, 0, z, 0, x, 0, y, y, y },
                    { 0, x, 0, 0, x, 0, 0, 0, x, 0, 0, 0, 0 },
                    { 0, x, x, 0, 0, x, 0, x, 0, 0, x, x, z },
                    { 0, 0, x, 0, 0, x, x, x, 0, 0, z, z, z },
                    { 0, 0, x, 0, s, x, t, x, 0, 0, x, z, z }
                }, new Dictionary<TankRank, int>() {
                    { TankRank.Rank1, 9 },
                    { TankRank.Rank2, 2 },
                    { TankRank.Rank3, 7 },
                    { TankRank.Rank4, 0 }
                }));
            Levels.Add(LevelType._07,
                new Level(new int[,]{
                    { 0, 0, 0, 0, 0, 0, 0, y, y, 0, 0, 0, r },
                    { 0, 0, y, y, y, y, 0, 0, 0, 0, y, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, z, 0, y, y, y, 0, 0 },
                    { 0, 0, 0, 0, 0, z, y, 0, 0, 0, y, 0, 0 },
                    { 0, 0, 0, 0, z, y, y, 0, 0, 0, y, y, 0 },
                    { 0, y, 0, z, y, y, y, 0, x, 0, 0, 0, 0 },
                    { 0, y, 0, y, y, 0, 0, 0, x, x, 0, 0, 0 },
                    { 0, 0, 0, 0, y, 0, x, x, x, 0, 0, y, 0 },
                    { 0, 0, y, 0, 0, 0, x, x, z, 0, 0, y, 0 },
                    { 0, y, 0, 0, 0, 0, x, z, 0, 0, y, y, 0 },
                    { 0, y, y, y, 0, 0, z, 0, 0, y, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, x, x, x, 0, y, 0, y, y },
                    { y, y, 0, 0, s, x, t, x, 0, 0, 0, 0, 0 }
                }, new Dictionary<TankRank, int>() {
                    { TankRank.Rank1, 10 },
                    { TankRank.Rank2, 4 },
                    { TankRank.Rank3, 6 },
                    { TankRank.Rank4, 0 }
                }));
            Levels.Add(LevelType._08,
                new Level(new int[,]{
                    { 0, 0, x, 0, 0, x, 0, x, 0, x, 0, 0, r },
                    { z, x, x, x, 0, x, 0, y, 0, x, 0, 0, 0 },
                    { z, z, z, 0, 0, 0, 0, x, 0, x, 0, x, 0 },
                    { z, u, u, u, u, u, u, u, u, u, u, 0, u },
                    { 0, x, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, x, 0, 0, x, x, x, x, x, x, y, y },
                    { x, x, 0, x, 0, x, x, x, z, x, y, y, x },
                    { 0, 0, 0, y, 0, y, 0, z, z, z, z, 0, 0 },
                    { u, u, 0, u, u, u, u, u, 0, u, u, u, u },
                    { z, z, 0, x, 0, 0, x, x, 0, 0, 0, 0, 0 },
                    { z, z, x, 0, x, 0, 0, x, 0, y, x, x, 0 },
                    { z, y, x, 0, x, x, x, x, 0, 0, 0, x, 0 },
                    { 0, 0, 0, 0, s, x, t, x, 0, x, 0, x, 0 }
                }, new Dictionary<TankRank, int>() {
                    { TankRank.Rank1, 7 },
                    { TankRank.Rank2, 4 },
                    { TankRank.Rank3, 7 },
                    { TankRank.Rank4, 2 }
                }));
            Levels.Add(LevelType._09,
                new Level(new int[,]{
                    { 0, 0, 0, x, 0, 0, 0, 0, 0, y, z, 0, r },
                    { x, 0, 0, 0, 0, 0, y, z, y, y, y, 0, x },
                    { 0, 0, 0, y, z, y, y, y, 0, y, z, 0, 0 },
                    { 0, 0, y, y, y, 0, y, z, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, y, z, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, z, y, z, 0, z, y, z, 0, 0, 0 },
                    { y, x, 0, y, y, y, 0, y, y, y, 0, x, y },
                    { 0, 0, 0, z, y, z, 0, z, y, z, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { x, 0, 0, y, y, y, 0, y, y, y, 0, 0, x },
                    { x, 0, 0, z, y, z, 0, z, y, z, 0, 0, x },
                    { 0, 0, x, 0, 0, x, x, x, 0, 0, x, 0, 0 },
                    { 0, 0, x, x, s, x, t, x, 0, x, x, 0, 0 }
                }, new Dictionary<TankRank, int>() {
                    { TankRank.Rank1, 6 },
                    { TankRank.Rank2, 7 },
                    { TankRank.Rank3, 4 },
                    { TankRank.Rank4, 3 }
                }));
            Levels.Add(LevelType._10,
                new Level(new int[,]{
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, r },
                    { 0, x, x, x, 0, 0, 0, 0, 0, 0, x, x, 0 },
                    { x, x, 0, 0, x, 0, z, z, 0, x, 0, 0, x },
                    { x, 0, 0, 0, x, z, z, z, z, x, 0, 0, x },
                    { x, 0, 0, x, x, z, y, y, z, x, x, 0, x },
                    { x, 0, 0, x, u, u, u, u, u, u, x, x, x },
                    { 0, x, x, x, y, y, x, y, y, x, x, x, x },
                    { 0, 0, x, x, y, 0, x, 0, y, x, x, x, 0 },
                    { 0, 0, x, x, x, x, x, x, x, x, x, x, 0 },
                    { x, z, 0, 0, 0, y, y, 0, 0, 0, 0, z, x },
                    { x, z, z, z, z, z, z, z, z, z, z, z, x },
                    { 0, 0, z, z, z, x, x, x, z, z, z, z, 0 },
                    { 0, 0, 0, x, s, x, t, x, 0, 0, x, 0, 0 }
                }, new Dictionary<TankRank, int>() {
                    { TankRank.Rank1, 12 },
                    { TankRank.Rank2, 2 },
                    { TankRank.Rank3, 4 },
                    { TankRank.Rank4, 6 }
                }));
            Levels.Add(LevelType._11,
                new Level(new int[,]{
                    { 0, 0, 0, 0, 0, y, 0, x, 0, x, x, 0, r },
                    { 0, x, x, x, x, x, 0, x, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, x, 0, x, 0, x, x, 0, z, z, z },
                    { 0, x, 0, 0, 0, 0, 0, y, 0, z, z, z, z },
                    { 0, x, 0, x, x, x, y, x, x, z, z, x, y },
                    { 0, x, x, x, y, 0, 0, x, 0, z, z, 0, x },
                    { x, x, x, x, 0, y, z, z, z, z, z, 0, 0 },
                    { 0, 0, 0, y, 0, 0, z, z, z, z, z, x, 0 },
                    { y, x, 0, z, z, z, z, y, z, z, z, x, 0 },
                    { x, x, z, z, z, z, z, 0, 0, 0, 0, x, x },
                    { 0, x, z, z, 0, 0, 0, 0, y, x, x, x, 0 },
                    { 0, 0, z, z, 0, x, x, x, 0, x, 0, x, 0 },
                    { 0, x, z, z, s, x, t, x, 0, 0, 0, 0, 0 }
                }, new Dictionary<TankRank, int>() {
                    { TankRank.Rank1, 0 },
                    { TankRank.Rank2, 10 },
                    { TankRank.Rank3, 4 },
                    { TankRank.Rank4, 6 }
                }));
            Levels.Add(LevelType._12,
                new Level(new int[,]{
                    { 0, 0, 0, 0, 0, 0, 0, x, x, x, 0, 0, r },
                    { 0, x, x, x, x, 0, 0, 0, 0, x, 0, 0, 0 },
                    { 0, 0, 0, 0, x, 0, 0, 0, 0, 0, 0, x, x },
                    { 0, u, u, u, u, u, 0, x, x, 0, 0, x, y },
                    { 0, 0, y, y, y, u, 0, x, 0, y, y, x, 0 },
                    { x, 0, x, x, x, u, u, u, 0, u, x, x, 0 },
                    { 0, 0, 0, 0, y, u, 0, 0, 0, u, y, 0, 0 },
                    { u, u, u, 0, u, u, x, x, 0, u, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, x, y, y, 0, u, u, u, 0 },
                    { x, x, x, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, x, 0, y, y, 0, 0, 0, x, x, 0, x },
                    { x, 0, 0, 0, 0, x, x, x, 0, x, 0, 0, x },
                    { 0, 0, 0, 0, s, x, 0, x, 0, 0, 0, 0, 0 }
                }, new Dictionary<TankRank, int>() {
                    { TankRank.Rank1, 0 },
                    { TankRank.Rank2, 6 },
                    { TankRank.Rank3, 8 },
                    { TankRank.Rank4, 6 }
                }));
            Levels.Add(LevelType._13,
                new Level(new int[,]{
                    { 0, 0, 0, 0, x, 0, 0, 0, x, 0, 0, 0, r },
                    { 0, x, x, x, x, 0, 0, 0, x, x, x, x, 0 },
                    { 0, x, 0, 0, 0, 0, x, 0, 0, 0, 0, y, 0 },
                    { 0, y, 0, x, x, 0, 0, 0, x, x, 0, x, x },
                    { 0, x, 0, x, z, y, y, y, z, x, 0, y, x },
                    { 0, 0, 0, 0, z, z, z, z, z, 0, 0, y, x },
                    { x, y, 0, 0, z, z, z, z, z, 0, 0, 0, x },
                    { x, y, 0, x, z, y, y, y, z, x, 0, x, 0 },
                    { x, x, 0, x, x, 0, 0, 0, x, x, 0, y, 0 },
                    { x, y, 0, 0, 0, 0, x, 0, 0, 0, 0, x, 0 },
                    { x, x, x, x, x, 0, 0, 0, x, x, x, y, y },
                    { x, x, 0, 0, x, x, x, x, x, 0, 0, x, 0 },
                    { x, x, 0, 0, s, x, t, x, 0, 0, 0, 0, 0 }
                }, new Dictionary<TankRank, int>() {
                    { TankRank.Rank1, 0 },
                    { TankRank.Rank2, 0 },
                    { TankRank.Rank3, 8 },
                    { TankRank.Rank4, 4 }
                }));
            Levels.Add(LevelType._14,
            new Level(new int[,]{
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, r },
                    { z, z, 0, 0, 0, x, x, x, 0, 0, 0, z, z },
                    { z, 0, 0, 0, x, x, x, x, x, 0, 0, 0, z },
                    { 0, 0, 0, x, x, z, x, z, x, x, 0, 0, 0 },
                    { 0, 0, 0, x, z, z, x, z, z, x, 0, 0, 0 },
                    { z, 0, 0, x, x, x, x, x, x, x, 0, 0, z },
                    { z, z, 0, 0, x, z, x, z, x, 0, 0, z, z },
                    { u, u, u, 0, x, x, x, x, x, 0, u, u, u },
                    { 0, 0, 0, 0, x, 0, x, 0, x, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { y, y, y, 0, 0, 0, 0, 0, 0, 0, y, y, y },
                    { 0, x, 0, 0, 0, x, x, x, 0, 0, 0, x, 0 },
                    { y, y, 0, y, s, x, t, x, 0, y, 0, y, y }
                }, new Dictionary<TankRank, int>() {
                    { TankRank.Rank1, 0 },
                    { TankRank.Rank2, 4 },
                    { TankRank.Rank3, 10 },
                    { TankRank.Rank4, 6 }
                }));
            Levels.Add(LevelType._15,
                new Level(new int[,]{
                    { 0, 0, 0, 0, x, x, 0, 0, x, 0, 0, 0, r },
                    { 0, z, z, x, x, 0, 0, 0, x, 0, 0, 0, 0 },
                    { z, z, z, z, z, z, z, z, x, x, 0, 0, 0 },
                    { z, y, x, z, x, x, x, z, z, z, z, x, y },
                    { z, z, x, z, z, z, y, z, z, x, y, x, 0 },
                    { 0, z, z, x, y, z, z, z, z, x, 0, x, 0 },
                    { 0, x, x, x, x, x, z, z, x, x, x, z, z },
                    { y, y, x, x, 0, 0, 0, x, 0, 0, 0, 0, z },
                    { 0, x, 0, x, 0, y, 0, x, z, z, x, x, z },
                    { 0, x, 0, 0, x, x, x, z, z, x, 0, 0, z },
                    { 0, x, x, 0, x, 0, z, z, x, z, x, z, z },
                    { 0, 0, x, 0, z, x, x, x, x, z, x, z, 0 },
                    { 0, 0, x, 0, s, x, t, x, 0, z, z, z, 0 }
                }, new Dictionary<TankRank, int>() {
                    { TankRank.Rank1, 2 },
                    { TankRank.Rank2, 10 },
                    { TankRank.Rank3, 0 },
                    { TankRank.Rank4, 8 }
                }));
            Levels.Add(LevelType._16,
            new Level(new int[,]{
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, r },
                    { 0, 0, y, z, y, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, z, 0, z, y, 0, 0, 0, 0, 0, 0 },
                    { 0, z, 0, 0, 0, 0, z, x, 0, 0, 0, 0, 0 },
                    { 0, z, z, 0, 0, z, 0, z, y, 0, 0, 0, 0 },
                    { 0, z, 0, z, 0, z, 0, 0, z, x, 0, 0, 0 },
                    { 0, z, 0, 0, z, 0, 0, 0, z, z, y, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, z, z, z, z, x, 0 },
                    { 0, 0, 0, 0, 0, 0, z, 0, z, z, z, z, 0 },
                    { x, 0, 0, 0, 0, 0, z, 0, 0, z, z, z, y },
                    { x, x, 0, 0, 0, 0, 0, z, 0, z, z, z, z },
                    { y, x, x, 0, 0, x, x, x, z, 0, z, z, z },
                    { y, y, x, x, s, x, t, x, z, 0, 0, z, z }
                }, new Dictionary<TankRank, int>() {
                    { TankRank.Rank1, 16 },
                    { TankRank.Rank2, 2 },
                    { TankRank.Rank3, 0 },
                    { TankRank.Rank4, 2 }
                }));
            Levels.Add(LevelType._17,
            new Level(new int[,]{
                    { 0, 0, 0, 0, x, 0, 0, 0, 0, 0, x, 0, r },
                    { 0, x, 0, x, x, 0, 0, q, q, q, x, x, 0 },
                    { 0, x, 0, 0, x, 0, y, q, q, q, q, q, 0 },
                    { q, q, q, y, x, 0, 0, x, q, q, q, q, 0 },
                    { q, q, q, q, q, q, x, x, 0, x, 0, 0, 0 },
                    { 0, 0, y, q, q, q, q, x, 0, x, 0, y, y },
                    { x, x, x, x, q, q, q, q, q, q, q, x, x },
                    { 0, 0, 0, x, x, q, q, q, q, y, 0, 0, 0 },
                    { 0, x, x, x, 0, q, q, q, x, x, 0, x, 0 },
                    { q, q, q, x, q, y, 0, y, 0, x, 0, x, 0 },
                    { q, q, q, q, q, 0, 0, 0, 0, 0, x, x, 0 },
                    { x, q, q, q, q, x, x, x, 0, x, 0, 0, 0 },
                    { x, x, y, 0, s, x, t, x, 0, x, 0, x, 0 }
                }, new Dictionary<TankRank, int>() {
                    { TankRank.Rank1, 8 },
                    { TankRank.Rank2, 2 },
                    { TankRank.Rank3, 8 },
                    { TankRank.Rank4, 2 }
                }));
            Levels.Add(LevelType._18,
                new Level(new int[,]{
                    { 0, 0, 0, 0, 0, 0, 0, 0, y, y, y, z, r },
                    { 0, x, 0, 0, 0, 0, 0, 0, y, 0, 0, y, 0 },
                    { x, z, x, 0, 0, 0, x, x, x, x, 0, y, 0 },
                    { 0, x, z, x, 0, 0, x, 0, z, x, y, y, 0 },
                    { 0, 0, x, 0, z, y, x, z, 0, x, 0, 0, 0 },
                    { 0, 0, 0, 0, y, 0, x, y, x, x, 0, 0, 0 },
                    { 0, 0, x, x, y, x, 0, y, 0, 0, 0, 0, 0 },
                    { 0, 0, x, 0, z, x, y, z, 0, 0, 0, 0, 0 },
                    { y, y, y, z, 0, x, 0, 0, x, x, 0, 0, 0 },
                    { y, 0, x, x, x, x, 0, 0, x, y, y, 0, 0 },
                    { y, 0, 0, y, 0, 0, 0, 0, 0, y, x, x, 0 },
                    { z, y, y, y, 0, x, x, x, 0, 0, x, y, y },
                    { 0, 0, 0, 0, s, x, t, x, 0, 0, 0, y, y }
                }, new Dictionary<TankRank, int>() {
                    { TankRank.Rank1, 2 },
                    { TankRank.Rank2, 8 },
                    { TankRank.Rank3, 6 },
                    { TankRank.Rank4, 4 }
                }));

            Levels.Add(LevelType._19,
            new Level(new int[,]{
                    { 0, x, 0, x, 0, x, 0, x, 0, x, 0, x, r },
                    { 0, x, 0, x, 0, x, 0, x, 0, x, 0, x, 0 },
                    { 0, y, 0, y, 0, y, 0, y, 0, y, 0, y, 0 },
                    { 0, 0, 0, 0, x, 0, 0, 0, x, 0, 0, 0, 0 },
                    { x, 0, x, x, x, 0, x, 0, x, x, x, 0, x },
                    { y, 0, y, 0, y, 0, y, 0, y, 0, y, 0, y },
                    { z, z, 0, 0, x, 0, z, 0, x, 0, 0, z, z },
                    { z, z, z, z, x, x, z, x, x, z, z, z, z },
                    { z, z, z, z, z, z, z, z, z, z, z, z, z },
                    { x, 0, x, 0, x, z, z, z, x, 0, x, 0, x },
                    { 0, x, 0, x, 0, 0, z, 0, 0, x, 0, x, 0 },
                    { 0, x, 0, x, 0, x, x, x, 0, x, 0, x, 0 },
                    { 0, x, 0, x, s, x, t, x, 0, x, 0, x, 0 }
                }, new Dictionary<TankRank, int>() {
                    { TankRank.Rank1, 4 },
                    { TankRank.Rank2, 4 },
                    { TankRank.Rank3, 4 },
                    { TankRank.Rank4, 8 }
                }));

            Levels.Add(LevelType._20,
            new Level(new int[,]{
                    { 0, 0, 0, u, 0, x, 0, 0, x, 0, x, 0, r },
                    { 0, 0, 0, 0, 0, 0, 0, 0, x, 0, y, 0, 0 },
                    { 0, 0, 0, u, 0, x, y, 0, x, 0, x, 0, 0 },
                    { y, 0, x, u, 0, y, 0, x, 0, 0, x, 0, 0 },
                    { 0, 0, x, u, 0, 0, 0, x, 0, 0, 0, 0, 0 },
                    { x, 0, x, u, u, 0, u, u, u, u, 0, 0, x },
                    { 0, 0, 0, 0, 0, 0, 0, z, 0, u, 0, y, y },
                    { x, x, x, x, 0, y, z, z, z, u, 0, x, x },
                    { x, 0, x, 0, 0, x, z, z, z, u, 0, x, 0 },
                    { 0, y, 0, 0, 0, x, 0, z, 0, u, 0, z, 0 },
                    { 0, x, 0, y, 0, x, x, x, 0, 0, z, z, z },
                    { 0, x, 0, x, 0, x, x, x, 0, u, z, z, z },
                    { 0, 0, 0, 0, s, x, t, x, 0, u, 0, z, 0 }
                }, new Dictionary<TankRank, int>() {
                    { TankRank.Rank1, 2 },
                    { TankRank.Rank2, 8 },
                    { TankRank.Rank3, 2 },
                    { TankRank.Rank4, 8 }
                }));
            Levels.Add(LevelType._21,
            new Level(new int[,]{
                    { 0, 0, 0, x, x, 0, 0, 0, x, 0, 0, 0, r },
                    { 0, 0, x, x, x, x, x, x, x, x, 0, 0, 0 },
                    { 0, z, z, z, z, z, z, z, z, x, x, 0, 0 },
                    { z, z, 0, 0, 0, 0, 0, 0, z, z, x, x, 0 },
                    { z, 0, y, 0, 0, y, 0, 0, 0, z, z, z, 0 },
                    { z, 0, y, 0, 0, y, 0, 0, 0, z, z, z, 0 },
                    { z, 0, 0, z, 0, 0, 0, 0, z, z, x, x, x },
                    { z, z, z, z, z, z, z, z, z, x, x, x, x },
                    { x, z, z, x, x, z, z, z, x, x, x, x, 0 },
                    { 0, x, x, x, x, x, x, x, x, x, x, 0, y },
                    { y, 0, x, y, x, 0, 0, 0, x, x, 0, 0, y },
                    { 0, y, x, x, y, x, x, x, x, x, y, y, y },
                    { 0, 0, 0, 0, s, x, t, x, 0, 0, 0, 0, 0 }
                }, new Dictionary<TankRank, int>() {
                    { TankRank.Rank1, 6 },
                    { TankRank.Rank2, 2 },
                    { TankRank.Rank3, 8 },
                    { TankRank.Rank4, 4 }
                }));
            Levels.Add(LevelType._22,
            new Level(new int[,]{
                    { 0, 0, 0, 0, 0, z, 0, 0, 0, 0, 0, 0, r },
                    { 0, 0, 0, 0, z, y, z, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, z, 0, 0, z, 0, 0, z, z, 0, 0, 0 },
                    { 0, z, x, z, 0, 0, 0, z, x, x, z, 0, 0 },
                    { 0, 0, z, x, z, 0, 0, 0, z, z, 0, 0, z },
                    { z, 0, 0, z, 0, 0, z, 0, 0, 0, 0, z, y },
                    { x, z, 0, 0, 0, z, y, z, 0, 0, z, 0, z },
                    { y, x, z, 0, 0, 0, z, 0, 0, z, y, z, 0 },
                    { x, z, 0, 0, z, 0, 0, 0, z, 0, z, 0, 0 },
                    { z, 0, 0, z, x, z, 0, z, x, z, 0, 0, 0 },
                    { 0, 0, 0, z, x, z, 0, 0, z, 0, 0, z, 0 },
                    { 0, z, 0, 0, z, x, x, x, 0, 0, z, y, z },
                    { z, y, z, 0, s, x, t, x, 0, z, x, z, 0 }
                }, new Dictionary<TankRank, int>() {
                    { TankRank.Rank1, 6 },
                    { TankRank.Rank2, 8 },
                    { TankRank.Rank3, 2 },
                    { TankRank.Rank4, 4 }
                }));
            Levels.Add(LevelType._23,
                new Level(new int[,]{
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, r },
                    { 0, 0, 0, 0, 0, y, y, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, y, 0, 0, 0, 0, 0, 0 },
                    { 0, y, y, z, z, x, y, x, z, z, y, y, 0 },
                    { 0, 0, 0, y, z, z, y, z, z, y, 0, 0, 0 },
                    { z, 0, 0, 0, y, z, z, z, y, 0, 0, 0, z },
                    { y, z, 0, 0, 0, z, z, z, 0, 0, 0, z, y },
                    { z, 0, 0, 0, 0, y, z, y, 0, 0, 0, 0, z },
                    { 0, 0, 0, 0, y, 0, 0, 0, y, 0, 0, 0, 0 },
                    { 0, 0, 0, y, 0, 0, y, 0, 0, y, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, x, x, x, 0, 0, 0, 0, 0 },
                    { 0, 0, y, 0, s, x, t, x, 0, 0, y, 0, 0 }
                }, new Dictionary<TankRank, int>() {
                    { TankRank.Rank1, 0 },
                    { TankRank.Rank2, 10 },
                    { TankRank.Rank3, 4 },
                    { TankRank.Rank4, 6 }
                }));
            Levels.Add(LevelType._24,
            new Level(new int[,]{
                    { 0, 0, y, 0, x, y, 0, 0, 0, 0, x, 0, r },
                    { 0, 0, x, 0, x, z, 0, x, x, x, x, 0, 0 },
                    { 0, z, z, 0, x, z, x, 0, 0, 0, 0, y, y },
                    { z, z, z, z, z, z, x, x, x, 0, 0, x, 0 },
                    { 0, 0, z, z, x, x, y, x, 0, 0, x, x, x },
                    { x, y, 0, x, 0, 0, 0, 0, 0, x, x, 0, x },
                    { x, 0, 0, x, q, q, q, q, q, q, q, q, q },
                    { x, 0, x, 0, q, q, q, q, q, q, q, q, q },
                    { 0, 0, y, 0, q, q, q, q, q, q, q, q, q },
                    { x, 0, x, 0, q, q, q, q, q, q, q, q, q },
                    { x, 0, x, 0, q, q, q, q, q, q, q, q, q },
                    { x, 0, x, 0, 0, x, x, x, q, q, q, q, q },
                    { 0, 0, x, 0, s, x, t, x, 0, q, q, q, q }
                }, new Dictionary<TankRank, int>() {
                    { TankRank.Rank1, 10 },
                    { TankRank.Rank2, 4 },
                    { TankRank.Rank3, 4 },
                    { TankRank.Rank4, 2 }
                }));
            Levels.Add(LevelType._25,
            new Level(new int[,]{
                    { 0, 0, 0, y, 0, x, 0, x, 0, x, 0, y, r },
                    { 0, x, 0, x, 0, 0, 0, 0, 0, y, 0, 0, 0 },
                    { 0, x, 0, x, 0, 0, y, 0, 0, y, 0, y, y },
                    { 0, x, 0, 0, 0, x, 0, y, x, 0, 0, 0, y },
                    { 0, 0, 0, 0, x, x, 0, x, x, 0, y, 0, 0 },
                    { 0, 0, y, 0, x, 0, 0, x, x, 0, x, x, 0 },
                    { y, 0, y, 0, 0, x, 0, y, 0, 0, y, x, 0 },
                    { 0, 0, x, x, 0, x, 0, 0, 0, x, y, 0, 0 },
                    { 0, y, x, x, 0, x, x, 0, x, x, 0, 0, x },
                    { 0, x, 0, 0, 0, x, y, 0, 0, 0, 0, x, x },
                    { 0, 0, 0, x, 0, x, x, y, 0, y, 0, 0, x },
                    { x, 0, x, x, 0, x, x, x, 0, x, y, 0, 0 },
                    { x, 0, x, 0, s, x, t, x, 0, x, x, x, 0 }
                }, new Dictionary<TankRank, int>() {
                    { TankRank.Rank1, 0 },
                    { TankRank.Rank2, 8 },
                    { TankRank.Rank3, 2 },
                    { TankRank.Rank4, 10 }
                }));
        }
    }
}