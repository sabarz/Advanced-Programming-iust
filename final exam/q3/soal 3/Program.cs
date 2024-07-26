using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace soal_3
{
    interface Iprintable<t>
    {
        string print();
    }
    
    class Program
    {
        void genFun<t>(t nmd) where t : Iprintable<t>, IEnumerable<t>
        {
            Random r = new Random();
            string path = "OUT" + r.Next(1000, 9999) + "txt";
            
            StreamWriter writer = new StreamWriter(path);
            writer.WriteLine(nmd.LongCount());
            writer.WriteLine(nmd.print());

            writer.Close();
        }
        static void Main(string[] args)
        {

        }
    }
}
