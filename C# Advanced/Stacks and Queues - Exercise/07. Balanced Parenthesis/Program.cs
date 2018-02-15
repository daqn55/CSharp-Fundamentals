using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var beggining = new Stack<char>();
            bool isBalanced = true;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '{' || input[i] == '[' || input[i] == '(')
                {
                    beggining.Push(input[i]);
                }
                else if (input[i] == '}' || input[i] == ']' || input[i] == ')')
                {
                    if (beggining.Count > 0)
                    {
                        if (beggining.Peek() == '(' && input[i] == ')' || beggining.Peek() == '[' && input[i] == ']' || beggining.Peek() == '{' && input[i] == '}')
                        {
                            beggining.Pop();
                        }
                        else
                        {
                            isBalanced = false;
                            break;
                        }
                    }
                    else
                    {
                        isBalanced = false;
                        break;
                    }
                }
            }
            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
