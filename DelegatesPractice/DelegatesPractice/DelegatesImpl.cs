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

        /*public static void onWord(string value)
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
        }*/

        public static void DelegateCallBack(string value, DelegatesPrac delegatesPrac)
        {
            delegatesPrac(value);
        }

        public static void ReadingValue(string inputFromConsole)
        {
            InputTypeFactory inputTypeFactory = new InputTypeFactory();
            IInputType inputType = inputTypeFactory.createInputType(inputFromConsole);
            inputType.printInputType(inputFromConsole);

            //DelegatesPrac delegatesPrac = null;

            /*if (inputFromConsole.All(char.IsDigit) == true)
            {
                DelegatesImpl.onNumber(inputFromConsole);
                *//*delegatesPrac += onNumber;
                delegatesPrac.Invoke(inputFromConsole);*//*
            }
            else if (Regex.IsMatch(inputFromConsole, "^[a-zA-Z0-9]*$"))
            {
                DelegatesImpl.onWord(inputFromConsole);
                *//*delegatesPrac += onWord;
                delegatesPrac.Invoke(inputFromConsole);*//*
            }
            else if (!Regex.IsMatch(inputFromConsole, "^[a-zA-Z0-9]*$"))
            {
                DelegatesImpl.onJunk(inputFromConsole);
                *//*delegatesPrac += onJunk;
                delegatesPrac.Invoke(inputFromConsole);*//*
            }*/
        }



        public interface IInputType
        {
            void printInputType(string input);
        }


        public class WordInputType : IInputType
        {
            public void printInputType(string input)
            {
                Console.WriteLine("Calling onWord Delegate. Your input is " + input);
            }

        }

        public class NumberInputType : IInputType
        {
            public void printInputType(string input)
            {
                Console.WriteLine("Calling onNumber Delegate. Your input is " + input);
            }

        }

        public class JunkInputType : IInputType
        {
            public void printInputType(string input)
            {
                Console.WriteLine("Calling onJunk Delegate. Your input is " + input);
            }

        }


        public class InputTypeFactory
        {
            public IInputType createInputType(string inputType)
            {

                if (inputType.All(char.IsDigit) == true)
                {
                    return new NumberInputType();
                }
                else if (Regex.IsMatch(inputType, "^[a-zA-Z0-9]*$"))
                {
                    return new WordInputType();
                }
                else if (!Regex.IsMatch(inputType, "^[a-zA-Z0-9]*$"))
                {
                    return new JunkInputType();
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
