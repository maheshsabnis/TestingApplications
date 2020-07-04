using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_SourceProject
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Hello World");
        }

        public static int Add(int x,int y)
        {
            return x + y;
        }

        public static int Sub(int x, int y)
        {
            return x - y;
        }

        public static int Divide(int x,int y)
        {
            if (y == 0)
            {
                throw new DivideByZeroException("Denominator cannot be zero 0");
            }
            return x / y;
        }
    }




}
