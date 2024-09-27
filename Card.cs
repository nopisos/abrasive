using System;

namespace OCPrefactoring
{
    public class Card : PaymentSystem
    {
        public override void Call()
        {
            Console.WriteLine("Вызов API банка эмитера карты Card...");
        }
    }
}