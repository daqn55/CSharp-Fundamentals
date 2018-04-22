namespace FestivalManager.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
	using Contracts;
	using Controllers.Contracts;
    using FestivalManager.Core.Controllers;
    using FestivalManager.Core.IO;
    using FestivalManager.Entities;
    using IO.Contracts;

	class Engine : IEngine
	{
	    private IReader Reader;
        private IWriter Writer;

        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;

        public Engine(IFestivalController festivalCоntroller, ISetController setCоntroller)
        {
            this.festivalCоntroller = festivalCоntroller;
            this.setCоntroller = setCоntroller;
            this.Reader = new Reader();
            this.Writer = new Writer();
        }

        public void Run()
        {
            while (true)
            {
                var input = this.Reader.ReadLine();
                if (input == "END")
                {
                    this.Writer.WriteLine("Results:");
                    this.Writer.WriteLine(this.festivalCоntroller.ProduceReport());
                    break;
                }

                this.Writer.WriteLine(ProcessCommand(input));
            }
        }

        public string ProcessCommand(string input)
        {
            var args = input.Split();
            var commandName = args[0];
            string[] argsToSend = args.Skip(1).ToArray();

            try
            {
                if (commandName != "LetsRock")
                {
                    Assembly assembly = Assembly.GetCallingAssembly();
                    Type commandType = assembly.GetType(typeof(FestivalController).FullName);
                    object[] argsOfMethod = new object[] { argsToSend };

                    var method = commandType.GetMethods().FirstOrDefault(m => m.Name == commandName);
                    var result = method.Invoke(this.festivalCоntroller, argsOfMethod);

                    return result.ToString();
                }
                else
                {
                    return this.setCоntroller.PerformSets();
                }
            }
            catch (TargetInvocationException a)
            {
                return "ERROR: " + a.InnerException.Message;
            }
            
        }
    }
}