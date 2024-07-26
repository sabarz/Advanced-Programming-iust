using System;
using System.Collections.Generic;

namespace soal_2
{
    enum NameProduct { phone = 1 , car , watch , tshert , laptop , tablet , charger , glass , robot};
    class Product
    {
        private string name;
        private int id;
        private int price;
        private int score;
        private string factory; 

        public string NAME
        {
            get { return name; }
            set { this.name = value; }
        }
        public int ID
        {
            get { return id;}
            set { this.id = value; } 
        }
        public int PRICE
        {
            get { return price; }
            set { this.price = value; }
        }
        public int SCORE
        {
            get { return score; }
            set { this.score = value; }
        }
        public string FACTORY
        {
            get { return factory; }
        }

        public Product(string name , int id , int p , int s )
        {
            ID = id;
            NAME = name;
            PRICE = p;
            SCORE = s;

            if(ID >= 1 && ID <= 5)
            {
                factory = "a";
            }

            else if(ID > 5 && ID <= 10)
            {
                factory = "b";
            }

            else if(ID > 10)
            {
                factory = "c";
            }
        }
        //منحصر بودن عایدی
    }

    class Category
    {
        private int j = 0;
        private int id;
        private NameProduct name;
        private List<Product> product;
        public Category(int id  , NameProduct name)
        {
            this.name = name;
            this.id = id;
            product = new List<Product>();
        }

        public void AddProductCategory(Product[] p)
        {
            for(int i = 0; i < p.Length;i++)
            product.Add(p[i]);
        }

        public List<Product> FilterByPrice(int min , int max)
        {
            List<Product> ans = new List<Product>();

            for(int i = 0; i < product.Count; i++)
            {
                if(product[i].PRICE >= min && product[i].PRICE <= max)
                {
                    ans.Add(product[i]);
                }
            }
          
            return ans;
        }

        public void ShowSupply()
        {
            Product temp ; 

            for (int i = 0; i < product.Count; i ++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (product[i].PRICE < product[j].PRICE)
                    {
                        temp = product[i];
                        product[i] = product[j];
                        product[j] = temp; 
                    }
                }
            }

