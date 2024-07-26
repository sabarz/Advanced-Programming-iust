using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace soal_3
{
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

    public static class Extentions
    {
        public static Nullable<int> ParseIntOrNull(this string str)
           => !string.IsNullOrEmpty(str) ? int.Parse(str) as Nullable<int> : null;
        public static string ParseStringOrNull(this string str)
            => !string.IsNullOrEmpty(str) ? str : null;

        public static IMDBData GetHighestMetascore(this IEnumerable<IMDBData> data)
           => data.OrderByDescending(x => x.Metascore).First();
        public static void WRITELINE(this IEnumerable<string> movies)
        {
            foreach(string i in movies)
            {
                Console.WriteLine(i);
            }
        }
        public static List<string> UnderHunderedTime(this IEnumerable<IMDBData> movies)
        {
             return movies.Where(x => x.Runtime < 100).GroupBy(x => x.Genre).Select(x => x.Key).ToList();
        }
        public static List<string> VinDiesel(this IEnumerable<IMDBData> movies)
        {
            return movies.Where(x => x.Actor1.Contains("Vin Diesel") || x.Actor2.Contains("Vin Diesel") ||
                    x.Actor3.Contains("Vin Diesel") || x.Actor4.Contains("Vin Diesel"))
                    .Select(x => x.Director).ToList();
        }
        public static List<string> MostRated(this IEnumerable<IMDBData> movies)
        {
            List<string> ans = new List<string>();
            IMDBData selected = movies.Where(x => x.Year == 2016).OrderByDescending(x => x.Votes).First();

            ans.Add(Convert.ToString("Title : " + selected.Title));
            ans.Add(Convert.ToString("Rank : " + selected.Rank));
            ans.Add(Convert.ToString("Genre :" + selected.Genre));
            ans.Add(Convert.ToString("Director : " + selected.Director));
            ans.Add(Convert.ToString("Actors : : " + selected.Actor1+"," + selected.Actor2 + "," + selected.Actor3 + "," + selected.Actor4));
            ans.Add(Convert.ToString("Year: " + selected.Year ));
            ans.Add(Convert.ToString("Time :" + selected.Runtime));
            ans.Add(Convert.ToString("Rating: " + selected.Rating ));
            ans.Add(Convert.ToString("Vote :" + selected.Votes));
            ans.Add(Convert.ToString("Revenue: " + selected.Revenue));
            ans.Add(Convert.ToString(" Meta score : " + selected.Metascore));

            return ans;
        }
        public static List<string> BryanSinger(this IEnumerable<IMDBData> movies)
        {
            List<IMDBData> selected = movies.Where(x => x.Director == "Bryan Singer").OrderByDescending(x => x.Revenue).Select(x => x).ToList() ;
            
            List<string> ans = new List<string>();
            foreach(IMDBData i in selected)
            ans.Add(Convert.ToString(i.Title + " " + i.Revenue));
            
            return ans;
        }
        public static double Sailin2011(this IEnumerable<IMDBData> movies) =>movies.Where(x => x.Year == 2011).Sum(x => double.Parse(x.Revenue));
        
        public static List<string> Top10ActionMovies(this IEnumerable<IMDBData> movies)=> movies.Where(x => x.Genre == "Action").Where(x => x.Runtime > 120)
                                                          .OrderByDescending(x => double.Parse(x.Revenue)).Select(x => x.Title).Take(10).ToList();
        
        public static List<string> NumberInName(this IEnumerable<IMDBData> movies) 
        {
            return movies.Where(x => x.Title.Any(y => char.IsDigit(y))).Select(x => x.Title).ToList(); 
        }
        public static List<string> TwoActorsRating(this IEnumerable<IMDBData> movies)
        {
            List<string> hold = new List<string>();

            hold.Add("Jennifer Lawrence");
            hold.AddRange(movies.Where(x => x.Actor1.Contains("Jennifer Lawrence") || x.Actor2.Contains("Jennifer Lawrence") ||
                x.Actor3.Contains("Jennifer Lawrence") || x.Actor4.Contains("Jennifer Lawrence"))             
                     .OrderByDescending(x => x.Year).ThenBy(x => double.Parse(x.Rating)).Select(x => x.Title).Reverse().ToList());

            hold.Add("Anne Hathaway");
            hold.AddRange(movies.Where(x => x.Actor1.Contains("Anne Hathaway") ||x.Actor2.Contains("Anne Hathaway") ||
                x.Actor3.Contains("Anne Hathaway") || x.Actor4.Contains("Anne Hathaway"))
                     .OrderByDescending(x => x.Year).ThenBy(x => double.Parse(x.Rating)).Select(x => x.Title).Reverse().ToList());

            return hold;
        }
        public static List<string> MoviesDramComedyRateUp(this IEnumerable<IMDBData> movies)
        {
            List<IMDBData> hold = new List<IMDBData>();
            List<string> ans = new List<string>();
            ans.Add("number of comedy");
            hold = movies.Where(x => x.Genre =="Comedy" && double.Parse(x.Rating) > 8).Select(x => x).ToList();
            ans.AddRange(hold.Select(x => x.Title));
            int com = hold.Count;
            ans.Add(com.ToString());
            ans.Add("number of drama");
            hold = movies.Where(x => x.Genre == "Drama" && double.Parse(x.Rating) > 8).ToList();
            ans.AddRange(hold.Select(x => x.Title));
            int dram = hold.Count;
            ans.Add(dram.ToString());

            return ans;
        }
        public static string BadActors(this IEnumerable<IMDBData> movies)
        {
            List<string> hold = new List<string>();
            hold.AddRange(movies.Where(x => double.Parse(x.Rating) < 7).Select(x => x.Actor1.Replace('"',' ')));
            hold.AddRange(movies.Where(x => double.Parse(x.Rating) < 7).Select(x => x.Actor2.Replace('"', ' ')));
            hold.AddRange(movies.Where(x => double.Parse(x.Rating) < 7).Select(x => x.Actor3.Replace('"', ' ')));
            hold.AddRange(movies.Where(x => double.Parse(x.Rating) < 7).Select(x => x.Actor4.Replace('"', ' ')));

            return hold.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var data = File.ReadAllLines(@"..\..\IMDB-Movie-Data.csv")
                .Skip(1)
                .Select(line => new IMDBData(line));
            Console.WriteLine($"The film with highest metascore : {data.GetHighestMetascore().Title}");
            Console.WriteLine($"Question 1:");
            data.UnderHunderedTime().WRITELINE();
            Console.WriteLine($"Question 2: ");
            data.VinDiesel().WRITELINE();
            Console.WriteLine($"Question 3: ");
            data.MostRated().WRITELINE();
            Console.WriteLine($"Question 4: ");
            data.BryanSinger().WRITELINE();
            Console.WriteLine($"Question 5: {data.Sailin2011()}");
            Console.WriteLine($"Question 6: ");
            data.Top10ActionMovies().WRITELINE();
            Console.WriteLine($"Question 7: ");
            data.NumberInName().WRITELINE();
            Console.WriteLine($"Question 8: ");
            data.TwoActorsRating().WRITELINE();
            Console.WriteLine($"Question 9: ");
            data.MoviesDramComedyRateUp().WRITELINE();
            Console.WriteLine($"Question 10: {data.BadActors()}");
        }
    }
}
