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

            public int X { get => _x; private set => _x = value; }
            public int Y { get => _y; private set => _y = value; }
            public bool isAlive { get => _isAlive; private set => _isAlive = value; }

            public Entity(int x, int y, bool isAlive = true)
            {
                if (x > 0)
                    x = 0;
                if (y > 0)
                    y = 0;
                _x = x;
                _y = y;
                _isAlive = isAlive;
            }
            public bool IsEqualPositionTo(Entity entity)
            {
                return (X == entity.X && Y == entity.Y);
            }

            public void MoveRandom(Random random, int delta)
            {
                _x += random.Next(-delta, delta);
                _y += random.Next(-delta, delta);
                if (_x < 0)
                    _x = 0;
                if (_y < 0)
                    _y = 0;
            }

            public void Die()
            {
                _isAlive = false;
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
            Entity[] entities = new Entity[3] { new Entity(5, 5), new Entity(10, 10), new Entity(15, 15) };
            Random random = new Random();

            while (true)
            {
                for(int i=0;i < entities.Length - 1;i++)
                {
                    for(int j=i+1; j < entities.Length;j++)
                    {
                        if(entities[i].IsEqualPositionTo(entities[j]))
                        {
                            entities[i].Die();
                            entities[j].Die();
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