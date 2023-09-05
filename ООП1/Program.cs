using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите переменные разных типов bool, byte, sbyte, char, short, ushort, int, long, ulong, float, double, demical, uint, string");
            Console.WriteLine("Переменная типа bool");
            bool a1 = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine(a1);
            Console.WriteLine("Переменная типа byte");
            byte a2 = Convert.ToByte(Console.ReadLine());
            Console.WriteLine(a2);
            Console.WriteLine("Переменная типа sbyte");
            sbyte a3 = Convert.ToSByte(Console.ReadLine());
            Console.WriteLine(a3);
            Console.WriteLine("Переменная типа char");
            char a4 = Convert.ToChar(Console.ReadLine());
            Console.WriteLine(a4);
            Console.WriteLine("Переменная типа decimal");
            decimal a5 = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine(a5);
            Console.WriteLine("Переменная типа double");
            double a6 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(a6);
            Console.WriteLine("Переменная типа float");
            float a7 = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine(a7);
            Console.WriteLine("Переменная типа int");
            int a8 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(a8);
            Console.WriteLine("Переменная типа uint");
            uint a9 = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine(a9);
            Console.WriteLine("Переменная типа nint");
            nint a10 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(a10);
            Console.WriteLine("Переменная типа nuint");
            nuint a11 = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine(a11);
            Console.WriteLine("Переменная типа long");
            long a12 = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine(a12);
            Console.WriteLine("Переменная типа ulong");
            ulong a13=Convert.ToUInt64(Console.ReadLine());
            Console.WriteLine(a13);
            Console.WriteLine("Переменная типа short");
            short a14=Convert.ToInt16(Console.ReadLine());
            Console.WriteLine(a14);
            Console.WriteLine("Переменная типа ushort");
            ushort a15=Convert.ToUInt16(Console.ReadLine());
            Console.WriteLine(a15);
            //неявное приведение
            long FromIntToLong = a8;
            int  FromShortToInt= a14;
            double FromFloatToDouble = a6;
            float FromIntToFloat = a8;
            double FromIntToDouble = a8;
            //явное приведение
            byte FromIntToByte = (byte)a8;
            uint FromIntToUint = (uint)a8;
            int FromLongToInt = (int)a12;
            long FromShortToLong = (long)a14;
            int FromCharToInt = (int)a4;
            //упаковка и распаковка

            Object boxing = a8;
            boxing = 133;
            a5 = (int)boxing;

            //Неявное типизирование
            var myNumber = true; // Компилятор определит тип как bool
            Console.WriteLine(myNumber.GetType());
            //myNumber = 7;

            //Работа с nullable
            float? a = null;

            //Работа с литералами
            //a
            string str1 = "abc";
            string str2 = "cde";
            string str3 = "abc";
            Console.WriteLine($"Сравнение 1 и 2 строки: {str1 == str2}");
            Console.WriteLine($"Сравнение 2 и 3 строки: {str1 == str3}");
            //b
            string str4 = "First string";
            string str5 = "Second string";
            string str6 = "Third string";
            string[] str7;
            Console.WriteLine($"Сцепление строк: {String.Concat(str4, str5)}");
            Console.WriteLine($"Копирование строки:{String.Copy(str5)}");
            Console.WriteLine($"Выделение подстроки:{str6.Substring(6)}");
            str7 = str4.Split();
            Console.WriteLine($"Раздение строки:{str7}");
            for(int i = 0; i < str7.Length; i++)
            {
                Console.WriteLine(str7[i]);
            }
            Console.WriteLine($"Вставка подстроки:{str5.Insert(6, str4)}");
            Console.WriteLine($"Удаление подстроки:{str6.Remove(6)}");
            //c
            string str8 = ""; 
            string str9 = null;
            Console.WriteLine($"IsNullOrEmpty:{string.IsNullOrEmpty(str8)}");
            Console.WriteLine($"IsNullOrEmpty:{string.IsNullOrEmpty(str9)}");
            Console.WriteLine($"Сранение строк:{str8 == str9}");
            //d
            StringBuilder str10=new StringBuilder("ello Worll");
            str10.Remove(9, 1);
            str10.Append('d');
            str10.Insert(0, 'H');
            Console.WriteLine($"StringBuilder:{str10}");
            //Работа с массивами
            //а
            int[,] arr1 = { { 1, 2, 3 }, { 4, 5, 6 } };
            int rows = arr1.GetUpperBound(0) + 1;
            int col = arr1.Length / rows;
             for(int i=0; i < rows; i++)
            {
                for(int j=0;j<col;j++)
                {
                    Console.Write($"{arr1[i, j]} \t");
                }
                Console.WriteLine();
            }
            //b
            string[] arr2 = { "aaa", "bbb", "ccc" };
            for(int i=0;i<arr2.Length;i++)
            {
                Console.Write(arr2[i]+" ");
            }
            Console.WriteLine("Введите номер элемента");
            int elem=Convert.ToInt32(Console.ReadLine());
            arr2[elem-1] = Console.ReadLine();
            for (int i = 0; i < arr2.Length; i++)
            {
                Console.Write(arr2[i] + " ");
            }
            //c
            double[][] jaggedArr = new double[3][];
            jaggedArr[0] = new double[2];
            jaggedArr[1] = new double[3];
            jaggedArr[2] = new double[4];
            for(int i=0;i<jaggedArr.Length;i++)
            {
                Console.WriteLine($"Введите числа для строки под номером {i+1}") ;
                for(int j = 0; j < jaggedArr[i].Length; j++)
                {
                    jaggedArr[i][j] = Convert.ToDouble(Console.ReadLine());
                }
            }
            Console.WriteLine("Ваш ступенчатый массив:");
            for (int i = 0; i < jaggedArr.Length; i++)
            {
                for (int j = 0; j < jaggedArr[i].Length; j++)
                {
                    Console.Write(jaggedArr[i][j] + " ");
                }
                Console.WriteLine();
            }
            //d
            var arr3 = new[] { 1, 2, 3, 4, 5 };
            var arr4 = new[] { "aaa" };
            //Кортежи
            //a,b
            (int, string, char, string, ulong) tup = (5, "qweq", 'a', "abcd", 123456);
            Console.WriteLine(tup);
            Console.WriteLine(tup.Item1);
            Console.WriteLine(tup.Item3);
            Console.WriteLine(tup.Item4);
            //c
            //(int i, string str, char c, string str20, ulong ul) = tup;
            var(q, str, c, str20, ul) = tup;
            (int i2, _, _, _, ulong ul2) = tup;
            var tup1 = (3, 2, 4, 5, 6, 3, 5);
            var tup2 = (3, 2, 4, 5, 5, 3, 5);
            Console.WriteLine($"Результат сравнения конртежей:{tup1 == tup2}");
            //Функция
            (int,int,int,char) Func1(int[] numbers,string str)
            {
                int max = numbers[0];
                int min = numbers[0];
                int sum = 0;
                for(int i=0;i<numbers.Length;i++)
                {
                    if (numbers[i]>max)
                    {
                        max= numbers[i];
                    }
                    if (numbers[i] < min)
                    {
                        min = numbers[i];
                    }
                    sum += numbers[i];
                }
                for (int i = 0; i < numbers.Length; i++)
                {
                   
                }
                return (max, min, sum, str[0]);
            }
            int[] numb = { 1, 2, 3, 4, 5 };
            Console.WriteLine(Func1(numb,"abcd"));
            //Работа с checked и unchecked
            void CheckedExample()
            {
                checked
                {
                    int maxValue = int.MaxValue;
                    int result = maxValue + 1; 
                }
            }

            void UncheckedExample()
            {
                unchecked
                {
                    int maxValue = int.MaxValue;
                    int result = maxValue + 1; // Нет генерации исключения, result будет отрицательным числом
                }
            }
            UncheckedExample();
            Console.WriteLine("Функция завершена.");
            CheckedExample();
        }
    }
}
