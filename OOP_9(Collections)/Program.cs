using OOP_9_Collections_;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_9_Collections_
{

public class Program
    {
        static void Main(string[] args)
        {
            Image image1 = new Image(1, "image1", 480, 360);
            Image image2 = new Image(2, "imag2", 480, 360);
            Image image3 = new Image(3, "imag3", 480, 360);
            //работа с классом построенном на интерфейсее Iset
            ImageSet imageSet = new ImageSet();
            imageSet.Add(image1);
            imageSet.Add(image2);
            imageSet.Add(image3);
            Console.WriteLine("Все элементы ImageSet:");
            foreach (var image in imageSet)
            {
                Console.WriteLine(image.FileName);
            }
            // Выводим количество элементов в ImageSet
            Console.WriteLine("Количество элементов в ImageSet: " + imageSet.Count);

            // Проверяем наличие элементов в ImageSet
            Console.WriteLine("Наличие image1 в ImageSet: " + imageSet.Contains(image1));
            Console.WriteLine("Наличие image2 в ImageSet: " + imageSet.Contains(image2));
            Console.WriteLine("Наличие image3 в ImageSet: " + imageSet.Contains(image3));

            // Удаляем один элемент из ImageSet
            bool removed = imageSet.Remove(image2);
            Console.WriteLine("Удаление image2 из ImageSet: " + removed);

            // Выводим количество элементов в ImageSet после удаления
            Console.WriteLine("Количество элементов в ImageSet после удаления: " + imageSet.Count);

            // Очищаем ImageSet
            imageSet.Clear();

            // Выводим количество элементов в ImageSet после очистки
            Console.WriteLine("Количество элементов в ImageSet после очистки: " + imageSet.Count);
            Console.WriteLine("------------------- Задание 2 ------------------------");
            LinkedList<int> list = new LinkedList<int>();
            for(int i=0;i<10;i++)
            {
                list.AddLast(i);
            }
            Console.WriteLine("Исходная коллекция:");
            foreach(var item in list)
            {
                Console.WriteLine(item);
            }
            // Удаление последовательных элементов
            int n = Convert.ToInt32(Console.ReadLine()); // Количество элементов для удаления
            LinkedListNode<int> current = list.First;
            LinkedListNode<int> next = current.Next;
            for (int i=0;i<n;i++)
            {
            list.Remove(current);
            current = next;
            next = current.Next;
            }
            // Вывод коллекции после удаления
            Console.WriteLine("Коллекция после удаления {0} последовательных элементов:", n);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            //Создание второй коллекции
            Queue<int> q = new Queue<int>(list);
            Console.WriteLine("\nОчередь: ");
            foreach(var item in q)
            {
                Console.WriteLine(item);
            }
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Содержит ли заданный элемент в очереди:"+ q.Contains(n));
           ObservableCollection<int> testObsCol= new ObservableCollection<int>();
           testObsCol.CollectionChanged += CollectionChange;
           for(int i=0;i<5;i++)
           {
           testObsCol.Add(i);
           }
           testObsCol.Remove(3);

            void CollectionChange(object sender, NotifyCollectionChangedEventArgs e)
            {
                Console.WriteLine("Изменения произошли в " + e.NewStartingIndex);
                Console.WriteLine("Новые элементы: " + e.NewItems);
                Console.WriteLine("Remove (индекс): " + e.OldItems);
            }
        }
    }
    
}
