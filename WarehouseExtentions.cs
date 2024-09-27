using System;

namespace Shop
{
    public static class WarehouseExtentions
    {
        public static Cart Cart(this Warehouse warehouse)
        {
            return new Cart(warehouse);
        }
    }
}
