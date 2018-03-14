using System;
using System.Collections.Generic;
using System.Text;


public static class TyreFactory
{
    public static Tyre CreateType(List<string> arguments)
    {
        var tyreType = arguments[4];
        var tyreHardness = double.Parse(arguments[5]);

        if (tyreType == "Ultrasoft")
        {
            var grip = double.Parse(arguments[6]);
            Tyre tyre = new UltrasoftTyre(tyreHardness, grip);
            return tyre;
        }
        else if (tyreType == "Hard")
        {
            Tyre tyre = new HardTyre(tyreHardness);
            return tyre;
        }
        else
        {
            throw new ArgumentException();
        }
    } 
}

