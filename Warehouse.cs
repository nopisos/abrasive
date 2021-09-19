using System;
using System.Collections.Generic;

namespace Shop
{
    public class Warehouse
    {
        private readonly List<StackedGood> _goods = new List<StackedGood>();

        public void Delive(Good good, int count)
        {
            if (good == null)
                throw new ArgumentNullException(nameof(good));

            StackedGood stackedGood = _goods.FirstOrDefault(stacked => stacked.Good == good);

            if(stackedGood != null)
                stackedGood.Merge(new StackedGood(good, count));
            else
                _goods.Add(new StackedGood(good, count));
        }

        public bool IsGoodsCountAvailable(Good good, int count)
        {
            if (good == null)
                throw new ArgumentNullException(nameof(good));

            StackedGood stackedGood = _goods.FirstOrDefault(stacked => stacked.Good == good);

            if(stackedGood != null)
                return stackedGood.Count >= count;
            else
                return false;
        }
    }
}
