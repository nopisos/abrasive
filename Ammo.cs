using System;

namespace Weapon
{
    public class Ammo
    {
        private int _amount;

        public Ammo(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            _amount = amount;
        }

        public bool CanEject => _amount > 0;

        public int GetPossibleProjectiles(int projectilesQuantity)
        {
            if (_amount < 0)
                throw new InvalidOperationException();

            if (_amount - projectilesQuantity < 0)
            {
                int requiredProjectiles = _amount;
                _amount = 0;
                return requiredProjectiles;
            }
                
            _amount -= projectilesQuantity;
            return projectilesQuantity;
        }
    }
}
