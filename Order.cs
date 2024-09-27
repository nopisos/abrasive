using System;

namespace Shop
{
    public class Order
    {
        public Order(string paylink)
        {
            Paylink = paylink ?? throw new ArgumentNullException(nameof(paylink));
        }

        public string Paylink { get; }
    }
}
