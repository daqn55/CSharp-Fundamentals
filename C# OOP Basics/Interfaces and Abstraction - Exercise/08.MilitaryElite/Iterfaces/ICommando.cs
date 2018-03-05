using System;
using System.Collections.Generic;
using System.Text;


public interface ICommando
{
    List<string> CodeName { get; set; }
    List<string> State { get; set; }
}

