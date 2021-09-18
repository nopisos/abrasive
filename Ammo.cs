using System;

namespace Weapon
{
    public class Ammo
    {
        private int _quantity;

        public Ammo(int quantity)
        {
            if (quantity < 0)
                throw new ArgumentOutOfRangeException(nameof(quantity));

            _quantity = quantity;
        }

        public bool CanEject => _quantity > 0;

        public void Eject(int projectilesPerShot)
        {
            if (_quantity < 0)
                throw new InvalidOperationException();

            if (_quantity - projectilesPerShot < 0)
                _quantity = 0;
            else
                _quantity -= projectilesPerShot;
        }
    }
}
