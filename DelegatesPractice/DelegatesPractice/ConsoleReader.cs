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
        public delegate void onWord(string value);
        public delegate void onNumber(string value);
        public delegate void onJunk(string value);

        public void Word(string value)
        {
            Console.WriteLine("Calling onWord Delegate. Your input is " + value);
        }

        public void Number(string value)
        {
            Console.WriteLine("Calling onNumber Delegate. Your input is " + value);
        }

        public void Junk(string value)
        {
            Console.WriteLine("Calling onJunk Delegate. Your input is " + value);
        }

        public void runConsole()
        {
            Task task = Task.Run(() =>
            {
                while (true)
                {
                    Console.WriteLine("Enter Input");
                    string inputFromConsole = Console.ReadLine();
                    ReadingValue(inputFromConsole);
                    Task.Delay(3000);
                }
            });
            task.Wait();
        }

        public void ReadingValue(string inputFromConsole)
        {
            ConsoleReader reader = new ConsoleReader();
            onWord wordDelegates = new onWord(reader.Word);
            onNumber numberDelegates = new onNumber(reader.Number);
            onJunk junkDelegates = new onJunk(reader.Junk);

            if(inputFromConsole.All(char.IsDigit) == true)
            {
                numberDelegates(inputFromConsole);
            } else if (Regex.IsMatch(inputFromConsole, "^[a-zA-Z0-9]*$"))
            {
                wordDelegates(inputFromConsole);
            } else if (!Regex.IsMatch(inputFromConsole, "^[a-zA-Z0-9]*$"))
            {
                junkDelegates(inputFromConsole);
            }
        }        
    }
}
