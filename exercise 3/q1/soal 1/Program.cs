using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace soal_1
{
    enum search
    {
        Web = 83,
        AI = 36,
        IT = 45,
        IOT = 21,
        Database = 55,
        ImageProcessing = 27
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            
            string first;

            do
            {
                //Admin
                Console.WriteLine("ADMIN , USER , close (to close the program)");
                first = Console.ReadLine();

                int[] count = new int[6];

                if (first == "ADMIN")
                {
                    string pass;
                    do
                    {
                        Console.WriteLine("enter your password to start:");
                        pass = Console.ReadLine();
                    } while (!trypass(pass));

                    string choose;
                    string[] newpass = new string[2];

                    do
                    {
                        Console.WriteLine("choose: Count , ChangePassword , Exit");
                        choose = Console.ReadLine();

                        if (choose == "Count")
                        {
                            Console.WriteLine("83 Web: {0}", count[0]);
                            Console.WriteLine("36 AI: {0}", count[1]);
                            Console.WriteLine("45 IOT: {0}", count[2]);
                            Console.WriteLine("21 IT: {0}", count[3]);
                            Console.WriteLine("55 Database: {0}", count[4]);
                            Console.WriteLine("27 ImageProcessing: {0}", count[5]);
                        }

                        else if (choose == "ChangePassword")
                        {
                            do
                            {
                                Console.WriteLine("enter your password to change :");
                                pass = Console.ReadLine();
                            } while (!trypass(pass));

                            do
                            {
                                Console.WriteLine("enter your new password");
                                newpass[0] = Console.ReadLine();
                                Console.WriteLine("enter your new password again");
                                newpass[1] = Console.ReadLine();

                            } while (newpass[0] != newpass[1]);

                            File.WriteAllText("Password.txt", string.Empty);
                            using (SHA256 sha256Hash = SHA256.Create())
                            {
                                string hash = GetHash(sha256Hash, newpass[0]);

                                File.WriteAllText("Password.txt", string.Empty);
                                StreamWriter writer = new StreamWriter("Password.txt");
                                writer.WriteLine(hash);
                                writer.Close();
                            }
                        }

                    } while (choose != "Exit");
                }

                else if (first == "USER")
                {
                    string search;
                    do
                    {
                        Console.WriteLine("enter your word");
                        search = Console.ReadLine();
                        search s;

                        if (search == "Exit")
                            break;

                        try
                        {
                            if ((search)Enum.Parse(typeof(search), search, true) == (search)Enum.Parse(typeof(search), "83", true))
                            {
                                count[0]++;
                                Console.WriteLine("The World Wide Web commonly known as the Web," +
                                    " is an information system where documents and other web resources are identified");
                            }
                            else if ((search)Enum.Parse(typeof(search), search, true) == (search)Enum.Parse(typeof(search), "36", true))
                            {
                                count[1]++;
                                Console.WriteLine("Artificial intelligence (AI) is intelligence demonstrated by machines");
                            }
                            else if ((search)Enum.Parse(typeof(search), search, true) == (search)Enum.Parse(typeof(search), "45", true))
                            {
                                count[2]++;
                                Console.WriteLine("The Internet of things (IoT) describes the network of physical objects");
                            }
                            else if ((search)Enum.Parse(typeof(search), search, true) == (search)Enum.Parse(typeof(search), "21", true))
                            {
                                count[3]++;
                                Console.WriteLine("Information technology (IT) is the use of computers to store," +
                                    " retrieve, transmit, and manipulate data");
                            }
                            else if ((search)Enum.Parse(typeof(search), search, true) == (search)Enum.Parse(typeof(search), "55", true))
                            {
                                count[4]++;
                                Console.WriteLine("A database is an organized collection of data, " +
                                    "generally stored and accessed electronically");
                            }
                            else if ((search)Enum.Parse(typeof(search), search, true) == (search)Enum.Parse(typeof(search), "27", true))
                            {
                                count[5]++;
                                Console.WriteLine("Digital image processing is the use of a digital computer " +
                                    "to process digital images through an algorithm");
                            }
                            else
                            {
                                throw new Exception("not fount, it is going to be added int future!");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("not fount, it is going to be added in future!");
                        }
                    } while (search != "Exit");
                }

            } while (first != "close");

            Console.Clear(); 
        }

        public static bool trypass(string pass)
        {
            if (!File.Exists("Password.txt"))
            {
                if (pass == "Hello@P")
                {
                    return true;
                }

                else
                {
                    Console.WriteLine("invalid password!");
                    return false;
                }
            }

            else
            {
                StreamReader reader = new StreamReader("Password.txt");
                try
                {
                    string content = reader.ReadLine();
                    reader.Close();
                    using (SHA256 sha256Hash = SHA256.Create())
                    {
                        if (VerifyHash(sha256Hash, pass, content))
                            return true;

                        else
                        {
                            Console.WriteLine("invalid password!");
                            return false;
                        }
                    }
                }
                catch 
                {
                    Console.WriteLine("file not ok!");
                    return false;
                }
                finally
                {
                    reader.Close();
                }
            }
        }
            private static string GetHash(HashAlgorithm hashAlgorithm, string input)
            {
                byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
            private static bool VerifyHash(HashAlgorithm hashAlgorithm, string input, string hash)
            {
                var hashOfInput = GetHash(hashAlgorithm, input);
                StringComparer comparer = StringComparer.OrdinalIgnoreCase;
                return comparer.Compare(hashOfInput, hash) == 0;
            }

        
    }
}