using Microsoft.SqlServer.Server;
using IMoveAndSmart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ExepClass;
using System.Diagnostics;

namespace Class2
{
    public abstract class SmartBeing:ISmart
    {
        private protected string name;
        private protected int age;
        public abstract void Think();
        public abstract void Speak();
        public abstract void Display();
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set
            {
                if(value<0)
                {
                    throw new AgeExeptionArg("Возраст не может быть отрицательным", value);
                }
                else
                {
                    age = value;
                }
            }
        }
        public SmartBeing(string Name, int Age)
        {
            name = Name;
            if (Age < 0)
            {
                throw new AgeExeptionArg("Возраст не может быть отрицательным", Age);
            }
            else
            {
                age = Age;
            }
        }
       

    }
    public partial class Human : SmartBeing
    {
        private Gender gender;
        public Human(string Name, int Age,Gender Gender, string City,string Street,int House):base(Name,Age)
        {
            Assert(Age < 100, "Слишком большой возраст");
            gender = Gender;
            address.city = City;
            address.street = Street;
            address.house = House;
            
        }
        public enum Gender
        {
            Male,
            Female
        }
        
        public override void Think() => Console.WriteLine("The human is thinking...");
        public override void Speak() => Console.WriteLine("The human is speaking!!!");

        public override void Display()
        {
            Console.WriteLine($"Name:{name} Age:{age} Пол:{gender}\n Адрес:{address.city}{address.street}{address.house}");
        }
        [Conditional("DEBUG")]
        public static void Assert(bool condition, string message)
        {
            if (!condition)
            {
                throw new Exception($"Условие не выполнено: {message}");
            }
        }
    }
    public class Transformer :SmartBeing, IMoveable
    {
        public Transformer(string Name, int Age) : base(Name, Age) { }
        public override void Think() => Console.WriteLine("The transformer is thinking...");
        public override void Speak() => Console.WriteLine("The  transformer is speaking!!!");
        public void Move()
        {
            Console.WriteLine($"transformer is moving");
        }
        public void Stop()
        {
            Console.WriteLine($"transformer is stoped");
        }
        public void MaxSpeed() => Console.WriteLine("MaxSpeed is 60");
        public void MinSpeed() => Console.WriteLine("Minspeed is 0");
        public override void Display()
        {
            Console.WriteLine($"Name:{name} Age:{age}");
        }
    }
    
}
