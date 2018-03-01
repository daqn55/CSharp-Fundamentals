using System;
using System.Collections.Generic;
using System.Text;


public class Song
{
    private string fullSongInput;

    public string FullSongInput
    {
        get { return fullSongInput; }
        set
        {
            string[] checkIsvalidInput = value.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            bool artist = checkIsvalidInput[0].Length < 3 || checkIsvalidInput[0].Length > 20;
            bool name = checkIsvalidInput[0].Length < 3 || checkIsvalidInput[0].Length > 30;
            bool isDigitMin = int.TryParse(checkIsvalidInput[2].Split(':')[0], out int minutes);
            bool isDigitSec = int.TryParse(checkIsvalidInput[2].Split(':')[1], out int seconds);
            bool length = minutes > 14 && seconds > 59 || minutes < 0 && seconds < 0 || !isDigitMin || !isDigitSec;

            if (checkIsvalidInput.Length != 3 && artist && name && length)
            {
                throw new ArgumentException("Invalid song.");
            }
            fullSongInput = value;
        }
    }

    private string artist;

    public string Artist
    {
        get { return artist; }
        set
        {
            if (value.Length < 3 || value.Length > 20)
            {
                throw new ArgumentException("Artist name should be between 3 and 20 symbols.");
            }
            artist = value;
        }
    }

    private string songName;

    public string SongName
    {
        get { return songName; }
        set
        {
            if (value.Length < 3 || value.Length > 30)
            {
                throw new ArgumentException("Song name should be between 3 and 30 symbols.");
            }
            songName = value;
        }
    }
    private string songLength;

    public string SongLength
    {
        get { return songLength; }
        set
        {
            string[] time = value.Split(':', StringSplitOptions.RemoveEmptyEntries);

            bool isDigitMin = int.TryParse(time[0], out int minutes);
            bool isDigitSec = int.TryParse(time[1], out int seconds);
            
            if (minutes > 14 && seconds > 59 || minutes < 0 && seconds < 0 || !isDigitMin || !isDigitSec || time.Length > 2)
            {
                throw new ArgumentException("Invalid song length.");
            }
            else if (minutes > 14 || minutes < 0)
            {
                throw new ArgumentException("Song minutes should be between 0 and 14.");
            }
            else if (seconds > 59 || seconds < 0)
            {
                throw new ArgumentException("Song seconds should be between 0 and 59.");
            }
            songLength = value;
        }
    }

    public Song(string fullSongInput, string artist, string songName, string songLength)
    {
        this.FullSongInput = fullSongInput;
        this.Artist = artist;
        this.SongName = songName;
        this.SongLength = songLength;
    }

    public override string ToString()
    {
        return $"Song added.";
    }
}

