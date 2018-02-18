using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    private string carModel = "";

    public string CarModel
    {
        get { return carModel; }
        set { carModel = value; }
    }

    private int carSpeed;

    public int CarSpeed
    {
        get { return carSpeed; }
        set { carSpeed = value; }
    }

    public Car(string carModel, int carSpeed)
    {
        this.CarModel = carModel;
        this.CarSpeed = carSpeed;
    }
}

