using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Core
{
    public class Engine
    {
        private StorageMaster storageMaster;

        public Engine()
        {
            storageMaster = new StorageMaster();
        }

        public void Run()
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] commandArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    string command = commandArgs[0];

                    var typeName = string.Empty;
                    if (commandArgs.Length > 1)
                    {
                        typeName = commandArgs[1];
                    }

                    switch (command)
                    {
                        case "AddProduct":
                            var price = double.Parse(commandArgs[2]);
                            Console.WriteLine(this.storageMaster.AddProduct(typeName, price));
                            break;
                        case "RegisterStorage":
                            var name = commandArgs[2];
                            Console.WriteLine(this.storageMaster.RegisterStorage(typeName, name));
                            break;
                        case "SelectVehicle":
                            var garageSlot = int.Parse(commandArgs[2]);
                            Console.WriteLine(this.storageMaster.SelectVehicle(typeName, garageSlot));
                            break;
                        case "LoadVehicle":
                            Console.WriteLine(this.storageMaster.LoadVehicle(commandArgs.Skip(1)));
                            break;
                        case "SendVehicleTo":
                            var sourceGarageSlot = int.Parse(commandArgs[2]);
                            var destinationName = commandArgs[3];
                            Console.WriteLine(this.storageMaster.SendVehicleTo(typeName, sourceGarageSlot, destinationName));
                            break;
                        case "UnloadVehicle":
                            var slot = int.Parse(commandArgs[2]);
                            Console.WriteLine(this.storageMaster.UnloadVehicle(typeName, slot));
                            break;
                        case "GetStorageStatus":
                            Console.WriteLine(this.storageMaster.GetStorageStatus(typeName));
                            break;
                    }
                }
                catch (InvalidOperationException a)
                {
                    if (a.Message.StartsWith("Loaded"))
                    {
                        Console.WriteLine(a.Message);
                    }
                    else
                    {
                        Console.WriteLine($"Error: {a.Message}");
                    }
                }
            }

            Console.WriteLine(this.storageMaster.GetSummary());
        }
    }
}
