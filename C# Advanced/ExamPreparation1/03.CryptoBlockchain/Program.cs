using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.CryptoBlockchain
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                sb.Append(input);
            }

            var fullBlokchain = sb.ToString();

            string pattern = @"(?:({[^\[\]{}]+})|(\[[^{}\[\]]+\]))";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(fullBlokchain);

            //List<int> lenghtOfBlock = new List<int>();
            string letterToPrint = string.Empty;
            foreach (Match m in matches)
            {
                var block = m.ToString();

                //lenghtOfBlock.Add(block.Length);

                var count = 0;
                var numbersInStr = string.Empty;
                foreach (var b in block)
                {
                    var isNum = char.IsDigit(b);
                    if (isNum)
                    {
                        count++;
                        numbersInStr += b;
                    }
                }

                if (count % 3 == 0)
                {
                    for (int i = 0; i < numbersInStr.Length; i+=3)
                    {
                        string numToParse = numbersInStr[i].ToString() + numbersInStr[i + 1] + numbersInStr[i + 2];
                        int num = int.Parse(numToParse);

                        letterToPrint += Convert.ToChar(num - block.Length);
                    }
                }
            }

            Console.WriteLine(letterToPrint);
        }
    }
}
