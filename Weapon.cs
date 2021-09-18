using System;

namespace Weapon
{
    public class Weapon
    {
        private readonly int _damage;
        private readonly int _projectilesPerShot;
        private readonly Ammo _ammo;

        public Weapon(int damage, Ammo ammo, int projectilesPerShot)
        {
            _damage = damage;
            _ammo = ammo;
            _projectilesPerShot = projectilesPerShot;
        }

        public bool IsReadyToShoot => _ammo.CanEject;

        public void Fire(Player player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            if (!player.IsAlive)
                throw new InvalidOperationException();

            if (!IsReadyToShoot)
                throw new InvalidOperationException();

            _ammo.Eject(_projectilesPerShot);
            int finalDamage = _damage * _projectilesPerShot;
            player.TakeDamage(finalDamage);
        }
    }
}
