using System;
using System.Collections.Generic;
using System.Text;


public class Garage
{
    public Garage()
    {
        this.ParkedCars = new Dictionary<int, Car>();
    }

    public Dictionary<int, Car> ParkedCars { get; set; }
}

