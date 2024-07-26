using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace tamrin_6
{
    interface user
    {
        public void SaveInfo();
    }
    class Student : user
    {
        private string name;
        private int shomaredaneshjooyi;
        public Student()
        {
            Console.WriteLine("enter name ");
            string name = Console.ReadLine();
            int id;
            do
            {
                Console.WriteLine("enter number (shomare daneshjooyi)");
                id = int.Parse(Console.ReadLine());

            } while (!CheckShomare(id));

            this.name = name;
            shomaredaneshjooyi = id;
        }
        
        public bool CheckShomare(int id)
        {
            if(id.ToString().Length == 8 && id.ToString()[0] == '9')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void SaveInfo()
        {
            if (File.Exists("CustomersInfo.txt"))
            {
                List<string> HoldInfo = new List<string>();
                StreamReader reader = new StreamReader("CustomersInfo.txt");
                string l = "";

                while ((l = reader.ReadLine()) != null)
                {
                    HoldInfo.Add(l);
                }

                reader.Close();
                File.WriteAllText("CustomersInfo.txt", string.Empty);
                StreamWriter writer = new StreamWriter("CustomersInfo.txt");

                foreach (string x in HoldInfo)
                {
                    writer.WriteLine(x);
                }
                writer.WriteLine(name);
                writer.WriteLine(shomaredaneshjooyi);
                writer.Close();

            }

            else
            {
                StreamWriter writer = new StreamWriter("CustomersInfo.txt");

                writer.WriteLine(name);
                writer.WriteLine(shomaredaneshjooyi);
                writer.Close();
            }
        }
    }
    class Teacher : user
    {
        private string name;
        private string institude;

        public Teacher(string name , string ins)
        {
            this.name = name;
            institude = ins;
        }

        public void SaveInfo()
        {
            if (File.Exists("CustomersInfo.txt"))
            {
                List<string> HoldInfo = new List<string>();
                StreamReader reader = new StreamReader("CustomersInfo.txt");
                string l = "";

                while ((l = reader.ReadLine()) != null)
                {
                    HoldInfo.Add(l);
                }

                reader.Close();
                File.WriteAllText("CustomersInfo.txt", string.Empty);
                StreamWriter writer = new StreamWriter("CustomersInfo.txt");

                foreach (string x in HoldInfo)
                {
                    writer.WriteLine(x);
                }

                writer.WriteLine(name);
                writer.WriteLine(institude);
                writer.Close();
            }

            else
            {
                StreamWriter writer = new StreamWriter("CustomersInfo.txt");
                writer.WriteLine(name);
                writer.WriteLine(institude);
                writer.Close();
            }
        }
    }
    class Customer : user
    {
        private string name;
        private string codemeli;

        public Customer()
        {
            Console.WriteLine("enter name ");
            string nname = Console.ReadLine();
            string id;

            do
            {
                Console.WriteLine("enter number (code meli)");
                id = Console.ReadLine();

            } while (String.CheckCode(id) == false && id.ToLower() != "exit") ;

            this.name = nname;
            codemeli = id;
        }
        public void SaveInfo()
        {
            if (File.Exists("CustomersInfo.txt"))
            {
                List<string> HoldInfo = new List<string>();
                StreamReader reader = new StreamReader("CustomersInfo.txt");
                string l = "";

                while ((l = reader.ReadLine()) != null)
                {
                    HoldInfo.Add(l);
                }
                reader.Close();
                File.WriteAllText("CustomersInfo.txt", string.Empty);
                StreamWriter writer = new StreamWriter("CustomersInfo.txt");

                foreach (string x in HoldInfo)
                {
                    writer.WriteLine(x);
                }

                writer.WriteLine(name);
                writer.WriteLine(codemeli);
                writer.Close();
            }

            else
            {
                StreamWriter writer = new StreamWriter("CustomersInfo.txt");
                writer.WriteLine(name);
                writer.WriteLine(codemeli);
                writer.Close();
            }
        }

    }
    class Seller
    {
        private string email;
        public string password;
        private string time; 
        public Seller()
        {
            string email;
            do
            {
                Console.WriteLine("Please Enter your Email : ");
                email = Console.ReadLine();

            } while (CheckEmail(email) == false);

            this.email = email;

            password = "MyShop1234$";
            time = "Tuesday, October 27, 2020 9:39:13 AM";
        }
        public bool CheckEmail(string newemail)
        {
            var pattern = @"[a-zA-Z0-9._-]+@[a-zA-Z0-9-]+\.[a-zA-Z.]{2,18}";
            var rx = new Regex(pattern, RegexOptions.Compiled);

            if(rx.IsMatch(newemail))
            {
                return true; 
            }
            else
            {
                return false;
            }

        }
        public void ChangePassword()
        {
            Console.WriteLine("Date of previous pasword :  " + time);

            Console.WriteLine("Please Enter new password");
            string newpassword = Console.ReadLine();
            password = newpassword;

            DateTime now = DateTime.Now;
            time = now.ToString("F");
            Console.WriteLine("Date of new pasword :  " + time);
        }
        public bool CHECKPASS(string newpassword)
        {
            if(password == newpassword)
            {
                return true;
            }    
            else
            {
                return false;
            }
        }
    }

    static class String
    {
        public static bool CheckCode(this string co )
        {
            bool check = true;
            long code = int.Parse(co);

            long a = code % 10;
            long b = 0;
            int hold = 0;

            for(int i = 2; i <= 10; i++)
            {
                code =(code - (code % 10))/10;
                b += i * (code % 10); 
            }

            long c = b % 11;

            for(int i = 1; i < co.Length; i++)
            {
                if(co[i] == co[i-1])
                {
                    hold++;
                }
            }

            if (code.ToString().Length != 10)
            {
                check = false;
            }

            else if(hold == 9)
            {
                check = false;
            }

            else if (c == 0 && a == c)
            {
                check = true;
            }

            else if(c == 1 && a == 1)
            {
                check = true;
            }

            else if(c > 1 && (-1 * (c-11)) == a)
            {
                check = true;
            }

            return check;
        }
    }
    //*******************************************************************************************
    interface media
    {
        public void CalculatePrice();
    }
    class Media
    {
        private string name;
        public double realPrice;
        private int id;
        public Media(string name , double Price , int id)
        {
            this.name = name;
            this.realPrice = Price;
            this.id = id;
        }
    }
    class Book : Media , media
    {
        public string writer;
        public string publisher;
        public Book(string name , int realprice, int id ,string writer , string publisher) : base(name , realprice, id)
        {
            this.writer = writer;
            this.publisher = publisher;
            CalculatePrice();
        }
        public void CalculatePrice()
        {
            realPrice = ((double)110 / (double)100) * (double)realPrice;
        }
    }
    class Movie : Media , media
    {
        public int time;
        public int CDnumber;
        public Movie(string name, int realprice , int id , int time , int CDnumber) : base(name , realprice , id )
        {
            this.time = time;
            this.CDnumber = CDnumber;
            CalculatePrice();
        }
        public void CalculatePrice()
        {
            realPrice = ((((double)time / (double)60) * (double)5 + ((double)CDnumber / (double)3) * (double)3) + 100)
                / (double)100 * (double)realPrice;
        }
    }
    class Magazine : Media , media
    {
        public int pages;
        public string nasher;
        public Magazine(string name, int realprice , int id , int pages , string nasher) : base(name , realprice , id)
        {
            this.pages = pages;
            this.nasher = nasher;
            CalculatePrice();
        }
        public void CalculatePrice()
        {
            if(pages >= 1 && pages <= 20)
            {
                realPrice = ((double)102 / (double)100) * (double)realPrice;
            }
            else if(pages >= 21 && pages <= 50)
            {
                realPrice = ((double)103 / (double)100) * (double)realPrice;
            }
            else
            {
                realPrice = ((double)105 / (double)100) * (double)realPrice;
            }
        }
    }
    class Library 
    {
        public List<string> listproduct = new List<string>();
        public void AddMedia()
        {      
            
            do
            {
                Console.WriteLine(" ");
                Console.WriteLine("Enter Type of Product :");
                Console.WriteLine("if you want to finish please enter EXIT!");
                Console.WriteLine(" ");
                string t = Console.ReadLine();

                if(t.ToLower() == "magazine")
                {
                    try
                    {
                        Console.WriteLine("Enter Name : ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter Price : ");
                        int price = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter ID : ");
                        int id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter writer : ");
                        int pages = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Pubisher : ");
                        string publisher = Console.ReadLine();

                        Magazine m = new Magazine(name, price, id, pages, publisher);
                        listproduct.Add(name);
                        listproduct.Add(m.realPrice.ToString());
                        listproduct.Add(id.ToString());
                        listproduct.Add(pages.ToString());
                        listproduct.Add(publisher);

                        if (File.Exists("Products.txt"))
                        {
                            List<string> HoldInfo = new List<string>();
                            StreamReader reader = new StreamReader("Products.txt");
                            string l = "";

                            while ((l = reader.ReadLine()) != null)
                            {
                                HoldInfo.Add(l);
                            }


                            reader.Close();
                            File.WriteAllText("Products.txt", string.Empty);
                            StreamWriter fwriter = new StreamWriter("Products.txt");

                            foreach (string x in HoldInfo)
                            {
                                fwriter.WriteLine(x);
                            }
                            fwriter.WriteLine(name);
                            fwriter.WriteLine(m.realPrice.ToString());
                            fwriter.WriteLine(id);
                            fwriter.WriteLine(pages.ToString());
                            fwriter.WriteLine(publisher);
                            fwriter.Close();
                        }

                        else
                        {
                            StreamWriter fwriter = new StreamWriter("Products.txt");

                            fwriter.WriteLine(name);
                            fwriter.WriteLine(m.realPrice.ToString());
                            fwriter.WriteLine(id);
                            fwriter.WriteLine(pages.ToString());
                            fwriter.WriteLine(publisher);
                            fwriter.Close();
                        }
                    }

                    catch
                    {
                        Console.WriteLine("somathing went wrong");
                    }
                }

                else if (t.ToLower() == "book")
                {
                    try
                    {
                        Console.WriteLine("Enter Name : ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter Price : ");
                        int price = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter ID : ");
                        int id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter writer : ");
                        string writer = Console.ReadLine();
                        Console.WriteLine("Enter Pubisher : ");
                        string publisher = Console.ReadLine();

                        Book b = new Book(name, price, id, writer, publisher);
                        listproduct.Add(name);
                        listproduct.Add(b.realPrice.ToString());
                        listproduct.Add(id.ToString());
                        listproduct.Add(writer);
                        listproduct.Add(publisher);

                        if (File.Exists("Products.txt"))
                        {
                            List<string> HoldInfo = new List<string>();
                            StreamReader reader = new StreamReader("Products.txt");
                            string l = "";

                            while ((l = reader.ReadLine()) != null)
                            {
                                HoldInfo.Add(l);
                            }

                            reader.Close();
                            File.WriteAllText("Products.txt", string.Empty);
                            StreamWriter fwriter = new StreamWriter("Products.txt");

                            foreach (string x in HoldInfo)
                            {
                                fwriter.WriteLine(x);
                            }
                            fwriter.WriteLine(name);
                            fwriter.WriteLine(b.realPrice.ToString());
                            fwriter.WriteLine(id);
                            fwriter.WriteLine(writer);
                            fwriter.WriteLine(publisher);
                            fwriter.Close();
                        }

                        else
                        {
                            StreamWriter fwriter = new StreamWriter("Products.txt");

                            fwriter.WriteLine(name);
                            fwriter.WriteLine(b.realPrice.ToString());
                            fwriter.WriteLine(id);
                            fwriter.WriteLine(writer);
                            fwriter.WriteLine(publisher);
                            fwriter.Close();
                        }
                    }

                    catch
                    {
                        Console.WriteLine("somathing went wrong");
                    }
                }
                else if (t.ToLower() == "movie")
                {
                    try
                    {
                        Console.WriteLine("Enter Name : ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter Price : ");
                        int price = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter ID : ");
                        int id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Number of CDs : ");
                        int CDs = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter time : ");
                        int time = int.Parse(Console.ReadLine());

                        Movie m = new Movie(name, price, id, time, CDs);
                        listproduct.Add(name);
                        listproduct.Add(m.realPrice.ToString());
                        listproduct.Add(id.ToString());
                        listproduct.Add(time.ToString());
                        listproduct.Add(CDs.ToString());

                        if (File.Exists("Products.txt"))
                        {
                            List<string> HoldInfo = new List<string>();
                            StreamReader reader = new StreamReader("Products.txt");
                            string l = "";

                            while ((l = reader.ReadLine()) != null)
                            {
                                HoldInfo.Add(l);
                            }

                            File.WriteAllText("Products.txt", string.Empty);
                            reader.Close();
                            StreamWriter fwriter = new StreamWriter("Products.txt");

                            foreach (string x in HoldInfo)
                            {
                                fwriter.WriteLine(x);
                            }

                            fwriter.WriteLine(name);
                            fwriter.WriteLine(m.realPrice.ToString());
                            fwriter.WriteLine(id);
                            fwriter.WriteLine(CDs);
                            fwriter.WriteLine(time);
                            fwriter.Close();
                        }

                        else
                        {
                            StreamWriter fwriter = new StreamWriter("Products.txt");

                            fwriter.WriteLine(name);
                            fwriter.WriteLine(m.realPrice.ToString());
                            fwriter.WriteLine(id);
                            fwriter.WriteLine(CDs);
                            fwriter.WriteLine(time);
                            fwriter.Close();
                        }
                    }

                    catch
                    {
                        Console.WriteLine("somathing went wrong");
                    }
                }
                
                else if (t.ToLower() == "exit")
                {
                    break;
                }
                Console.WriteLine("Product has been added !");

            } while (true);
        }
        public void DelMedia()
        {
            do
            {
                Console.WriteLine(" ");
                Console.WriteLine("if you want to finish please enter EXIT!");
                Console.WriteLine("Please Enter id of the Media you want to delete!");
                Console.WriteLine(" ");
                string i = Console.ReadLine();

                if (i.ToLower() == "exit")
                {
                    break;
                }

                try
                {
                    for (int j = 2; j < listproduct.Count; j += 5)
                    {
                        if (listproduct[j] == i)
                        {
                            listproduct.RemoveRange(j - 2, 5);
                            break;
                        }
                    }

                    if (File.Exists("Products.txt"))
                    {
                        List<string> HoldInfo = new List<string>();
                        StreamReader reader = new StreamReader("Products.txt");
                        string l = "";

                        while ((l = reader.ReadLine()) != null)
                        {
                            HoldInfo.Add(l);
                        }

                        reader.Close();
                        File.WriteAllText("Products.txt", string.Empty);
                        StreamWriter fwriter = new StreamWriter("Products.txt");

                        foreach (string x in HoldInfo)
                        {
                            fwriter.WriteLine(x);
                        }

                        for (int j = 0; j < listproduct.Count; j++)
                        {
                            fwriter.WriteLine(listproduct[j]);
                        }
                        fwriter.Close();
                    }

                    else
                    {
                        StreamWriter fwriter = new StreamWriter("Products.txt");

                        for (int j = 0; j < listproduct.Count; j++)
                        {
                            fwriter.WriteLine(listproduct[j]);
                        }
                        fwriter.Close();
                    }
                }
                catch
                {
                    Console.WriteLine("something went wrong");
                }
   
            } while (true);
        }
        public void SearchMedia()
        {
            do
            {
                Console.WriteLine(" ");
                Console.WriteLine("if you want to finish please enter EXIT!");
                Console.WriteLine("Please Enter id of the Media you want to search!");
                Console.WriteLine(" ");
                string i = Console.ReadLine();

                if(i.ToLower() == "exit")
                {
                    break;
                }

                bool real = false;

                try
                {
                    for (int j = 2; j < listproduct.Count; j += 5)
                    {
                        if (listproduct[j] == i)
                        {
                            real = true;
                            Console.WriteLine(listproduct[j - 2]);
                            Console.WriteLine(listproduct[j - 1]);
                            Console.WriteLine(listproduct[j]);
                            Console.WriteLine(listproduct[j + 1]);
                            Console.WriteLine(listproduct[j + 2]);
                            break;
                        }
                    }

                    if (!real)
                    {
                        Console.WriteLine("Not Found!");
                    }
                }
                catch
                {
                    Console.WriteLine("something went wrong");
                }
            } while (true);

        }
    }

    //******************************************************************************************

    enum PERSONTYPE { ADMIN, USER };
    class Program
    {
        static void Main(string[] args)
        {
            string a = "";

            Library library = new Library();

            try
            {
                if (File.Exists("Products.txt"))
                {
                    List<string> HoldInfo = new List<string>();
                    StreamReader reader = new StreamReader("Products.txt");
                    string l = "";

                    while ((l = reader.ReadLine()) != null)
                    {
                        HoldInfo.Add(l);
                        library.listproduct.Add(l);
                    }

                    reader.Close();
                    File.WriteAllText("Products.txt", string.Empty);
                    StreamWriter fwriter = new StreamWriter("Products.txt");

                    foreach (string x in HoldInfo)
                    {
                        fwriter.WriteLine(x);
                    }
                }
            }
            catch
            {
                Console.WriteLine("something went wrong");
            }

            do
            {
                Console.WriteLine("choose ADMIN or USER or EXIT");
                Console.WriteLine(" ");
                a = Console.ReadLine();

                string pass, c;

                try
                {
                    if ((PERSONTYPE)Enum.Parse(typeof(PERSONTYPE), a, true) == PERSONTYPE.ADMIN)
                    {
                        Seller seller = new Seller();

                        do
                        {
                            Console.WriteLine("Please Enter your password :");
                            pass = Console.ReadLine();

                        } while (seller.CHECKPASS(pass) == false);

                        do
                        {
                            Console.WriteLine("choose : ADD , DELETE , SEARCH , SHOWCUSTOMERS , CHANGEPASS , EXIT");
                            c = Console.ReadLine();

                            if (c.ToUpper() == "ADD")
                            {
                                library.AddMedia();
                            }
                            else if (c.ToUpper() == "DELETE")
                            {
                                library.DelMedia();
                            }
                            else if (c.ToUpper() == "SEARCH")
                            {
                                library.SearchMedia();
                            }
                            else if (c.ToUpper() == "SHOWCUSTOMERS")
                            {
                                try
                                {
                                    List<string> HoldInfo = new List<string>();
                                    StreamReader reader = new StreamReader("CustomersInfo.txt");
                                    string l = "";

                                    while ((l = reader.ReadLine()) != null)
                                    {
                                        HoldInfo.Add(l);
                                        Console.WriteLine(l);
                                    }

                                    reader.Close();
                                    File.WriteAllText("Products.txt", string.Empty);
                                    StreamWriter fwriter = new StreamWriter("Products.txt");

                                    foreach (string x in HoldInfo)
                                    {
                                        fwriter.WriteLine(x);
                                    }
                                    fwriter.Close();
                                }
                                catch
                                {
                                    Console.WriteLine("something went wrong");
                                }
                            }
                            else if (c.ToUpper() == "CHANGEPASS")
                            {
                                do
                                {
                                    Console.WriteLine("Please Enter current password");
                                    pass = Console.ReadLine();

                                } while (seller.CHECKPASS(pass) == false);

                                seller.ChangePassword();
                            }
                            else if (c.ToLower() == "exit")
                            {
                                break;
                            }

                        } while (true);
                    }

                    else if ((PERSONTYPE)Enum.Parse(typeof(PERSONTYPE), a, true) == PERSONTYPE.USER)
                    {
                        do
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine("Please choose what type of user you are ");
                            Console.WriteLine("Student , Teacher , Customer");
                            Console.WriteLine(" ");
                            c = Console.ReadLine();

                            int[] chances = new int[9] { 0, 2, 3, 5, 7, 10, 15, 25, 30 };


                            if (c.ToLower() == "student")
                            {
                                try
                                {
                                    List<string> cart = new List<string>();
                                    int t = 0;
                                    int chance = 0;

                                    Student student = new Student();
                                    student.SaveInfo();

                                    do
                                    {
                                        Console.WriteLine("Please choose SELECT , EDIT , BUY , CHANCE , EXIT");
                                        string nmd = Console.ReadLine();

                                        if (nmd.ToLower() == "select")
                                        {
                                            for (int i = 0; i < library.listproduct.Count; i++)
                                            {
                                                Console.WriteLine(library.listproduct[i]);

                                                if (i % 5 == 4)
                                                {
                                                    Console.WriteLine(" ");
                                                }
                                            }

                                            do
                                            {
                                                Console.WriteLine(" ");
                                                Console.WriteLine("if you want to finish please enter EXIT!");
                                                Console.WriteLine("Enter Product name that you want to add");
                                                Console.WriteLine(" ");
                                                string n = Console.ReadLine();

                                                int hold = 0;
                                                bool real = false;

                                                for (int i = 0; i < library.listproduct.Count; i += 5)
                                                {
                                                    if (library.listproduct[i] == n)
                                                    {
                                                        cart.Add(library.listproduct[i]);
                                                        cart.Add(library.listproduct[i + 1]);
                                                        cart.Add(library.listproduct[i + 2]);
                                                        cart.Add(library.listproduct[i + 3]);
                                                        cart.Add(library.listproduct[i + 4]);
                                                        real = true;
                                                        Console.WriteLine("Product Added");

                                                        hold += int.Parse(library.listproduct[i + 1]);
                                                        Console.WriteLine("Purchase : " + hold);
                                                        break;
                                                    }
                                                }

                                                if (real == false)
                                                {
                                                    Console.WriteLine("Not Found!");
                                                }

                                                if (n.ToLower() == "exit")
                                                {
                                                    break;
                                                }

                                            } while (t < 20);
                                        }
                                        else if (nmd.ToLower() == "edit")
                                        {
                                            for (int i = 0; i < cart.Count; i++)
                                            {
                                                Console.WriteLine(cart[i]);
                                                if (i % 5 == 4)
                                                {
                                                    Console.WriteLine(" ");
                                                }
                                            }

                                            Console.WriteLine(" ");
                                            Console.WriteLine("Enter Product name that you want to delete");
                                            Console.WriteLine(" ");
                                            string n = Console.ReadLine();

                                            bool real = false;
                                            for (int i = 0; i < cart.Count; i += 5)
                                            {
                                                if (n == cart[i])
                                                {
                                                    cart.RemoveRange(i, 5);
                                                    Console.WriteLine("Product Deleted");
                                                    real = true;
                                                    break;
                                                }
                                            }
                                            if (real == false)
                                            {
                                                Console.WriteLine("Not Found!");
                                            }
                                        }
                                        else if (nmd.ToLower() == "buy")
                                        {
                                            int hold = 0;
                                            for (int i = 0; i < cart.Count; i += 5)
                                            {
                                                hold += int.Parse(cart[i + 1]);
                                            }

                                            double d = ((double)80 - (double)chances[chance]) / (double)100;
                                            double final = d * (double)hold;
                                            Console.WriteLine("Your final purchase is : {0}", final);

                                            for (int i = 0; i < cart.Count; i += 5)
                                            {
                                                for (int j = 0; j < library.listproduct.Count; j += 5)
                                                {
                                                    if (library.listproduct[j] == cart[i])
                                                    {
                                                        library.listproduct.RemoveRange(j, 5);
                                                    }
                                                }
                                            }

                                            StreamWriter fwriter = new StreamWriter("Products.txt");

                                            for (int i = 0; i < library.listproduct.Count; i++)
                                            {
                                                fwriter.WriteLine(library.listproduct[i]);
                                            }
                                            fwriter.Close();
                                        }

                                        else if (nmd.ToLower() == "chance")
                                        {
                                            Random r = new Random();
                                            chance = r.Next(0, 100000) % 9;
                                        }

                                        else if (nmd.ToLower() == "exit")
                                        {
                                            break;
                                        }

                                    } while (true);
                                }
                                catch
                                {
                                    Console.WriteLine("something went wrong");
                                }
                            }
       
                            else if (c.ToLower() == "teacher")
                            {
                                try
                                {
                                    List<string> cart = new List<string>();
                                    int t = 0;
                                    int chance = 0;

                                    Console.WriteLine("enter name ");
                                    string name = Console.ReadLine();
                                    Console.WriteLine("enter institute");
                                    string ins = Console.ReadLine();

                                    Teacher teacher = new Teacher(name, ins);
                                    teacher.SaveInfo();

                                    do
                                    {
                                        Console.WriteLine("Please choose SELECT , EDIT , BUY , CHANCE , EXIT");
                                        string nmd = Console.ReadLine();

                                        if (nmd.ToLower() == "select")
                                        {
                                            for (int i = 0; i < library.listproduct.Count; i++)
                                            {
                                                Console.WriteLine(library.listproduct[i]);

                                                if (i % 5 == 4)
                                                {
                                                    Console.WriteLine(" ");
                                                }
                                            }
                                            do
                                            {
                                                Console.WriteLine(" ");
                                                Console.WriteLine("if you want to finish please enter EXIT!");
                                                Console.WriteLine("Enter Product name that you want to add");
                                                Console.WriteLine(" ");
                                                string n = Console.ReadLine();

                                                int hold = 0;
                                                bool real = false;
                                                for (int i = 0; i < library.listproduct.Count; i += 5)
                                                {
                                                    if (library.listproduct[i] == n)
                                                    {
                                                        cart.Add(library.listproduct[i]);
                                                        cart.Add(library.listproduct[i + 1]);
                                                        cart.Add(library.listproduct[i + 2]);
                                                        cart.Add(library.listproduct[i + 3]);
                                                        cart.Add(library.listproduct[i + 4]);
                                                        real = true;
                                                        Console.WriteLine("Product Added");

                                                        hold += int.Parse(library.listproduct[i + 1]);
                                                        Console.WriteLine("Purchase : " + hold);
                                                        break;
                                                    }
                                                }
                                                if (real == false)
                                                {
                                                    Console.WriteLine("Not Found!");
                                                }

                                                if (n.ToLower() == "exit")
                                                {
                                                    break;
                                                }
                                            } while (t < 20);
                                        }
                                        else if (nmd.ToLower() == "edit")
                                        {
                                            for (int i = 0; i < cart.Count; i++)
                                            {
                                                Console.WriteLine(cart[i]);
                                                if (i % 5 == 4)
                                                {
                                                    Console.WriteLine(" ");
                                                }
                                            }
                                            Console.WriteLine(" ");
                                            Console.WriteLine("Enter Product name that you want to delete");
                                            Console.WriteLine(" ");
                                            string n = Console.ReadLine();

                                            bool real = false;
                                            for (int i = 0; i < cart.Count; i += 5)
                                            {
                                                if (n == cart[i])
                                                {
                                                    cart.RemoveRange(i, 5);
                                                    Console.WriteLine("Product Deleted");
                                                    real = true;
                                                    break;
                                                }
                                            }
                                            if (real == false)
                                            {
                                                Console.WriteLine("Not Found!");
                                            }
                                        }
                                        else if (nmd.ToLower() == "buy")
                                        {
                                            int hold = 0;

                                            for (int i = 0; i < cart.Count; i += 5)
                                            {
                                                hold += int.Parse(cart[i + 1]);
                                            }

                                            if (cart.Count / 5 >= 3)
                                            {
                                                double d = ((double)85 - (double)chances[chance]) / (double)100;
                                                double final = d * (double)hold;
                                                Console.WriteLine("Your final purchase is : {0}", final);
                                            }
                                            else
                                            {
                                                double d = ((double)100 - (double)chances[chance]) / (double)100;
                                                double final = d * (double)hold;
                                                Console.WriteLine("Your final purchase is : {0}", final);
                                            }

                                            for (int i = 0; i < cart.Count; i += 5)
                                            {
                                                for (int j = 0; j < library.listproduct.Count; j += 5)
                                                {
                                                    if (library.listproduct[j] == cart[i])
                                                    {
                                                        library.listproduct.RemoveRange(j, 5);
                                                    }
                                                }
                                            }

                                            StreamWriter fwriter = new StreamWriter("Products.txt");

                                            for (int i = 0; i < library.listproduct.Count; i++)
                                            {
                                                fwriter.WriteLine(library.listproduct[i]);
                                            }
                                            fwriter.Close();
                                        }
                                        else if (nmd.ToLower() == "chance")
                                        {
                                            Random r = new Random();
                                            chance = r.Next(0, 100000) % 9;
                                        }
                                        else if (nmd.ToLower() == "exit")
                                        {
                                            break;
                                        }

                                    } while (true);
                                }
                                catch
                                {
                                    Console.WriteLine("something went wrong");
                                }
                            }
                            else if (c.ToLower() == "customer")
                            {
                                try
                                {
                                    List<string> cart = new List<string>();
                                    int t = 0;
                                    int chance = 0;

                                    Customer customer = new Customer();
                                    customer.SaveInfo();

                                    do
                                    {
                                        Console.WriteLine("Please choose SELECT , EDIT , BUY , CHANCE , EXIT");
                                        string nmd = Console.ReadLine();

                                        if (nmd.ToLower() == "select")
                                        {
                                            for (int i = 0; i < library.listproduct.Count; i++)
                                            {
                                                Console.WriteLine(library.listproduct[i]);

                                                if (i % 5 == 4)
                                                {
                                                    Console.WriteLine(" ");
                                                }
                                            }
                                            do
                                            {
                                                Console.WriteLine(" ");
                                                Console.WriteLine("if you want to finish please enter EXIT!");
                                                Console.WriteLine("Enter Product name that you want to add");
                                                Console.WriteLine(" ");
                                                string n = Console.ReadLine();

                                                int hold = 0;
                                                bool real = false;
                                                for (int i = 0; i < library.listproduct.Count; i += 5)
                                                {
                                                    if (library.listproduct[i] == n)
                                                    {
                                                        cart.Add(library.listproduct[i]);
                                                        cart.Add(library.listproduct[i + 1]);
                                                        cart.Add(library.listproduct[i + 2]);
                                                        cart.Add(library.listproduct[i + 3]);
                                                        cart.Add(library.listproduct[i + 4]);
                                                        real = true;
                                                        Console.WriteLine("Product Added");

                                                        hold += int.Parse(library.listproduct[i + 1]);
                                                        Console.WriteLine("Purchase : " + hold);
                                                        break;
                                                    }
                                                }
                                                if (real == false)
                                                {
                                                    Console.WriteLine("Not Found!");
                                                }

                                                if (n.ToLower() == "exit")
                                                {
                                                    break;
                                                }
                                            } while (t < 20);
                                        }
                                        else if (nmd.ToLower() == "edit")
                                        {
                                            for (int i = 0; i < cart.Count; i++)
                                            {
                                                Console.WriteLine(cart[i]);

                                                if (i % 5 == 4)
                                                {
                                                    Console.WriteLine(" ");
                                                }
                                            }

                                            Console.WriteLine("Enter Product name that you want to delete");
                                            string n = Console.ReadLine();

                                            bool real = false;
                                            for (int i = 0; i < cart.Count; i += 5)
                                            {
                                                if (n == cart[i])
                                                {
                                                    cart.RemoveRange(i, 5);
                                                    Console.WriteLine("Product Deleted");
                                                    real = true;
                                                    break;
                                                }
                                            }
                                            if (real == false)
                                            {
                                                Console.WriteLine("Not Found!");
                                            }
                                        }
                                        else if (nmd.ToLower() == "buy")
                                        {
                                            int hold = 0;

                                            for (int i = 0; i < cart.Count; i += 5)
                                            {
                                                hold += int.Parse(cart[i + 1]);
                                            }

                                            if (cart.Count / 5 >= 5)
                                            {
                                                double d = ((double)95 - (double)chances[chance]) / (double)100;
                                                double final = d * (double)hold;
                                                Console.WriteLine("Your final purchase is : {0}", final);
                                            }
                                            else
                                            {
                                                double d = ((double)100 - (double)chances[chance]) / (double)100;
                                                double final = d * (double)hold;
                                                Console.WriteLine("Your final purchase is : {0}", final);
                                            }

                                            for (int i = 0; i < cart.Count; i += 5)
                                            {
                                                for (int j = 0; j < library.listproduct.Count; j += 5)
                                                {
                                                    if (library.listproduct[j] == cart[i])
                                                    {
                                                        library.listproduct.RemoveRange(j, 5);
                                                    }
                                                }
                                            }

                                            StreamWriter fwriter = new StreamWriter("Products.txt");

                                            for (int i = 0; i < library.listproduct.Count; i++)
                                            {
                                                fwriter.WriteLine(library.listproduct[i]);
                                            }

                                            fwriter.Close();
                                        }
                                        else if (nmd.ToLower() == "chance")
                                        {
                                            Random r = new Random();
                                            chance = r.Next(0, 100000) % 9;
                                        }
                                        else if (nmd.ToLower() == "exit")
                                        {
                                            break;
                                        }

                                    } while (true);
                                }
                                catch
                                {
                                    Console.WriteLine("something went wrong");
                                }
                            }
                            else if (c.ToLower() == "exit")
                            {
                                break;
                            }

                        } while (true);
                    }
                }

                catch
                {
                    Console.WriteLine("something went wrong");
                }

                } while (a != "EXIT") ;
            }
        
    }
    //exeption
}
