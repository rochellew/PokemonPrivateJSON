using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingPokemon
{
    internal class Pokemon
    {
        public string Name { get; set; }
        public List<AbilityBase> Abilities { get; set; }
        public List<TypeBase> Types { get; set; }

        public Pokemon(string name, List<AbilityBase> abilities, List<TypeBase> types)
        {
            Name = name;
            Abilities = abilities;
            Types = types;
        }

        public override string ToString()
        {
            string pokemonString = $"Name: {Name}\n\n";
            foreach (var abilityBase in Abilities)
                pokemonString += $"{abilityBase.Ability.Name} ";

            pokemonString += "\n\n";

            foreach (var typeBase in Types)
                pokemonString += $"{typeBase.Type.Name} ";

            return pokemonString;
        }
    }
}
