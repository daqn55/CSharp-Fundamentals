 namespace P01_HarvestingFields
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type type = Type.GetType(typeof(HarvestingFields).FullName);

            FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            string input;
            while ((input = Console.ReadLine()) != "HARVEST")
            {
                IEnumerable<FieldInfo> fieldsToPrint = null;

                switch (input)
                {
                    case "public":
                        fieldsToPrint = fields.Where(x => x.IsPublic);
                        break;
                    case "protected":
                        fieldsToPrint = fields.Where(x => x.IsFamily);
                        break;
                    case "private":
                        fieldsToPrint = fields.Where(x => x.IsPrivate);
                        break;
                    case "all":
                        fieldsToPrint = fields;
                        break;
                }

                Print(fieldsToPrint);
            }
        }

        private static void Print(IEnumerable<FieldInfo> fieldsToPrint)
        {
            foreach (var field in fieldsToPrint)
            {
                string accses = field.Attributes.ToString().ToLower();
                if (accses == "family")
                {
                    accses = "protected";
                }

                Console.WriteLine($"{accses} {field.FieldType.Name} {field.Name}");
            }
        }
    }
}
