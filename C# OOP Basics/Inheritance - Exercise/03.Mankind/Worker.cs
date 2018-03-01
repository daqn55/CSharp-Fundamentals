using System;
using System.Collections.Generic;
using System.Text;


public class Worker : Human
{
    private decimal weekSalary;

    public decimal WeekSalary
    {
        get { return weekSalary; }
        set
        {
            if (value <= 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }
            weekSalary = value;
        }
    }

    private decimal workHoursPerDay;

    public decimal WorkHoursPerDay
    {
        get { return workHoursPerDay; }
        set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }
            workHoursPerDay = value;
        }
    }

    public Worker(string firstName, string lastName, decimal weekSalary, decimal workHoursPerDay)
        : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    public decimal SalaryPerHour()
    {
        decimal weekSalary = this.WeekSalary;
        decimal workHoursPerDay = this.WorkHoursPerDay;

        decimal salaryPerHour = (weekSalary / 5) / workHoursPerDay;

        return salaryPerHour;
    }

    public override string ToString()
    {
        var fullInfoStudent = new StringBuilder();

        fullInfoStudent.Append(this.HumanNames())
            .AppendLine($"Week Salary: {WeekSalary:f2}")
            .AppendLine($"Hours per day: {WorkHoursPerDay:f2}")
            .AppendLine($"Salary per hour: {SalaryPerHour():f2}");

        return fullInfoStudent.ToString();
    }
}

