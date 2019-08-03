using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BattleCity.Core.CommonTypes;
using BattleCity.Core.Entities;
using BattleCity.Core.Entities.Items;
using BattleCity.Core.Entities.Tanks;
using BattleCity.Core.Levels;
using BattleCity.Core.ScreenText;
using BattleCity.Core.Utils;

namespace BattleCity.Core
{
    internal class Level
    {
        private const int maxAITanksAllowed = 1;
        private CancellationToken cancellationToken = Game.CancellationTokenSource.Token;

        private static readonly object _locker = new object();
        private int _spawnedTankIDIncrementor = 1000;
        private Dictionary<EntityType, Point> _tankPositions;
        private Point _playerPosition;

        public Item[,] Layout;
        public HashSet<IEntity> Entities = new HashSet<IEntity>();

        public ITank Player1 { get; private set; }
        public ITank Player2 { get; private set; }
        public LevelType Type { get; private set; }
        public Dictionary<TankRank, int> AITanks { get; private set; }
        public int AIsSpawned { get; set; }

        public Level(LevelType levelType, int size = 3)
        {
            this.Type = levelType;

            this.AITanks = LevelsHolder.Levels[levelType].TankType;
            int[,] levelLayout = LevelsHolder.Levels[levelType].Layout;
            int matrixSize = levelLayout.GetLength(0);
            levelLayout = FixLevelOrientation(levelLayout);

            int itemsSize = matrixSize * size;
            this.Layout = new Item[itemsSize, itemsSize];

            this._tankPositions = new Dictionary<EntityType, Point>();

            for (int rowIndex = 0; rowIndex < matrixSize; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrixSize; colIndex++)
                {
                    ItemType itemType = (ItemType)levelLayout[rowIndex, colIndex];

                    for (int itemRowIndex = rowIndex * size; itemRowIndex < rowIndex * size + size && itemRowIndex < itemsSize; itemRowIndex++)
                    {
                        for (int itemColIndex = colIndex * size; itemColIndex < colIndex * size + size && itemColIndex < itemsSize; itemColIndex++)
                        {
                            Point position = new Point(itemRowIndex, itemColIndex);
                            Item item = new Item(itemType, position);
                            this.Layout[position.X, position.Y] = item;
                            this.AttachEvents(item);

                            CheckForSpawnPosition(item);
                        }
                    }
                }
            }
        }

        public void Write()
        {
            for (int rowIndex = 0; rowIndex < this.Layout.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < this.Layout.GetLength(1); colIndex++)
                {
                    this.Layout[rowIndex, colIndex].Write();
                }
            }

