using System;

namespace soal_3
{
    class Program
    {
        static int i = 0;
        static Employee[] emp = new Employee[100];
        static void Main(string[] args)
        {   
            string[] a = new string[7];
            string b;

            do
            {
                b = Console.ReadLine();
                a = b.Split(' ', '[', ']');
                if (a[0] == "hire")
                {
                    if (checkname(a[2]) == false || checkname2(a[2],emp) == false)
                    {
                        do
                        {
                            a[2] = Console.ReadLine();
   
                        } while (checkname(a[2]) == false || checkname2(a[2],emp) == false);
                    }
                    hire(a[2], int.Parse(a[5])); 
                
                }
                if (a[0] == "pay")
                {
                    pay(a[2],emp);
                }
                else if (a[0] == "get")
                {
                    get(a[2], int.Parse(a[5]), emp);
                }
                else if (a[0] == "special")
                {
                    special(a[2],emp);
                }
                else if (a[0] == "loan")
                {
                    loan(a[2],emp);
                }
                else if (a[0] == "promote")
                {
                    promote(emp);
                }
                else if (a[0] == "regress")
                {
                    regress(emp);
                }
                else if(a[0] == "report")
                {
                    report(a[2],emp);
                }
            } while (a[0] != "End Career");
        }

        static void hire(string name , int degree)
        {
            emp[i] = new Employee(name, degree);
            emp[i].hired = true;
            i++;
        }

        static bool checkname(string name)
        {
            for (int j = 0; j < name.Length; j++)
            {
                if (char.IsLower(name[j]) == false)
                {
                    Console.WriteLine("name is not valid");
                    return false; 
                }
            }

            return true;

        }

        static bool checkname2(string name, Employee[] emp)
        {
            if(i != 0)
            {
                for (int j = 0; j < i; j++)
                {
                    if (name == emp[j].name)
                    {
                        Console.WriteLine("tekrari!");
                        return false;
                    }
                }
            }
            return true;
        }

        static void pay(string name , Employee[] emp)
        {
            int hold = 0;
            for (int j = 0; j < i; j++)
            {
                if (name == emp[j].name)
                {
                    if (emp[j].degree == 1)
                        hold = 100; 

                    else if(emp[j].degree == 2)
                        hold = 300; 

                    else if(emp[j].degree == 3)
                        hold = 700; 

                    else if(emp[j].degree == 4)
                        hold = 900;

                    emp[j].balance += hold;
                    break;
                }
            }
        }

        static void get(string name , int q, Employee[] emp)
        {
            for(int j = 0; j < i; j++)
            {
                if(name == emp[j].name)
                {
                    if (emp[j].balance < q)
                    {
                        Console.WriteLine("Not enough money!");
                        break;
                    }

                    else
                    {
                        emp[j].balance -= q;
                        break;
                    }
                }
            }
        }

        static void special(string name, Employee[] emp)
        {
            for (int j = 0; j < i; j++)
            {
                if (name == emp[j].name)
                {
                    emp[j].special = true;
                }
            }
        }

        static void loan(string name , Employee[] emp)
        {
            int hold = 0;

            for (int j = 0; j < i; j++)
            {
                if (name == emp[j].name)
                {
                    if(emp[j].loaned == false && emp[j].special == true)
                    {
                        if (emp[j].degree == 1)
                            hold = 300;

                        else if (emp[j].degree == 2)
                            hold = 900;

                        else if (emp[j].degree == 3)
                            hold = 2100;

                        else if (emp[j].degree == 4)
                            hold = 2700;

                        emp[j].balance += hold;
                        emp[j].loaned = true;
                        break;
                    }

                }
            }
        }

        static void promote(Employee[] emp)
        {
            for(int j = 0; j < i; j++)
            {
                if(emp[j].special == true)
                {
                    if (emp[j].degree < 5)
                    {
                        emp[j].degree++;

                        if(emp[j].degree == 5)
                        {
                            for(int p = 0; p < i;p++)
                            {
                                if (emp[p].special == true && emp[p].loaned == true)
                                    emp[p].loaned = false;
                            }
                        }
                    }
                }
            }
        }

        static void regress(Employee[] emp)
        {
            for (int j = 0; j < i ; j++)
            {
                if (emp[j].special == false)
                {
                    if (emp[j].degree > 0)
                    {
                        emp[j].degree--;
                    }
                }
            }
        }
        static void report(string name , Employee[] emp)
        {
            string hold = "";
            for (int j = 0; j < i; j++)
            {
                if(emp[j].name == name)
                {
                    if (emp[j].degree == 1)
                        hold = "worker";

                    else if (emp[j].degree == 2)
                        hold = "foreman";

                    else if (emp[j].degree == 3)
                        hold = "supervisor";

                    else if (emp[j].degree == 4)
                        hold = "leader";

                    else if (emp[j].degree == 0)
                        hold = "fired";

                    else if (emp[j].degree == 5)
                        hold = "retired";

                    if (emp[j].special == true)
                    {
                        Console.WriteLine("special [{0}] [{1}] [{2}]", emp[j].name, hold,emp[j].balance);
                    }
                    else
                    {
                        Console.WriteLine("[{0}] [{1}]", emp[j].name, hold,emp[j].balance);

                    }
                }
            }
        }
    }

    class Employee
    {
        public string name;
        public int degree;
        public int balance = 0;
        public bool special = false;
        public bool loaned = false;
        public bool hired = false;
        public Employee(string name, int degree)
        {
            this.name = name;
            this.degree = degree;
        }
    }
}
