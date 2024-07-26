using System;
using System.Collections.Generic;

namespace soal_2
{
     class Sudoku
     {
        public int[,] mat;
        public int n; 
        public int s; 
        public int k; 
        public Sudoku(int k)
        {
            n = 9;
            this.k = k;

            s = 3;

            mat = new int[n, n];
        }

        public void Values()
        {
            Diagonal();

            Remaining(0, s);

            removedigits();
        }

        void Diagonal()
        {

            for (int i = 0; i < n; i = i + s)

                fillBox(i, i);
        }

        bool unUsed(int r, int c, int num)
        {
            for (int i = 0; i < s; i++)
                for (int j = 0; j < s; j++)
                    if (mat[r + i, c + j] == num)
                        return false;

            return true;
        }

        void fillBox(int row, int col)
        {
            int num;
            for (int i = 0; i < s; i++)
            {
                for (int j = 0; j < s; j++)
                {
                    do
                    {
                        num = randomGenerator(n);
                    }
                    while (!unUsed(row, col, num));

                    mat[row + i, col + j] = num;
                }
            }
        }

        int randomGenerator(int num)
        {
            Random rand = new Random();
            return (int)Math.Floor((rand.NextDouble() * num + 1));
        }
        bool CheckIfSafe(int i, int j, int num)
        {
            return (unUsedInRow(i, num) &&
                    unUsedInCol(j, num) &&
                    unUsed(i - i % s, j - j % s, num));
        }

        bool unUsedInRow(int i, int num)
        {
            for (int j = 0; j < n; j++)
                if (mat[i, j] == num)
                    return false;
            return true;
        }

        bool unUsedInCol(int j, int num)
        {
            for (int i = 0; i < n; i++)
                if (mat[i, j] == num)
                    return false;
            return true;
        }
        bool Remaining(int i, int j)
        {
            if (j >= n && i < n - 1)
            {
                i = i + 1;
                j = 0;
            }
            if (i >= n && j >= n)
                return true;

            if (i < s)
            {
                if (j < s)
                    j = s;
            }
            else if (i < n - s)
            {
                if (j == (int)(i / s) * s)
                    j = j + s;
            }
            else
            {
                if (j == n - s)
                {
                    i = i + 1;
                    j = 0;
                    if (i >= n)
                        return true;
                }
            }

            for (int num = 1; num <= n; num++)
            {
                if (CheckIfSafe(i, j, num))
                {
                    mat[i, j] = num;
                    if (Remaining(i, j + 1))
                        return true;

                    mat[i, j] = 0;
                }
            }
            return false;
        }
        public void removedigits()
        {
            int count = k;
            while (count != 0)
            {
                int cellId = randomGenerator(n * n);

                int i = (cellId / n);
                int j = cellId % 9;
                if (j != 0)
                    j = j - 1;

                if (mat[i, j] != 0)
                {
                    count--;
                    mat[i, j] = 0;
                }
            }
        }
    }
    class Box
    {
        public int radif;
        public int sotoon;
        public int value;
        public int able;