            for (int i = 0; i < product.Count; i++)
            {
                Console.WriteLine("name : {0} price : {1}" ,product[i].NAME, product[i].PRICE);
            }
        }
    }

    struct People
    {
        public string pname;
        public string lname;
        public int age;
        public string telephone;
    }

    class Cart
    {
        private People People;
        private List<Product> products;
        public Cart(string pname, string lname, int age, string telepgone)
        {
            People.pname = pname;
            People.lname = lname;
            People.age = age;
            People.telephone = telepgone;
            products = new List<Product>();
        }

        public void AddProductToCart(params Product[] product)
        {
            for (int i = 0; i < product.Length; i++)
            {
                products.Add(product[i]);
            }
        }
        
        public void CalculatePrice()
        {
            int hold = 0;
            Console.WriteLine("name and lastname: " + People.pname + " " + People.lname + " ,telephone " + People.telephone);
            
            for(int i = 0; i < products.Count; i ++)
            {
                Console.WriteLine("name :" + products[i].NAME + " price " + products[i].PRICE );
                hold += products[i].PRICE;
            }

            Console.WriteLine("total :" + hold);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string choose;

            do
            {
                Console.WriteLine("choose Category , Cart , Exit");
                choose = Console.ReadLine();

                if (choose == "Category")
                {
                    Console.WriteLine("enter name of category");
                    string name = Console.ReadLine();

                    int id = 9;
                    NameProduct np = NameProduct.robot;

                    if (name == "phone")
                    {
                        id = 1;
                        np = NameProduct.phone;
                    }
                    else if (name == "car")
                    {
                        id = 2;
                        np = NameProduct.car;
                    }
                    else if (name == "watch")
                    {
                        id = 3;
                        np = NameProduct.watch;
                    }
                    else if (name == "T-shert")
                    {
                        id = 4;
                        np = NameProduct.tshert;
                    }
                    else if (name == "laptop")
                    {
                        id = 5;
                        np = NameProduct.laptop;
                    }
                    else if (name == "tablet")
                    {
                        id = 6;
                        np = NameProduct.tablet;
                    }
                    else if (name == "charger")
                    {
                        id = 7;
                        np = NameProduct.charger;
                    }
                    else if (name == "glass")
                    {
                        id = 8;
                        np = NameProduct.glass;
                    }

                    Category cate = new Category(id, np);

                    string work; 

                    do
                    {
                        Console.WriteLine("choose AddProductCategory , FilterByPrice , ShowSupply");
                        work = Console.ReadLine();
                        int n = 0; 

                        if (work == "AddProductCategory")
                        {
                            Console.WriteLine("enter number of products");
                            n = int.Parse(Console.ReadLine());
                            Product[] products = new Product[n];

                            for (int i = 0; i < n; i++)
                            {
                                Console.WriteLine("enter name of product");
                                string nps = Console.ReadLine();
                                Console.WriteLine("enter id of product");
                                int idp = int.Parse(Console.ReadLine());
                                Console.WriteLine("enter price of product");
                                int p = int.Parse(Console.ReadLine());
                                Console.WriteLine("enter score of product");
                                int s = int.Parse(Console.ReadLine());

                                products[i] = new Product(nps, idp, p, s);
                            }
                            cate.AddProductCategory(products);
                        }

                        else if (work == "FilterByPrice")
                        {
                            Console.WriteLine("enter lowerbound and upperbownd");
                            string[] lbub = Console.ReadLine().Split(' ');
                            Console.WriteLine("name of category : {0} and id : {1}", name, id);

                            List<Product> hold = new List<Product>();
                            hold = cate.FilterByPrice(int.Parse(lbub[0]), int.Parse(lbub[1]));

                            for (int i = 0; i < hold.Count ; i++)
                            {
                                Console.WriteLine("name :{0}  id:{1} ", hold[i].NAME, hold[i].ID);
                                Console.WriteLine("price :{0}  score :{1}", hold[i].PRICE, hold[i].SCORE);
                                Console.WriteLine("factory : " + hold[i].FACTORY);
                            }
                        }

                        else if (work == "ShowSupply")
                        {
                            Console.WriteLine("name of category : {0} and id : {1}", name, id);
                            cate.ShowSupply();
                        }
                    } while (work != "Back");
                }

                else if (choose == "Cart")
                {
                    string t, work = " ";
                    Console.WriteLine("enter your name and lastname");
                    string[] st = Console.ReadLine().Split(' ');
                    Console.WriteLine("enter your age ");
                    int age = int.Parse(Console.ReadLine());

                    do
                    {
                        Console.WriteLine("enter your TELEPHONE ");
                        t = Console.ReadLine();

                    } while (t[0] != '0' || t[1] != '9');

                    Cart cart = new Cart(st[0], st[1], age, t);

                    do
                    {
                        Console.WriteLine("choose AddProductToCart , CaculatePrice , Back");
                        work = Console.ReadLine();
                        
                        if(work == "AddProductToCart")
                        {
                            Console.WriteLine("enter name of product");
                            string nps = Console.ReadLine();
                            Console.WriteLine("enter id of product");
                            int idp = int.Parse(Console.ReadLine());
                            Console.WriteLine("enter price of product");
                            int p = int.Parse(Console.ReadLine());
                            Console.WriteLine("enter score of product");
                            int s = int.Parse(Console.ReadLine());

                            Product products = new Product(nps , idp , p , s);
                            cart.AddProductToCart(products);
                        }
                        else if(work == "CaculatePrice")
                        {
                            cart.CalculatePrice();
                        }

                    } while (work != "Back");
                }

            } while (choose != "Back" && choose != "Exit");

        }
    }
}
