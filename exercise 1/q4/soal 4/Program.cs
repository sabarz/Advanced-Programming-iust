using System;

namespace soal_3
{
    class Program
    {
        static void Main()
        {
            int counter = 0, ans = 0;

            int n = int.Parse(Console.ReadLine());
            string khaiaban = Console.ReadLine();
            string[] st = Console.ReadLine().Split(' ');
            int s = int.Parse(st[0]);
            int t = int.Parse(st[1]);

            if (s > t)
            {
                int hold = t;
                t = s;
                s = hold;
            }
            int[] a = new int[10] { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512 };

            for (int i = s - 1; i < t; i++)
            {
                if (khaiaban[i] == 'H')
                {
                    counter++;
                }

                else if (counter != 0)
                {
                    while (counter != 0)
                    {
                        for (int j = 1; j < 10; j++)
                        {
                            if (counter >= a[j - 1] && counter < a[j])
                            {
                                counter -= a[j - 1];
                                ans++;
                                break;
                            }
                        }
                    }
                }
            }

            Console.WriteLine(ans);
        }
    }
}
