using System;
using System.Collections.Generic;
namespace quiz_4
{
    interface IMedia
    {
        public void Info();
        public void Shop(int x, int p);
    }
    class Media 
    {
        static int i = 0;
        private int id;
        protected int price;
        protected int t;
        private string name;
        public Media(string name , int t , int price)
        {
            try
            {
                if (price >= 0)
                {
                    this.price = price;
                }
                else
                {
                    throw new Exception("wrong price");
                }

                if (t >= 0)
                {
                    this.t = t;
                }
                else
                {
                    throw new Exception("wrong number");
                }

                if (name != null)
                {
                    this.name = name;
                }
                else
                {
                    throw new Exception("wrong name");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            id = i++;
        }
        public void Info()
        {
            if (t > 0)
            {
                Console.WriteLine("name : {0} price : {1} (mojood hast)" , name , price);
            }

            else
            {
                Console.WriteLine("name : {0} price : {1} (mojood nist)", name, price);
            }
        }

        public void Charge(int x)
        {
            t += x;
        }
    }

    class Book : Media,IMedia
    {
        private string writer;
        private int sal;

        public Book(string name, int t, int price ,string w , int s) : base( name, t, price)
        {
            writer = w;
            sal = s;
        }
        public void Info()
        {
            base.Info();
            Console.WriteLine("writer : {0} sal : {1}" , writer , sal);
        }

        public void Shop(int x , int p)
        {
            if(x > t || p < price*x)
            {
                Console.WriteLine("can't buy this");
            }

            else
            {
                t -= x;
                p -= price * x;
                Console.WriteLine("can buy this");
            }
        }

    }

    class Magezine : Book,IMedia
    {
        private int month;
        private int pages;
        private int m;
        
        public Magezine(string name, int t, int price, string w, int s, int month , int page ) : base( name, t, price, w, s)
        {
            m = 0;
            this.month = month;
            this.pages = page;
        }
        public void Shop(int x, int p)
        {
            if (x > t || p < price * x)
            {
                Console.WriteLine("can't buy this");
            }

            else
            {
                t -= x;
                m += x * price;
                p -= price * x;
                Console.WriteLine("can buy this");
            }
        }
        public void Info()
        {
            base.Info();
            Console.WriteLine("month : {0} page : {1} sell : {2} ", month, pages, m);
        }

    }
    enum game { think , sport , strategy};
    enum play { first , third};
    enum age { koodak , nojavan , javan};
    class Game : Media,IMedia
    {
        game g;
        play p;
        age a;

        public Game(string name, int t, int price, string ga , string pl , string ag) : base( name, t, price) 
        {
            if(ga == "think")
            {
                g = game.think;
            }
            else if(ga == "sport")
            {
                g = game.sport;
            }
            else if (ga == "strategy")
            {
                g = game.strategy;
            }

            if(pl == "first")
            {
                p = play.first;
            }
            else if (pl == "third")
            {
                p = play.third;
            }

            if(ag == "koodak")
            {
                a = age.koodak;
            }
            else if (ag == "nojavan")
            {
                a = age.nojavan;
            }
            else if(ag == "javan")
            {
                a = age.javan;
            }
        }
        public void Info()
        {
            base.Info();
            Console.WriteLine("game : {0} play : {1} age : {2}", g, p, a);
        }
        public void Shop(int x, int p)
        {
            if (x > t || p < price * x)
            {
                Console.WriteLine("can't buy this");
            }
            else
            {
                t -= x;
                p -= price * x;
                Console.WriteLine("can buy this");
            }
        }
    }

    static class EP1
    {
        public static string CurrencyPipe(this int w , string v)
        {
            return w.ToString()+ " " + v;
        }
    }

/*    static class EP2<mytype> : IComparable<mytype>
    {
        public static void CurrencyPipe(object x , object y)
        {
            if(x is y)
            {

            }
        }
    }*/
    class Program
    {
        static void Main(string[] args)
        {
            string a;
            List<Book> books = new List<Book>();
            List<Game> games = new List<Game>();
            List<Magezine> magezines= new List<Magezine>();

            do
            {
                Console.WriteLine("choose : BOOK , MAGAZINE , GAME ,EXIT");
                a = Console.ReadLine();
                try
                {
                    if (a == "BOOK")
                    {
                        Console.WriteLine("Enter name , number , price , writer , year");
                        string[] b = new string[5];
                        b = Console.ReadLine().Split(' ');
                        books.Add(new Book(b[0], int.Parse(b[1]), int.Parse(b[2]), b[3], int.Parse(b[4])));
                    }
                    else if (a == "MAGAZINE")
                    {
                        Console.WriteLine("Enter name , number , price , writer , year , month , page");
                        string[] b = new string[7];
                        b = Console.ReadLine().Split(' ');
                        magezines.Add(new Magezine(b[0], int.Parse(b[1]), int.Parse(b[2]), b[3], int.Parse(b[4]), int.Parse(b[5]), int.Parse(b[6])));
                    }
                    else if (a == "GAME")
                    {
                        Console.WriteLine("Enter name , number , price , game , play , age");
                        string[] b = new string[6];
                        b = Console.ReadLine().Split(' ');
                        games.Add(new Game(b[0], int.Parse(b[1]), int.Parse(b[2]), b[3], b[4], b[5]));
                    }
                }
                catch
                {
                    Console.WriteLine("some thing went wrong!");
                }
            } while (a != "EXIT");

            for(int j = 0; j < books.Count; j++)
            {
                books[j].Info();
                Console.WriteLine("enter number and price");
                string[] c = new string[2];
                books[j].Shop(int.Parse(c[0]) , int.Parse(c[1]));
            }
            for (int j = 0; j < games.Count; j++)
            {
                games[j].Info();
                Console.WriteLine("enter number and price");
                string[] c = new string[2];
                games[j].Shop(int.Parse(c[0]), int.Parse(c[1]));
            }
            for (int j = 0; j < magezines.Count; j++)
            {
                magezines[j].Info();
                Console.WriteLine("enter number and price");
                string[] c = new string[2];
                magezines[j].Shop(int.Parse(c[0]), int.Parse(c[1]));
            }
        }
    }
}
