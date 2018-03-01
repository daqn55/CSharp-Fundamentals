using System;
using System.Collections.Generic;
using System.Text;


public class Ferrari : ICars
{
    private string driver;

    public string Driver
    {
        get { return driver; }
        set { driver = value; }
    }

    private string model = "488-Spider";

    public string Model
    {
        get { return model; }
    }


    public string Breaks()
    {
        return "Brakes!";
    }
    public string GasPedal()
    {
        return "Zadu6avam sA!";
    }

    public Ferrari(string driver)
    {
        this.Driver = driver;
    }

    public override string ToString()
    {
        return this.Model + "/" + this.Breaks() + "/" + this.GasPedal() + "/" + this.Driver;
    }
}

