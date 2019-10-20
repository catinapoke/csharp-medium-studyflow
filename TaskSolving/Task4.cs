using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Разбейте класс на несколько
namespace TaskSolving
{
    class Player
    {
        public string Name { get; private set; }
        public float WeaponCooldown { get; private set; }
        public float MovementDirectionX { get; private set; }
        public float MovementDirectionY { get; private set; }
        public int Age { get; private set; }
        public int WeaponDamage { get; private set; }
        public float MovementSpeed { get; private set; }

        public void Move()
        {
            //Do move
        }

        public void Attack()
        {
            //attack
        }

        public bool IsReloading()
        {
            throw new NotImplementedException();
        }
    }
}
