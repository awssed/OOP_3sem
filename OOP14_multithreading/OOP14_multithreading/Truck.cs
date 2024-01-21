using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP14_multithreading
{
    class Warehouse
    {
        private object lockObject = new object();
        private List<string> products = new List<string>(); // Список товаров на складе

        public bool IsEmpty()
        {
            return products.Count == 0;
        }

        public void AddProduct(string product)
        {
            lock (lockObject)
            {
                products.Add(product);
                Console.WriteLine("Товар добавлен на склад: " + product);
            }
        }

        public string RemoveProduct()
        {
            lock (lockObject)
            {
                if (!IsEmpty())
                {
                    string product = products[0];
                    products.RemoveAt(0);
                    Console.WriteLine("Товар удален со склада: " + product);
                    return product;
                }
                else
                {
                    return null;
                }
            }
        }
    }

    class Truck
    {
        private string name;
        private int speed;
        private Warehouse warehouse;

        public Truck(string name, int speed, Warehouse warehouse)
        {
            this.name = name;
            this.speed = speed;
            this.warehouse = warehouse;
        }

        public void LoadUnloadProducts()
        {
            while (!warehouse.IsEmpty())
            {
                string product = warehouse.RemoveProduct();
                if (product != null)
                {
                    Console.WriteLine(name + " загружает/разгружает товар: " + product);
                    Thread.Sleep(speed);
                }
            }
        }
    }
}
