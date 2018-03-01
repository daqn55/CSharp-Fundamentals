using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


public class Student : Human
{
    private string facultyNumber;

    public string FacultyNumber
    {
        get { return facultyNumber; }
        set
        {
            bool containsSymbol = false;
            foreach (var c in value)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    containsSymbol = true;
                }
            }
            if (value.Length < 5 || value.Length > 10 || containsSymbol)
            {
                throw new ArgumentException("Invalid faculty number!");
            }
            facultyNumber = value;
        }
    }

    public Student(string firstName, string lastName, string facultyNumber)
        : base(firstName, lastName)
    {
        this.FacultyNumber = facultyNumber;
    }

    public override string ToString()
    {
        var fullInfoStudent = new StringBuilder();

        fullInfoStudent.Append(this.HumanNames())
            .AppendLine($"Faculty number: {FacultyNumber}");

        return fullInfoStudent.ToString();
    }
}

