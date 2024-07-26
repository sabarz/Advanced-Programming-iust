using System;
using System.IO;
using System.Text; 

namespace quiz_2
{

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
           Person[] person = new Person[n+2]; 

            for(int i = 0; i < n; i ++)
            {
                string name = Console.ReadLine();
                string lastname = Console.ReadLine();
                int age = int.Parse(Console.ReadLine());
                int salary = int.Parse(Console.ReadLine());
                int hours = int.Parse(Console.ReadLine());

                person[i] = new Person(name, lastname, age, salary, hours); 
            }

            for(int i = 0; i < n; i ++)
            {
                person[i].Identify();
            }

            string nname = Console.ReadLine();
            int aage = int.Parse(Console.ReadLine());
            int hhours = int.Parse(Console.ReadLine()); 

            person[n++] = person[0].shallowcopy(nname , aage , hhours);

            person[n++] = person[0].DeapCopy();

            StreamWriter writer = new StreamWriter("text.txt");
            string path = @"c:\text.txt";

            for(int i = 0; i < n; i ++)
            { 
                File.WriteAllText(path, person[i].Identify2()); 
            }
        }
    }
    class Person
    {
        private string name;
        private string lastname;
        private int age;
        private int salary;
        private int hours;
        static int n = 0;
        Person[] people;

        public Person(string pname, string plastname, int page , int psalary = 20 , int phours = 5)
        {
            if (pname != null)
                name = pname;

            if (plastname != null)
                lastname = plastname;

            if (page >= 0)
                age = page;

            if (psalary >= 0)
                salary = psalary;

            if (phours >= 0)
                hours = phours;
            people[n] = new Person(name, lastname, age, salary, hours);
            n++;
        }

       public Person()
        {
            name = "saba";
            lastname = "razi";
            age = 19;
            salary = 100;
            hours = 1;
        }

        public int SalaryYear()
        {
            int ans = 289 * hours * salary;
            return ans;
        }

        public int HoursYear()
        {
            int ans = 289 * hours;
            return ans;
        }

        public int NumberPeople()
        {
            return n;
        }

        public Person[] SearchPeople(string names)
        {
            Person[] ans = new Person[n];
            int j = 0;
            
            for (int i = 0; i < n ; i++)
            {
                if (names == people[i].name)
                {
                    ans[j] = people[i];
                    j++; 
                }
            }
            return ans;
        }

        public void Identify()
        {
            Console.WriteLine(name + " " + lastname + " " + age);
            Console.WriteLine(salary + " " + hours + " " + HoursYear() + " " + SalaryYear());
        }
        public string Identify2()
        {
            return name + " " + lastname + " " + age + " " + salary + " " + hours + " " + HoursYear() + " " + SalaryYear();
        }

        public Person DeapCopy()
        {
            string nname = name;
            string llastname = lastname;

            return new Person(nname, llastname, age, salary, hours);
        }

        public Person shallowcopy(string pname, int page, int phours)
        {
            return new Person(pname, lastname, page, salary, phours);
        }
    }
}
