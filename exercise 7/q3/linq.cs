using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment11
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = File.ReadAllLines(@"IMDB-Movie-Data.csv")
                .Skip(1)
                .Select(line => new IMDBData(line));
            Console.WriteLine($"The film with highest metascore : {data.GetHighestMetascore().Title}");
           Console.WriteLine("Q1\n");
            data.Under100Film().write();
            Console.WriteLine("\nQ2");
            data.Director().write();
            Console.WriteLine("\nQ3");
            Console.WriteLine( data.TopRated());
            Console.WriteLine("\nQ4");
            data.Bryanfilms().write();
            Console.WriteLine("\nQ5");
            Console.WriteLine(data.Total().ToString());
            Console.WriteLine("\nQ6");
            data.Top10().write();
            Console.WriteLine("\nQ7");
            data.digit().write();
            Console.WriteLine("\nQ8");
            data.specifiedfilm().write();
            Console.WriteLine("\nQ9");
            data.compare().write();
            Console.WriteLine("\nQ10");
            Console.WriteLine(data.worst());
            Console.ReadLine();
        }
    }
    public static class Extensions
    {
        public static void write(this List<string> s )
        {
            s.ForEach(x => Console.WriteLine(x));
        }
        public static Nullable<int> ParseIntOrNull(this string str)
            => !string.IsNullOrEmpty(str) ? int.Parse(str) as Nullable<int> : null;
        public static string ParseStringOrNull(this string str)
            => !string.IsNullOrEmpty(str) ? str : null;
        public static IMDBData GetHighestMetascore(this IEnumerable<IMDBData> data)
            => data.OrderByDescending(x => x.Metascore).First();
        public static IMDBData ExtensionMethodPlaceHolder(this IEnumerable<IMDBData> data)
            => data.First();
    public static List<string> Under100Film(this IEnumerable<IMDBData> data)
    {
        List<string> ls = new List<string>();
        ls.AddRange(data.Where(x => x.Runtime < 100).ToList().Select(x => x.Genre).ToList().Where(x => !ls.Contains(x)));
        return ls;
    }
        public static List<string> Director(this IEnumerable<IMDBData> data) => data.Where(x => x.Actor1.Contains("Vin Diesel") || x.Actor2.Contains("Vin Diesel") || x.Actor3.Contains("Vin Diesel") || x.Actor4.Contains("Vin Diesel")).ToList().Select(x => x.Director).ToList();     public static string TopRated(this IEnumerable<IMDBData> data)
    {
        IMDBData top = data.Where(x => x.Year==2016).OrderByDescending(x => x.Votes).First();
        return String.Format("Title :{0}\nGenre :{1}\nDirector:{2}\nActors : {3},{4},{5},{6}\nYear : {7}\nRuntime :{8}\nRating :{9}\n Votes :{10}\n Revenue : {11}\n Metascore : {12}", top.Title, top.Genre, top.Director, top.Actor1, top.Actor2, top.Actor3, top.Actor4,top.Year, top.Runtime, top.Rating, top.Votes, top.Revenue, top.Metascore);
    }
        public static List<string> Bryanfilms(this IEnumerable<IMDBData> data) => data.Where(x => x.Director.Equals("Bryan Singer")).ToList().OrderByDescending(x => double.Parse(x.Revenue)).ToList().Select(x => x.Title).ToList();
        public static double Total(this IEnumerable<IMDBData> data) => data.Where(x => x.Year == 2011).ToList().Sum(x => double.Parse(x.Revenue));
        public static List<string> Top10(this IEnumerable<IMDBData> data) => data.Where(x => x.Genre.Equals("Action") && x.Runtime > 120).ToList().OrderByDescending(x => double.Parse(x.Revenue)).Take(10).Select(x => x.Title).ToList();
        public static List<string> digit(this IEnumerable<IMDBData> data) => data.Where(x => x.Title.ToList().Any(y => char.IsDigit(y))).Select(x=> x.Title).ToList();
        public static List<string> specifiedfilm(this IEnumerable<IMDBData> data)
    {
        List<string> ls = new List<string>();
        ls.Add("Jennifer Lawrence");
        ls.AddRange(data.Where(x => x.Actor1.Contains("Jennifer Lawrence") || x.Actor2.Contains("Jennifer Lawrence") || 
        x.Actor3.Contains("Jennifer Lawrence") || x.Actor4.Contains("Jennifer Lawrence"))
            .OrderByDescending(x => x.Year).ThenBy(x => double.Parse(x.Rating)).Select(x => x.Title).ToList());
        ls.Add("Anne Hathaway");
        ls.AddRange(data.Where(x => x.Actor1.Contains("Anne Hathaway") || x.Actor2.Contains("Anne Hathaway") || x.Actor3.Contains("Anne Hathaway") || x.Actor4.Contains("Anne Hathaway"))
            .OrderByDescending(x => x.Year).ThenBy(x => double.Parse(x.Rating)).Select(x => x.Title).ToList());            
        return ls;
    }
    public static List<string> compare(this IEnumerable<IMDBData> data)
    {
        List<string> ls = new List<string>();
        ls.Add("Drama movies");
        ls.AddRange(data.Where(x => double.Parse(x.Rating) > 8 && x.Genre.Equals("Drama")).Select(x => x.Title).ToList());
        int count1 = ls.Count - 1;
        ls.Add("Count of drama movies " +count1.ToString());
        ls.Add("\nComedy movies");
        ls.AddRange(data.Where(x => double.Parse(x.Rating) > 8 && x.Genre.Equals("Comedy")).Select(x => x.Title).ToList());
        ls.Add("Count of comedy movies " + (ls.Count - (count1) - 3).ToString());
        return ls;
    }
    public static string worst(this IEnumerable<IMDBData> data)
        {
            List<string> ln = new List<string>();
            data.Where(x => double.Parse(x.Rating) < 7).ToList().ForEach(x => { ln.Add(x.Actor1.Replace('"','\t').TrimStart().TrimEnd()); 
                ln.Add(x.Actor2.Replace('"', '\t').TrimStart().TrimEnd());ln.Add(x.Actor3.Replace('"', '\t').TrimStart().TrimEnd());
                ln.Add(x.Actor4.Replace('"', '\t').TrimStart().TrimEnd()); });
            return ln.GroupBy(s => s).Where(x => x.Count() >= 1).OrderByDescending(x => x.Count()).Select(x => x.Key).First();
        }
    }
    public class IMDBData
    {
        public IMDBData(string line)
        {
            var toks = line.Split(',');
            Rank = int.Parse(toks[0]);
            Title = toks[1];
            Genre = toks[2];
            Director = toks[3];
            Actor1 = toks[4];
            Actor2 = toks[5];
            Actor3 = toks[6];
            Actor4 = toks[7];
            Year = int.Parse(toks[8]);
            Runtime = int.Parse(toks[9]);
            Rating = (toks[10]);
            Votes = int.Parse(toks[11]);
            Revenue = toks[12].ParseStringOrNull();
            Metascore = toks[13].ParseIntOrNull();
        }
        public int Rank;
        public string Title;
        public string Genre;
        public string Director;
        public string Actor1;
        public string Actor2;
        public string Actor3;
        public string Actor4;
        public int Year;
        public int Runtime;
        public string Rating;
        public int Votes;
        public string Revenue;
        public Nullable<int> Metascore;
    }
}
