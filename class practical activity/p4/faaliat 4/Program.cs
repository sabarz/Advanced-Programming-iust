using System;

namespace faaliat_4
{
    class Person
    {
        private int age;
        private string name;
        private string lastname; 

        public Person(int age , string name , string lastname)
        {
            this.age = age;
            this.name = name;
            this.lastname = lastname;
        }

        public string Information()
        {
            return name + " " + lastname + " " + age.ToString(); 
        }
    }

    class Student : Person
    {
        private string school ; 

        public Student(int age , string name , string lastname , string school) : base(age,name,lastname)
        {
            this.school = school;
        }

    }

    class Teacher : Person
    {
        private string lesson;

        public Teacher(int age , string name , string lastname , string lesson) : base(age,name,lastname)
        {
            this.lesson = lesson;
        }
    }
    class Program
    {
        static void Main()
        {
            Console.WriteLine("enter student information :");

            string name = Console.ReadLine();
            string lastname = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string school = Console.ReadLine();

            Student stu = new Student(age, name, lastname, school);

            Console.WriteLine("enter teacher information :");

            name = Console.ReadLine();
            lastname = Console.ReadLine();
            age = int.Parse(Console.ReadLine());
            string lesson = Console.ReadLine();

            Teacher teacher = new Teacher(age, name, lastname, lesson);

            Console.WriteLine(stu.Information());
            Console.WriteLine(teacher.Information());

            check(stu);
            check(teacher);

        }

        static void check(object obj)
        {
            if (obj is Student)
            {
                Console.WriteLine("student");
            }

            else
            {
                Teacher t = obj as Teacher;

                if (t != null)
                {
                    Console.WriteLine("teacher");
                }
            }
        }
    }
}
