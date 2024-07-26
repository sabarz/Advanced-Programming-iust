using System;

namespace soal_7
{
    class Program
    {
        static void Main()
        {
            int m = int.Parse(Console.ReadLine());
            int[] ar = new int[m];

            string[] st = Console.ReadLine().Split(' '); 
            for(int i = 0; i < m; i ++)
            {
                ar[i] = int.Parse(st[i]); 
            }

            Console.WriteLine(Math.Round(average(ar , m , 0),2));
        }
        static float average(int[] a, int n, int level)
        {
            if (n == 1)
                return a[level]; 

            if (level == 0)
                return (a[level] + average(a, n, level + 1)) / n;

            else if (level == n - 1)
                return a[level];

            return average(a, n, level + 1) + a[level];
        }
    }
}
