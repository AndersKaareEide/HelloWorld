using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RomanNumeralConverter
{
    // ReSharper disable once InconsistentNaming
    public class RNConverter
    {
        private readonly Dictionary<char, char[]> subtractionCases = new Dictionary<char, char[]>
        {
            {'I', new char[] {'V', 'X'}},
            {'V', new char[] { }},
            {'X', new char[] {'L', 'C'}},
            {'L', new char[] { }},
            {'C', new char[] {'D', 'M'}},
            {'D', new char[] { }},
            {'M', new char[] { }}
        };

        private readonly Dictionary<char, int> symbolValues = new Dictionary<char, int>
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        private readonly Dictionary<int, char> reversedSymbolValues;
        private readonly Dictionary<char, char> reversedSubtractionCases;

        public RNConverter()
        {
            reversedSymbolValues = new Dictionary<int, char>();
            foreach (char key in symbolValues.Keys.Reverse())
            {
                reversedSymbolValues.Add(symbolValues[key], key);
            }

            reversedSubtractionCases = new Dictionary<char, char>();
            foreach (char key in subtractionCases.Keys)
            {
                foreach (char value in subtractionCases[key])
                {
                    reversedSubtractionCases.Add(value, key);
                }
            }
        }

        public static void Main(string[] args)
        {
            RNConverter converter = new RNConverter();
            while (true)
            {
                string input = Console.ReadLine()?.ToUpper();
                try
                {
                    int decimalInput = Convert.ToInt32(input);
                    Console.WriteLine(converter.ToRoman(decimalInput));
                }
                catch (FormatException e)
                {
                    Console.WriteLine(converter.ToDecimal(input));
                }
            }
        }

        public int ToDecimal(string input)
        {
            int result = 0;
            for (int index = 0; index < input.Length; index++)
            {
                int symbolValue = symbolValues[input[index]];
                result += CheckSubtraction(input, index, symbolValue);
            }
            return result;
        }

        private int CheckSubtraction(string input, int index, int symValue)
        {
            if (index + 1 < input.Length)
            {
                char[] chars = subtractionCases[input[index]];
                if (chars.Contains(input[index + 1]))
                    return -symValue;
            }
            return symValue;
        }

        public String ToRoman(int input)
        {
            StringBuilder resultString = new StringBuilder();
            foreach (int symbolValue in reversedSymbolValues.Keys)
            {
                while (input >= symbolValue)
                {
                    char symbol = reversedSymbolValues[symbolValue];
                    resultString.Append(symbol);
                    input -= symbolValue;
                }
                try
                {
                    char symbol = reversedSymbolValues[symbolValue];
                    char subtractionSymbol = reversedSubtractionCases[symbol];
                    int subtractionValue = symbolValues[subtractionSymbol];

                    if (input >= symbolValue - subtractionValue)
                    {
                        resultString.Append(subtractionSymbol);
                        resultString.Append(symbol);
                        input -= (symbolValue - subtractionValue);
                    }
                }
                catch (KeyNotFoundException)
                {
                    continue;
                }
            }
            return resultString.ToString();
        }

    }
}