using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensioin
{
    public static class StringExtension
    {
        public static int ExtractLastNumber(this string input)
        {
            string numberString = string.Empty;
            for(int i=input.Length;i>=0;i--)
            {
                if (char.IsDigit(input[i]))
                {
                    numberString = input[i] + numberString;
                }
                else if (numberString.Length > 0)
                    break;
            }
            int number;
            if (int.TryParse(numberString, out number))
                return number;
            else
                throw new FormatException("Could not extract last number from the string.");
        }
    }

    public static class LinkedListExtension
    {
        public static void RemoveItem<T>(this LinkedList<T> list, T item)
        {
            LinkedListNode<T> current = list.First;
            while(current!=null)
            {
                LinkedListNode<T> next = current.Next;
                if(EqualityComparer<T>.Default.Equals(current.Value,item))
                {
                    list.Remove(current);
                    current = next;
                }
            }
        }
    }
}
