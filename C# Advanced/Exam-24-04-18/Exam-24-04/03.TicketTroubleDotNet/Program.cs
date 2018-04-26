using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.TicketTroubleDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            string location = Console.ReadLine();
            string tickets = Console.ReadLine();

            string pattern = @"(?:({[^{}]+})|(\[[^\[\]]+\]))";
            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(tickets);

            List<string> seats = new List<string>();
            foreach (Match m in matches)
            {
                var singleTicked = m.ToString();
                if (singleTicked.Length > location.Length)
                {
                    if (singleTicked.StartsWith("["))
                    {
                        string innerPattern = @"{[^{}]+}";
                        Regex innerRegex = new Regex(innerPattern);
                        MatchCollection innerMatches = innerRegex.Matches(singleTicked);
                        var isOurLoc = false;
                        List<string> memSeats = new List<string>();
                        foreach (Match innerMatch in innerMatches)
                        {
                            if (innerMatch.ToString() == "{" + location + "}")
                            {
                                isOurLoc = true;
                            }

                            memSeats.Add(innerMatch.ToString());
                        }
                        if (isOurLoc)
                        {
                            memSeats.Remove("{" + location + "}");
                            seats.AddRange(memSeats);
                        }
                    }
                    else if (singleTicked.StartsWith("{"))
                    {
                        string innerPattern = @"\[[^\[\]]+\]";
                        Regex innerRegex = new Regex(innerPattern);
                        MatchCollection innerMatches = innerRegex.Matches(singleTicked);
                        var isOurLoc = false;
                        List<string> memSeats = new List<string>();
                        foreach (Match innerMatch in innerMatches)
                        {
                            if (innerMatch.ToString() == "[" + location + "]")
                            {
                                isOurLoc = true;
                            }
                            memSeats.Add(innerMatch.ToString());
                        }

                        if (isOurLoc)
                        {
                            memSeats.Remove("[" + location + "]");
                            seats.AddRange(memSeats);
                        }
                    }
                }
            }

            for (int y = 0; y < seats.Count; y++)
            {
                var newSeat = "";
                for (int i = 1; i < seats[y].Length - 1; i++)
                {
                    newSeat += seats[y][i];
                }
                seats[y] = newSeat;
            }


            var firstSeat = "";
            var secondSeat = "";
            if (seats.Count > 2)
            {
                string numPattern = @"[0-9]+";
                Regex numRegex = new Regex(numPattern);
                var numToSame = "";
                Match firstMatch = numRegex.Match(seats[0]);
                numToSame = firstMatch.ToString();
                foreach (var s in seats)
                {
                    Match match = numRegex.Match(s);
                    if (numToSame == match.ToString())
                    {
                        numToSame = match.ToString();
                    }
                }

                firstSeat = seats.First(x => x.EndsWith(numToSame));
                seats.Remove(firstSeat);
                secondSeat = seats.FirstOrDefault(x => x.EndsWith(numToSame));
                if (secondSeat == default(string))
                {
                    firstSeat = seats[0];
                    secondSeat = seats[1];
                }
            }
            else
            {
                firstSeat = seats[0];
                secondSeat = seats[1];
            }

            Console.WriteLine($"You are traveling to {location} on seats {firstSeat} and {secondSeat}.");
        }
    }
}

