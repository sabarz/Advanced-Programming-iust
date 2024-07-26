using System;

namespace faaliat_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int hold = n;

            for (int i = 1; i <= (2 * n) - 1; i++)
            {
                int p = i % n;

                if (i >= n)
                {
                    p += hold;
                    hold -= 2;
                }

                for (int j = 1; j <= n - p; j++)
                    Console.Write(" ");

                for (int j = 1; j <= p; j++)
                    Console.Write("* ");

                Console.WriteLine();
            }

        }
    }
}
