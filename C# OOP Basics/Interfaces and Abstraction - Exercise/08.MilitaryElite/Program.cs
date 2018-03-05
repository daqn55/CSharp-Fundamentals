using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Soldier> soldiers = new List<Soldier>();
        while (true)
        {
            string[] input = Console.ReadLine().Split();
            if (input[0] == "End")
            {
                break;
            }
            DataCollect(input, soldiers);
        }

        Console.WriteLine(string.Join(Environment.NewLine, soldiers));
    }

    public static void DataCollect(string[] input, List<Soldier> soldiers)
    {
        switch (input[0])
        {
            case "Private":
                Private @private = new Private(input[1], input[2],
                    input[3], double.Parse(input[4]));
                soldiers.Add(@private);
                break;
            case "Spy":
                Spy spy = new Spy(input[1], input[2],
                    input[3], int.Parse(input[4]));

                soldiers.Add(spy);
                break;
            case "LeutenantGeneral":
                List<Soldier> privates = new List<Soldier>();

                for (int i = 5; i < input.Length; i++)
                {
                    string id = input[i];
                    privates.Add(soldiers.Find(x => x.Id == id));
                }

                LeutenantGeneral leutenantGeneral = new LeutenantGeneral(
                    input[1], input[2], input[3], double.Parse(input[4]),
                    privates);

                soldiers.Add(leutenantGeneral);
                break;
            case "Engineer":
                if (input[5] == "Airforces" || input[5] == "Marines")
                {
                    List<string> partNames = new List<string>();
                    List<int> hoursWorked = new List<int>();

                    for (int i = 6; i < input.Length - 1; i += 2)
                    {
                        partNames.Add(input[i]);
                        hoursWorked.Add(int.Parse(input[i + 1]));
                    }

                    Engineer engineer = new Engineer(input[1], input[2], input[3], double.Parse(input[4]), input[5],
                        partNames, hoursWorked);
                    soldiers.Add(engineer);
                }
                break;
            case "Commando":
                if (input[5] == "Airforces" || input[5] == "Marines")
                {
                    List<string> codeNames = new List<string>();
                    List<string> misionState = new List<string>();

                    for (int i = 6; i < input.Length - 1; i += 2)
                    {
                        if (input[i + 1] == "inProgress" || input[i + 1] == "Finished")
                        {
                            codeNames.Add(input[i]);
                            misionState.Add(input[i + 1]);
                        }
                    }

                    Commando commando = new Commando(input[1], input[2], input[3], double.Parse(input[4]), input[5],
                        codeNames, misionState);

                    soldiers.Add(commando);
                }
                break;
        }
    }
}

