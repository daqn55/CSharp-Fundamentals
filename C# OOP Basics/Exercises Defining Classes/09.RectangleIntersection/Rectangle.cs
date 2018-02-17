using System;
using System.Collections.Generic;
using System.Text;


public class Rectangle
{
    private string id;

    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    private decimal width;

    public decimal Width
    {
        get { return width; }
        set { width = value; }
    }

    private decimal height;

    public decimal Height
    {
        get { return height; }
        set { height = value; }
    }

    private decimal coordinatesHorizontal;

    public decimal CoordinatesHorizontal
    {
        get { return coordinatesHorizontal; }
        set { coordinatesHorizontal = value; }
    }

    private decimal coordinatesVertical;

    public decimal CoordinatesVertical
    {
        get { return coordinatesVertical; }
        set { coordinatesVertical = value; }
    }


    public Rectangle(string id, decimal width, decimal height, decimal coorHorizontal, decimal coorVertical)
    {
        this.Id = id;
        this.Width = width;
        this.Height = height;
        this.CoordinatesHorizontal = coorHorizontal;
        this.CoordinatesVertical = coorVertical;
    }
}

