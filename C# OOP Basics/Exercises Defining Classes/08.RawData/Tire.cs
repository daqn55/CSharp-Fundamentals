using System;
using System.Collections.Generic;
using System.Text;


public class Tire
{
    private List<int> tireAge = new List<int>();

    public List<int> TireAge
    {
        get { return tireAge; }
        set { tireAge = value; }
    }

    private List<double> tirePressure = new List<double>();

    public List<double> TirePressure
    {
        get { return tirePressure; }
        set { tirePressure = value; }
    }
}

