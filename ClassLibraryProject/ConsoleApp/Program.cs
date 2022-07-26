using ClassLibrary;
using System;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Demo demo = new Demo();
            demo.message();

            //Static Class with Static Method
            Display.displayMessage();
        }
    }
}
