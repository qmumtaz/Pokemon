using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pokemon.Common.Configuration;
using Pokemon.Common.Data;
using Pokemon.Dataloader.FileReader;
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
           var pokemon = _serviceProvider.GetService<IFileReader<Models.Pokemon>>().ReadFile();

           //TODO: 2 - Map pokemon to database objects

           //TODO: 3 - Save to database
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

            services.AddTransient<IFileReader<Models.Pokemon>, CsvReader<Models.Pokemon>>();
        }
    }
}
