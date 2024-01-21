using IMoveAndSmart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Reflection;

namespace OOP13
{
    [Serializable]
    public abstract class Transport
    {
        public string model;

        public Transport(string Model)
        {
            model = Model;
        }
        public Transport()
        {
            model= "unknown";
        }
        [Serializable]
        public class Car : Transport, IMoveable
        {
            public string typeOfAuto;
            public int year;
            [NonSerialized]
            public int ThisNonSerialized = 1;
            public Engine CarEngine;
            [Serializable]
            public class Engine
            {
                public string typeOfEngine;
                public int horsePower;
                public Engine(string TypeOfEngine, int HorsePower)
                {
                    typeOfEngine = TypeOfEngine;
                    horsePower = HorsePower;
                }
                public Engine()
                {
                    typeOfEngine = "unknown";
                    horsePower = 0;
                }
                public string TypeOfEngine
                {
                    get { return typeOfEngine; }
                    set { typeOfEngine = value; }
                }
                public int HorsePower
                {
                    get { return horsePower; }
                    set { horsePower = value; }
                }
                public override bool Equals(object obj)
                {
                    if (obj == null || GetType() != obj.GetType())
                        return false;
                    Engine otherEngine = (Engine)obj;
                    return typeOfEngine == otherEngine.typeOfEngine && horsePower == otherEngine.horsePower;
                }
            }
            public Car()
                : base()
            {
                TypeOfAuto = "unknown";
                CarEngine = new Engine("unknown", 0);
            }   
            public Car(string Model, string TypeOfAuto, string TypeOfEngine, int HorsePower)
                : base(Model)
            {
                typeOfAuto = TypeOfAuto;
                CarEngine = new Engine(TypeOfEngine, HorsePower);

            }
            public void Move()
            {
                Console.WriteLine($"{model} is movinh");
            }
            public void Stop()
            {
                Console.WriteLine($"{model} is stoped");
            }
            public void MaxSpeed() => Console.WriteLine("MaxSpeed is 60");
            public void MinSpeed() => Console.WriteLine("Minspeed is 0");
            public string TypeOfAuto
            {
                get { return typeOfAuto; }
                set { typeOfAuto = value; }
            }
            public int Year
            {
                get { return year; }
                set { year = value; }
            }
            public override string ToString()
            {
                return $"Model:{model} Type: {typeOfAuto}, Year: {year}, Engine: {CarEngine.TypeOfEngine}, Horsepower: {CarEngine.HorsePower}";
            }
            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                    return false;
                Car otherCar = (Car)obj;
                return model == otherCar.model && year == otherCar.Year && this.CarEngine.Equals(otherCar.CarEngine);

            }
        }
    }
}
