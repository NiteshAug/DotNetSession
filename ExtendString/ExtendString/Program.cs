using System;
using System.Linq;

namespace ExtendString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program pg =new Program();
            Console.WriteLine("Enter Value");
            string Value = Console.ReadLine();            
            Console.WriteLine(pg.ToCurrency(Value));
        }

        public string ToCurrency(string value)
        {
            bool result = value.All(char.IsDigit);
            if (result)
            {
                return "$" + value;
            } else
            {
                return value;
            }
            
        }
    }
}
