using System;
using System.Collections.Generic;
using System.Text;


public class Box
{
    private double lenght;

    public double Lenght
    {
        get { return lenght; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Length cannot be zero or negative.");
            }
            lenght = value;
        }
    }

    private double width;

    public double Width
    {
        get { return width; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Width cannot be zero or negative.");
            }
            width = value;
        }
    }

    private double height;

    public double Height
    {
        get { return height; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Height cannot be zero or negative.");
            }
            height = value;
        }
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
