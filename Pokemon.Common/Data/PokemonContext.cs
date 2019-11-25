using Microsoft.EntityFrameworkCore;
using Pokemon.Common.Data.EntityModels;
namespace Pokemon.Common.Data
{

    public class PokemonContext : DbContext
    {
        public DbSet<EntityModels.Pokemon> Pokemons { get; set; }
        public DbSet<EntityModels.PokemonType> PokemonTypes { get; set; }

        public PokemonContext(DbContextOptions<PokemonContext> options) 
            : base(options)
        {
        }
    }
}