            this.SpawnTanks();
        }

        public void Clear()
        {
            for (int rowIndex = 0; rowIndex < this.Layout.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < this.Layout.GetLength(1); colIndex++)
                {
                    this.Layout[rowIndex, colIndex].Clear();
                }
            }
        }

        private void SpawnTanks()
        {
            foreach (var tankPosition in this._tankPositions)
            {
                IEntity entity = null;
                switch (tankPosition.Key)
                {
                    case EntityType.Player:
                        entity = new Player(TankRank.Rank1);
                        this.Player1 = entity as ITank;
                        this.Spawn(entity);
                        AfterTankCreate(entity);
                        break;

                    case EntityType.AI:
                        this.SpawnNextAI();

                        break;

                    default:
                        throw new InvalidOperationException();
                }
            }
        }

        private void AfterTankCreate(IEntity entity)
        {
            lock (_locker)
            {
                entity.ID = this._spawnedTankIDIncrementor++;
                (entity as ITank).FireEvent += (projectile) =>
                {
                    this.AttachEvents(projectile);
                    return true;
                };
                this.AttachEvents(entity);
            }
        }

        private bool SpawnNextAI()
        {
            if (this.AIsSpawned < maxAITanksAllowed)
            {
                if (AITanks[TankRank.Rank1] > 0)
                {
                    Task.Run(() =>
                        {
                            var entity = new AI(TankRank.Rank1);
                            entity.Position = new Point(this._tankPositions[entity.EntityType]);
                            if (IsPositionOccupied(entity))
                            {
                                (entity as AI).RequestPathEvent += new AI.RequestPath(this.HandleAIPathRequest);
                                this.Spawn(entity);
                                (entity as AI).OnRequestPathEvent();
                                AfterTankCreate(entity);
                                AITanks[TankRank.Rank1]--;
                                this.AIsSpawned++;
                            }
                        });

                    return true;
                }
                else if (AITanks[TankRank.Rank2] > 0)
                {
                    Task.Run(() =>
                    {
                        var entity = new AI(TankRank.Rank2);
                        entity.Position = new Point(this._tankPositions[entity.EntityType]);
                        if (IsPositionOccupied(entity))
                        {
                            (entity as AI).RequestPathEvent += new AI.RequestPath(this.HandleAIPathRequest);
                            this.Spawn(entity);
                            (entity as AI).OnRequestPathEvent();
                            AfterTankCreate(entity);
                            AITanks[TankRank.Rank2]--;
                            this.AIsSpawned++;
                        }
                    });
                    return true;
                }
                else if (AITanks[TankRank.Rank3] > 0)
                {
                    Task.Run(() =>
                    {
                        var entity = new AI(TankRank.Rank3);
                        entity.Position = new Point(this._tankPositions[entity.EntityType]);
                        if (IsPositionOccupied(entity))
                        {
                            (entity as AI).RequestPathEvent += new AI.RequestPath(this.HandleAIPathRequest);
                            this.Spawn(entity);
                            (entity as AI).OnRequestPathEvent();
                            AfterTankCreate(entity);
                            AITanks[TankRank.Rank3]--;
                            this.AIsSpawned++;
                        }
                    });
                    return true;
                }
                else if (AITanks[TankRank.Rank4] > 0)
                {
                    Task.Run(() =>
                    {
                        var entity = new AI(TankRank.Rank4);
                        entity.Position = new Point(this._tankPositions[entity.EntityType]);
                        if (IsPositionOccupied(entity))
                        {
                            (entity as AI).RequestPathEvent += new AI.RequestPath(this.HandleAIPathRequest);
                            this.Spawn(entity);
                            (entity as AI).OnRequestPathEvent();
                            AfterTankCreate(entity);
                            AITanks[TankRank.Rank4]--;
                            this.AIsSpawned++;
                        }
                    });
                    return true;
                }
            }
            return false;
        }

        private void Spawn(IEntity entity)
        {
            Entities.Add(entity);
            entity.Position = new Point(this._tankPositions[entity.EntityType]);

            if (IsPositionOccupied(entity))
            {
                entity.Write();
            }
            else
            {
                Entities.Remove(entity);
            }
        }

        private bool IsPositionOccupied(IEntity entity)
        {
            foreach (var otherEntity in Entities)
            {
                if (otherEntity != entity)
                {
                    Point[] otherEntityOnLayout = otherEntity.GetPositionOnLayout();
                    Point[] thisEntityOnLayout = entity.GetPositionOnLayout();
                    for (int index = 0; index < otherEntityOnLayout.Length; index++)
                    {
                        for (int jIndex = 0; jIndex < thisEntityOnLayout.Length; jIndex++)
                        {
                            if (otherEntityOnLayout[index].X == thisEntityOnLayout[jIndex].X &&
                                otherEntityOnLayout[index].Y == thisEntityOnLayout[jIndex].Y)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }

        private IEntity GetEntityOnPosition(Point position)
        {
            foreach (var entity in Entities)
            {
                Point[] entityOnLayout = entity.GetPositionOnLayout();
                for (int index = 0; index < entityOnLayout.Length; index++)
                {
                    if (entityOnLayout[index].X == position.X &&
                        entityOnLayout[index].Y == position.Y)
                    {
                        return entity;
                    }
                }
            }
            return null;
        }

        private void SpawnItem(IEntity entity)
        {
            Random rd = new Random();
            Item item = null;
            int randomItemNumber = rd.Next(1, 6);
            switch (randomItemNumber)
            {
                case 1:
                    item = new Item(ItemType.Tank, entity.Position);
                    break;

                case 2:
                    item = new Item(ItemType.Star, entity.Position);
                    break;

                case 3:
                    item = new Item(ItemType.Clock, entity.Position);
                    break;

                case 4:
                    item = new Item(ItemType.Helmet, entity.Position);
                    break;

                case 5:
                    item = new Item(ItemType.Bomb, entity.Position);
                    break;

                case 6:
                    item = new Item(ItemType.Shovel, entity.Position);
                    break;

                default:
                    break;
            }
            item.Write();
            this.Layout[item.Position.X, item.Position.Y] = item;
        }

        private void AttachEvents(IEntity entity)
        {
            entity.MoveEvent += () =>
            {
                if (CheckPositionInMatrix(entity.Position))
                {
                    entity.IsHidden = false;
                    var obstacles = GetObstacles(entity);
                    bool result = !obstacles.Any() && CheckPositionInMatrix(entity.GetDirectionPosition());
                    foreach (var obstacle in obstacles)
                    {
                        result = entity.ApplyAffection(obstacle);
                        if (!result)
                        {
                            break;
                        }
                    }

                    if (entity is Player)
                    {
                        this._playerPosition = entity.Position;
                    }

                    if (entity is AI)
                    {
                        this.SpawnNextAI();
                    }

                    if (result)
                    {
                        //SetTankPosition(entity);
                    }

                    if (!IsPositionOccupied(entity))
                    {
                        return false;
                    }

                    return result;
                }
                else if (entity.EntityType == EntityType.Item)
                {
                    entity.IsDestroyed = true;
                    entity.Position = this.GetPreviousPosition(entity);
                    if (!entity.IsHidden)
                    {
                        entity.Clear();
                    }
                    this.Layout[entity.Position.X, entity.Position.Y] = new Item(ItemType.Nothing, entity.Position);
                }
                return false;
            };

            entity.DestroyEvent += () =>
            {
                if (entity is ITank)
                {
                    var tank = entity as ITank;

                    if (tank is AI)
                        Statistics.DestroyTankPoints(tank.Type);

                    if (tank.Lives > 0)
                    {
                        if (tank is Player)
                            this.Spawn(tank);
                    }
                    else if (Statistics.Player1Points % 50 == 0)
                    {
                        if (tank is AI)
                            this.SpawnItem(tank);
                    }

                    ScoreScreen.SideScreen(this.Player1, this.Type, this.AITanks);
                }
                else if (!(entity is Item) || (entity as Item).Type != ItemType.Projectile)
                {
                    this.Layout[entity.Position.X, entity.Position.Y] = new Item(ItemType.Nothing, entity.Position);
                }
                return true;
            };

            if (entity is AI)
            {
                (entity as AI).AIDownEvent += () =>
                {
                    Entities.Remove(entity);
                    this.AIsSpawned--;
                    SpawnNextAI();
                };
            }
            return;
        }

        private List<IEntity> GetObstacles(IEntity entity)
        {
            var obstacles = new List<IEntity>();
            var position = entity.GetDirectionPosition();
            if (CheckPositionInMatrix(position))
            {
                var nextPosition = new Point(position);
                switch (entity.Direction)
                {
                    case Direction.Up:
                        nextPosition.Y -= 1;
                        break;

                    case Direction.Left:
                        nextPosition.X -= 1;
                        break;

                    case Direction.Down:
                        nextPosition.Y += 1;
                        break;

                    case Direction.Right:
                        nextPosition.X += 1;
                        break;
                }
                var entityObstacle = GetEntityOnPosition(nextPosition);

                obstacles.Add(this.Layout[position.X, position.Y]);
                Action<int> addObstacle = null;
                switch (entity.Direction)
                {
                    case Direction.Up:
                    case Direction.Down:
                        addObstacle = (positionIndex) =>
                        {
                            obstacles.Add(this.Layout[position.X + positionIndex, position.Y]);
                            obstacles.Add(this.Layout[position.X - positionIndex, position.Y]);
                        };
                        break;

                    case Direction.Left:
                    case Direction.Right:
                        addObstacle = (positionIndex) =>
                        {
                            obstacles.Add(this.Layout[position.X, position.Y + positionIndex]);
                            obstacles.Add(this.Layout[position.X, position.Y - positionIndex]);
                        };
                        break;
                }

                var obstacleSize = entity.Symbols.GetLength(0) / 2;
                if ((entity is Item) && (entity as Item).Type == ItemType.Projectile)
                {
                    obstacleSize = this.Player1.Symbols.GetLength(0) / 2;
                }

                for (int positionIndex = 1, length = obstacleSize; positionIndex <= length; positionIndex++)
                {
                    addObstacle(positionIndex);
                }

                obstacles = obstacles.Where(obstacle => obstacle.EntityType != EntityType.Item || (obstacle as Item).Type != ItemType.Nothing).ToList();

                if (obstacles.Count == 0)
                {
                    if (entityObstacle != null && entityObstacle.EntityType != entity.EntityType)
                    {
                        return new List<IEntity>() { entityObstacle };
                    }
                }
            }

            return obstacles;
        }

        private bool CheckPositionInMatrix(Point position)
        {
            return this.Layout.GetLength(0) > position.X
                && this.Layout.GetLength(1) > position.Y
                && position.X >= 0
                && position.Y >= 0;
        }

        private Point GetPreviousPosition(IEntity entity)
        {
            Point previousPosition = null;
            switch (entity.Direction)
            {
                case Direction.Up:
                    previousPosition = entity.GetPosition(Direction.Down);
                    break;

                case Direction.Left:
                    previousPosition = entity.GetPosition(Direction.Right);
                    break;

                case Direction.Down:
                    previousPosition = entity.GetPosition(Direction.Up);
                    break;

                case Direction.Right:
                    previousPosition = entity.GetPosition(Direction.Left);
                    break;
            }
            return previousPosition;
        }

        private void SetTankPosition(IEntity entity)
        {
            var previousPosition = this.GetPreviousPosition(entity);

            var entitySize = entity.Symbols.GetLength(0);
            // Clear Previous Position
            for (int rowIndex = entitySize - 1; rowIndex < entitySize; rowIndex++)
            {
                for (int colIndex = 0; colIndex < entitySize; colIndex++)
                {
                    var positionX = previousPosition.X + rowIndex;
                    var positionY = previousPosition.Y + colIndex;

                    var item = this.Layout[positionX, positionY];
                    if (item.Type == ItemType.TankPosition)
                    {
                        this.Layout[previousPosition.X + rowIndex, previousPosition.Y + colIndex] = new Item(ItemType.Nothing, new Point(positionX, positionY));
                    }
                }
            }

            // Set New Position
            for (int rowIndex = 0; rowIndex < entitySize; rowIndex++)
            {
                for (int colIndex = 0; colIndex < entitySize; colIndex++)
                {
                    var positionX = entity.Position.X + rowIndex;
                    var positionY = entity.Position.Y + colIndex;
                    var item = this.Layout[positionX, positionY];
                    if (item.Type != ItemType.TankPosition)
                    {
                        var tankPosition = new Item(ItemType.TankPosition, new Point(positionX, positionY));
                        tankPosition.ID = entity.ID;
                        this.Layout[positionX, positionY] = tankPosition;
                    }
                }
            }
        }

        private int[,] FixLevelOrientation(int[,] levelLayout)
        {
            int matrixSize = levelLayout.GetLength(0);
            levelLayout = MatrixUtil.RotateRight<int>(levelLayout);
            levelLayout = MatrixUtil.MirrorHorizontal<int>(levelLayout);
            return levelLayout;
        }

        private void CheckForSpawnPosition(Item item)
        {
            if (item.Type == ItemType.AISpawnPoint || item.Type == ItemType.PlayerSpawnPoint)
            {
                var entityType = item.Type == ItemType.AISpawnPoint ? EntityType.AI : EntityType.Player;
                if (!this._tankPositions.ContainsKey(entityType))
                {
                    this._tankPositions.Add(entityType, new Point(item.Position));
                }
            }
        }

        private Queue<Direction> HandleAIPathRequest(object sender, Point position, bool requestingFlag)
        {
            if (this._playerPosition == null)
            {
                this._playerPosition = new Point(12, 36);
            }
            Grid grid = new Grid(39, 39, this.Layout);
            Queue<Direction> orders = new Queue<Direction>();
            //Queue<Node> orders = new Queue<Node>();
            Node startNode = grid.GetNodeAt(position.X, position.Y);
            Node endNode;
            if (!requestingFlag)
            {
                endNode = grid.GetNodeAt(_playerPosition.X, _playerPosition.Y);
            }
            else
            {
                endNode = grid.GetNodeAt(12, 36);
            }
            Queue<Node> openList = new Queue<Node>();

            openList.Enqueue(startNode);
            startNode.Opened = true;
            while (!cancellationToken.IsCancellationRequested && openList.Any())
            {
                Node currentNode = openList.Dequeue();
                currentNode.Closed = true;

                if (currentNode == endNode)
                {
                    orders = Grid.Backtrace(currentNode);
                    return orders;
                }

                List<Node> neighbors = grid.getNeighbors(currentNode);

                for (int index = 0; index < neighbors.Count; index++)
                {
                    Node neighbor = neighbors[index];

                    if (neighbor.Closed || neighbor.Opened)
                    {
                        continue;
                    }

                    openList.Enqueue(neighbor);
                    neighbor.Opened = true;
                    neighbor.Parent = currentNode;
                }
            }
            return orders;
        }
    }
}