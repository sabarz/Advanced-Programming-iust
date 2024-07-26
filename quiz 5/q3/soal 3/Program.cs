using System;

namespace soal_3
{
    class Circle
    {
        int arz;
        int tool;
        int r;
        public Circle(int a,int b , int r)
        {
            this.r = r;
            arz = a;
            tool = b;
        }

        public void print()
        {
            Console.WriteLine("r : " + r);
            Console.WriteLine("arz markaz : " + arz);
            Console.WriteLine("tool markaz : " + tool);
        }
        public static Circle operator +(Circle c1, Circle c2)
        {
            return new Circle(c1.arz + c2.arz, c1.tool + c2.tool, c1.r + c2.r);
        }
        public static Circle operator -(Circle c1, Circle c2)
        {
            if(c1.r - c2.r < 0)
            {
                throw new Exception("wrong r");
            }
            return new Circle(c1.arz - c2.arz, c1.tool - c2.tool, c1.r - c2.r);
        }
        public static Circle operator *(Circle c1, Circle c2)
        {
            return new Circle(c1.arz * c2.arz, c1.tool * c2.tool, c1.r * c2.r);
        }
        public static bool operator ==(Circle c1, Circle c2)
        {
            if(c1.arz == c2.arz && c1.tool == c2.tool && c1.r == c2.r)
            {
                return true;
            }    
            else
            {
                return false;
            }
        }
        public static bool operator !=(Circle c1, Circle c2)
        {
            return !(c1 == c2);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Circle c1 = new Circle(0, 0, 10);
            Circle c2 = new Circle(5,3,6);
            Circle c3 = c1 + c2;
            c3.print();

            try
            {
                c3 = c1 - c2;
                c3.print();
            }
            catch
            {
                Console.WriteLine("wrong r");
            }
            c3 = c1 * c3;
            c3.print();

        }
    }
}
