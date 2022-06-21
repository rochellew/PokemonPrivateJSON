using System.Text.Json;
using TestingPokemon;
using ConsoleTables;

var root = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
var filePath = root + @"\sableye.json";


string jsonString;
using (StreamReader sr = new StreamReader(filePath))
{
    jsonString = sr.ReadToEnd();
}

var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
var pokemon = JsonSerializer.Deserialize<Pokemon>(jsonString, options);

ConsoleTable table = new ConsoleTable("Name", "Types", "Abilities");


string[] types = new string[pokemon.Types.Count];
for(int i = 0; i < pokemon.Types.Count; i++)
{
    types[i] = pokemon.Types[i].Type.Name;
}

string[] abilities = new string[pokemon.Abilities.Count];
for(int i = 0; i < pokemon.Abilities.Count; i++)
{
    abilities[i] = pokemon.Abilities[i].Ability.Name;
}
    

table.AddRow(pokemon.Name, string.Join(", ", types), string.Join(", ", abilities));

Console.WriteLine(table);