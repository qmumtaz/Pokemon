using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Pokemon.API.RepositoryPattern
{
  public interface IPokemonRepository
    {
        IEnumerable<Pokemon.Common.Data.EntityModels.Pokemon> GetAll();

        Pokemon.Common.Data.EntityModels.Pokemon GetById(int id);


    }
}
