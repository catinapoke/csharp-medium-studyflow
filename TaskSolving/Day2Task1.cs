using System;

namespace TaskSolving
{
    abstract class Damagable
    {
        protected int _health;
        public int Health { get => _health; private set => _health = value; }
        public void TakeDamage(int rawDamage)
        {
            _health -= DamageCalculate(rawDamage);
            DeadCheck();
        }
        protected void DeadCheck()
        {
            if (_health <= 0)
            {
                Console.WriteLine("Я умер");
            }
        }
        protected virtual int DamageCalculate(int rawDamage)
        {
            throw new NotImplementedException();
        }
    }

    class Wombat : Damagable
    {
        private int _armor;
        public int Armor { get => _armor; private set => _armor = value; }

        protected override int DamageCalculate(int rawDamage)
        {
            return rawDamage - _armor;
        }
    }

    class Human : Damagable
    {
        private int _agility;
        public int Agility { get => _agility; private set => _agility = value; }

        protected override int DamageCalculate(int rawDamage)
        {
            return rawDamage / _agility;
        }
    }
}
