using System.Collections.Generic;
using System.Linq;

public class Department
{
    private string averageDepartment;
    private List<decimal> salaryes = new List<decimal>();

    public string AverageDepartment
    {
        get { return averageDepartment; }
        set { averageDepartment = value; }
    }

    public List<decimal> Salaryes
    {
        get { return salaryes; }
        set { salaryes = value; }
    }

    public Department(){}

    public Department(string averageDepartment, List<decimal> salaryes)
    {
        this.Salaryes = salaryes;
        this.AverageDepartment = averageDepartment;
    }
    public decimal AverageSalary => this.salaryes.Average();
    
}