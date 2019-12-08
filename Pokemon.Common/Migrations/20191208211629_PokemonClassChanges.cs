using Microsoft.EntityFrameworkCore.Migrations;

namespace Pokemon.Common.Migrations
{
    public partial class PokemonClassChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Legendary",
                table: "Pokemons",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Generation",
                table: "Pokemons",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Legendary",
                table: "Pokemons",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "Generation",
                table: "Pokemons",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
