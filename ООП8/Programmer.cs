using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП8
{
    public class Programmer
    {
        public delegate void DeleteHandler(Programmer programmer);
        public delegate void MutantHandler();
        public event DeleteHandler delete;
        public event MutantHandler mutant;

        int value;
        public Programmer(int value)
        {
            this.value = value;
        }
       public int Value
        {
            get { return value; }
        }
        public void Display()
        {
            Console.Write(this.value+" ");
        }
        public void Delete()
        {
            Console.WriteLine("Удаление");
            delete.Invoke(this);
        }
        public void Mutant()
        {
            Console.WriteLine("Мутирование");
            mutant.Invoke();
        }
    }   
}
