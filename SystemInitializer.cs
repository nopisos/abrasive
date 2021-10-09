using System;

namespace OCPrefactoring
{
    public class SystemInitializer
    {
        public PaymentSystem Get(string id)
        {
            switch (id)
            {
                case "QIWI":
                    return new QIWI();
                case "WebMoney":
                    return new WebMoney();
                case "Card":
                    return new Card();
            }

            throw new ArgumentException(nameof(id));
        }
    }
}