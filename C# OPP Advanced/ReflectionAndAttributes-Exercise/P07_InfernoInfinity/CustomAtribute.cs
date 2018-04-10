using System;
using System.Collections.Generic;
using System.Text;

[System.AttributeUsage(AttributeTargets.Class)]
public class CustomAtribute : Attribute
{
    public string author;
    public int revision;
    public string description;
    public string reviewers;

    public CustomAtribute(string author, int revision, string description, string reviewers)
    {
        this.author = author;
        this.revision = revision;
        this.description = description;
        this.reviewers = reviewers;
    }
}

