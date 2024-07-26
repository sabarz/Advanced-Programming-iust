using System;
using System.Collections.Generic;
using System.Collections;

namespace soal_4
{
    class GenCol<T1> : IEnumerable<T1> where T1 : IComparable<T1> 
    {
        List<T1> data = new List<T1>();   
        public void add(T1 g1 , T1 g2)
        {
            if(g1.CompareTo(g2) == -1)
            {
                data.Add(g1);
            }

            else
            {
                data.Add(g2);
            }
        } 
        public void remove()
        {
            try
            {
                if (data.Count == 0)
                {
                    throw new Exception("Not found");
                }

                T1 max = data[0];
                int hold = 0;

                for (int i = 1; i < data.Count; i++)
                {
                    if (data[i].CompareTo(max) == 1)
                    {
                        max = data[i];
                        hold = i;
                    }
                }

                data.RemoveAt(hold);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public IEnumerator<T1> GetEnumerator()
        {
            data.Sort();

            foreach (var i in data)
            {
                yield return i;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)data).GetEnumerator();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
