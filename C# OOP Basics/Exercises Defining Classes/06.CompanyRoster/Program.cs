using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        List<Employee> employees = new List<Employee>();
        List<Department> departments = new List<Department>();
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries);
            Employee employee = new Employee();

            if (input.Length == 5)
            {
                bool isAge = int.TryParse(input[4], out int age);
                if (isAge)
                {
                    employee.Age = age;
                }
                else
                {
                    employee.Email = input[4];
                }
            }
            else if (input.Length == 6)
            {
                employee.Age = int.Parse(input[5]);
                employee.Email = input[4];
            }
            employee.Name = input[0];
            employee.Salary = decimal.Parse(input[1]);
            employee.Position = input[2];
            employee.Department = input[3];

            employees.Add(employee);

            if (departments.Any(x => x.AverageDepartment.Equals(input[3])))
            {
                departments.Find(x => x.AverageDepartment.Equals(input[3])).Salaryes.Add(decimal.Parse(input[1]));
            }
            else
            {
                Department department = new Department();
                department.AverageDepartment = input[3];
                department.Salaryes.Add(decimal.Parse(input[1]));

                departments.Add(department);
            }
        }

        var highestSalary = departments.OrderByDescending(x => x.AverageSalary).First();

        Console.WriteLine($"Highest Average Salary: {highestSalary.AverageDepartment}");
        foreach (var e in employees.Where(x => x.Department.Equals(highestSalary.AverageDepartment)).OrderByDescending(x => x.Salary))
        {
            Console.WriteLine($"{e.Name} {e.Salary:f2} {e.Email} {e.Age}");
        }
    }
}

