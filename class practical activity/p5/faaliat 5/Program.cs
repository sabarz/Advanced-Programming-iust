using System;

namespace faaliat_5
{
    enum ctype {hatchback , SUV , sedan , coupe};
    interface IDrive
    {
        string UseFor();
    }

    class Vehicle
    {
        private string name;
        private int num;
        
        public Vehicle(int num , string name)
        {
            this.num = num;
            this.name = name;
        }

    }

    class Car : Vehicle,IDrive
    {
        private ctype type; 

        public Car(int num , string name , ctype type) : base(num , name)
        {
            this.type = type; 
        }
        public string UseFor()
        {
            return "use for traveling";
        }
    }

    class Truck : Vehicle , IDrive
    {
        bool havetrailer;

        public Truck(int num, string name, bool havetr) : base(num, name)
        {
            havetrailer = havetr;
        }

        public string UseFor()
        {
            return "use for transportation";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] T = new string[3];
            Console.WriteLine("enter truck information");
            T = Console.ReadLine().Split(' ');
            bool tr;

            if (T[2] == "yes")
            {
                tr = true;
            }
            else
            {
                tr = false;
            }

            Truck truck = new Truck(int.Parse(T[1]), T[0], tr);

            string[] C = new string[3];
            Console.WriteLine("enter car information");
            C = Console.ReadLine().Split(' ');

            Car car = new Car(int.Parse(C[1]), C[0], (ctype)Enum.Parse(typeof(ctype), C[2], true);               

            IDrive[] drive = new IDrive[2];
            drive[0] = truck;
            drive[1] = car;

            Console.WriteLine(drive[0].UseFor());
            Console.WriteLine(drive[1].UseFor());
        }
    }
}
