using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pokemon.Common.Data.EntityModels
{
 public class Pokemon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int? Type1Id { get; set; }

        public int? Type2Id { get; set; }

        public int HealthPoints { get; set; }

        public int Attack { get; set; }

        public int Defense { get; set; }

        public int SpecialAttack { get; set; }

        public int SpecialDefence { get; set; }

        public int Speed { get; set; }

        public string Generation { get; set; }

        public string Legendary { get; set; }

        [ForeignKey("Type1Id")]
        public virtual PokemonType Type1 { get; set; }
        [ForeignKey("Type2Id")]
        public virtual PokemonType Type2 { get; set; }
    }
}
