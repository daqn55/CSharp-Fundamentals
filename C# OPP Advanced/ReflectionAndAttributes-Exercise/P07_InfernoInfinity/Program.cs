using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class Program
{
    static void Main(string[] args)
    {
        var weapons = new List<Weapon>();

        while (true)
        {
            var data = Console.ReadLine().Split(';');
            var commandName = data[0];

            Assembly assembly = Assembly.GetCallingAssembly();
            Type commandType = assembly.GetTypes().FirstOrDefault(t => t.Name == commandName);

            object[] commandArgs = new object[] { data, weapons };
            object instance = Activator.CreateInstance(commandType, commandArgs);
            string result = commandType.GetMethod("Execute").Invoke(instance, null).ToString();

            if (result != string.Empty)
            {
                Console.WriteLine(result);
            }
        }
    }
}

