using System;

namespace soal_2
{
    class Program
    {
        static void Main()
        {
            string st = Console.ReadLine();
            string main = Console.ReadLine();
            string tobe = Console.ReadLine();

            string[] part = st.Split(' '); 

            for(int i = part.Length-1 ; i >= 0 ; i --)
            {
                if (part[i].CompareTo(main) == 0)
                    Console.Write(tobe);

                else
                Console.Write(part[i]); 

                if(i != 0 && i != part.Length)
                Console.Write("&") ;
            }
          //  st = st.Replace(' ', '&');
            //Console.WriteLine(st); 

            
        }
    }
}
