using System;

namespace soal_5
{
    class Program
        {
            static void Main()
            {
                string[] a = new string[10];
                library libe = new library();
                Console.WriteLine("enter (end) to finish the program!");
                do
                {
                    a = Console.ReadLine().Split(' ', '[', ']');
                  
                    if (a[0] == "AddBook")
                    {
                        libe.addbook(int.Parse(a[2]), a[5], int.Parse(a[8]));
                    }
                    
                    else if (a[0] == "AddMember")
                    {
                        libe.addmember(int.Parse(a[2]), a[5]);
                    }
                   
                    else if (a[0] == "get")
                    {
                        libe.get(int.Parse(a[2]), int.Parse(a[5]));
                    }
                    
                    else if (a[0] == "return")
                    {
                        libe.Return(int.Parse(a[2]), int.Parse(a[5]));
                    }
                    
                    else if (a[0] == "bookstate")
                    {
                        libe.bookstate();
                    }
                   
                    else if (a[0] == "memberstate")
                    {
                        libe.memberstate();
                    }
                } while (a[0] != "end");

            }
        }
        class library
        {
            Book[] book = new Book[50];
            Aza[] azaa = new Aza[50];
            static int i = 0, j = 0 ;
            public void addbook(int id, string name, int tedad)
            {
                book[i] = new Book(id, name, tedad);
                i++;
            }
            public void addmember(int id, string name)
            {
                azaa[j] = new Aza(id, name);
                j++;
        }
            public void get(int mid, int bid)
            {
                int holdm = 0, holdb = 0;

                for (int p = 0;p < j; p++)
                {
                    if (azaa[p].id == mid)
                    {
                        holdm = p;
                        break;
                    }
                }
                for (int p = 0; p < i; p++)
                {
                    if (book[p].id == bid)
                    {
                        holdb = p;
                        break;
                    }
                }

                if (azaa[holdm].te < 5 && book[holdb].tedad > 0)
                {
                    azaa[holdm].books[azaa[holdm].te + 1] = new Book(bid, book[holdb].name, book[holdb].tedad);
                    book[holdb].tedad--;
                    azaa[holdm].te++;
                }
                else if (azaa[holdm].te >= 5)
                {
                    Console.WriteLine("MaxReached: [{0}] [{1}]", azaa[holdm].name, azaa[holdm].id);
                }
                else
                {
                    Console.WriteLine("NotAvailable: [{0}] [{1}]", book[holdb].name, bid);
                }

            }
            public void Return(int mid, int bid)
            {
                int holdm = 0, holdb = 0;

                for (int p = 0; p < j; p++)
                {
                    if (azaa[p].id == mid)
                    {
                        holdm = p;
                        break;
                    }
                }
                for (int p = 0; p < i; p++)
                {
                    if (book[p].id == bid)
                    {
                        holdb = p;
                        break;
                    }
                }

                for (int p = 0; p < azaa[holdm].te; p++)
                {
                    if (azaa[holdm].books[p].id == bid)
                    {
                        azaa[holdm].books[p] = null;
                    }
                }

                book[holdb].tedad++;
            }
            public void bookstate()
            {
                for (int p = 0; p < i; p++)
                {
                    Console.WriteLine("[{0}] [{1}] [{2}]", book[p].name, book[p].id, book[p].tedad);
                }
            }
            public void memberstate()
            {
                for (int p = 0; p < j; p++)
                {
                    Console.Write("[{0}] [{1}] ", azaa[p].name, azaa[p].id);

                    for (int t = 0; t < azaa[p].te; t++)
                    {
                        Console.Write("[{0}] [{1}] - ", azaa[p].books[t].name, azaa[p].books[t].id);
                    }
                    Console.WriteLine("");
                }

            }

        }
        class Book
        {
            public int id;
            public string name;
            public int tedad;
            public Book(int id, string name, int count)
            {
                this.id = id;
                this.name = name;
                tedad = count;
            }
    }
        class Aza
        {
            public int id;
            public string name;
            public Book[] books = new Book[5];
            public int te ;
            public Aza(int id, string name)
            {
                this.id = id;
                this.name = name;
                te = 0;
            }
    }
    
}
