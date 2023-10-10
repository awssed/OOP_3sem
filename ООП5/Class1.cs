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

namespace Class1
{
    class Program
    {
        static void Main(string[] args)
        {
            Transport[] transports = new Transport[2];
            transports[0] = new Car("Toyota", "Sedan", "Petrol", 200);
            transports[1] = new Car("Honda", "SUV", "Diesel", 250);
            Human human1 = new Human("Человек1", 15, Human.Gender.Male,"Minsk","Kirova",10);
            human1.Display();
            foreach (var transport in transports)

            {
                Console.WriteLine($"Transport: {transport.GetType().Name}");

                if (transport is IMoveable moveableTransport)
                {
                    moveableTransport.Move();
                }

                if (transport is Car car)
                {
                    car.Stop();
                    car.MaxSpeed();
                    car.MinSpeed();
                    Console.WriteLine(car);
                }

                Console.WriteLine();
                Printer printer = new Printer();

                Transport.Car car1 = new Transport.Car("Tesla", "Electric", "Electric Engine", 500);

                Transport[] objects = { car1 };

                foreach (var obj in objects)
                {
                    printer.IAmPrinting(obj);
                    Console.WriteLine();
                }
                Army_Control Army1 = new Army_Control();
                Transformer transformer1 = new Transformer("Transformer1", 100);
                Army1.addUnit(human1);
                Army1.addUnit(transformer1);
                Army1.DisplayTransformers();
                Army1.Display();

            }
        }
    }
}
