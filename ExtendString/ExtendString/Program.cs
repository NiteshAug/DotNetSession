using System;
using System.Linq;

namespace ExtendString
{
    public class Program
    {
        public void Example1()
        {
            Console.WriteLine("Print Example 1");
        }

        public void Example2()
        {
            Console.WriteLine("Print Example 2");
        }
        public static void Main(string[] args)
        {
            Program pg = new Program();
            pg.Example1();
            pg.Example2();

            //Calling Extension Method
            pg.Example4();
            pg.Example5("Print Example 5");
            Console.WriteLine(pg.ToCurrency("123"));
        }
    }
}
