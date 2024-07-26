using System;
using System.IO;
using System.Collections.Generic;

namespace soal_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter name of the input file:");
            string input =Console.ReadLine();
            input = input + ".txt"; 

            Console.WriteLine("enter name of the output file:");
            string output = Console.ReadLine();
            output = output + ".txt";

            StreamReader reader = new StreamReader(input);
            int cnt = 0;
            int star = 0, vowel = 0, number = 0;
            List<string> hold = new List<string>();

            while (!reader.EndOfStream)
            {
                hold.Add(reader.ReadLine());
                cnt++;
            }
            reader.Close();

            string[] s = new string[cnt];
            int i = 0;
            foreach (var item in hold)
            {
                s[i] = item;
                i++;
            }

            StreamWriter writer = new StreamWriter(output);

            for(i = 0; i < cnt; i++)
            {
                s[i] = s[i].Replace(' ', '*');
                writer.WriteLine(s[i]);

                foreach(var item in s[i].ToLower())
                {
                    if ("aeiou".Contains(item))
                        vowel++;

                    else if (item == '*')
                        star++;

                    else if (item == '1' || item == '2' || item == '3' || item == '4' || item == '5'
                        || item == '6' || item == '7' || item == '8' || item == '9' || item == '0')
                    {
                        number++;
                    }
                }
            }

            writer.Close();

            Console.WriteLine("Stars: {0} ", star);
            Console.WriteLine("Numbers: {0} ", number);
            Console.WriteLine("vowels: {0}", vowel);
            Console.WriteLine("Lines: {0}", cnt);
        }
    }
}
