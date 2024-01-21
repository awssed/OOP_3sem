using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP10_LINQ_
{
    class Car
    {
        private int id;
        private string brand;
        private string model;
        private int year;
        private string color;
        private decimal price;
        private string registrationNumber;

        public int Id
        {
            get { return id; }
            set
            {
                if (value > 0)
                    id = value;
                else
                    throw new ArgumentException("Invalid Id");
            }
        }

        public string Brand
        {
            get { return brand; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    brand = value;
                else
                    throw new ArgumentException("Invalid Brand");
            }
        }

        public string Model
        {
            get { return model; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    model = value;
                else
                    throw new ArgumentException("Invalid Model");
            }
        }

        public int Year
        {
            get { return year; }
            set
            {
                int currentYear = DateTime.Now.Year;
                if (value >= 1900 && value <= currentYear)
                    year = value;
                else
                    throw new ArgumentException("Invalid Year");
            }
        }

        public string Color
        {
            get { return color; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    color = value;
                else
                    throw new ArgumentException("Invalid Color");
            }
        }

        public decimal Price
        {
            get { return price; }
            set
            {
                if (value >= 0)
                    price = value;
                else
                    throw new ArgumentException("Invalid Price");
            }
        }

        public string RegistrationNumber
        {
            get { return registrationNumber; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    registrationNumber = value;
                else
                    throw new ArgumentException("Invalid Registration Number");
            }
        }

        public Car(int id, string brand, string model, int year, string color, decimal price, string registrationNumber)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Year = year;
            Color = color;
            Price = price;
            RegistrationNumber = registrationNumber;
        }

        public int CalculateAge()
        {
            int currentYear = DateTime.Now.Year;
            int age = currentYear - Year;
            return age;
        }
        public override string ToString()
        {
            return $"Id: {Id}\nBrand: {Brand}\nModel: {Model}\nYear: {Year}\nColor: {Color}\nPrice: {Price}\nRegistration Number: {RegistrationNumber}";
        }
    }
}
