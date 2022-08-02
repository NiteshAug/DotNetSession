using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DelegatesPractice
{
    public static class DelegatesImpl
    {
        public delegate void DelegatesPrac(string value);

        public static void onWord(string value)
        {
            Console.WriteLine("Calling onWord Delegate. Your input is " + value);
        }

        public static void onNumber(string value)
        {
            Console.WriteLine("Calling onNumber Delegate. Your input is " + value);
        }

        public static void onJunk(string value)
        {
            Console.WriteLine("Calling onJunk Delegate. Your input is " + value);
        }

        public static void DelegateCallBack(string value, DelegatesPrac delegatesPrac)
        {
            delegatesPrac(value);
        }

        public static void ReadingValue(string inputFromConsole)
        {
            DelegatesPrac delegatesPrac = null;

            if (inputFromConsole.All(char.IsDigit) == true)
            {
                delegatesPrac += onNumber;
                delegatesPrac.Invoke(inputFromConsole);
            }
            else if (Regex.IsMatch(inputFromConsole, "^[a-zA-Z0-9]*$"))
            {
                delegatesPrac += onWord;
                delegatesPrac.Invoke(inputFromConsole);
            }
            else if (!Regex.IsMatch(inputFromConsole, "^[a-zA-Z0-9]*$"))
            {
                delegatesPrac += onJunk;
                delegatesPrac.Invoke(inputFromConsole);
            }
        }
    }
}
