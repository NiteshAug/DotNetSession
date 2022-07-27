using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtendString
{
    public static class ExtentionMethod
    {
        public static void Example4(this Program pg)
        {
            Console.WriteLine("Print Example 4");
        }

        public static void Example5(this Program pg, string value)
        {
            Console.Write(value);
        }

        public static string ToCurrency(this Program pg, string value)
        {
            bool result = value.All(char.IsDigit);
            if (result)
            {
                return "$" + value;
            }
            else
            {
                return value;
            }
        }
    }
}
