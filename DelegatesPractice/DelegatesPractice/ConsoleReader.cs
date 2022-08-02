using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DelegatesPractice
{
    public class ConsoleReader
    {
        public void runConsole()
        {
            Task task = Task.Run(() =>
            {
                while (true)
                {
                    Console.WriteLine("Enter Input");
                    string inputFromConsole = Console.ReadLine();
                    DelegatesImpl.DelegatesPrac del = DelegatesImpl.ReadingValue;
                    DelegatesImpl.DelegateCallBack(inputFromConsole, del);
                    Task.Delay(3000);
                }
            });
            task.Wait();
        }            
    }
}
