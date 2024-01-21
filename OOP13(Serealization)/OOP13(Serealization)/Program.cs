using System;
using static OOP13.Transport;
using System.Runtime.Serialization.Formatters.Binary;

namespace OOP13
{
    class Programm
    {
        static void Main(string[] args)
        {
            Transport car1 = new Car("Toyota", "Sedan", "Petrol", 200);
            Transport car2 = new Car("Honda", "SUV", "Diesel", 250);
            BinaryFormatter formater = new BinaryFormatter();
            using (FileStream fs=new FileStream("cars.dat",FileMode.OpenOrCreate))
            {
                formater.Serialize(fs, car1);
            }
        }
    }
}