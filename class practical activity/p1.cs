using System;
class soal1T1
{
  static void Main() 
  {
    int n = int.Parse(Console.ReadLine());
    int p =0;
    for(int i = 2 ; i <= n ; i ++)
    {
         p = 0 ;
        for(int j = 2 ; j < i/2 ; j++)
        {
            if(i%j == 0)
            {
                p = 1 ;
                break ; 
            }
        }
        
        if(p == 0)
        {
            if(n % i == 0)
            Console.Write(i+" ") ;
        } 
    }
  }
}
