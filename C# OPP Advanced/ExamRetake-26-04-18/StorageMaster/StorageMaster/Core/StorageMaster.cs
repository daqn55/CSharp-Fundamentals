using StorageMaster.Entities.Products;
using StorageMaster.Entities.Storages;
using StorageMaster.Entities.Vehicles;
using StorageMaster.Fatories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Core
{
    public class StorageMaster
    {
        private ProductFactory productFactory;
        private StorageFactory storageFactory;
        private readonly List<Product> productsPool;
        private readonly List<Storage> storageRegistry;
        private Vehicle currentVehicle;

        public StorageMaster()
        {
            this.productFactory = new ProductFactory();
            this.storageFactory = new StorageFactory();
            this.productsPool = new List<Product>();
            this.storageRegistry = new List<Storage>();
        }

        public string AddProduct(string type, double price)
        {
            var product = this.productFactory.CreateProduct(type, price);

            this.productsPool.Add(product);

            string result = $"Added {type} to pool";

            return result;
        }

        public string RegisterStorage(string type, string name)
        {
            var storage = this.storageFactory.CreateStorage(type, name);

            this.storageRegistry.Add(storage);

            string result = $"Registered {name}";

            return result;
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            var getVehicle = this.storageRegistry.First(x => x.Name == storageName).GetVehicle(garageSlot);
            currentVehicle = getVehicle;

            return $"Selected {getVehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {

            int countLoadedProducts = 0;
            foreach (var p in productNames)
            {
                var product = this.productsPool.LastOrDefault(x => x.GetType().Name == p);
                if (product == default(Product))
                {
                    throw new InvalidOperationException($"{p} is out of stock!");
                }

                if (this.currentVehicle.IsFull)
                {
                    throw new InvalidOperationException($"Loaded {countLoadedProducts}/{productNames.Count()} products into {this.currentVehicle.GetType().Name}");
                }

                this.currentVehicle.LoadProduct(product);

                var lastIndex = this.productsPool.LastIndexOf(product);
                this.productsPool.RemoveAt(lastIndex);


                countLoadedProducts++;
            }

            string result = $"Loaded {countLoadedProducts}/{productNames.Count()} products into {this.currentVehicle.GetType().Name}";

            return result;
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            var sourceStorage = this.storageRegistry.FirstOrDefault(x => x.Name == sourceName);
            var destinationStorage = this.storageRegistry.FirstOrDefault(x => x.Name == destinationName);

            if (sourceStorage == default(Storage))
            {
                throw new InvalidOperationException("Invalid source storage!");
            }
            else if (destinationStorage == default(Storage))
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }

            var typeOfVehicle = sourceStorage.GetVehicle(sourceGarageSlot).GetType().Name;

            var destinationGarageSlot = sourceStorage.SendVehicleTo(sourceGarageSlot, destinationStorage);

            string result = $"Sent {typeOfVehicle} to {destinationName} (slot {destinationGarageSlot})";

            return result;
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            var storage = this.storageRegistry.FirstOrDefault(x => x.Name == storageName);

            var numOfProducts = storage.GetVehicle(garageSlot).Trunk.Count;

            var unloadedProductsCount = storage.UnloadVehicle(garageSlot);

            string result = $"Unloaded {unloadedProductsCount}/{numOfProducts} products at {storageName}";

            return result;
        }

        public string GetStorageStatus(string storageName)
        {
            var storage = this.storageRegistry.FirstOrDefault(x => x.Name == storageName);

            var products = new Dictionary<string, int>();
            products.Add("Gpu", 0);
            products.Add("HardDrive", 0);
            products.Add("Ram", 0);
            products.Add("SolidStateDrive", 0);

            foreach (var p in storage.Products)
            {
                products[p.GetType().Name]++;
            }

            var sb = new StringBuilder();

            sb.Append($"Stock ({storage.Products.Sum(s => s.Weight)}/{storage.Capacity}): [");

            foreach (var p in products.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                if (p.Value > 0)
                {
                    sb.Append($"{p.Key} ({p.Value}), ");
                }
            }
            if (sb.ToString().EndsWith(", "))
            {
                sb.Length -= 2;
            }

            sb.AppendLine("]");

            sb.Append("Garage: [");
            foreach (var g in storage.Garage)
            {
                if (g == null)
                {
                    sb.Append("empty|");
                }
                else
                {
                    sb.Append($"{g.GetType().Name}|");
                }
            }
            sb.Length--;
            sb.AppendLine("]");

            return sb.ToString().TrimEnd();
        }

        public string GetSummary()
        {
            var sb = new StringBuilder();

            foreach (var p in this.storageRegistry.OrderByDescending(x => x.Products.Sum(p => p.Price)))
            {
                sb.AppendLine($"{p.Name}:")
                    .AppendLine($"Storage worth: ${(p.Products.Sum(s => s.Price)):f2}");
            }

            return sb.ToString().Trim();
        }

    }
}
