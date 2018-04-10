using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Commands
{
    public class RetireCommand : Command
    {
        public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string unitType = this.Data[1];
            string output = string.Empty;
            try
            {
                this.Repository.RemoveUnit(unitType);
                output = unitType + " retired!";
            }
            catch (Exception a)
            {
                output = a.Message;
            }


            return output;
        }
    }
}
