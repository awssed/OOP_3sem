using Lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book[] books=new Book[3];
            books[0] =new Book("book1",new string[]{ "Автор1","Автор2"},"Издательство1",2005,150,300,"Мягкий");
            books[1] = new Book("book2", new string[] { "Автор3" }, "Издательство2", 2006, 150, 300, "Твёрдый");
            books[2] = new Book("book3", new string[] { "Автор3", "Автор6" }, "Издательство3", 2007, 150, 300, "Твёрдый");
            int newPriceBook1 = 1000;
            books[0].ChangePrice(ref newPriceBook1);
            for(int i=0;i<Book.count;i++)
            {
                Console.WriteLine("_______________________");
                books[i].DisplayInfo();
            }
            Console.WriteLine("_______________________");
            Console.WriteLine("Сравнение book1 и book2: "+books[1].Equals(books[2]));
            Console.WriteLine("_______________________");
            Console.WriteLine("Введите автора для поиска");
            string authorSearch = Console.ReadLine();
            foreach(Book book1 in books)
            {
                foreach(string author in book1.Authors)
                {
                    if (author==authorSearch)
                    {
                        book1.DisplayInfo();
                    }
                }
            }
            Console.WriteLine("_______________________");
            Console.WriteLine("Введите год для вывода следующих книг");
            int yearSearch = Convert.ToInt32(Console.ReadLine());
            foreach(Book book1 in books)
            {
                if (book1.Year >= yearSearch)
                {
                    book1.DisplayInfo();
                }
            }
        }
    }
}
