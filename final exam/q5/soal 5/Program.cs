using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace soal_5
{
    class Account
    {
        public string name;
        public int codeMeli;
        public int ShHesab;
        public double Money;
        public Account(string name , int code , int sh , double money)
        {
            this.name = name;
            codeMeli = code;
            ShHesab = sh;
            Money = money;
        }

    }
    class Program
    {
        public static void print(List<string> ans)
        {
            foreach (string i in ans)
                Console.WriteLine(i);
        }
        static void Main(string[] args)
        {
            List<Account> infos = new List<Account>();

            Console.WriteLine("Question 1 :");
            infos.GroupBy(x => x.codeMeli).OrderByDescending(x => x.Key)
                                .Select(x => x.Key).ToList().ForEach(Console.WriteLine);

            Console.WriteLine("Question 2 :");
            infos.Where(x => x.ShHesab % 100 == 0).Sum(y => y.Money);

            Console.WriteLine("Question 3 :");
            Console.WriteLine(infos.GroupBy(x => x.codeMeli).OrderByDescending(x => x.Sum(t => t.Money))
                                            .Select(x => x.Sum(x => x.Money)).Last().ToString());
        }
    }
}
