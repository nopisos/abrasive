using System;

namespace OCPrefactoring
{
    public abstract class PaymentSystem
    {
        private string Name => GetType().Name;
        public abstract void Call();

        public void ShowPaymentResult()
        {
            Console.WriteLine($"Проверка платежа через {Name}...\n" +
                $"Оплата совершена с помощью {Name}\n" +
                $"Оплата прошла успешно!");
        }
    }
}