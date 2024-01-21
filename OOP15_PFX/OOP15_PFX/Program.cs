using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Laba16
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            Task1();
            //Task2();
            //Task3(1, 2, 3);
            //Task8();
        }
        private static void multiplicationMatrix(int size)
        {
            //перемножение матриц
            var matrix1 = new int[size, size];
            var matrix2 = new int[size, size];
            var matrix3 = new int[size, size];
            var rand = new Random();
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    matrix1[i, j] = rand.Next(1, 10);
                    matrix2[i, j] = rand.Next(1, 10);
                }
            }

            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    matrix3[i, j] = matrix1[i, j] * matrix2[i, j];
                }
            }

            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    Console.Write(matrix3[i, j] + " ");
                }

                Console.WriteLine();
            }

        }
        private static void ParralelmultiplicationMatrix(int size)
        {
            //перемножение матриц
            var matrix1 = new int[size, size];
            var matrix2 = new int[size, size];
            var matrix3 = new int[size, size];
            var rand = new Random();
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    matrix1[i, j] = rand.Next(1, 10);
                    matrix2[i, j] = rand.Next(1, 10);
                }
            }

            var tasks = new Task[size];
            for (var i = 0; i < size; i++)
            {
                var row = i; // Захват переменной в цикле
                tasks[i] = Task.Run(() =>
                {
                    for (var j = 0; j < size; j++)
                    {
                        matrix3[row, j] = matrix1[row, j] * matrix2[row, j];
                    }
                });
            }
                Task.WaitAll(tasks);

                for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    Console.Write(matrix3[i, j] + " ");
                }

                Console.WriteLine();
            }

        }
        private static void Task1() 
        {
            var task = new Task(() =>
            {
                ParralelmultiplicationMatrix(20);
            });
            Console.WriteLine("ID задачи: " + task.Id);
            Console.WriteLine("Статус задачи до выполнения: " + task.Status);
            var sw = new Stopwatch();
            task.Start();
            sw.Start();
            Console.WriteLine("Статус задачи во время выполнения: " + task.Status);
            task.Wait();
            sw.Stop();
            Console.WriteLine("Время выполнения: " + sw.Elapsed);//затраченное время
            sw.Restart();
            Console.WriteLine("Статус задачи после выполнения: " + task.Status);
            Console.WriteLine("Время выполнения: " + sw.Elapsed + "\n");//затраченное время

            var sw2 = new Stopwatch();
            sw2.Start();
            multiplicationMatrix(20);
            sw2.Stop();
            Console.WriteLine("Время выполнения последовательного алгоритма: " + sw2.Elapsed + "\n");

        }
        private static void Task2()
        {//Реализуйте второй вариант этой же задачи с токеном отмены CancellationToken и отмените задачу
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            var task = new Task(() =>
            {
                ParralelmultiplicationMatrix(20);
            }, token);
            task.Start();
            try
            {
                tokenSource.Cancel();
                task.Wait();
            }
            catch (AggregateException ex)
            {
                if (task.IsCanceled)
                {
                    Console.WriteLine($"Задача {task.Id} была отменена\n");
                }
            }
            finally
            {
                tokenSource.Dispose();
            }
        }
        private static int Task3_3(int x, int y, int z)
        {
            return x + y + z;
        }
        public static int Task3_2(int x, int y, int z)
        {
            return x * y * z;
        }
        private static int Task3_1(int x, int y, int z)
        {
            return y * y + z * z;
        }
        private static void Task3(int x, int y, int z)
        {
            var task1 = Task.Run(() => Task3_1(x, y, z));
            //var contnueTask = task1.ContinueWith(prev =>
            //{
            //    int value = prev.Result;
            //    Console.WriteLine($"Continuation Task Result: {value}");
            //});
            var awaiter = task1.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                int value = awaiter.GetResult();
                Console.WriteLine($"Continuation Task Result: {value}");
            });
            var task2 = Task.Run(() => Task3_2(x, y, z));
            var task3 = Task.Run(() => Task3_3(x, y, z));

            Task.WaitAll(task1, task2, task3);

            int result = task1.Result + task2.Result + task3.Result;
            Console.WriteLine(result);

        }
        private static void Task5()
        {
            var array1 = new int[10000000];
            var array2 = new int[10000000];
            var array3 = new int[10000000];
            var array4 = new int[10000000];
            Parallel.For(0, 10000000, CreatingArrayElements);
            void CreatingArrayElements(int x)
            {
                var rand = new Random();
                array1[x] = rand.Next(0,20);
                array2[x] = rand.Next(0, 20);
                array3[x] = rand.Next(0, 20);
            }
            int sum = 0;
            Parallel.ForEach(array1, item =>
            {
                sum += item;
            });
            Console.WriteLine(sum);
        }
        public static void Task6()
        {
            //Используя Parallel.Invoke() распараллельте выполнение блока операторов.

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Parallel.Invoke(() => multiplicationMatrix(3), () => multiplicationMatrix(4));
            stopwatch.Stop();
            Console.WriteLine($"Parallel Invoke {stopwatch.ElapsedMilliseconds} ms");

        }
        public static void Task8()
        {
            BlockingCollection<string> collection = new BlockingCollection<string>(5);
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;

            Task[] sell = new Task[5] {
                new Task(() => {
                Thread.Sleep(1000);
                    collection.Add("Помидор");
                }),
                new Task(() => {
                Thread.Sleep(100);
                    collection.Add("Огурец");
                }),
                new Task(() => {
                Thread.Sleep(2000);
                    collection.Add("Шоколадка");
                }),
                new Task(() => {
                Thread.Sleep(4000);
                    collection.Add("Вантуз");
                }),
                new Task(() => {
                Thread.Sleep(6000);
                    collection.Add("Туалетная бумага");
                }),
                };

            Task[] consumers = new Task[10] {
                new Task(() => {
                    Thread.Sleep(5000);
                    if (collection.Count != 0)
                    {
                        Console.WriteLine($"Покупатель {Task.CurrentId} купил {collection.Take()}");
                    }
                    else
                        {
                        tokenSource.Cancel();
                        Console.WriteLine($"Корзина пуста, покупатель{Task.CurrentId}ушел") ;
                    }
                }, token),
                new Task(() => {
                    Thread.Sleep(6000);
                     if (collection.Count != 0)
                    {
                        Console.WriteLine($"Покупатель {Task.CurrentId} купил {collection.Take()}");
                    }
                    else
                        {
                        tokenSource.Cancel();
                        Console.WriteLine($"Корзина пуста, покупатель{Task.CurrentId}ушел") ;
                    }
                }, token),
                new Task(() => {
                    Thread.Sleep(7000);
                      if (collection.Count != 0)
                    {
                        Console.WriteLine($"Покупатель {Task.CurrentId} купил {collection.Take()}");
                    }
                    else
                        {
                        tokenSource.Cancel();
                        Console.WriteLine($"Корзина пуста, покупатель{Task.CurrentId}ушел") ;
                    }
                }, token),
                new Task(() => {
                    Thread.Sleep(4000);
                     if (collection.Count != 0)
                    {
                        Console.WriteLine($"Покупатель {Task.CurrentId} купил {collection.Take()}");
                    }
                    else
                        {
                        tokenSource.Cancel();
                        Console.WriteLine($"Корзина пуста, покупатель{Task.CurrentId}ушел") ;
                    }
                }, token),
                new Task(() => {
                    Thread.Sleep(8000);
                       if (collection.Count != 0)
                    {
                        Console.WriteLine($"Покупатель {Task.CurrentId} купил {collection.Take()}");
                    }
                    else
                        {
                        tokenSource.Cancel();
                        Console.WriteLine($"Корзина пуста, покупатель{Task.CurrentId}ушел") ;
                    }
                }, token),
                new Task(() => {
                    Thread.Sleep(9000);
                       if (collection.Count != 0)
                    {
                        Console.WriteLine($"Покупатель {Task.CurrentId} купил {collection.Take()}");
                    }
                    else
                        {
                        tokenSource.Cancel();
                        Console.WriteLine($"Корзина пуста, покупатель{Task.CurrentId}ушел") ;
                    }
                }, token),
                new Task(() => {
                    Thread.Sleep(10000);
                       if (collection.Count != 0)
                    {
                        Console.WriteLine($"Покупатель {Task.CurrentId} купил {collection.Take()}");
                    }
                    else
                        {
                        tokenSource.Cancel();
                        Console.WriteLine($"Корзина пуста, покупатель{Task.CurrentId}ушел") ;
                    }
                }, token),
                new Task(() => {
                    Thread.Sleep(11000);
                       if (collection.Count != 0)
                    {
                        Console.WriteLine($"Покупатель {Task.CurrentId} купил {collection.Take()}");
                    }
                    else
                        {
                        tokenSource.Cancel();
                        Console.WriteLine($"Корзина пуста, покупатель{Task.CurrentId}ушел") ;
                    }
                }, token),
                new Task(() => {
                    Thread.Sleep(12000);
                       if (collection.Count != 0)
                    {
                        Console.WriteLine($"Покупатель {Task.CurrentId} купил {collection.Take()}");
                    }
                    else
                        {
                        tokenSource.Cancel();
                        Console.WriteLine($"Корзина пуста, покупатель{Task.CurrentId}ушел") ;
                    }
                }, token),
                new Task(() => {
                    Thread.Sleep(13000);
                       if (collection.Count != 0)
                    {
                        Console.WriteLine($"Покупатель {Task.CurrentId} купил {collection.Take()}");
                    }
                    else
                        {
                        tokenSource.Cancel();
                        Console.WriteLine($"Корзина пуста, покупатель{Task.CurrentId}ушел") ;
                    }
                }, token),
            };
            foreach (var item in sell)
            {
                if (item.Status != TaskStatus.Running)
                {
                    item.Start();
                }
            }
            foreach (var item in consumers)
            {
                if (item.Status != TaskStatus.Running)
                {
                    item.Start();
                }
            }
            int count = 0;
            while (true)
            {
                if (collection.Count != count && collection.Count != 0)
                {
                    count = collection.Count;
                    Thread.Sleep(500);
                    Console.Clear();
                    Console.WriteLine("--------------- Склад ---------------");

                    foreach (var i in collection)
                        Console.WriteLine(i);
                }
            }
        }
    }
}