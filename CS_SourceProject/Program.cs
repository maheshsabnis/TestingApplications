using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_SourceProject
{
    public class Program
    {
        public static List<string> lstGlobal = new List<string>();  
        public static void Main()
        {

            Banking b = new Banking(20000);
            // Subscribing to the Notification from Bank
            EventListener evt = new EventListener(b);
            b.Deposit(90000);
            Console.WriteLine($"Net Balance after deposit {b.ShowBalance()}");
            b.Withdrawal(108000);
            Console.WriteLine($"Net Balance afeter withdrawal {b.ShowBalance()}");

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

        public static bool PositiveValue(int x)
        {
            if (x < 0) return false;
            return true;
        }

        public static void AddListData(string name)
        {
            lstGlobal.Add(name);
        }

        public static int AddIntegers(int first, int second)
        {
            int sum = first;
            for (int i = 0; i < second; i++)
            {
                sum += 1;
            }
            return sum;
        }
    }




}
