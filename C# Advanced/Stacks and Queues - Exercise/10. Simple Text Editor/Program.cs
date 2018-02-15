using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<char> list = new List<char>();
            Stack<List<char>> stackList = new Stack<List<char>>();
            for (int i = 0; i < n; i++)
            {
                string command = Console.ReadLine();
                string[] input = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                List<char> subList = new List<char>();
                if (input[0] == "1")
                {
                    for (int y = 0; y < input[1].Length; y++)
                    {
                        list.Add(input[1][y]);
                    }

                    subList.AddRange(list);
                    stackList.Push(subList);
                }
                else if (input[0] == "2")
                {
                    list.RemoveRange(list.Count - int.Parse(input[1]), int.Parse(input[1]));

                    subList.AddRange(list);
                    stackList.Push(subList);
                }
                else if (input[0] == "3")
                {
                    Console.WriteLine(list[int.Parse(input[1]) - 1]);
                }
                else if (input[0] == "4")
                {
                    try
                    {
                        stackList.Pop();
                        list.Clear();
                        list.AddRange(stackList.Peek());
                    }
                    catch { }
                }
            }
        }
    }
}
