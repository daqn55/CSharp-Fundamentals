using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        List<Rectangle> rectangles = new List<Rectangle>();
        for (int i = 0; i < input[0]; i++)
        {
            string[] data = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Rectangle rectangle = new Rectangle(data[0], decimal.Parse(data[1]), decimal.Parse(data[2]),
                decimal.Parse(data[3]), decimal.Parse(data[4]));

            rectangles.Add(rectangle);
        }

        for (int i = 0; i < input[1]; i++)
        {
            string[] pairsOfIds = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string result = "";
            if (Intersect(pairsOfIds[0], pairsOfIds[1], rectangles))
            {
                result = "true";
            }
            else
            {
                result = "false";
            }
            Console.WriteLine(result);
            
        }
    }

    public static bool Intersect(string firstId, string secondId, List<Rectangle> rectangles)
    {
        decimal widthFirst = rectangles.Find(x => x.Id == firstId).Width;
        decimal heightFirst = rectangles.Find(x => x.Id == firstId).Height;
        decimal coorHorizontalFirst = Math.Abs(rectangles.Find(x => x.Id == firstId).CoordinatesHorizontal);
        decimal coorVertialFirst = Math.Abs(rectangles.Find(x => x.Id == firstId).CoordinatesVertical);

        decimal widthSecond = rectangles.Find(x => x.Id == secondId).Width;
        decimal heightSecond = rectangles.Find(x => x.Id == secondId).Height;
        decimal coorHorizontalSec = Math.Abs(rectangles.Find(x => x.Id == secondId).CoordinatesHorizontal);
        decimal coorVertialSec = Math.Abs(rectangles.Find(x => x.Id == secondId).CoordinatesVertical);



        bool intersect = Math.Abs(coorHorizontalFirst) < Math.Abs(coorHorizontalSec + widthSecond) && Math.Abs(coorHorizontalFirst + widthFirst) >= Math.Abs(coorHorizontalSec)
            && coorVertialFirst < Math.Abs((coorVertialSec - heightSecond)) && Math.Abs(coorVertialFirst + heightFirst) >= Math.Abs(coorVertialSec);

        return intersect;
    }
}

