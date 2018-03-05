using System;
using System.Collections.Generic;
using System.Text;


public class Spy : Soldier, ISpy
{
    public Spy(string id, string firstName, string lastName, int codeNumber)
        : base(id, firstName, lastName)
    {
        this.CodeNumber = codeNumber;
    }

    private int codeNumber;

    public int CodeNumber
    {
        get { return codeNumber; }
        set { codeNumber = value; }
    }

    public override string ToString()
    {
        return base.ToString() + Environment.NewLine + $"Code Number: {this.CodeNumber}";
    }
}

