using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExepClass
{
     class AgeExeptionArg:ArgumentException
    {
        public int Value;
        public AgeExeptionArg(string message,int val):base (message)
        {
            Value=val;
        }
    }
    class NegativeArg:ArgumentException
    {
        public int Value;
        public NegativeArg(string message,int val):base (message)
        {
            Value=val;
        }
    }
    class NullUnitExeption : ArgumentNullException
    {
        public string name;
        public NullUnitExeption(string Name)
        {
            name = Name;
        }
    }
}
