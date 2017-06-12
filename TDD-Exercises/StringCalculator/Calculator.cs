using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            int result = 0;
            bool negativeNumber = false;
            List<string> numbersList = new List<string>();
            List<char> delimetersList = new List<char>() { ',' };
            List<int> negativeList = new List<int>();
            Regex regexSplit = new Regex(@"^\/{2}.?$");

            if (string.IsNullOrEmpty(numbers))
            {
                return result;
            }

            var newLineString = numbers.Split('\n');
            if (regexSplit.IsMatch(newLineString.ToString()))
            {
                delimetersList.Add(Char.Parse(newLineString.ToString()));
            }

            foreach (var rowString in newLineString)
            {
                foreach (var delimiter in delimetersList)
                {
                    numbersList.AddRange(rowString.Split(delimiter));
                }

            }

            foreach (var n in numbersList)
            {
                int number;
                int.TryParse(n, out number);

                if (number < 0)
                {
                    negativeNumber = true;
                    negativeList.Add(number);
                }
                else
                {
                    if (number < 1001)
                    {
                        result += number;
                    }
                }

            }
            if (negativeNumber)
            {
                var message = "negatives not allowed ";
                foreach (var nn in negativeList)
                {
                    message += "- " + nn + " ";
                }
                throw new NegativeNumberException();
            }

            return result;
        }

    }
}