        public Box(int radif, int sotoon, int value, int able)
        {
            this.value = value;
            this.radif = radif;
            this.sotoon = sotoon;
            this.able = able;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();

            string[] a = new string[4];

            do
            {
                Console.WriteLine("Add or Del or ShowChart or NewChart or Exit");
                a = Console.ReadLine().Split(' ');

                try
                {
                    if (a[0] == "Add")
                    {
                        int radif = int.Parse(a[1]) - 1 ;
                        int sotoon = int.Parse(a[2]) - 1;
                        int value = int.Parse(a[3]);
                        int nmd = radif * 8 + sotoon + radif;
                        bool hast = true;

                        if (value <= 9 && value >= 1)
                        {
                            if (boxes[nmd].able != 0 && boxes[nmd].able != 2)
                            {
                                if (radif / 3 == 0 && sotoon / 3 == 0)
                                {
                                    for (int j = 0; j < 3; j++)
                                    {
                                        if (value == boxes[j].value || value == boxes[j + 9].value || value == boxes[j + 18].value)
                                        {
                                            hast = false;
                                        }
                                    }
                                }
                                else if (radif / 3 == 0 && sotoon / 3 == 1)
                                {
                                    for (int j = 3; j < 6; j++)
                                    {
                                        if (value == boxes[j].value || value == boxes[j + 9].value || value == boxes[j + 18].value)
                                        {
                                            hast = false;
                                        }
                                    }
                                }
                                else if (radif / 3 == 0 && sotoon / 3 == 2)
                                {
                                    for (int j = 6; j < 9; j++)
                                    {
                                        if (value == boxes[j].value || value == boxes[j + 9].value || value == boxes[j + 18].value)
                                        {
                                            hast = false;
                                        }
                                    }
                                }
                                else if (radif / 3 == 1 && sotoon / 3 == 0)
                                {
                                    for (int j = 27; j < 30; j++)
                                    {
                                        if (value == boxes[j].value || value == boxes[j + 9].value || value == boxes[j + 18].value)
                                        {
                                            hast = false;
                                        }
                                    }
                                }
                                else if (radif / 3 == 1 && sotoon / 3 == 1)
                                {
                                    for (int j = 30; j < 33; j++)
                                    {
                                        if (value == boxes[j].value || value == boxes[j + 9].value || value == boxes[j + 18].value)
                                        {
                                            hast = false;
                                        }
                                    }
                                }
                                else if (radif / 3 == 1 && sotoon / 3 == 2)
                                {
                                    for (int j = 33; j < 36; j++)
                                    {
                                        if (value == boxes[j].value || value == boxes[j + 9].value || value == boxes[j + 18].value)
                                        {
                                            hast = false;
                                        }
                                    }
                                }
                                else if (radif / 3 == 2 && sotoon / 3 == 0)
                                {
                                    for (int j = 54; j < 57; j++)
                                    {
                                        if (value == boxes[j].value || value == boxes[j + 9].value || value == boxes[j + 18].value)
                                        {
                                            hast = false;
                                        }
                                    }
                                }
                                else if (radif / 3 == 2 && sotoon / 3 == 1)
                                {
                                    for (int j = 57; j < 60; j++)
                                    {
                                        if (value == boxes[j].value || value == boxes[j + 9].value || value == boxes[j + 18].value)
                                        {
                                            hast = false;
                                        }
                                    }
                                }
                                else if (radif / 3 == 2 && sotoon / 3 == 2)
                                {
                                    for (int j = 60; j < 63; j++)
                                    {
                                        if (value == boxes[j].value || value == boxes[j + 9].value || value == boxes[j + 18].value)
                                        {
                                            hast = false;
                                        }
                                    }
                                }

                                for (int i = radif * 9; i < (radif * 9) + 8; i++)
                                {
                                    if (boxes[i].value == value)
                                    {
                                        hast = false;
                                    }
                                }

                                for (int i = sotoon; i < sotoon + 72; i += 9)
                                {
                                    if (boxes[i].value == value)
                                    {
                                        hast = false;
                                    }
                                }

                                if (hast == true)
                                {
                                    boxes[nmd].value = value;
                                    boxes[nmd].able = 2;
                                }

                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("not possible!");
                                    Console.ResetColor();
                                    hast = true;
                                }
                            }

                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("home full");
                                Console.ResetColor();
                            }
                        }

                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("wrong value");
                            Console.ResetColor();
                        }
                    }

                    else if (a[0] == "Del")
                    {
                        int radif = int.Parse(a[1]) - 1;
                        int sotoon = int.Parse(a[2]) - 1;
                        int nmd = radif * 8 + sotoon + radif;

                        if (boxes[nmd].able != 0)
                        {
                            boxes[nmd].value = 0;
                            boxes[nmd].able = 1;
                        }
                    }

                    else if (a[0] == "ShowChart")
                    {
                        int hold = 0;

                        for (int t = 0; t < 23; t++)
                        {
                            Console.Write("-");
                        }
                        Console.WriteLine();

                        for (int i = 0; i < 9; i++)
                        {
                            for (int j = 0; j < 9; j++)
                            {
                                if (boxes[hold].able == 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(boxes[hold].value + " ");
                                }

                                else if (boxes[hold].value == 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write(boxes[hold].value + " ");
                                }

                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.Write(boxes[hold].value + " ");
                                }

                                if (j % 3 == 2)
                                {
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("| ");
                                }
                                hold++;
                            }

                            if (i % 3 == 2)
                            {
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.White;
                                for (int t = 0; t < 23; t++)
                                {
                                    Console.Write("-");
                                }
                            }
                            Console.WriteLine();
                        }
                    }
                    else if (a[0] == "NewChart")
                    {
                        Sudoku sudoku = new Sudoku(20);
                        sudoku.Values();
                        for (int i = 0; i < 9; i++)
                        {
                            for (int j = 0; j < 9; j++)
                            {
                                if(sudoku.mat[i, j] == 0)
                                {
                                    boxes.Add(new Box(i, j, sudoku.mat[i, j], 1));
                                }
                                else
                                {
                                    boxes.Add(new Box(i, j, sudoku.mat[i, j], 0));
                                }
                            }
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("there was a problem!");
                }
            } while (a[0] != "Exit");

        }
    }
}