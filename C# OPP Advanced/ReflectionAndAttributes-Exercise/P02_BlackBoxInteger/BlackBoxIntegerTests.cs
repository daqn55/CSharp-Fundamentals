namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type type = Type.GetType(typeof(BlackBoxInteger).FullName);

            FieldInfo innerValue = type.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance);
            MethodInfo[] methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            object instance = Activator.CreateInstance(type, true);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var tokens = input.Split("_");
                var command = tokens[0];
                var num = int.Parse(tokens[1]);

                MethodInfo method = methods.First(x => x.Name == command);

                method.Invoke(instance, new object[] { num });
                Console.WriteLine(innerValue.GetValue(instance));
            }
        }
    }
}
