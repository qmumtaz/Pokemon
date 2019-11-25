using CsvHelper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Pokemon.Dataloader.FileReader
{
    public class CsvReader<T> : IFileReader<T> where T : class
    {
        private readonly FileSettings _settings;

        public CsvReader(FileSettings settings)
        {
            _settings = settings;
        }

        public List<T> ReadFile()
        {
            Console.WriteLine($"Hello From the CSV file reader. Reading file from {_settings.Path}");
           
            var pokemon = Read();

            return pokemon;
        }

        private List<T> Read()
        {
            // Read file here

            List<T> records = new List<T>();

            try
            {
                using (var reader = new StreamReader(_settings.Path))
                using (var csv = new CsvReader(reader))
                {
                    csv.Configuration.HasHeaderRecord = _settings.HasHeader;
                    records = csv.GetRecords<T>().ToList();
                }

                return records;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                var pokemon = records as List<Models.Pokemon>;
                Audit.RecordsFound(pokemon);
            }
        }
    }
}
