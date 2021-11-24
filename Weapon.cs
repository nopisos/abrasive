using System;

namespace Weapon
{
    public class Weapon
    {
        private readonly int _damage;
        private readonly int _projectilesPerShot;
        private int _bulletsAmount;

        public Weapon(int damage, int amount, int projectilesPerShot)
        {
            _damage = damage;
            _bulletsAmount = amount;
            _projectilesPerShot = projectilesPerShot;
        }

        public bool CanFire(Player player) => _bulletsAmount > 0 && player.IsAlive;

        public void Fire(Player player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            if (!CanFire(player))
                throw new InvalidOperationException();

            if (_bulletsAmount < 0)
                throw new InvalidOperationException();

            int possibleProjectiles = GetPossibleProjectiles(_projectilesPerShot, _bulletsAmount);
            int finalDamage = _damage * possibleProjectiles;
            player.TakeDamage(finalDamage);
        }

        private int GetPossibleProjectiles(int projectilesPerShot, int amount)
        {
            if (amount - projectilesPerShot < 0)
            {
                int requiredProjectiles = amount;
                amount = 0;
                return requiredProjectiles;
            }

            amount -= projectilesPerShot;
            return projectilesPerShot;
        }
    }
}
