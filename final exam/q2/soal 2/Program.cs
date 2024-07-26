using System;
using System.Collections;
using System.Collections.Generic;

namespace soal_2
{
    class Account
    {
        protected string name;
        protected int codeMeli;
        protected int ShHesab;
        protected double Money;
        List<int> shhesabha = new List<int>();
        public Account(string name, int code, int sh, double money)
        {
            try
            {
                for (int i = 0; i < shhesabha.Count; i++)
                {
                    if (sh == shhesabha[i])
                    {
                        throw new Exception("repeated number");
                    }
                }
                if (money < 0)
                {
                    throw new Exception("Not enough money!");
                }
                else
                {
                    if (sh.ToString().Length > 4)
                    {
                        sh = sh % 10000;
                        this.name = name;
                        codeMeli = code;
                        ShHesab = sh;
                        Money = money;
                    }
                    else if (sh.ToString().Length == 3)
                    {
                        char[] a = new char[4];
                        a[0] = '0';
                        a[1] = sh.ToString()[0];
                        a[2] = sh.ToString()[1];
                        a[3] = sh.ToString()[2];
                    }
                    else if (sh.ToString().Length == 1)
                    {
                        char[] a = new char[4];
                        a[0] = '0';
                        a[1] = '0';
                        a[2] = '0';
                        a[3] = sh.ToString()[0];
                    }
                    else if (sh.ToString().Length == 2)
                    {
                        char[] a = new char[4];
                        a[0] = '0';
                        a[1] = '0';
                        a[2] = sh.ToString()[0];
                        a[3] = sh.ToString()[1];
                    }
                    else
                    {
                        this.name = name;
                        codeMeli = code;
                        ShHesab = sh;
                        Money = money;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public Account(string name, int code)
        {
            bool done = false;

            do
            {
                Random r = new Random();
                ShHesab = r.Next(1000, 9999);

                for (int i = 0; i < shhesabha.Count; i++)
                {
                    if (ShHesab == shhesabha[i])
                    {
                        break;
                    }
                    if (i == shhesabha.Count - 1)
                    {
                        done = true;
                    }
                }

            } while (done == false);

            Money = 0;
        } 
    }
    sealed class Babyaccount : Account
    {
        double max;
        int age;
        public Babyaccount(string name , int code ,int sh, double money , double ma , int age) : base(name , code,sh , money)
        {
            try
            {
                if (ma < 0)
                {
                    throw new Exception("wrong max");
                }
                else if (age > 18 || age < 1)
                {
                    throw new Exception("wrong age");
                }
                else
                {
                    this.max = ma;
                    this.age = age;
                    this.ShHesab += 10000;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
