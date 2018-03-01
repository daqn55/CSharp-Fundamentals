using System;
using System.Collections.Generic;
using System.Text;


public interface ICars
{
    string Driver { get; }
    string Model { get; }
    string Breaks();
    string GasPedal();
}

