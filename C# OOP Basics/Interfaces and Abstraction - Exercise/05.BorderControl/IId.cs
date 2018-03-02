using System;
using System.Collections.Generic;
using System.Text;


public interface IId
{
    string Id { get; set; }
    bool fakeId(string numToCheck);
}

