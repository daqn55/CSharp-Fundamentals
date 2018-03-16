using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Nation
{
    public Nation()
    {
        this.Benders = new List<Bender>();
        this.Monuments = new List<Monument>();
    }

    public string Name { get; set; }
    public List<Bender> Benders { get; set; }
    public List<Monument> Monuments { get; set; }
}

