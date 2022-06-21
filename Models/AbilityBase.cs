using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingPokemon
{
    internal class AbilityBase
    {
        public Ability Ability { get; set; }

        public AbilityBase(Ability ability)
        {
            Ability = ability;
        }
    }
}
