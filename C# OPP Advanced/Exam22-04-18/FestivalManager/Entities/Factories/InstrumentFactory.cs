namespace FestivalManager.Entities.Factories
{
	using System;
	using System.Linq;
	using System.Reflection;
	using Contracts;
	using Entities.Contracts;

	public class InstrumentFactory : IInstrumentFactory
	{
		public IInstrument CreateInstrument(string type)
		{
            Type typeOfInstrument = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == type);
            var constructors = typeOfInstrument.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
            IInstrument instrument = (IInstrument)constructors[0].Invoke(new object[] { });

            return instrument;
        }
	}
}