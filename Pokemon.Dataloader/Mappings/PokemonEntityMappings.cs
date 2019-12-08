using Pokemon.Dataloader.Models;

using System.Collections.Generic;
using Pokemon.Common.Data;
using System.Linq;
using Pokemon.Common.Data.EntityModels;

namespace Pokemon.Dataloader.Mappings
{
    public class PokemonEntityMappings
    {

        public List<Pokemon.Common.Data.EntityModels.Pokemon> ToPokemonEntityList(List<PokemonCSV> list, List<PokemonType> types) {

            var entityList = new List<Pokemon.Common.Data.EntityModels.Pokemon>();

            foreach (var item in list)
            {
                var p = new Pokemon.Common.Data.EntityModels.Pokemon
                {
                    Name = item.Name,
                    Attack = item.Attack,
                    Type1 = types.Where(x => x.Type == item.Type1).FirstOrDefault(),
                    Type2 = types.Where(x => x.Type == item.Type2).FirstOrDefault(),
                };
                entityList.Add(p);

            }

            return entityList;
        }

        public List<Pokemon.Common.Data.EntityModels.PokemonType> ToPokemonType(List<PokemonCSV> list)
        {
            var type1 = list.Select(x => x.Type1).ToList();
            var type2 = list.Select(x => x.Type2).ToList();

            type1.AddRange(type2);
            var dis = type1.Where(x => x != "").Distinct().ToList();

            List<Pokemon.Common.Data.EntityModels.PokemonType> typeEntityList = new List<Common.Data.EntityModels.PokemonType>();


            foreach (var item in dis)
            {
                Pokemon.Common.Data.EntityModels.PokemonType t = new Common.Data.EntityModels.PokemonType
                {
                    Type = item
                };
                typeEntityList.Add(t);
            }
            return typeEntityList;
        }
    }
}
