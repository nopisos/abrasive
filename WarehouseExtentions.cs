using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop
{
    public class Cart
    {
        private readonly Warehouse _warehouse;
        private readonly List<StackedGood> _orderedGoods = new List<StackedGood>();

        public Cart(Warehouse warehouse)
        {
            _warehouse = warehouse ?? throw new ArgumentNullException(nameof(warehouse));
        }

        public void Add(Good good, int count)
        {
            if (good == null)
                throw new ArgumentNullException(nameof(good));

            if (!_warehouse.Available(good, count))
                throw new InvalidOperationException();

            StackedGood stackedGood = _orderedGoods.FirstOrDefault(stacked => stacked.Good == good);

            if (stackedGood != null)
                stackedGood.Add(good, count);
            else
                _orderedGoods.Add(new StackedGood(good, count));
        }

        public Order Order()
        {
            return new Order("https://www.youtube.com/watch?v=cfD9Oz_8BwM");
        }
    }
}
