using System;

namespace quiz_3
{

    class Account
    {
        public static int[] ids;
        static int cnt;
        private int id;
        private int hesabnum; 
        private string kartnum;
        protected int money;

        public Account(int money)
        {
            this.money = money;

            Random r = new Random();
            id = r.Next() % 100;
            ids[cnt + 1] = id;

            hesabnum = r.Next(10000000, 999999999);

            int a = r.Next(1000, 9999);
            int b = r.Next(1000, 9999);
            int c = r.Next(1000, 9999);
            int d = r.Next(1000, 9999);
            kartnum = a + "-" + b + "-" + c + "-" + d;

            for(int i = 0; i < cnt; i ++)
            {
                try
                {
                    if(id == ids[i])
                        throw new Exception("id tekrari");
                }

                catch
                {
                    Console.WriteLine("id tekrari!");
                }

            }

            try
            {
                if (money < 0)
                    throw new Exception("money wrong");
            }

            catch
            {
                Console.WriteLine("money wrong");
            }

            cnt++;
        }

        public virtual void variz(int x)
        {
            Console.WriteLine("not implemented");
        }
        public virtual void bardasht(int x)
        {
            Console.WriteLine("not implemented");
        }
        public virtual void sood(int x)
        {
            Console.WriteLine("not implemented");
        }
        public virtual void log()
        {
            Console.WriteLine("not implemented");
        }
    }

    class juniorAcc : Account
    {
        private int saghf;
        private int kaf;
        private double profitmonth = 0.07;
        private int mahdoodiat;

        public juniorAcc(int saghf , int kaf , int m ) : base( m)
        {
            this.saghf = saghf;
            this.kaf = kaf;

        }

        public override void variz(int x)
        {
            try
            {
                if (money + x > saghf || money + x <kaf)
                {
                    throw new Exception("money ziad");
                }

                else
                {
                    money += x;
                }
            }

            catch
            {
                Console.WriteLine("money ziad ya kam");
            }
        }
        public override void bardasht(int x)
        {
            try
            {
                if(x <= money/2 || money - x < kaf)
                {
                    throw new Exception("bardasht nemishe");

                }
            }

            catch
            {
                Console.WriteLine("bardasht nemishe");
            }
        }
        public override void sood(int x)
        {
            for (int i = 0; i < x; i++)
            {
                int hold = (int)(money * profitmonth);
                money += hold;
            }

            Console.WriteLine(money);
        }
        public override void log()
        {
            Console.WriteLine("{0}  {1}  {2}  {3}", saghf, kaf, profitmonth, mahdoodiat);
        }

        public void jayeze()
        {
            Random r = new Random();
            int hold = r.Next(0, 20);

            int w = (hold / 100) * money;
            money += w;

            Console.WriteLine(money);

        }
    }

    class longtimeAcc :Account
    {
        private int kaf;
        private int profityear;
        bool block = false;
        public longtimeAcc(int kaf, int m) : base(m)
        {
            this.kaf = kaf;
        }

        public override void variz(int x)
        {
            if (block == false)
            {
                try
                {
                    if (money + x < kaf)
                    {
                        throw new Exception("money kam");
                    }

                    else
                    {
                        money += x;
                    }
                }

                catch
                {
                    Console.WriteLine("money kam");
                }
            }
        }
        public override void bardasht(int x)
        {
            if (block == false)
            {
                try
                {
                    if (money - x < kaf)
                    {
                        throw new Exception("bardasht nemishe");
                    }
                }

                catch
                {
                    Console.WriteLine("bardasht nemishe");
                }
            }
        }
        public override void sood(int x)
        {
            int h = x / 12;

            int hold = (h * (profityear / 100));

            int nmd = hold * money;

            money += nmd;
        }
        public override void log()
        {
            Console.WriteLine("{0}  {1} ",  kaf, profityear);
        }

        public void Block()
        {
            if (block == false)
            {
                block = true;
            }
            else
                block = false;
        }
    }

    class Person : Account
    {
        private int id;
        private string name;
        private Account hesab;
        bool check = false;
        public Person(string s)
        {
            name = s;
            Random r = new Random();
            this.id = r.Next() % 100;
        }

        public void IjadHesab(int m ,int kaf , int saghf , string typeacc)
        {
            if (check == false)
            {
                if (typeacc == "junioracc")
                    hesab = new juniorAcc(saghf, kaf, m);

                else
                    hesab = new longtimeAcc(kaf, m);
            }
            check = true;
        }

        public void amaliathesab()
        {
            juniorAcc tem = hesab as juniorAcc;
            if(tem != null)
            {
                Console.WriteLine("enter 1 for variz");
                Console.WriteLine("enter 2 for bardasht");
                Console.WriteLine("enter 3 for log");
                Console.WriteLine("enter 4 for sood");
                Console.WriteLine("enter 5 for jayeze");

                int n = int.Parse(Console.ReadLine());

                if (n == 1)
                {
                    int x = int.Parse(Console.ReadLine());
                    hesab.variz(x);
                }
                if (n == 2)
                {
                    int x = int.Parse(Console.ReadLine());
                    hesab.bardasht(x);
                }
                if (n == 3)
                {
                    int x = int.Parse(Console.ReadLine());
                    hesab.log();
                }
                if (n == 4)
                {
                    int x = int.Parse(Console.ReadLine());
                    hesab.sood(x);
                }
            
                if (n == 1)
                {
                    int x = int.Parse(Console.ReadLine());
                    hesab.jayeze();
                }

            }

            else
            {
                Console.WriteLine("enter 1 for variz");
                Console.WriteLine("enter 2 for bardasht");
                Console.WriteLine("enter 3 for log");
                Console.WriteLine("enter 4 for sood");
                Console.WriteLine("enter 5 for jayeze");

                int n = int.Parse(Console.ReadLine());

                if (n == 1)
                {
                    int x = int.Parse(Console.ReadLine());
                    hesab.variz(x);
                }
                if (n == 2)
                {
                    int x = int.Parse(Console.ReadLine());
                    hesab.bardasht(x);
                }
                if (n == 3)
                {
                    int x = int.Parse(Console.ReadLine());
                    hesab.log();
                }
                if (n == 4)
                {
                    int x = int.Parse(Console.ReadLine());
                    hesab.sood(x);
                }

                if (n == 1)
                {
                    int x = int.Parse(Console.ReadLine());
                    hesab.jayeze();
                }
            }

        }
        public void bastan()
        {
            hesab.block();
            Console.WriteLine(hesab.mon)
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
        }
    }
}
