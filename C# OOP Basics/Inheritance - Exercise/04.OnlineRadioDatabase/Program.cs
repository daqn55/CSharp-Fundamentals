using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        List<Song> songs = new List<Song>();
        for (int i = 0; i < n; i++)
        {
            try
            {
                string fullSondInput = Console.ReadLine();
                string[] splitSong = fullSondInput.Split(';', StringSplitOptions.RemoveEmptyEntries);

                Song song = new Song(fullSondInput, splitSong[0], splitSong[1],
                splitSong[2]);
                Console.WriteLine(song);
                songs.Add(song);
            }
            catch (ArgumentException a)
            {
                Console.WriteLine(a.Message);
            }
        }
        Console.WriteLine($"Songs added: {songs.Count}");

        int AllSeconds = 0;
        foreach (var s in songs)
        {
            AllSeconds += int.Parse(s.SongLength.Split(':')[1]) + int.Parse(s.SongLength.Split(':')[0]) * 60;
        }
        TimeSpan t = TimeSpan.FromSeconds(AllSeconds);

        string songsLength = string.Format("{0:D}h {1:D}m {2:D}s",
                t.Hours,
                t.Minutes,
                t.Seconds);
        Console.WriteLine("Playlist length: " + songsLength);
    }
}

