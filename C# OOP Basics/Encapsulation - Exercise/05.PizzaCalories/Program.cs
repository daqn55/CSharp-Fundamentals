using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string[] nameOfPizza = Console.ReadLine().Split();
        try
        {
            Pizza pizza = new Pizza(nameOfPizza[1]);

            string[] doughInput = Console.ReadLine().Split();
            Dough dough = new Dough(doughInput[1], doughInput[2], int.Parse(doughInput[3]));
            pizza.Dough = dough;

            List<Topping> toppings = new List<Topping>();
            while (true)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "END")
                {
                    break;
                }
                Topping topping = new Topping(input[1], int.Parse(input[2]));
                pizza.AddTopping(topping);
            }
            Console.WriteLine(pizza);
        }
        catch (ArgumentException argEx)
        {
            Console.WriteLine(argEx.Message);
        }
    }
}

