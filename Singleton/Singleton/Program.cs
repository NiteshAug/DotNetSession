using System;

namespace Singleton
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Counter.GetInstance.Increment();
            Counter.GetInstance.Increment();
            Counter.GetInstance.Increment();

            Console.WriteLine("Decrement Started");

            Counter.GetInstance.Decrement();
            Counter.GetInstance.Decrement();
            Counter.GetInstance.Decrement();
            Console.ReadLine();
        }
    }
}
