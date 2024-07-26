using System;
using System.Collections.Generic;

namespace soal_2
{
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

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (i == 0)
                    {
                        if (j == 0)
                        {
                            boxes.Add(new Box(i, j, 5, 0));
                        }
                        else if (j == 1)
                        {
                            boxes.Add(new Box(i, j, 3, 0));
                        }
                        else if (j == 4)
                        {
                            boxes.Add(new Box(i, j, 7, 0));
                        }
                        else
                            boxes.Add(new Box(i, j, 0, 1));
                    }

                    else if (i == 1)
                    {
                        if (j == 0)
                        {
                            boxes.Add(new Box(i, j, 6, 0));
                        }
                        else if (j == 3)
                        {
                            boxes.Add(new Box(i, j, 1, 0));
                        }
                        else if (j == 4)
                        {
                            boxes.Add(new Box(i, j, 9, 0));
                        }
                        else if (j == 5)
                        {
                            boxes.Add(new Box(i, j, 5, 0));
                        }
                        else
                            boxes.Add(new Box(i, j, 0, 1));
                    }
                    else if (i == 2)
                    {
                        if (j == 1)
                        {
                            boxes.Add(new Box(i, j, 9, 0));
                        }
                        else if (j == 2)
                        {
                            boxes.Add(new Box(i, j, 8, 0));
                        }
                        else if (j == 7)
                        {
                            boxes.Add(new Box(i, j, 6, 0));
                        }
                        else
                            boxes.Add(new Box(i, j, 0, 1));
                    }
                    else if (i == 3)
                    {
                        if (j == 0)
                        {
                            boxes.Add(new Box(i, j, 8, 0));
                        }
                        else if (j == 4)
                        {
                            boxes.Add(new Box(i, j, 6, 0));
                        }
                        else if (j == 8)
                        {
                            boxes.Add(new Box(i, j, 3, 0));
                        }
                        else
                            boxes.Add(new Box(i, j, 0, 1));
                    }
                    else if (i == 4)
                    {
                        if (j == 0)
                        {
                            boxes.Add(new Box(i, j, 4, 0));
                        }
                        else if (j == 3)
                        {
                            boxes.Add(new Box(i, j, 8, 0));
                        }
                        else if (j == 5)
                        {
                            boxes.Add(new Box(i, j, 3, 0));
                        }
                        else if (j == 8)
                        {
                            boxes.Add(new Box(i, j, 1, 0));
                        }

                        else
                            boxes.Add(new Box(i, j, 0, 1));

                    }
                    else if (i == 5)
                    {
                        if (j == 0)
                        {
                            boxes.Add(new Box(i, j, 7, 0));
                        }
                        else if (j == 4)
                        {
                            boxes.Add(new Box(i, j, 2, 0));
                        }
                        else if (j == 8)
                        {
                            boxes.Add(new Box(i, j, 6, 0));
                        }

                        else
                            boxes.Add(new Box(i, j, 0, 1));

                    }
                    else if (i == 6)
                    {
                        if (j == 1)
                        {
                            boxes.Add(new Box(i, j, 6, 0));
                        }
                        else if (j == 6)
                        {
                            boxes.Add(new Box(i, j, 2, 0));
                        }
                        else if (j == 7)
                        {
                            boxes.Add(new Box(i, j, 8, 0));
                        }

                        else
                            boxes.Add(new Box(i, j, 0, 1));

                    }
                    else if (i == 7)
                    {
                        if (j == 3)
                        {
                            boxes.Add(new Box(i, j, 4, 0));
                        }
                        else if (j == 4)
                        {
                            boxes.Add(new Box(i, j, 1, 0));
                        }
                        else if (j == 5)
                        {
                            boxes.Add(new Box(i, j, 9, 0));
                        }
                        else if (j == 8)
                        {
                            boxes.Add(new Box(i, j, 5, 0));
                        }

                        else
                            boxes.Add(new Box(i, j, 0, 1));

                    }
                    else if (i == 8)
                    {
                        if (j == 4)
                        {
                            boxes.Add(new Box(i, j, 8, 0));
                        }
                        else if (j == 7)
                        {
                            boxes.Add(new Box(i, j, 7, 0));
                        }
                        else if (j == 8)
                        {
                            boxes.Add(new Box(i, j, 9, 0));
                        }
                        else
                            boxes.Add(new Box(i, j, 0, 1));
                    }
                }
            }

            string[] a = new string[4];

            do
            {
                Console.WriteLine("Add or Del or ShowChart or Exit");
                a = Console.ReadLine().Split(' ');

                if (a[0] == "Add")
                {
                    int radif = int.Parse(a[1]) - 1;
                    int sotoon = int.Parse(a[2]) - 1;
                    int value = int.Parse(a[3]);
                    int nmd = radif * 8 + sotoon+radif;
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

                            else if(boxes[hold].value == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write(boxes[hold].value + " ");
                            }

                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(boxes[hold].value + " ");
                            }

                            if(j % 3 == 2)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("| ");
                            }
                            hold++;
                        }

                        if(i % 3 == 2)
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            for(int t = 0; t < 23; t++)
                            {
                                Console.Write("-");
                            }
                        }
                        Console.WriteLine();
                    }
                }

            } while (a[0] != "Exit");

        }
    }
}