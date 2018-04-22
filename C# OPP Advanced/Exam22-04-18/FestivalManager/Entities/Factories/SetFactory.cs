using System;

using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;





namespace FestivalManager.Entities.Factories
{
	using Contracts;
	using Entities.Contracts;

	public class SetFactory : ISetFactory
	{
		public ISet CreateSet(string name, string type)
		{
            Type typeOfSet = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == type);
            var constructors = typeOfSet.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
            ISet set = (ISet)constructors[0].Invoke(new object[] { name });

            return set;
		}
	}




}
