using System;

namespace soal_6
{
    class Program
    {
        static void square (ref int a)
        {
            a = a * a; 
        }

        static void Sum (out int b, int[] t)
        {
            b = 0; 

            for(int i = 0; i < 10 ; i++)
            {
                b += t[i]; 
            }
        }
        static void Main()
        {
            int[] a = new int[10];
           
            for (int i = 0; i < 10; i++)
            {
                Random r = new Random();
                a[i] = r.Next(1000); 
                square(ref a[i]);
            }

            int b;
            Sum(out b, a);

            Console.WriteLine(b);
        }
    }
}
