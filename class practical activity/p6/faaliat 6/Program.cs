using System;
using System.Collections.Generic;
using System.Linq;

namespace faaliat_6
{
    class LimitedColection<type> where type : IComparable<type>
    {
        private int n = 0;
        private type bala ;
        private type payin;
        private List<type> s;
        public LimitedColection(type bala , type payin)
        {
            this.bala = bala;
            this.payin = payin;
            s = new List<type>() ;
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

                foreach(var i in s)
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

        public void ItemAccepted()
        {
            foreach(var i in s)
            {
                Console.WriteLine(i);
            }
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

            limitedcolect.ItemAccepted();
            limitedcolect.remove();
            limitedcolect.ItemAccepted();

            Console.WriteLine("enter had bala and had payin");
            a = Console.ReadLine().Split(' ');
            int[] c = new int[2];
            c[0] = int.Parse(a[0]);
            c[1] = int.Parse(a[1]);

            LimitedColection<int> limitedcolect2 = new LimitedColection<int>(c[0], c[1]);

            string[] d = Console.ReadLine().Split(' ');

            foreach(var i in d)
            {
                int hold = int.Parse(i);
                limitedcolect2.insert(hold);
            }
            
            limitedcolect2.ItemAccepted();
            limitedcolect2.remove();

        }
    }
}
