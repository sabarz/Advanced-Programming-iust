using System;

namespace faaliat_3
{
    class student
    {
        private string[] name = new string[2];
        private int shomare; 

        public student(string[] pname , int pshomare)
        {
            name = pname;
            shomare = pshomare; 
        }

        public student Clone()
        {
            student deepcopystudent = new student((string[])name.Clone(), shomare);

            return deepcopystudent; 
        }

        public object badClone()
        {
            return MemberwiseClone(); 
        }

        public string stdInfo()
        {
            string etelaat = name[0]+" " + name[1]+" " + shomare.ToString();
            return etelaat;
        }

        public void changeInfo(char a , int b)
        {
            string h = Convert.ToString(a);
            string h2 = name[0].Remove(0, 1);
            h = h + h2;
            name[0] = h; 

            shomare += b; 
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter name");
            string[] firstname1 = new string[2];
            firstname1 = Console.ReadLine().Split(' ');
            Console.WriteLine("enter number"); 
            int sh1 = int.Parse(Console.ReadLine());
            student s1 = new student(firstname1, sh1);

            Console.WriteLine("enter name");
            string[] firstname2 = new string[2];
            firstname2 = Console.ReadLine().Split(' ');
            Console.WriteLine("enter number");
            int sh2 = int.Parse(Console.ReadLine());
            student s2 = new student(firstname2 , sh2);

            Console.WriteLine("enter name");
            string[] firstname3 = new string[2];
            firstname3 = Console.ReadLine().Split(' ');
            Console.WriteLine("enter number");
            int sh3 = int.Parse(Console.ReadLine());
            student s3 = new student(firstname3 , sh3);

            student[] students = new student[3];
            students[0] = s1;
            students[1] = s2;
            students[2] = s3;

            studentInfo(students);

            student s4 = s1.Clone();
            s1.changeInfo('q', 5);
            studentInfo(s1, s4);

            student s5 = (student)s2.badClone();
            s2.changeInfo('p', 10);
            studentInfo(s2, s5); 

        }
        static void studentInfo(params student[] paramlist)
        {
            foreach (var i in paramlist)
            {
                Console.WriteLine(i.stdInfo());
            }
        }
    }
}
