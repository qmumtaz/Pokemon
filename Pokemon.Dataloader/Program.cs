using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pokemon.Common.Configuration;
using Pokemon.Common.Data;
using Pokemon.Dataloader.FileReader;
using Pokemon.Dataloader.Mappings;
using System;
using System.IO;

namespace Pokemon.Dataloader
{
    public class Program
    {
        private static IServiceProvider _serviceProvider;

        private static void Main()
        {
            ConfigureServices();

           //TODO: 1 - Read file
           var pokemon = _serviceProvider.GetService<IFileReader<Models.PokemonCSV>>().ReadFile();

            PokemonEntityMappings mappings = new PokemonEntityMappings();
            //TODO: 2 - Map pokemon to database objects
            var mappedTypes = mappings.ToPokemonType(pokemon);
            var mappedPokemon = mappings.ToPokemonEntityList(pokemon,mappedTypes);


            //TODO: 3 - Save to database
           var context =  _serviceProvider.GetService<PokemonContext>();
           context.PokemonTypes.AddRange(mappedTypes);
           context.Pokemons.AddRange(mappedPokemon);
            context.SaveChanges();
        }

        private static void ConfigureServices()
        {
            var services = new ServiceCollection();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(AppContext.BaseDirectory))
                .AddJsonFile("appsettings.json", optional: true);

            var configuration = builder.Build();

            RegisterDependencies(configuration, services);

            _serviceProvider = services.BuildServiceProvider();
        }

        private static void RegisterDependencies(IConfigurationRoot configuration,
                                                 IServiceCollection services)
        {
            var connectionStringSettings = new ConnectionStringsSettings();
            configuration.Bind("ConnectionStrings", connectionStringSettings);

            var fileSettings = new FileSettings();
            configuration.Bind("File", fileSettings);
            services.AddSingleton(fileSettings);

            services.AddDbContext<PokemonContext>(options =>
                options.UseSqlServer(connectionStringSettings.DefaultConnection));

            services.AddTransient<IFileReader<Models.PokemonCSV>, CsvReader<Models.PokemonCSV>>();
        }
    }
}
