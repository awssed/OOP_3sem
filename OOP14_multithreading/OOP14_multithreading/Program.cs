using OOP14_multithreading;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace OOP14
{ 
    class Programm
    {
        static string locker = "null";
        public static void Numbers()
        {
            int n;
            Console.WriteLine("Введите n");
            n = Convert.ToInt32(Console.ReadLine());
            using (StreamWriter sw = new StreamWriter("../numbers.txt"))
            {
                for(int i=0;i<n;i++)
                {
                    Console.WriteLine(i);
                    sw.WriteLine(i);
                    Thread.Sleep(200);
                }
            }
        }
        public static void evenNumbers()
        {
            for (var i = 1; i <= 12; i++)
            {
                lock (locker)
                {
                    using (StreamWriter sw = new StreamWriter(@"EvenOddNumbers.txt", true, System.Text.Encoding.Default))
                    {
                        if (i % 2 == 0)
                        {
                            sw.WriteLine(i);
                            Console.WriteLine(i);
                            Thread.Sleep(600);
                        }
                    }
                }
            }

        }
        public static void oddNumbers()
        {

            
            for (var i = 1; i <= 12; i++)
            {
                lock(locker){
                    using (StreamWriter sw = new StreamWriter(@"EvenOddNumbers.txt", true, System.Text.Encoding.Default))
                    {
                        if (i % 2 != 0)
                        {
                            sw.WriteLine(i);
                            Console.WriteLine(i);
                            Thread.Sleep(600);
                        }
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("\n------------------------------Все запущенные процессы------------------------------\n");
            foreach (Process process in Process.GetProcesses())//Метод GetProcesses(): возвращает массив всех запущенных процессов
            {
                Console.WriteLine($"ID: {process.Id} | Name: {process.ProcessName} | Priority: {process.BasePriority} | Memory: {process.WorkingSet64}");
            }
            Console.WriteLine("\n------------------------------Текущий домен------------------------------\n");
            var currentDomain = AppDomain.CurrentDomain;
            Console.WriteLine("Детали конфигурации домена:");
            Console.WriteLine("Base Directory: " + currentDomain.BaseDirectory);
            // Вывод всех сборок в домене
            Console.WriteLine("Список сборок в домене:");
            foreach (var assembly in currentDomain.GetAssemblies())
            {
                Console.WriteLine(assembly.FullName);
            }
            //AppDomain newDomain = AppDomain.CreateDomain("New");
            //newDomain.Load("Сборка");
            //AppDomain.Unload(newDomain); //Secondary AppDomains are not supported on this platform.
            Thread threadNumbers = new Thread(Numbers);
            threadNumbers.Start();
            Console.WriteLine($"\n------------------------------Информация о потоке------------------------------\n");
            Console.WriteLine($"Name:{threadNumbers.Name} Context:{threadNumbers.ExecutionContext} ID:{threadNumbers.ManagedThreadId} Priority:{threadNumbers.Priority} State:{threadNumbers.ThreadState}");
            threadNumbers.Join();
            Thread.Sleep(300);
            Console.WriteLine($"State:{threadNumbers.ThreadState}");
            Console.WriteLine("\n------------------------------ЗАДАНИЕ4------------------------------\n");
            Thread evenThread = new Thread(evenNumbers);
            Thread oddThread=new Thread(oddNumbers);
            evenThread.Priority = ThreadPriority.AboveNormal;
            oddThread.Priority= ThreadPriority.BelowNormal;
            evenThread.Start();
            oddThread.Start();
            evenThread.Join();
            oddThread.Join();
            Console.WriteLine("\n------------------------------ДОП------------------------------\n");
            Warehouse warehouse = new Warehouse();
            warehouse.AddProduct("Товар 1");
            warehouse.AddProduct("Товар 2");
            warehouse.AddProduct("Товар 3");
            warehouse.AddProduct("Товар 4");
            warehouse.AddProduct("Товар 5");

            Truck truck1 = new Truck("Грузовик 1", 2000, warehouse);
            Truck truck2 = new Truck("Грузовик 2", 1500, warehouse);
            Truck truck3 = new Truck("Грузовик 3", 1000, warehouse);
            Thread thread1 = new Thread(truck1.LoadUnloadProducts);
            Thread thread2 = new Thread(truck2.LoadUnloadProducts);
            Thread thread3 = new Thread(truck3.LoadUnloadProducts);
            thread1.Start();
            thread2.Start();
            thread3.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();

            Console.WriteLine("Склад полностью разгружен.");
        }
    }
}