using System;

namespace soal_3
{
    class program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int a = 2;
            string ans = "YES";
            
            while(n > a)
            {
                if(n % a == 0)
                {
                    ans = "NO";
                    break;
                }

                else
                {
                    n -= (n / a);
                    a++;
                }
            }

            Console.WriteLine(ans);
        }
    }
}