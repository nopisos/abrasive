using System;

namespace Weapon
{
    public class Player
    {
        private int _health;

        public Player(int health)
        {
            if (health < 0)
                throw new ArgumentOutOfRangeException(nameof(health));

            _health = health;
        }

        public bool IsAlive => _health > 0;

        public void TakeDamage(int damage)
        {
            if (!IsAlive)
                throw new InvalidOperationException();

            _health -= damage;
        }
    }
}
