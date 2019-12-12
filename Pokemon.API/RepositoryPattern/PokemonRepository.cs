
using System.Collections.Generic;
using System.Linq;
using Pokemon.Common.Data;
using Pokemon.Common.Data.EntityModels;

namespace Pokemon.API.RepositoryPattern
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly Pokemon.Common.Data.PokemonContext _db;

        public PokemonRepository(Pokemon.Common.Data.PokemonContext db)
        {
            _db = db;
        }
        public IEnumerable<Common.Data.EntityModels.Pokemon> GetAll()
        {
           return  _db.Pokemons.ToList();
        }

        public Common.Data.EntityModels.Pokemon GetById(int id)
        {
            var pokemon = _db.Pokemons.SingleOrDefault(x => x.Id == id);

            return pokemon;
        }

        

      public IEnumerable<Common.Data.EntityModels.Pokemon> GetByTypeName(string name)
        {
            var pokemon = _db.Pokemons.Where(x => x.Type1.Type == name).ToList();

            return pokemon;
        }


        public IEnumerable<Common.Data.EntityModels.Pokemon> GetByType1And2(string name, string name2)
        {
            var pokemon = _db.Pokemons.Where(x => x.Type1.Type == name && x.Type2.Type == name2).ToList();

            return pokemon;
        }
    }
}
