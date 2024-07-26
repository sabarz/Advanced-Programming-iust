using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace soal_1
{
    public class Vector<T> : IEnumerable<T> , IEquatable<Vector<T>>
    {
        int number;
        public List<T> data;
        public Vector(int n)
        {
            number = n;
            data = new List<T>();
        }
        public void Add(T NewItem)
        {
            data.Add(NewItem);
        }
        public void AddItem(T NewItem)
        {
            data.Add(NewItem);
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in data)
                yield return item;
        }
        IEnumerator GetEnumerator1()
        {
            return this.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator1(); 
        }
        public bool Equals(Vector<T> NewItem)
        {
            if(this == NewItem)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override string ToString()
        {
            string ans = "[";

            for (int i = 0; i < data.Count; i++)
            {
                if (i <= data.Count - 1)
                {
                    ans += data[i];
                    ans += ",";
                }
                
                else
                {
                    ans += data[i];
                }
            }
            ans += "]";

            return ans;
        }
        public static Vector<T> operator + (Vector<T> v1 , Vector<T> v2)
        {
            if(v1.data.Count != v2.data.Count)
            {
                throw new Exception("can't do the operation!");
            }

            else
            {
                Vector<T> v3 = new Vector<T>(v1.data.Count);
                for (int i = 0; i < v1.data.Count; i++)
                {
                    dynamic nmd1 = v1.data[i];
                    dynamic nmd2 = v2.data[i];
                    v3.data.Add(nmd1 + nmd2);
                }
                return v3;
            }
        }
        public static bool operator ==(Vector<T> v1, Vector<T> v2)
        {
            return Enumerable.SequenceEqual(v1.data, v2.data);
        }
        public static bool operator !=(Vector<T> v1, Vector<T> v2)
        {
            return !(v1 == v2);
        }
    }

    class Matrix<T> : IEnumerable<Vector<T>>, IEquatable<Matrix<T>>
    {
        List<Vector<T>> vectors;
        int colomn, row;
        public Matrix(int r, int c)
        {
            colomn = c;
            row = r;
            vectors = new List<Vector<T>>();
        }
        public void Add(Vector<T> NewItem)
        {
            vectors.Add(NewItem);
        }
        public void AddItem(Vector<T> NewItem)
        {
            vectors.Add(NewItem);
        }
        public IEnumerator<Vector<T>> GetEnumerator()
        {
            foreach (Vector<T> item in vectors)
                yield return item;
        }
        IEnumerator GetEnumerator1()
        {
            return this.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator1();
        }
        public bool Equals(Matrix<T> NewItem)
        {
            if (this == NewItem)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    
        public override string ToString()
        {
            string ans = "[ ";
            for (int i = 0; i < row ; i++)
            {
                ans += "[ ";
                for (int j = 0; j < colomn; j++)
                {
                    if (j < colomn - 1)
                    {
                        ans += vectors[i].data[j];
                        ans += ",";
                    }

                    else
                    {
                        ans += vectors[i].data[j];
                    }
                }
                ans += " ]";
            }
            ans += " ]";

            return ans;
        }

        public static Matrix<T> operator +(Matrix<T> m1, Matrix<T> m2)
        {
            Matrix<T> m3 = new Matrix<T>(m1.row, m1.colomn);

            if (m1.row != m2.row || m1.colomn != m2.colomn)
            {
                throw new Exception("can't do the operation!");
            }
            else
            {
                for(int i = 0; i < m1.vectors.Count; i++)
                {
                    dynamic nmd1 = m1.vectors[i];
                    dynamic nmd2 = m2.vectors[i];
                    m3.vectors.Add(nmd1 + nmd2);
                }
            }

            return m3;
        }
        public static bool operator == (Matrix<T> m1, Matrix<T> m2)
        {
            if(m1.row != m2.row || m1.colomn != m2.colomn)
            {
                return false;
            }
            else
            {
                for(int i = 0; i < m1.row; i++)
                {
                    if(m1.vectors[i] != m2.vectors[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }
        public static bool operator !=(Matrix<T> m1, Matrix<T> m2)
        {
            return !(m1 == m2);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Vector<int> v1 = new Vector<int>(5) { 0, 1, 2, 3, 4 };
            Vector<int> v2 = new Vector<int>(5) {50, 12, 7, 9, 10};
            Vector<string> v3 = new Vector<string>(3) { "ali" , "maryam " , "saba"};

            Console.WriteLine(v2.ToString());

            Console.WriteLine((v2 + v1).ToString());

            if(v3.Equals(v1))
            {
                Console.WriteLine("V1 and V3 are equal");
            }

            else
            {
                Console.WriteLine("V1 and V3 are not equal");
            }

            Matrix<int> m1 = new Matrix<int>(4, 2){ new Vector<int>(2) { 1,2 },
                                                    new Vector<int>(2) { 3,4 },
                                                    new Vector<int>(2) { 5,6 },
                                                    new Vector<int>(2) { 7,8 }}; 
            
            Matrix<string> m2 = new Matrix<string>(3, 2) { new Vector<string>(2) { "ab", "cd" },
                                                            new Vector<string>(2) { "ef", "gh" },     
                                                            new Vector<string>(2) { "ij" , "kl" } };

            Matrix<string> m3 = new Matrix<string>(3, 2){ new Vector<string>(2) { "ab", "cd" },
                                                            new Vector<string>(2) { "ef", "gh" },
                                                            new Vector<string>(2) { "ij" , "kl" } }; ;

            Console.WriteLine(m1.ToString());

            Console.WriteLine((m2 + m3).ToString());

            if (m3.Equals(m1))
            {
                Console.WriteLine("M1 and M3 are equal");
            }
            else
            {
                Console.WriteLine("M1 and M3 are not equal");
            }
        }
    }
}
