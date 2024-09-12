using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    class Example
    {       
        private void Test()
        {
            //пишет лог в файл
            ILogger fileWriter = new FileWriter();

            //пишет в консоль
            ILogger consoleWriter = new ConsoleWriter();

            //пишет лог в файл по пятницам
            ILogger fridayFileWriter = new OnlyFridayWriter(new FileWriter());

            //пишет лог в консоль по пятницам
            ILogger pathfinder = new OnlyFridayWriter(new ConsoleWriter());

            //пишет лог в консоль, а по пятницам ещё и в файл
            ILogger writer = new ConsoleWriterDecorator(new OnlyFridayWriter(new FileWriter()));
        }
    }
}
