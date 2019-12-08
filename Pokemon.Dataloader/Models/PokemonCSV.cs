using CsvHelper.Configuration.Attributes;
using Pokemon.Common.Data.EntityModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokemon.Dataloader.Models
{
    public class PokemonCSV
    {
        [Index(2)]
        [Name("Name")]
        public string Name { get; set; }

        [Index(3)]
        [Name("Type1")]
        public string Type1 { get; set; }

        [Index(4)]
        [Name("Type2")]
        public string Type2 { get; set; }

        [Ignore]
        [Index(5)]
        [Name("Total")]
        public int Total { get; set; }

        [Index(6)]
        [Name("HP")]
        public int HealthPoints { get; set; }

        [Index(7)]
        [Name("Attack")]
        public int Attack { get; set; }

        [Index(8)]
        [Name("Defense")]
        public int Defense { get; set; }

        [Index(9)]
        [Name("Sp. Atk")]
        public int SpecialAttack { get; set; }

        [Index(10)]
        [Name("Sp. Def")]
        public int SpecialDef { get; set; }

        [Index(11)]
        [Name("Speed")]
        public int Speed { get; set; }

        [Index(12)]
        [Name("Generation")]
        public string Generation { get; set; }

        [Index(13)]
        [Name("Legendary")]
        public string Legendary { get; set; }

        [Index(14)]
        [Name("Strong Against")]
        public string StrongAgainst { get; set; }

        [Index(15)]
        [Name("Weak Against")]
        public string WeakAgainst { get; set; }

        [Index(16)]
        [Name("Other")]
        public string Other { get; set; }
    }
}
