using System;

namespace OCPrefactoring
{
    public class WebMoney : PaymentSystem
    {
        public override void Call()
        {
            Console.WriteLine("Вызов API WebMoney...");
        }
    }
}