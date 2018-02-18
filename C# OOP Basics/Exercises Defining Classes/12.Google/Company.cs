using System;
using System.Collections.Generic;
using System.Text;


public class Company
{
    private string companyName = "";

    public string CompanyName
    {
        get { return companyName; }
        set { companyName = value; }
    }

    private string department;

    public string Department
    {
        get { return department; }
        set { department = value; }
    }

    private decimal salary;

    public decimal Salary
    {
        get { return salary; }
        set { salary = value; }
    }

    public Company(string companyName, string department, decimal salary)
    {
        this.CompanyName = companyName;
        this.Department = department;
        this.Salary = salary;
    }
}

