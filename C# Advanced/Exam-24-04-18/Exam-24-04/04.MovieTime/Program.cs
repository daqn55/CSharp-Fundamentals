using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.MovieTime
{
    class Program
    {
        static void Main()
        {
            string genreLike = Console.ReadLine();
            string duration = Console.ReadLine();

            string movies = "";
            Dictionary<string, TimeSpan> moviesInfo = new Dictionary<string, TimeSpan>();
            TimeSpan playlistTime = new TimeSpan();
            while ((movies = Console.ReadLine()) != "POPCORN!")
            {
                string[] infoMovie = movies.Split('|');
                string name = infoMovie[0];
                string genre = infoMovie[1];
                string[] fullTime = infoMovie[2].Split(':');
                TimeSpan movieDuration = new TimeSpan(int.Parse(fullTime[0]), int.Parse(fullTime[1]), int.Parse(fullTime[2]));
                playlistTime += movieDuration;
                if (genreLike == genre)
                {
                    moviesInfo.Add(name, movieDuration);
                }
            }

            string agree = "";
            if (duration == "Long")
            {
                foreach (var movie in moviesInfo.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine(movie.Key);
                    agree = Console.ReadLine();
                    if (agree == "Yes")
                    {
                        Console.WriteLine($"We're watching {movie.Key} - {movie.Value}");
                        Console.WriteLine($"Total Playlist Duration: {playlistTime}");
                        break;
                    }
                }
            }
            else if (duration == "Short")
            {
                foreach (var movie in moviesInfo.OrderBy(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine(movie.Key);
                    agree = Console.ReadLine();
                    if (agree == "Yes")
                    {
                        Console.WriteLine($"We're watching {movie.Key} - {movie.Value}");
                        Console.WriteLine($"Total Playlist Duration: {playlistTime}");
                        break;
                    }
                }
            }

        }
    }
}
