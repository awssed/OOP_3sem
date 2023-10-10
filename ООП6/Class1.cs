using Class3;
using Class2;
using IMoveAndSmart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using static Class3.Transport;
using Conteiner;
using Print;
using ExepClass;

namespace Class1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Transport[] transports = new Transport[2];
            //transports[0] = new Car("Toyota", "Sedan", "Petrol", 200);
            //transports[1] = new Car("Honda", "SUV", "Diesel", 250);
            //Human human1 = new Human("Человек1", -15, Human.Gender.Male,"Minsk","Kirova",10);
            //human1.Display();
            //foreach (var transport in transports)

            //{
            //    Console.WriteLine($"Transport: {transport.GetType().Name}");

            //    if (transport is IMoveable moveableTransport)
            //    {
            //        moveableTransport.Move();
            //    }

            //    if (transport is Car car)
            //    {
            //        car.Stop();
            //        car.MaxSpeed();
            //        car.MinSpeed();
            //        Console.WriteLine(car);
            //    }

            //    Console.WriteLine();
            //    Printer printer = new Printer();

            //    Transport.Car car1 = new Transport.Car("Tesla", "Electric", "Electric Engine", 500);

            //    Transport[] objects = { car1 };

            //    foreach (var obj in objects)
            //    {
            //        printer.IAmPrinting(obj);
            //        Console.WriteLine();
            //    }
            //    Army_Control Army1 = new Army_Control();
            //    Transformer transformer1 = new Transformer("Transformer1", 100);
            //    Army1.addUnit(human1);
            //    Army1.addUnit(transformer1);
            //    Army1.DisplayTransformers();
            //    Army1.Display();
            //}
            try
            {
                Human human1 = new Human("Человек1", -15, Human.Gender.Male, "Minsk", "Kirova", 10);
            }
            catch (AgeExeptionArg ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                Human human2 = null;
                Army_Control Army1 = new Army_Control();
                Army1.addUnit(human2);
            }
            catch (NullUnitExeption ex)
            {
                Console.WriteLine($"Объект {ex.name} является нулевой ссылкой");
            }
            try
            {
                Human human2 = new Human("Человек1", 15, Human.Gender.Male, "Minsk", "Kirova", 10);
                Army_Control Army1 = new Army_Control();
                Army1.addUnit(human2);
                Army1.getUnit(-5);
            }
            catch (NegativeArg ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                Human human2 = new Human("Человек1", 15, Human.Gender.Male, "Minsk", "Kirova", 10);
                Army_Control Army1 = new Army_Control();
                Army1.addUnit(human2);
                Army1.getUnit(3);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                MethodA();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Исключение обработано в Main:");
                Console.WriteLine($"Место: {ex.TargetSite}");
                Console.WriteLine($"Диагностика: {ex.StackTrace}");
                Console.WriteLine($"Причина: {ex.Message}");
            }
            try
            {
                Human human2 = new Human("Человек1", 101, Human.Gender.Male, "Minsk", "Kirova", 10);
                Army_Control Army1 = new Army_Control();
                Army1.addUnit(human2);
                Army1.getUnit(3);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void MethodA()
        {
            try
            {
                MethodB();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Исключение обработано в MethodA: " + ex.Message);
                throw; // Проброс исключения дальше по стеку вызовов
            }
        }

        public static void MethodB()
        {
            try
            {
                // Генерируем исключение
                throw new Exception("Произошла ошибка в MethodB");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Исключение обработано в MethodB: " + ex.Message);
                throw; // Проброс исключения дальше по стеку вызовов
            }
        }

    }
}
