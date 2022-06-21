using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingPokemon
{
    internal class Type
    {
        public string Name { get; set; }

        public Type(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
