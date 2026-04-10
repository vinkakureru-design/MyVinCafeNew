using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyVinCafeNewLibrary.Migrations
{
    /// <inheritdoc />
    public partial class TambahModelAlat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alats",
                columns: table => new
                {
                    IdAlat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaAlat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JumlahAlat = table.Column<int>(type: "int", nullable: false),
                    HargaAlat = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alats", x => x.IdAlat);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alats");
        }
    }
}
