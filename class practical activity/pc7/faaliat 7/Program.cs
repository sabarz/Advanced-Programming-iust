using System;
using System.Collections.Generic;
using System.Collections;

namespace faaliat_6
{
    class LimitedColection<type> : IEnumerable<type> 
        where type : IComparable<type>
    {
        private int n = 0;
        private type bala;
        private type payin;
        private List<type> s;
        public LimitedColection(type bala, type payin)
        {
            this.bala = bala;
            this.payin = payin;
            s = new List<type>();
        }
        public int N
        {
            get { return n; }
        }
        public void insert(type x)
        {
            if (x.CompareTo(bala) < 0 && x.CompareTo(payin) > 0)
            {
                s.Add(x);
                n++;
            }
            else
            {
                Console.WriteLine("it is not in limit!");
            }
        }
        public void remove()
        {
            if (N > 0)
            {
                type temp = s[0];

                foreach (var i in s)
                {
                    if (i.CompareTo(temp) < 0)
                    {
                        temp = i;
                    }
                }
                s.Remove(temp);
            }

            else
            {
                try
                {
                    throw new Exception("no member");
                }
                catch
                {
                    Console.WriteLine("no member!");
                }
            }

        }
        public IEnumerator<type> GetEnumerator()
        {
            foreach(var i in s)
            {
                yield return i;
            }
        }
        public IEnumerable<type> Reverse
        {
            get
            {
                for (int i = N-1; i >= 0; i--)
                {
                    yield return s[i];
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter had bala and had payin");
            string[] a = new string[2];
            a = Console.ReadLine().Split(' ');

            LimitedColection<string> limitedcolect = new LimitedColection<string>(a[0], a[1]);

            string[] b = Console.ReadLine().Split(' ');
           
            foreach (var i in b)
            {
                limitedcolect.insert(i);
            }

            foreach(var i in limitedcolect)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine(" ");

            foreach(var i in limitedcolect.Reverse)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("enter had bala and had payin");
            a = Console.ReadLine().Split(' ');
            int[] c = new int[2];
            c[0] = int.Parse(a[0]);
            c[1] = int.Parse(a[1]);

            LimitedColection<int> limitedcolect2 = new LimitedColection<int>(c[0], c[1]);

            string[] d = Console.ReadLine().Split(' ');

            foreach (var i in d)
            {
                int hold = int.Parse(i);
                limitedcolect2.insert(hold);
            }

            foreach (var i in limitedcolect2)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine(" ");

            foreach (var i in limitedcolect2.Reverse)
            {
                Console.WriteLine(i);
            }
        }
    }
}
