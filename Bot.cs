using System;

namespace Weapon
{
    public class Bot
    {
        private readonly Weapon _weapon;

        public Bot(Weapon weapon)
        {
            if (weapon == null)
                throw new ArgumentNullException(nameof(weapon));

            _weapon = weapon;
        }

        public void OnSeePlayer(Player player)
        {
            if (!player.IsAlive)
                throw new InvalidOperationException();

            if (_weapon.CanFire)
                _weapon.Fire(player);
        }
    }
}
