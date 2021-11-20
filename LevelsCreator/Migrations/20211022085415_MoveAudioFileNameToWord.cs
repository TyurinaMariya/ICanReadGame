using Microsoft.EntityFrameworkCore.Migrations;

namespace LevelsCreator.Migrations
{
    public partial class MoveAudioFileNameToWord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AudioFileName",
                table: "entities");

            migrationBuilder.AddColumn<string>(
                name: "AudioFileName",
                table: "Words",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AudioFileName",
                table: "Words");

            migrationBuilder.AddColumn<string>(
                name: "AudioFileName",
                table: "entities",
                type: "TEXT",
                nullable: true);
        }
    }
}
