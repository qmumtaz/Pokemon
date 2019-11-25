using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pokemon.Dataloader
{
 public static class Audit
    {
        public static void RecordsFound<T>(List<T> pokemon) where T : Models.Pokemon
        {
            if (pokemon == null || pokemon.Count() == 0)
            {
                Console.WriteLine("No pokemon records found!");
            }
            else
            {
                Console.WriteLine($"Records found: {pokemon.Count()}");

                foreach (var x in pokemon)
                {
                    Console.WriteLine($"{x.Name}\t{x.Type1}/{x.Type2} Type");
                }
            }
        }

        public static void TypesFound(List<string> types)
        {
            if (types == null || types.Count() == 0)
            {
                Console.WriteLine("No pokemon types found!");
            }
            else
            {
                Console.WriteLine($"Types found: {types.Count()}");

                foreach (var type in types.OrderBy(x => x))
                {
                    Console.WriteLine($"{type}");
                }
            }
        }
    }
}
