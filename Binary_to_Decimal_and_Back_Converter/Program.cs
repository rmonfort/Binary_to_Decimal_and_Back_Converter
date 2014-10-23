using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Binary_to_Decimal_and_Back_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please select a conversion type (32 bit)");
            Console.WriteLine("1. Binary to decimal");
            Console.WriteLine("2. Decimal to binary");
            Console.WriteLine();
            Console.Write("Selection: ");
            string userSelection = Console.ReadLine();

            if (userSelection == "1")
            {
                Console.WriteLine("Please enter a binary number: ");
                string userInput = Console.ReadLine();
                if (Regex.IsMatch(userInput, "^[01]+$")) // Check if input is actually a binary number
                {
                    int number = Convert.ToInt32(userInput, 2); // Converts binary string to integer
                    Console.WriteLine(number);
                }
                else
                {
                    Console.WriteLine("Value entered is not a binary number. Exiting...");
                    Environment.Exit(1);
                }
            }
            else if (userSelection == "2")
            {
                Console.WriteLine("Please enter a positive integer: ");
                string userInput = Console.ReadLine();
                int number;
                if (Int32.TryParse(userInput, out number)) // Check if input is actually a decimal number
                {
                    if (number < 0)
                    {
                        Console.WriteLine("Value entered is less than zero. Exiting...");
                        Environment.Exit(1);
                    }
                    else
                    {
                        Console.WriteLine(ConvertIntToBinaryStringAndRemoveZeros(number));
                    }
                }
                else
                {
                    Console.WriteLine("Value entered is not a positive integer. Exiting...");
                    Environment.Exit(1);
                }
            }
            else
            {
                Console.WriteLine("Invalid selection. Exiting...");
            }

            Environment.Exit(0);
        }

        private static string ConvertIntToBinaryStringAndRemoveZeros(int number)
        {
            char[] binary = new char[32];
            int position = 31;
            int i = 0;

            while (i < 32)
            {
                if ((number & (1 << i)) != 0)
                {
                    binary[position] = '1';
                }
                else
                {
                    binary[position] = '0';
                }
                position--;
                i++;
            }
            return new string(binary).TrimStart('0'); // Trim zeroes from binary value
        }
    }
}
