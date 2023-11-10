using System;
using System.Collections.Generic;
using System.Linq;

namespace RimCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите выражение:");
            string expression = Console.ReadLine();
            try
            {
                double result;

                if (TryCalculate(expression, out result))
                    Console.WriteLine("= " + result);
                else
                    Console.WriteLine("Это выражение нельзя посчитать");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Деление на 0 невозможно");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка в записи выражения");
            }
        }

        public static bool TryCalculate(string expression, out double result)
        {
            result = 0;

            char mult = '*', div = '/', sum = '+', dist = '-';
            char[] possibleOperands = { mult, div, sum, dist };

            expression = string.Join("", expression.Split(' '));
            List<char> operands = expression.ToCharArray().Where(x => possibleOperands.Contains(x)).ToList();
            List<double> nums = expression.Split(operands.ToArray()).Select(ProcessRimNumber).ToList();

            if (nums.Count != operands.Count + 1)
                return false;

            int ind = 0;
            result = nums[0];

            while (ind < operands.Count)
            {
                if (operands[ind] == mult)
                {
                    result *= nums[ind + 1];
                }
                else if (operands[ind] == div)
                {
                    if (nums[ind + 1] == 0)
                        throw new DivideByZeroException();

                    result /= nums[ind + 1];
                }
                else if (operands[ind] == sum)
                {
                    if (ind == operands.Count - 1 || (operands[ind + 1] == sum || operands[ind + 1] == dist))
                    {
                        result += nums[ind + 1];
                    }
                    else
                    {
                        double tempRes = nums[ind + 1];

                        do
                        {
                            ind++;
                            tempRes = GetResult(tempRes, nums[ind + 1], operands[ind]);
                        }
                        while (ind < operands.Count && operands[ind + 1] != sum && operands[ind + 1] != dist);

                        result += tempRes;
                    }
                }
                else
                {
                    if (ind == operands.Count - 1 || (operands[ind + 1] == sum || operands[ind + 1] == dist))
                    {
                        result -= nums[ind + 1];
                    }
                    else
                    {
                        double tempRes = nums[ind + 1];

                        do
                        {
                            ind++;
                            tempRes = GetResult(tempRes, nums[ind + 1], operands[ind]);
                        }
                        while (ind < operands.Count && operands[ind + 1] != sum && operands[ind + 1] != dist);

                        result -= tempRes;
                    }
                }

                ind++;
            }

            return true;
        }

        public static double GetResult(double a, double b, char operand)
        {
            switch (operand)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;
                case '/':
                    if (b == 0)
                        throw new DivideByZeroException();
                    return a / b;
                default:
                    throw new ArgumentException();
            }
        }

        public static double ProcessRimNumber(string number)
        {
            number = number.ToUpper();
            char[] possibleSymbols = { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };

            if (number.Where(x => possibleSymbols.Contains(x) == false).Count() != 0)
                throw new ArgumentException("Некорректное римское число");

            int[] nums = new int[] { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };
            string[] numerals = new string[] { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };

            for (int i = 0; i < numerals.Length; i++)
                if (numerals[i] == number)
                    return nums[i];

            int currentNumeral = 12;
            int newNumLen = 1;
            int res = 0;

            while (newNumLen <= number.Length)
            {
                while (number.Substring(newNumLen - 1, numerals[currentNumeral].Length) != numerals[currentNumeral])
                {
                    currentNumeral--;

                    if (currentNumeral == 0) 
                        break;
                }

                res += nums[currentNumeral];
                newNumLen += numerals[currentNumeral].Length;
            }

            return res;
        }
    }
}