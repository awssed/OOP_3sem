using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class2;
using Class3;
using ExepClass;

namespace Conteiner
{
    public class Army_Control
    {
        Cont_Army Army;
        public Army_Control()
        {
            Army = new Cont_Army();
        }

        public void addUnit(SmartBeing unit)
        {
            if(unit==null)
            {
                throw new NullUnitExeption(nameof(unit));
            }
            Army._Army.Add(unit);
            Army.ccount++;
        }
        public SmartBeing find(string name)
        {
            for (int i = 0; i < Army.ccount; i++)
            {
                if (Army._Army[i].Name == name)
                {
                    return Army._Army[i];
                }
            }
            return null;
        }
        public SmartBeing getUnit(int i)
        {
            if(i<0)
            {
                throw new NegativeArg("Отрицательный индекс", i);
            }
            else
            return Army._Army[i];
        }
        public void removeUnit(string Name)
        {
            Army._Army.Remove(this.find(Name));
        }
        public void DisplayTransformers()
        {
            for (int i = 0; i < Army.ccount; i++)
            {
                if (Army._Army[i].GetType() == typeof(Transformer))
                {
                    Army._Army[i].Display();
                }
            }
        }
        public void Display()
        {
            for(int i = 0; i < Army.ccount; i++)
            {
                Army._Army[i].Display();
            }
        }

        public class Cont_Army
        {
            public List<SmartBeing> _Army;
            public List<SmartBeing> Army
            {
                get => _Army;
                set => _Army = value;
            }
            public uint ccount;
            public uint Ccount
            {
                get => ccount;
                set => ccount = value;
            }
            public uint MaxCount { get; } = 5;
            public Cont_Army()
            {
                _Army = new List<SmartBeing>();
                ccount = 0;
            }
        }
    }
    
}
