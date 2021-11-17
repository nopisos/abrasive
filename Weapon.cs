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

        public bool CanFire => _ammo.CanEject;

        public void Fire(Player player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            if (!CanFire)
                throw new InvalidOperationException();
            
            int possibleProjectiles = _ammo.GetPossibleProjectiles(_projectilesPerShot);
            int finalDamage = _damage * possibleProjectiles;
            player.TakeDamage(finalDamage);
        }
    }
}
