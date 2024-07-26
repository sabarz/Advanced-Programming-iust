using System;

namespace soal_5
{
    class Program
    {
        static void Main()
        {
            string[] st = Console.ReadLine().Split(' ');
            int mazrab = int.Parse(st[0]);
            int ali = int.Parse(st[1]);
            int zahra = int.Parse(st[2]);

            int h1 = 0 , h2 = 0 , h3 = 0 , h4= 0,h5 = 0 ; 

            if(ali > zahra)
            {
                int hold = ali;
                ali = zahra;
                zahra = hold;
            }

            int fasele = zahra - ali; 

            if(ali < 0)
            {
                ali *= -1;
                zahra = ali + fasele;
            }

            //h1
            h1 += ali % mazrab;
            h1 += zahra % mazrab;
            h1++; 

            //h2
            h2 += ali % mazrab;
            h2 += mazrab - (zahra % mazrab);
            h2 += 2; 

            //h3
            h3 += mazrab - (ali % mazrab);
            h3 += zahra % mazrab;

            //h4
            h4 += mazrab - (ali % mazrab);
            h4 += mazrab - (zahra % mazrab);
            h4++;

            //h5
            h5 += fasele; 

            int min = 0 ;

            if (h1 < h2)
                min = h1;
            
            else
                min = h2;

            if (min > h3)
                min = h3;

            if (min > h4)
                min = h4;

            if (min > h5)
                min = h5;

            if(min == h1)
            {
                ali -= ali % mazrab;
                zahra -= zahra % mazrab;
                min--;
            }

            else if(min == h2)
            {
                ali -= ali % mazrab;
                zahra += mazrab - (zahra % mazrab);
                min -= 2;
            }

            else if (min == h3)
            {
                ali += mazrab - (ali % mazrab);
                zahra -= zahra % mazrab;
            }

            else if(min == h4)
            {
                ali += mazrab - (ali % mazrab);
                zahra += mazrab - (zahra % mazrab);
                min--;
            }

            while(ali != zahra && h5 != min)
            {
                ali += mazrab;
                min++; 
            }

            Console.WriteLine(min);
        }
    }
}
