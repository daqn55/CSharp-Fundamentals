using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    private string model;
    private Engine engine = new Engine();
    private Cargo cargo = new Cargo();
    private Tire tire = new Tire();

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public Engine Engine
    {
        get { return engine; }
        set { engine = value; }
    }

    public Cargo Cargo
    {
        get { return cargo; }
        set { cargo = value; }
    }

    public Tire Tire
    {
        get { return tire; }
        set { tire = value; }
    }


    public Car(string model, Engine engine, Cargo cargo, Tire tire)
    {
        this.Model = model;
        this.Engine = engine;
        this.Cargo = cargo;
        this.Tire = tire;
    }
}

