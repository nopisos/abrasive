using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCPrefactoring
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderForm orderForm = new OrderForm();
            string id = orderForm.ShowForm();
            SystemInitializer initializer = new SystemInitializer();
            PaymentSystem system = initializer.Get(id);
            system.Call();
            system.ShowPaymentResult();
        }
    }
}