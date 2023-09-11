using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Book
    {
        private readonly int id;
        private string title;
        private string[] authors;
        private string publ_house;
        private int year;
        private int pages;
        private int price;
        private string bindingType;
        public static short count =0;

        public int Id
        {
            get { return id; }
        }
         public string[] Authors
        {
            get { return authors; }
            set { authors = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Publ_house
        {
            get { return publ_house; }
            set { publ_house = value; }
        }

        public int Year
        { get { return year; }
          set { year=value; } 
        }

        public int Pages
        { 
            get { return pages; }
            set { pages = value; }
        }

        public int Price
        {
            get { return price; }
            set { price = value;}
        }
        public string BindingType
        {
            get { return bindingType; }
            set { bindingType = value; }
        }
        //полный конструктор
        public Book(string Atitle,string[] Aauthors, string Apubl_house,int Ayear, int Apages, int Aprice,string AbindingType)
        {
            title= Atitle;
            authors= Aauthors;
            publ_house= Apubl_house;
            year= Ayear;
            pages= Apages;
            price = Aprice;
            bindingType= AbindingType;
            id = GetHashCode();
            count++;
        }
        //неполный конструктор
        public Book(string Atitle,string[] Aauthors, string Apubl_house, int Ayear, int Apages)
        {
            title = Atitle;
            authors = Aauthors;
            publ_house = Apubl_house;
            year = Ayear;
            pages = Apages;
            price = 0;
            bindingType = "Default";
            id = GetHashCode();
            count++;
        }
        //конструктор по умолчанию
        public Book()
        { 
            title = "unknown";
            authors = new string[] { "unknown" };
            publ_house = "unknown";
            year = 0;
            pages = 0;
            price = 0;
            bindingType = "unknow";
            id = GetHashCode();
            count++;
        }
        static Book()
        {
            count = 0;
        }
        //поле константа
        const string university = "belstu";
        //метод для вывода
        public void DisplayInfo()
        {
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Название: {title}");
            Console.WriteLine($"Автор(ы): {string.Join(", ", authors)}");
            Console.WriteLine($"Издательство: {publ_house}");
            Console.WriteLine($"Год издания: {year}");
            Console.WriteLine($"Количество страниц: {pages}");
            Console.WriteLine($"Цена: {price}");
            Console.WriteLine($"Тип переплета: {bindingType}");
            Console.WriteLine($"Университет:{university}");
        }

        public override int GetHashCode()
        {
            var hash = 0;
            foreach (char temp in title)
            {
                hash += Convert.ToInt32(temp);
            }
            return Convert.ToInt32(hash);
        }

        public void ChangePrice(ref int newPrice)
        {
            if (newPrice <= 0)
            {
                Console.WriteLine("Цена должна быть положительным числом.");
            }
            else
            {
                price = newPrice;
                Console.WriteLine($"Новая цена книги \"{title}\": {newPrice:C}");
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if(obj.GetType() != typeof(Book)) return false;
            Book book = (Book)obj;
            if(book == null) return false;
            return this.title==book.title && this.price==book.price && this.authors==book.authors && this.publ_house==book.publ_house
                && this.bindingType==book.bindingType && this.pages==book.pages && this.pages==book.pages;
               
        }

        public override string ToString()
        {
            return $"ID: {id}, Название: {title}, Автор(ы): {string.Join(", ", authors)}, " +
                $"Издательство: {publ_house}, Год издания: {year}, " +
                $"Количество страниц: {pages}, Цена: {price:C}, Тип переплета: {bindingType}";
        }

    }
}
