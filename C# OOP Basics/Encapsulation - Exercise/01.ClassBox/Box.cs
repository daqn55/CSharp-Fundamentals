using System;
using System.Collections.Generic;
using System.Text;


public class Box
{
    private double lenght;

    public double Lenght
    {
        get { return lenght; }
        set { lenght = value; }
    }

    private double width;

    public double Width
    {
        get { return width; }
        set { width = value; }
    }

    private double height;

    public double Height
    {
        get { return height; }
        set { height = value; }
    }

    public Box(double lenght, double width, double height)
    {
        this.Lenght = lenght;
        this.Width = width;
        this.Height = height;
    }

    public double SurfaceArea()
    {
        return 2 * lenght * width + 2 * lenght * height + 2 * width * height;
    }

    public double LateralSurface()
    {
        return 2 * lenght * height + 2 * width * height;
    }

    public double Volume()
    {
        return lenght * width * height;
    }
}
