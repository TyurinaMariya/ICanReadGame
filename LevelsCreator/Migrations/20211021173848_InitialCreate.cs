using Microsoft.EntityFrameworkCore.Migrations;

namespace LevelsCreator.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "entities",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "INTEGER", nullable: false)
            //            .Annotation("Sqlite:Autoincrement", true),
            //        PictureFileName = table.Column<string>(type: "TEXT", nullable: true),
            //        AudioFileName = table.Column<string>(type: "TEXT", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_entities", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "GameTypes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "INTEGER", nullable: false)
            //            .Annotation("Sqlite:Autoincrement", true),
            //        Name = table.Column<string>(type: "TEXT", nullable: true),
            //        Lang = table.Column<string>(type: "TEXT", nullable: true),
            //        Game = table.Column<string>(type: "TEXT", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_GameTypes", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Words",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "INTEGER", nullable: false)
            //            .Annotation("Sqlite:Autoincrement", true),
            //        EntityId = table.Column<int>(type: "INTEGER", nullable: false),
            //        Text = table.Column<string>(type: "TEXT", nullable: true),
            //        Complexity = table.Column<int>(type: "INTEGER", nullable: false),
            //        Lang = table.Column<string>(type: "TEXT", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Words", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Words_entities_EntityId",
            //            column: x => x.EntityId,
            //            principalTable: "entities",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Levels",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "INTEGER", nullable: false)
            //            .Annotation("Sqlite:Autoincrement", true),
            //        Number = table.Column<int>(type: "INTEGER", nullable: false),
            //        Locked = table.Column<bool>(type: "INTEGER", nullable: false),
            //        GameTypeId = table.Column<int>(type: "INTEGER", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Levels", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Levels_GameTypes_GameTypeId",
            //            column: x => x.GameTypeId,
            //            principalTable: "GameTypes",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LevelWords",
            //    columns: table => new
            //    {
            //        LevelId = table.Column<int>(type: "INTEGER", nullable: false),
            //        WordId = table.Column<int>(type: "INTEGER", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LevelWords", x => new { x.LevelId, x.WordId });
            //        table.ForeignKey(
            //            name: "FK_LevelWords_Levels_LevelId",
            //            column: x => x.LevelId,
            //            principalTable: "Levels",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_LevelWords_Words_WordId",
            //            column: x => x.WordId,
            //            principalTable: "Words",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Levels_GameTypeId",
            //    table: "Levels",
            //    column: "GameTypeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_LevelWords_WordId",
            //    table: "LevelWords",
            //    column: "WordId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Words_EntityId",
            //    table: "Words",
            //    column: "EntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "LevelWords");

            //migrationBuilder.DropTable(
            //    name: "Levels");

            //migrationBuilder.DropTable(
            //    name: "Words");

            //migrationBuilder.DropTable(
            //    name: "GameTypes");

            //migrationBuilder.DropTable(
            //    name: "entities");
        }
    }
}
