// using this API: https://pokeapi.co/
using System.Text.Json;
using TestingPokemon;
using ConsoleTables;
using System.Net;

namespace TestingPokemon
{
    class Program
    {
        static void Main(string[] args)
        {
            TestWeb();
            var root = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
            var filePath = root + $"{Path.DirectorySeparatorChar}Data{Path.DirectorySeparatorChar}sableye.json";
            var dataPath = root + $"{Path.DirectorySeparatorChar}Data";

            List<string> fileNames = new List<string>();
            foreach (string fileName in Directory.GetFiles(dataPath))
            {
                fileNames.Add(fileName);
            }


            List<Pokemon> pokedex = new List<Pokemon>();
            foreach (var fileName in fileNames)
            {
                string jsonString;
                using (StreamReader sr = new StreamReader(fileName))
                {
                    jsonString = sr.ReadToEnd();
                }

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var pokemon = JsonSerializer.Deserialize<Pokemon>(jsonString, options);
                pokedex.Add(pokemon);
            }

            ConsoleTable table = new ConsoleTable("Name", "Types", "Abilities");

            foreach (var pokemon in pokedex)
            {

                string[] types = new string[pokemon.Types.Count];
                for (int i = 0; i < pokemon.Types.Count; i++)
                {
                    types[i] = pokemon.Types[i].Type.Name;
                }

                string[] abilities = new string[pokemon.Abilities.Count];
                for (int i = 0; i < pokemon.Abilities.Count; i++)
                {
                    abilities[i] = pokemon.Abilities[i].Ability.Name;
                }

                table.AddRow(pokemon.Name, string.Join(", ", types), string.Join(", ", abilities));
            }

            Console.WriteLine(table);
        }

        static  void TestWeb()
        {
            string jsonString = string.Empty;
            string url = "https://www.googleapis.com/books/v1/volumes?q=Dracula+inauthor:stoker+isbn:0307743306&key=AIzaSyBnAMHA93pXeI9rlEGD8m0uBLZOttTcBa4";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                jsonString = reader.ReadToEnd();
            }

            Console.WriteLine(jsonString);
        }
    }
}