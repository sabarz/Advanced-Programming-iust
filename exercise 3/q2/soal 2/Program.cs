using System;
using System.IO;

namespace soal_2
{
    enum Animal { lion = 9600 , tiger = 9611 , bear = 9622 ,monkey = 9633 , elephant = 9644 , giraffe = 9655 , owl = 9666}
    enum Food { vegetable , meat}
    class Care
    {
        private int id;
        private Animal name;
        private string location;
        private Food food;
        private int number;
        private int[] schedule = new int[3];

        public Care(int id, Animal name , string location , Food food , int number , int[] schedule)
        {
            this.id = id;
            this.name = name;
            this.location = location;
            this.food = food;
            this.number = number;
            this.schedule = schedule;
        }

        public void SetSchedule(string food)
        {
            string hold;

            if (id == 9600)
                hold = "9600.txt";
            else if (id == 9611)
                hold = "9611.txt";
            else if (id == 9622)
                hold = "9622.txt";
            else if (id == 9633)
                hold = "9633.txt";
            else if (id == 9644)
                hold = "9644.txt";
            else if (id == 9655)
                hold = "9655.txt";
            else
                hold = "9666.txt";

            if (food == "vegetable")
            {
                var rand = new Random();
                schedule[0] = rand.Next(6, 23);
                schedule[1] = schedule[0] - 3;
                schedule[2] = schedule[1] - 2;

                File.WriteAllText(hold, string.Empty);

                StreamWriter writer = new StreamWriter(hold);

                writer.WriteLine("ID: {0}", id);
                writer.WriteLine("Location: {0}", location);
                writer.WriteLine("Food: {0}", this.food);
                writer.WriteLine("Schedule: {0}-{1}-{2}", schedule[0], schedule[1], schedule[2]);
                writer.WriteLine("Number: {0}", number);
                writer.Close();
            }

            else
            {
                if (schedule[2] == 22)
                {
                    var rand = new Random();
                    schedule[2] = rand.Next(17, 22);

                    File.WriteAllText(hold, string.Empty);

                    StreamWriter writer = new StreamWriter(hold);

                    writer.WriteLine("ID: {0}", id);
                    writer.WriteLine("Location: {0}", location);
                    writer.WriteLine("Food: {0}", this.food);
                    writer.WriteLine("Schedule: {0}-{1}-{2}", schedule[0], schedule[1], schedule[2]);
                    writer.WriteLine("Number: {0}", number);
                    writer.Close();
                }
            }
        }

        public void SaveToFile()
        {
            StreamWriter writer;
            if (id == 9600)
                writer = new StreamWriter("9600.txt");
            else if (id == 9611)
                writer = new StreamWriter("9611.txt");
            else if (id == 9622)
                writer = new StreamWriter("9622.txt");
            else if (id == 9633)
                writer = new StreamWriter("9633.txt");
            else if (id == 9644)
                writer = new StreamWriter("9644.txt");
            else if (id == 9655)
                writer = new StreamWriter("9655.txt");
            else
                writer = new StreamWriter("9666.txt");

            writer.WriteLine("ID: {0}", id);
            writer.WriteLine("Location: {0}", location);
            writer.WriteLine("Food: {0}", food);
            writer.WriteLine("Schedule: {0}-{1}-{2}", schedule[0], schedule[1], schedule[2]);
            writer.WriteLine("Number: {0}", number);

            writer.Close();
        }

        public static void AllInfo(Care[] care)
        {
            StreamWriter writer = new StreamWriter("AllInfo.txt");
            for (int i = 0; i < care.Length; i++)
            {
                writer.WriteLine("name:{0} id:{1}", care[i].name, care[i].id);
            }
            writer.Close();
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int  num;
            string loc,food,name="",id;
            int[] sch = new int[3];
            
            Console.WriteLine("enter number of animals");
            int n = int.Parse(Console.ReadLine());

            Care[] care = new Care[n];

            for (int i = 0; i < n; i++)
            { 
                Console.WriteLine("enter the code");
                id = Console.ReadLine();

                Console.WriteLine("enter the location");
                loc = Console.ReadLine();

                Console.WriteLine("enter the food");
                food = Console.ReadLine();

                Console.WriteLine("enter the schedule");
                string[] hold = Console.ReadLine().Split('-');
                for (int j = 0; j < 3; j++)
                    sch[j] = int.Parse(hold[j]);

                Console.WriteLine("enter the number");
                num = int.Parse(Console.ReadLine());

                care[i] = new Care(int.Parse(id), (Animal)Enum.Parse(typeof(Animal), id, true), loc,
                    (Food)Enum.Parse(typeof(Food), food, true), num, sch);

                care[i].SaveToFile();
                care[i].SetSchedule(food);
            }

            Care.AllInfo(care);
        }
    }
}
