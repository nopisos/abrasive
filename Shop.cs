using System;

namespace Shop
{
    public class Shop
    {
        private readonly Warehouse _warehouse;

        public Shop(Warehouse warehouse)
        {
            _warehouse = warehouse ?? throw new ArgumentNullException(nameof(warehouse));
        }

        public bool GoodsCountAvailable(Good good, int count) => _warehouse.IsGoodsCountAvailable(good, count);

        public Cart Cart()
        {
            return new Cart(this);
        }
    }
}
