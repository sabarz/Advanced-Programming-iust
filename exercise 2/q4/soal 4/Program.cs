using System;

namespace soal_4
{
    class Program
    {
        static void Main()
        {
            TwoComplex tc = new TwoComplex();
            tc.start();
            bool end = false;
            int hold;

            do
            {
                Console.WriteLine("for add enter 1");
                Console.WriteLine("for sub enter 2");
                Console.WriteLine("for mul enter 3");
                Console.WriteLine("for div enter 4");
                Console.WriteLine("for change number enter 5");
                Console.WriteLine("for end enter 6");

                hold = int.Parse(Console.ReadLine());

                if (hold == 1)
                    tc.Add();

                else if (hold == 2)
                    tc.Sub();

                else if (hold == 3)
                    tc.Mul();

                else if (hold == 4)
                    tc.Div();

                else if (hold == 5)
                    tc.changeInfo();

                else if (hold == 6)
                    end = true;

            } while (!end);
        }
    }

    class TwoComplex
    {
        private int a;
        private int b;
        private int c;
        private int d;

        public void start()
        {
            a = int.Parse(Console.ReadLine()); 
            b = int.Parse(Console.ReadLine());
            c = int.Parse(Console.ReadLine());
            d = int.Parse(Console.ReadLine());
        }

        public void Add()
        {
            Console.WriteLine("{0} + {1}i", a+c, b+d);
        }
        public void Sub()
        {
            Console.WriteLine("{0} + {1}i",a-c, b-d);
        }
        public void Mul()
        {
            Console.WriteLine("{0} + {1}i", a * c - b * d, a * c - b * d);
        }
        public void Div()
        {
            Console.WriteLine("{0}/{1} + {2}/{3}i", a * c + b * d, c * c + d * d, b * c - a * d, c * c + d * d);
        }
        public void changeInfo()
        {
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
            c = int.Parse(Console.ReadLine());
            d = int.Parse(Console.ReadLine());
        }
    }

}
