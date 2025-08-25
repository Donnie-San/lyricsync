using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LyricSync.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lyric_Tasks_SongId",
                table: "Lyric");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lyric",
                table: "Lyric");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "Songs");

            migrationBuilder.RenameTable(
                name: "Lyric",
                newName: "Lyrics");

            migrationBuilder.RenameIndex(
                name: "IX_Lyric_SongId",
                table: "Lyrics",
                newName: "IX_Lyrics_SongId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Songs",
                table: "Songs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lyrics",
                table: "Lyrics",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lyrics_Songs_SongId",
                table: "Lyrics",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lyrics_Songs_SongId",
                table: "Lyrics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Songs",
                table: "Songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lyrics",
                table: "Lyrics");

            migrationBuilder.RenameTable(
                name: "Songs",
                newName: "Tasks");

            migrationBuilder.RenameTable(
                name: "Lyrics",
                newName: "Lyric");

            migrationBuilder.RenameIndex(
                name: "IX_Lyrics_SongId",
                table: "Lyric",
                newName: "IX_Lyric_SongId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lyric",
                table: "Lyric",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lyric_Tasks_SongId",
                table: "Lyric",
                column: "SongId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
