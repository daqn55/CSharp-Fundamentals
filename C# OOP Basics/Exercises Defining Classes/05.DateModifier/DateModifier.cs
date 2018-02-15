using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;


public class DateModifier
{
    public double DifferenceBetweenTwoDates(string firstDate, string secondDate)
    {
        var dateOne = DateTime.ParseExact(firstDate, "yyyy MM dd", CultureInfo.InvariantCulture);
        var dateTwo = DateTime.ParseExact(secondDate, "yyyy MM dd", CultureInfo.InvariantCulture);

        double days = (dateOne - dateTwo).TotalDays;
        return days;
    }
}

