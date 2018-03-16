using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        NationsBuilder nationsBuilder = new NationsBuilder();
        bool programStop = false;

        while (true)
        {
            string[] input = Console.ReadLine().Split();
            if (programStop)
            {
                break;
            }

            List<string> arguments = input.Skip(1).ToList();

            switch (input[0])
            {
                case "Bender":
                    nationsBuilder.AssignBender(arguments);
                    break;
                case "Monument":
                    nationsBuilder.AssignMonument(arguments);
                    break;
                case "Status":
                    Console.WriteLine(nationsBuilder.GetStatus(arguments[0]));
                    break;
                case "War":
                    nationsBuilder.IssueWar(arguments[0]);
                    break;
                case "Quit":
                    Console.WriteLine(nationsBuilder.GetWarsRecord());
                    programStop = true;
                    break;
            }
        }
    }
}

