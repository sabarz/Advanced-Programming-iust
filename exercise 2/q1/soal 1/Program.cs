using System;

namespace soal_1
{
    class confrenece
    {
        private string hamayesh;
        private string salon;
        private int zarfiat;
        private participant[] azaa;
        public confrenece(string hamayesh , string salon , int zarfiat)
        {
            this.hamayesh = hamayesh;
            this.salon = salon;
            this.zarfiat = zarfiat; 
        }
        public confrenece(string hamayesh, string salon, int zarfiat, participant[] azaa)
        {
            this.hamayesh = hamayesh;
            this.salon = salon;
            this.zarfiat = zarfiat;
            this.azaa = azaa; 
        }
        public void addPrticipant(int tedad)
        {
            int m = participant.countParticipant();

            if (tedad + m > zarfiat)
                Console.WriteLine("zarfiat nadare!");

            else
            {
                while (tedad > 0)
                {
                    string name = Console.ReadLine();
                    string lastname = Console.ReadLine();
                    int id = int.Parse(Console.ReadLine());

                    azaa[m] = new participant(name, lastname, id);
                    m++;
                    tedad--;
                }
            }
        }

    }
    class participant
    {
        private string name;
        private string lastname;
        private int id;
        private int price = p ;
        static int n = 0;
        static int p = 990 ;
        public participant(int id)
        {
            this.id = id;
            n++;
        }
        public participant(string name , string lastname , int id)
        {
            this.name = name;
            this.lastname = lastname;
            this.id = id;
            n++; 
        }
        public static int countParticipant()
        {
            return n;
        }
        static int calculatePrice()
        {
            p += 10;
            return p;
        }
    }
    class Program
    {
        static void Main()
        {
        }
    
    }
}
