using System;

namespace soal_1
{
    class Program
    {
        static void Main()
        {
           
            long hold = int.Parse(Console.ReadLine());
            int p = 0;
          
            for (int i = 2; i <= hold; i++)
            {
                p = 1;
                while (hold % i == 0)
                {
                    hold /= i;

                    if (p == 1)
                    {
                        p = 0;
                        Console.Write(i + " ");
                    }
                }
            }
        }
    }
}
