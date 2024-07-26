

using System;

namespace soal_3
{
    enum stype { TA, normal, rebel };
    class student
    {
        private string name;
        private string lastname;
        public string id;
        private int hours;
        private stype type;

        public student(string name, string lastname, string id, stype type, int hours = 6)
        {
            this.name = name;
            this.lastname = lastname;
            this.id = id;
            this.hours = hours;
            this.type = type;
        }

        public double calculateScore()
        {

            if (type.ToString() == "normal")
            {
                if (hours <= 3)
                    return 0.0;

                else if (hours >= 4 && hours <= 6)
                    return 6.0;

                else
                    return 8.0;
            }

            else if (type.ToString() == "TA")
            {
                return Convert.ToDouble(hours * 2);
            }

            else
            {
                return Convert.ToDouble(hours / 2);
            }
        }
        public static void print(student s)
        {
            Console.WriteLine("{0} {1}: {2}", s.name, s.lastname, s.calculateScore());
        }

    }
    class Program
    {
        static void Main()
        {
            string[] st = new string[5];
            int i = 0;

            Console.WriteLine("Enter number of people:");
            int n = int.Parse(Console.ReadLine());

            student[] stud = new student[n];

            while (i != n)
            {
                Console.WriteLine("Enter name,family,code,hours and group of person:");
                st = Console.ReadLine().Split(',');

                for (int j = 0; j < i; j++)
                {
                    if (stud[j].id == st[2])
                    {
                        Console.WriteLine("Invalid code , please enter information again");
                        st = Console.ReadLine().Split(',');
                        j = -1;
                    }
                }

                bool check = false;

                while (!check)
                {
                    if (st[2][0] == '9' && (st[2][1] == '5' || st[2][1] == '6' || st[2][1] == '7' || st[2][1] == '8' || st[2][1] == '9'))
                    {
                            check = true;
                    }

                    else
                    {
                        Console.WriteLine("Invalid num , please enter information again");
                        st = Console.ReadLine().Split(',');
                    }
                }

                while (check == true)
                {
                    if (st[2].Length != 8)
                    {
                        Console.WriteLine("Invalid length , please enter information again");
                        st = Console.ReadLine().Split(',');
                    }
                    else
                        check = false;
                }

                if (char.IsDigit(Convert.ToChar(st[3][0])))
                {
                    while (!check)
                    {
                        if (int.Parse(st[3]) < 0 || int.Parse(st[3]) > 8)
                        {
                            Console.WriteLine("Invalid hour , please enter information again");
                            st = Console.ReadLine().Split(',');
                        }

                        else
                            check = true;
                    }

                    while (check == true)
                    {
                        if (st[4] == "TA" || st[4] == "normal" || st[4] == "rebel")
                        {
                            check = false;
                        }

                        else
                        {
                            Console.WriteLine("Invalid group , please enter information again");
                            st = Console.ReadLine().Split(',');
                        }
                    }
                    stud[i] = new student(st[0], st[1], st[2], (stype)Enum.Parse(typeof(stype), st[4], true), int.Parse(st[3]));
                }

                else
                {
                    while (!check)
                    {
                        if (st[3] == "TA" || st[3] == "normal" || st[3] == "rebel")
                        {
                            check = true;
                        }

                        else
                        {
                            Console.WriteLine("Invalid group , please enter information again");
                            st = Console.ReadLine().Split(',');
                        }
                    }
                    stud[i] = new student(st[0], st[1], st[2], (stype)Enum.Parse(typeof(stype), st[3], true));
                }

                i++;
            }

            for (int j = 0; j < n; j++)
            {
                student.print(stud[j]);
            }
        }
    }
}