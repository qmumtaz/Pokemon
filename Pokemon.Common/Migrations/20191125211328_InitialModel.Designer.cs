﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pokemon.Common.Data;

namespace Pokemon.Common.Migrations
{
    [DbContext(typeof(PokemonContext))]
    [Migration("20191125211328_InitialModel")]
    partial class InitialModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Pokemon.Common.Data.EntityModels.Pokemon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Attack")
                        .HasColumnType("int");

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<short>("Generation")
                        .HasColumnType("smallint");

                    b.Property<int>("HealthPoints")
                        .HasColumnType("int");

                    b.Property<bool>("Legendary")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpecialAttack")
                        .HasColumnType("int");

                    b.Property<int>("SpecialDefence")
                        .HasColumnType("int");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<int?>("Type1Id")
                        .HasColumnType("int");

                    b.Property<int?>("Type2Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Type1Id");

                    b.HasIndex("Type2Id");

                    b.ToTable("Pokemons");
                });

            modelBuilder.Entity("Pokemon.Common.Data.EntityModels.PokemonType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PokemonTypes");
                });

            modelBuilder.Entity("Pokemon.Common.Data.EntityModels.Pokemon", b =>
                {
                    b.HasOne("Pokemon.Common.Data.EntityModels.PokemonType", "Type1")
                        .WithMany()
                        .HasForeignKey("Type1Id");

                    b.HasOne("Pokemon.Common.Data.EntityModels.PokemonType", "Type2")
                        .WithMany()
                        .HasForeignKey("Type2Id");
                });
#pragma warning restore 612, 618
        }
    }
}
