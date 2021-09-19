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

        public void Merge(StackedGood stackedGood)
        {
            if (Good != stackedGood.Good)
                throw new InvalidOperationException();

            Count += stackedGood.Count;
        }
    }
}
