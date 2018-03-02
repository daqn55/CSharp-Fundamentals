using System;
using System.Collections.Generic;
using System.Text;


public class Robot : CityData, IRobot
{
    public Robot(string model, string id) : base(id)
    {
        this.Model = model;
    }

    private string model;

    public string Model
    {
        get { return model; }
        set { model = value; }
    }
}

