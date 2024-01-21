using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OOP10_LINQ_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------------ЗАДАНИЕ 1---------------------------------");
            string[] months = new string[12] {
            "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"};
            int l;
            l = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Запрос выбирающий последовательность месяцев с длиной строки равной n:");
            IEnumerable<string> result = months.Where(n => n.Length == l).Select(n => n);
            foreach(var item in result)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Запрос возвращающий только летние и зимние месяцы:");
            IEnumerable<string> WinterAndSummer = months.Where(n => n is ("January" or "February" or "December" or "June" or "July" or "August"))
                                                        .Select(n => n);
            foreach (var item in WinterAndSummer)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Запрос вывода месяцев в алфавитном порядке");
            IEnumerable<string> SortedMonths = months.OrderBy(n => n).Select(n => n);
            foreach (var item in SortedMonths)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Запрос считающий месяцы содержащие букву «u» и длиной имени не менее 4-х");
            IEnumerable<string> MonthWithU = months.Where(n => n.Contains('u')).Where(n=>n.Length>=4).Select(n => n);
            foreach (var item in MonthWithU)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----------------------------ЗАДАНИЕ 2---------------------------------");
            List<Car> cars = new List<Car>();
            cars.Add(new Car(1, "Ford", "Mustang", 2020, "Yellow", 50000, "DEF456"));
            cars.Add(new Car(2, "Chevrolet", "Cruze", 2019, "Silver", 20000, "GHI789"));
            cars.Add(new Car(3, "BMW", "X5", 2017, "Black", 60000, "JKL012"));
            cars.Add(new Car(4, "Mercedes-Benz", "E-Class", 2021, "White", 70000, "MNO345"));
            cars.Add(new Car(5, "Audi", "A4", 2018, "Gray", 40000, "PQR678"));
            cars.Add(new Car(6, "Volkswagen", "Golf", 2016, "Blue", 30000, "STU901"));
            cars.Add(new Car(7, "Hyundai", "Elantra", 2020, "Red", 25000, "VWX234"));
            cars.Add(new Car(8, "Kia", "Sportage", 2019, "Green", 28000, "YZA567"));
            cars.Add(new Car(9, "Nissan", "Sentra", 2015, "Silver", 18000, "BCD890"));
            cars.Add(new Car(10, "Subaru", "Outback", 2022, "Gray", 35000, "EFG123"));
            Console.WriteLine("Cписок автомобилей заданной марки");
            string searchBrand = Console.ReadLine();
            IEnumerable<Car> cars1 = cars.Where(n => n.Brand.Equals(searchBrand));
            foreach(var item in cars1)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Cписок автомобилей заданной модели, которые\r\nэксплуатируются больше n лет;");
            int n = Convert.ToInt32(Console.ReadLine());
            IEnumerable<Car> cars2 = cars1.Where(car => car.CalculateAge() > n).Select(car=>car);
            foreach (var item in cars2)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Количество автомобильной заданного цвета и диапазона цены");
            string SearchColor = Console.ReadLine();
            int MinPrice = Convert.ToInt32(Console.ReadLine());
            int MaxPrice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(cars.Where(car => car.Color.Equals(SearchColor)).Where(car => car.Price >= MinPrice).Where(car => car.Price <= MaxPrice).Count());
            Console.WriteLine("Cамый старый автомобиль");
            Car TheOldestCar = cars.OrderBy(car => car.Year).FirstOrDefault();
            Console.WriteLine(TheOldestCar.ToString());
            Console.WriteLine("Первых пять самых новых автомобилей");
            IEnumerable<Car> newestCars = cars.OrderByDescending(car => car.Year).Take(5);
            foreach(var car in newestCars)
            {
                Console.WriteLine(car.ToString());
            }
            Console.WriteLine("Упорядоченный массив по цене");
            Car[] ArrayOfCars = cars.OrderBy(car => car.Price).ToArray();
            foreach(var car in ArrayOfCars)
            {
                Console.WriteLine(car.ToString());
            }
            IEnumerable<string> result = cars
                                .Where(car => car.Year > 2015) // Условие: выбираем автомобили, выпущенные после 2015 года
                                .OrderByDescending(car => car.Price) // Упорядочивание: сортируем по убыванию цены
                                .Take(3) // Проекция: выбираем первые три автомобиля из отсортированного списка
                                .Select(car => car.Brand) // Проекция: выбираем только марки автомобилей
                                .Distinct() // Группировка: удаляем повторяющиеся марки
                                .OrderBy(brand => brand) // Упорядочивание: сортируем марки по алфавиту
                                .Skip(1) // Разбиение: пропускаем первую марку
                                .Take(2); // Разбиение: выбираем две марки

            foreach (var brand in result)
            {
                Console.WriteLine(brand);
            }
        }

    }
}
