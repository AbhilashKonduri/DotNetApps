using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App20
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10, b = 20;

            swap(ref a, ref b);
            //int temp = a;
            //a = b; // copying value of b to a
            //b = temp; // copying value of temp to b
            int s, p;

            SumProduct(a, b, out s, out p);

            Console.WriteLine(a + " " +b);
        }
        static void swap( ref int x, ref int y) // here X and y are new objects (without out)
                                        // here  x and y are referance variables if given ref int x => X ref to object a and Y ref to obj b
                                        // In call w give swap(ref x, ref y)
        {
            
            int temp = x;
            x = y; // copying value of y to x
            y = temp; // copying value of temp to y
        }

        static void SumProduct(int a, int b, out int sum, out int product)
        {
            sum = a + b;
            product = a * b;
            
        }
    }
}
