using System;
using System.IO;

namespace soal_2
{
    class Circle
    {
        private int tool;
        private int arz;
        private int shoaa; 

        public Circle(int tool , int arz , int shoaa)
        {
            this.tool = tool;
            this.arz = arz;
            this.shoaa = shoaa;
        }

        public double mohit()
        {
            return 3.14 * 2 * shoaa; 
        }

        public double masahat()
        {
            return 3.14 * shoaa * shoaa; 
        }

        public double faseleMabda()
        {
            return Math.Sqrt(Math.Pow(tool, 2) + Math.Pow(arz, 2)); 
        }

        public double faseleMarkaz(int x , int y)
        {
            return Math.Sqrt(Math.Pow(x-tool, 2) + Math.Pow(y-arz, 2));
        }

        public string HastNist(int x , int y)
        {
            double fasele = faseleMarkaz(x, y);    

                if (fasele < shoaa)
                return "dakhel";

            else if (fasele == shoaa)
                return "rooye dayere";

            else
                return "biroon"; 
        }
        public Circle copy()
        {
            if((shoaa*2)-3 == 0)
                return new Circle(tool - 2, arz + 1,1);

            else
            return new Circle(tool - 2, arz + 1,Math.Abs((2 * shoaa)-3)); 
        }

    }
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int shoaa, arz, tool, x, y;

            StreamWriter writer = new StreamWriter("circle.txt");
            Circle[] c = new Circle[2 * n];

            for (int i = 0; i < 2 * n; i = +2)
            {
                do
                {
                    shoaa = int.Parse(Console.ReadLine());

                } while (shoaa <= 0);

                tool = int.Parse(Console.ReadLine());
                arz = int.Parse(Console.ReadLine());
                x = int.Parse(Console.ReadLine());
                y = int.Parse(Console.ReadLine());

                c[i] = new Circle(shoaa, tool, arz);
                c[i + 1] = c[i].copy();

                Console.WriteLine(c[i].mohit());
                Console.WriteLine(c[i].masahat());
                Console.WriteLine(c[i].faseleMarkaz(x, y));
                Console.WriteLine(c[i].HastNist(x, y));

                Console.WriteLine(c[i + 1].mohit());
                Console.WriteLine(c[i + 1].masahat());
                Console.WriteLine(c[i + 1].faseleMarkaz(x, y));
                Console.WriteLine(c[i + 1].HastNist(x, y));

                writer.WriteLine(c[i].mohit());
                writer.WriteLine(c[i].masahat());
                writer.WriteLine(c[i].faseleMarkaz(x, y));
                writer.WriteLine(c[i].HastNist(x, y));

                writer.WriteLine(c[i + 1].mohit());
                writer.WriteLine(c[i + 1].masahat());
                writer.WriteLine(c[i + 1].faseleMarkaz(x, y));
                writer.WriteLine(c[i + 1].HastNist(x, y));
            }

            double[] mohit = new double[2 * n];

            for (int i = 0; i < 2 * n; i++)
                mohit[i] = c[i].mohit();

            Array.Sort(mohit);

            foreach (double i in mohit)
            {
                Console.WriteLine(i);
                writer.WriteLine(i);
            }

            double[] masahat = new double[2 * n];

            for (int i = 0; i < 2 * n; i++)
                masahat[i] = c[i].masahat();

            Array.Sort(masahat);

            foreach (double i in masahat)
            {
                Console.WriteLine(i);
                writer.WriteLine(i);
            }

            double[] dis = new double[2 * n];

            for (int i = 0; i < 2 * n; i++)
                dis[i] = c[i].faseleMabda();

            Array.Sort(dis);

            foreach (double i in dis)
            {
                Console.WriteLine(i);
                writer.WriteLine(i);                   
            }
            writer.Close();

        }
    }
}
