using Microsoft.EntityFrameworkCore;

namespace Pokemon.Common.Data
{
    public class PokemonContext : DbContext
    {
        public PokemonContext(DbContextOptions<PokemonContext> options) 
            : base(options)
        {
        }
    }
}
