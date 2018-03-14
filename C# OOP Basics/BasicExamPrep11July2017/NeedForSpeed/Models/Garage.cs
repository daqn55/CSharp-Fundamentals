using System;
using System.Collections.Generic;
using System.Text;


public class Garage
{
    public Garage()
    {
        this.ParkedCars = new List<Car>();
    }

    public List<Car> ParkedCars { get; set; }
}

