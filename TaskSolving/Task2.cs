using System;

// Избавьтесь от дублирующегося кода
namespace TaskSolving
{
    internal class Task2
    {
        class Entity
        {
            private int _x;
            private int _y;
            private bool _isAlive;

            public int X { get => _x; set => _x = value; }
            public int Y { get => _y; set => _y = value; }
            public bool isAlive { get => _isAlive; set => _isAlive = value; }

            private Entity(int x, int y, bool isAlive)
            {
                _x = x;
                _y = y;
                _isAlive = isAlive;
            }

            public static Entity CreateEntity(int x, int y)
            {
                if (x > 0)
                    x = 0;
                if (y > 0)
                    y = 0;
                bool isAlive = true;
                return new Entity(x, y, isAlive);
            }

            public bool ComparePositionTo(Entity entity)
            {
                return (X == entity.X && Y == entity.Y);
            }

            public void MoveRandom(Random random, int maxDistance)
            {
                _x += random.Next(-maxDistance, maxDistance);
                _y += random.Next(-maxDistance, maxDistance);
                if (_x < 0)
                    _x = 0;
                if (_y < 0)
                    _y = 0;
            }
        }

        static void DrawEntityIfAlive(Entity entity)
        {
            if (entity.isAlive)
            {
                Console.SetCursorPosition(entity.X, entity.Y);
                Console.Write("1");
            }
        }

        public static void Main(string[] args)
        {
            Entity[] entities = new Entity[3] { Entity.CreateEntity(5, 5), Entity.CreateEntity(10, 10), Entity.CreateEntity(15, 15) };
            Random random = new Random();

            while (true)
            {
                for(int i=0;i < entities.Length - 1;i++)
                {
                    for(int j=i+1; j < entities.Length;j++)
                    {
                        if(entities[i].ComparePositionTo(entities[j]))
                        {
                            entities[i].isAlive = false;
                            entities[j].isAlive = false;
                        }
                    }
                }

                foreach(Entity entity in entities)
                {
                    entity.MoveRandom(random, 1);
                    DrawEntityIfAlive(entity);
                }
            }
        }
    }
}