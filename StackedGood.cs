using System;

namespace Shop
{
    public class StackedGood
    {
        public StackedGood(Good good, int count)
        {
            Good = good ?? throw new ArgumentNullException(nameof(good));

            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            Count = count;
        }

        public Good Good { get; private set; }
        public int Count { get; private set; }

        public void Add(Good good, int count)
        {
            if (Good != good)
                throw new InvalidOperationException();

            Count += count;
        }
    }
}
