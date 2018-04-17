using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class WareHouse : IWareHouse
{
    public List<IAmmunition> Ammunitions { get; private set; }
}

