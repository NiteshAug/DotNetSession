﻿using WebApplication2.Interface;

namespace WebApplication2.Service
{
    public class MathService : IMath
    {
        public int Add(int x, int y)
        {
            return x + y;
        }

        public int Divide(int x, int y)
        {
            return  x / y;
        }

        public int Multiply(int x, int y)
        {
            return x * y;
        }

        public int Substract(int x, int y)
        {
            return x - y;
        }
    }
}
