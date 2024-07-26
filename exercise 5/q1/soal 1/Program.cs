using System;
using System.Collections.Generic;

namespace soal_1
{
    class Point
    {
        private int x, y;

        public Point(int x , int y)
        {
            this.x = x;
            this.y = y;
        }

        public virtual void print()
        {
            Console.WriteLine("x : {0}  y : {1}", x, y);
        }

        public virtual int NumberShape()
        {
            return x + y;
        }

        public virtual void Information()
        {

        }
    }

    class Circle : Point
    {
        private int r;     
        public Circle(int r , int x , int y) : base(x , y)
        {
            this.r = r;
        }

        public double masahat()
        {
            return 3.14 * r * r;
        }

        public double mohit()
        {
            return 2 * 3.14 * r;
        }
        public override void print()
        {
            base.print();
            Console.WriteLine("r : {0}", r);
        }
        public override int NumberShape()
        {
            return base.NumberShape() + r; 
        }
        public override void Information()
        {
            Console.WriteLine("mohit : {0} ", mohit());
            Console.WriteLine("masahat : {0} ", masahat());
        }
    }

    class Cylinder : Circle
    {
        private int h;

        public Cylinder(int h , int r , int x , int y) : base(r , x , y)
        {
            this.h = h;
        }
        public double hajm()
        {
            return base.masahat() * h; 
        }
        public double mohit()
        {
            return base.mohit() * h;
        }
        public double masahat()
        {
            return 2 * base.masahat() + h * base.mohit();
        }
        public override void print()
        {
            base.print();
            Console.WriteLine("h : {0}", h);
        }
        public override int NumberShape()
        {
            return base.NumberShape() + h;
        }
        public override void Information()
        {
            Console.WriteLine("mohit : {0} ", mohit());
            Console.WriteLine("masahat : {0}", masahat());
            Console.WriteLine("hajm : {0}", hajm());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Point> lpoint = new List<Point>();
            string a1;
            do
            {
                Console.WriteLine("choose : NewObject  or ShowAll or Exit");
                a1 = Console.ReadLine();

                if (a1 == "NewObject")
                {
                    Console.WriteLine("choose : Circle , Point , Cylinder");
                    string a2 = Console.ReadLine();

                    if (a2 == "Circle")
                    {
                        Console.WriteLine("Enter r and x and y");
                        string[] b = new string[3];
                        b = Console.ReadLine().Split(' ');
                        Circle circle = new Circle(int.Parse(b[0]), int.Parse(b[1]), int.Parse(b[2]));
                        circle.print();
                        Console.WriteLine("mohit : {0} ", circle.mohit());
                        Console.WriteLine("masahat : {0} ", circle.masahat());
                        Console.WriteLine("number : {0}", circle.NumberShape());
                        lpoint.Add(circle);
                    }
                    else if (a2 == "Point")
                    {
                        Console.WriteLine("Enter x and y");
                        string[] b = new string[2];
                        b = Console.ReadLine().Split(' ');
                        Point point = new Point(int.Parse(b[0]), int.Parse(b[1]));
                        point.print();
                        Console.WriteLine("number : {0}", point.NumberShape());
                        lpoint.Add(point);
                    }
                    else if (a2 == "Cylinder")
                    {
                        Console.WriteLine("Enter h and r and x and y");
                        string[] b = new string[4];
                        b = Console.ReadLine().Split(' ');
                        Cylinder cylinder = new Cylinder(int.Parse(b[0]), int.Parse(b[1]), int.Parse(b[2]), int.Parse(b[3]));
                        cylinder.print();
                        Console.WriteLine("hajm : {0}", cylinder.hajm());
                        Console.WriteLine("mohit : {0} ", cylinder.mohit());
                        Console.WriteLine("masahat : {0}", cylinder.masahat());
                        Console.WriteLine("number : {0}", cylinder.NumberShape());
                        lpoint.Add(cylinder);
                    }
                }

                else if (a1 == "ShowAll")
                {
                    for (int i = 0; i < lpoint.Count; i++)
                    {
                        lpoint[i].print();
                        lpoint[i].Information();
                        lpoint[i].NumberShape();
                    }
                }
            } while (a1 != "Exit");
        }
    }
}
