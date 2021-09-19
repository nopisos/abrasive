using System;
using System.Collections.Generic;

namespace Shop
{
    public class Cart
    {
        private readonly Shop _shop;
        private readonly List<StackedGood> _orderedGoods = new List<StackedGood>();

        public Cart(Shop shop)
        {
            _shop = shop ?? throw new ArgumentNullException(nameof(shop));
        }

        public void Add(Good good, int count)
        {
            if (good == null)
                throw new ArgumentNullException(nameof(good));

            if (!_shop.GoodsCountAvailable(good, count))
                throw new InvalidOperationException();

            StackedGood stackedGood = _orderedGoods.FirstOrDefault(stacked => stacked.Good == good);

            if (stackedGood != null)
                stackedGood.Merge(new StackedGood(good, count));
            else
                _orderedGoods.Add(new StackedGood(good, count));
        }

        public Order Order()
        {
            return new Order("https://www.youtube.com/watch?v=cfD9Oz_8BwM");
        }
    }
}
