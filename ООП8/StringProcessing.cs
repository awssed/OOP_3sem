using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП8
{
    public class StringProcessing
    {
        public static string RemovePunctuation(string input)
        {
            string[] punctuation = { ".", ",", "!", "?" };

            foreach (string symbol in punctuation)
            {
                input = input.Replace(symbol, "");
            }
            return input;
        }

        public static string AddSuffix(string input)
        {
            Console.WriteLine("Введите суффикс для добавления");
            string suffix = Console.ReadLine();
            input += suffix;
            return input;
        }

        public static string ConvertToUpperCase(string input)
        {
            input = input.ToUpper();
            return input;
        }

       public  static string RemoveExtraSpaces(string input)
        {
            while (input.Contains("  "))
            {
                input = input.Replace("  ", " ");
            }
            return input;
        }
    }
}
