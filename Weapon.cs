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

        public int BulletsAfterShoot => _bulletsAmount - _projectilesPerShot;

        public bool CanFire(Player player) => BulletsAfterShoot >= 0 && _bulletsAmount > 0 && player.IsAlive;

        public void Fire(Player player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            if (!CanFire(player))
                throw new InvalidOperationException();

            _bulletsAmount -= _projectilesPerShot;
            int finalDamage = _damage * _projectilesPerShot;
            player.TakeDamage(finalDamage);
        }
    }
}
