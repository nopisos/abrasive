using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                stackedGood.Add(good, count);
            else
                _goods.Add(new StackedGood(good, count));
        }

        public bool Available(Good good, int count)
        {
            if (good == null)
                throw new ArgumentNullException(nameof(good));

            StackedGood stackedGood = _goods.FirstOrDefault(stacked => stacked.Good == good);

            if(stackedGood != null)
                return stackedGood.Count >= count;
            else
                return false;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var stackedGood in _goods)
                builder.AppendLine(stackedGood.ToString());

            return builder.ToString();
        }
    }
}
