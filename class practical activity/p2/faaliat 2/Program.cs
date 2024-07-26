using System; 

namespace faaliat_2
{
    class Book
    {
        private int pages, price;
        private string writer; 
        public Book (int pprice, int ppages, string pwriter)
        {
            pages = ppages;
            price = pprice;
            writer = pwriter;
        }
        public Book (int pprice , string pwriter)
        {
            price = pprice;
            writer = pwriter;
            Random rd = new Random(); 
            pages = rd.Next(0,100);
        }

        public void PrintInfo()
        {
            Console.WriteLine(price +" "+ pages+ " " + writer);
        }
    }

    class program
    {
        static void Main ()
        {
            int Price, Page;
            string Writer;
            Price = int.Parse(Console.ReadLine());
            Page = int.Parse(Console.ReadLine());
            Writer = Console.ReadLine();
            
            Book book1;
            book1 = new Book(Price, Page, Writer);

            Price = int.Parse(Console.ReadLine());
            Writer = Console.ReadLine();

            Book book2;
            book2 = new Book(Price, Writer);

            book1.PrintInfo();
            book2.PrintInfo();
        }
    }
}