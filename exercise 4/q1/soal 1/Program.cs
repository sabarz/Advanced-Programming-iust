using System;
using System.Linq;
using System.IO;

namespace soal_1
{
    struct Book
    {
        private string bookname;
        private string writername;
        private int price;
        private int id;
        private string nasher;
        private char flag;

        public Book(string bn, string wn, int p, int id, string n) //ADD
        {
            bookname = bn;
            writername = wn;
            price = p;
            nasher = n;
            this.id = id;
            flag = ' ';
        }

        public void LIST()
        {
            if (flag == ' ')
            {
                Console.WriteLine("book");
                Console.WriteLine("name : {0}", bookname);
                Console.WriteLine("writer : {0}", writername);
                Console.WriteLine("price : {0}", price);
                Console.WriteLine("ID : {0}", id);
                Console.WriteLine("publication : {0}", nasher);
                Console.WriteLine(" ");
            }
        }

        public bool SEARCH()
        {
            if (flag == ' ')
            {
                Console.WriteLine("book name is : {0}", bookname);
                Console.WriteLine("writer name is : {0}", writername);
                Console.WriteLine("price is : {0}", price);
                Console.WriteLine("nasher is : {0}", nasher);

                return true;
            }
            else
                return false;

        }

        public void DELETE()
        {
            flag = '*';
        }
        class Program
        {
            static Book[] books = new Book[100];
            static int cnt = 0;

            static void Main(string[] args)
            {
                string choose;
                do
                {
                    Console.WriteLine("Please choose");
                    Console.WriteLine("ADD for adding a book");
                    Console.WriteLine("LIST for showing list of the books that we have in our book store");
                    Console.WriteLine("SEARCH for searching the book that you want based on the ID of the book");
                    Console.WriteLine("SORT for sorting list of the books");
                    Console.WriteLine("DELETE for deleting the book from the list");
                    Console.WriteLine("EXIT for exiting from program");
                    choose = Console.ReadLine();

                    if (choose == "ADD")
                    {
                        try
                        {

                            Console.WriteLine("Please enter information of the book");
                            Console.WriteLine("enter name of the book");
                            string name = Console.ReadLine();
                            Console.WriteLine("enter writer of the book");
                            string wname = Console.ReadLine();
                            Console.WriteLine("enter id of the book");
                            int id = int.Parse(Console.ReadLine());
                            Console.WriteLine("enter price of the book");
                            int p = int.Parse(Console.ReadLine());
                            Console.WriteLine("enter publication of the book");
                            string nashr = Console.ReadLine();
                            books[cnt] = new Book(name, wname, p, id, nashr);
                            cnt++;
                        }
                        catch
                        {
                            Console.WriteLine("there is a problem!");
                        }
                    }

                    else if (choose == "LIST")
                    {
                        File.WriteAllText("text.txt", string.Empty);
                        StreamWriter writer = new StreamWriter("text.txt");

                        for (int i = 0; i < cnt; i++)
                        {
                            try
                            {
                                books[i].LIST();
                                if (books[i].flag != '*')
                                {
                                    writer.WriteLine("book");
                                    writer.WriteLine("name : {0}", books[i].bookname);
                                    writer.WriteLine("writer : {0}", books[i].writername);
                                    writer.WriteLine("price : {0}", books[i].price);
                                    writer.WriteLine("ID : {0}", books[i].id);
                                    writer.WriteLine("publication : {0}", books[i].nasher);
                                    writer.WriteLine(" ");
                                    writer.Close();
                                }
                            }
                            catch
                            {
                                Console.WriteLine("there is a problem!");
                            }
                        }
                    }

                    else if (choose == "SEARCH")
                    {
                        Console.WriteLine("enter the ID of the book you want to search");
                        int id = int.Parse(Console.ReadLine());

                        bool check = false;
                        for (int i = 0; i < cnt; i++)
                        {
                            try
                            {
                                if (id == books[i].id)
                                {
                                    if (books[i].SEARCH())
                                    {
                                        check = true;
                                        break;
                                    }
                                }
                            }
                            catch
                            {
                                Console.WriteLine("there is a problem!");

                            }
                        }
                        if(!check)
                        {
                            Console.WriteLine("Book not found");
                        }
                    }

                    else if (choose == "SORT")
                    {
                        Console.WriteLine("Please choose which one do you want");
                        Console.WriteLine("SortByName");
                        Console.WriteLine("SortByID");
                        string sort = Console.ReadLine();
                        SORT(sort);
                    }

                    else if (choose == "DELETE")
                    {
                        Console.WriteLine("Please enter the ID of the book that you want to delete");
                        int id = int.Parse(Console.ReadLine());

                        try
                        {
                            for (int i = 0; i < cnt; i++)
                            {
                                if (books[i].id == id)
                                {
                                    books[i].DELETE();
                                }
                            }
                        }
                        catch
                        {
                            Console.WriteLine("there is a problem!");
                        }

                        Console.WriteLine("the book is deleted");
                    }

                } while (choose != "EXIT");
            }
            public static void SORT(string type)
            {
                int cc = cnt;
                int j = 0;
                int t = 0;

                try
                {
                    if (type == "SortByName")
                    {
                        string[] temp = new string[cnt];
                        while (cc != -1)
                        {
                            if (books[cc].flag == ' ')
                            {
                                temp[j] = books[cc].bookname;
                                j++;
                                t++;
                            }
                            cc--;
                        }
                        for (int i = 0; i < t; i++)
                        {
                            for (j = 0; j < i; j++)
                            {
                                if (temp[i].CompareTo(temp[j]) < 0)
                                {
                                    string hold = temp[i];
                                    temp[i] = temp[j];
                                    temp[j] = hold;
                                }
                            }
                        }

                        for (int i = 0; i < t; i++)
                        {
                            Console.WriteLine(temp[i]);
                        }
                    }

                    else
                    {
                        int[] temp = new int[cnt];
                        while (cc != -1)
                        {
                            if (books[cc].flag == ' ')
                            {
                                temp[j] = books[cc].id;
                                j++;
                                t++;
                            }
                            cc--;
                        }

                        for (int i = 0; i < t; i++)
                        {
                            for (j = 0; j < i; j++)
                            {
                                if (temp[i].CompareTo(temp[j]) < 0)
                                {
                                    int hold = temp[i];
                                    temp[i] = temp[j];
                                    temp[j] = hold;
                                }
                            }
                        }

                        for (int i = 0; i < t; i++)
                        {
                            Console.WriteLine(temp[i]);
                        }
                    }
                }

                catch
                {
                    Console.WriteLine("there is a problem!");

                }
            }
        }
    }
}
