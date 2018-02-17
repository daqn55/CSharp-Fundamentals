using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    private string model;

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    private Engine engine;

    public Engine Engine
    {
        get { return engine; }
        set { engine = value; }
    }

    private string weight;

    public string Weight
    {
        get { return weight; }
        set { weight = value; }
    }

    private string color;

    public string Color
    {
        get { return color; }
        set { color = value; }
    }

    public Car()
    {
        this.Weight = "n/a";
        this.Color = "n/a";
    }
    public Car(string model, Engine engine, string weight, string color):this()
    {
        this.Model = model;
        this.Engine = engine;
        this.Weight = weight;
        this.Color = color;
    }

    public override string ToString()
    {
        return $"{this.Model}:\r\n" +
            $"  {this.Engine.Model}:\r\n" +
            $"    Power: {this.Engine.Power}\r\n" +
            $"    Displacement: {this.Engine.Displacements}\r\n" +
            $"    Efficiency: {this.Engine.Efficiency}\r\n" +
            $"  Weight: {this.Weight}\r\n" +
            $"  Color: {this.Color}";
    }
}

