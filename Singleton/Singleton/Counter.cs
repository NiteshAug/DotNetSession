using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton
{
    public class Counter
    {
        static int count = 0;
        private static Counter getInstance = null;
        public Counter()
        {
            count++;
            Console.WriteLine("Instances created " + count);
        }

        public static Counter GetInstance
        {
            get
            {
                if (getInstance == null)
                {
                    getInstance = new Counter();
                }
                return getInstance;
            }
        }

        public int Increment()
        {
            Console.WriteLine(count++);
            return count++;
        }

        public int Decrement()
        {
            Console.WriteLine(count--);
            return count--;
        }
    }
}
