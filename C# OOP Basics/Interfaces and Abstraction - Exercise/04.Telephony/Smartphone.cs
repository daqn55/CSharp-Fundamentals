using System;
using System.Collections.Generic;
using System.Text;


public class Smartphone : ICalling, IBrowsing
{
    public string Calling(string number)
    {
        foreach (var n in number)
        {
            if (!char.IsDigit(n))
            {
                return "Invalid number!";
            }
        }
        return "Calling... " + number;
    }

    public string Browsing(string site)
    {
        foreach (var s in site)
        {
            if (char.IsDigit(s))
            {
                return "Invalid URL!";
            }
        }
        return "Browsing: " + site + "!";
    }
}

