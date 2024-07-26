using System;

namespace soal_1
{
    static class ExtenionMethos
    {
        public static int counZiros(this int i)
        {
            int ans = 0;
            string hold = i.ToString();
            
            for(int j = 0; j < hold.Length; j++)
            {
                if(hold[j] == '0')
                {
                    ans++;
                }
            }

            return ans;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int i = 80039380;
           Console.WriteLine( i.counZiros());
        }
    }
}
