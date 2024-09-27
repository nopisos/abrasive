using System;

namespace OCPrefactoring
{
    public class QIWI : PaymentSystem
    {
        public override void Call()
        {
            Console.WriteLine("Перевод на страницу QIWI...");
        }
    }
}