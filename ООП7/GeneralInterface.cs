﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП7
{
    interface IItems<T>
    {
        void Print(string message);
        void Add(T value);

        void Delete(int index);
    }
    class ArrayItems<T> : IItems<T>
    {
        T[] items;
        public ArrayItems()
        {
            items = default(T[]);

        }
        public ArrayItems(T[] _items)
        {
            items = _items;
        }
        public void Add(T value)
        {
            T[] items2 = items;

            items = new T[items.Length + 1];

            for (int i = 0; i < items.Length - 1; i++)
                items[i] = items2[i];

            items[items.Length - 1] = value;
        }
        public void Delete(int index)
        {
            if ((index < 0) || (index >= items.Length))
                return;

            T[] items2 = new T[items.Length - 1];

            for (int i = 0; i < index; i++)
                items2[i] = items[i];
            for (int i = index + 1; i < items.Length; i++)
                items2[i - 1] = items[i];

            items = items2;
        }
        public void Print(string message)
        {
            Console.Write(message + "\t\t");

            for (int i = 0; i < items.Length; i++)
            {
                Console.Write("{0} ", items[i]);
            }
            Console.WriteLine();
        }
    }
}
