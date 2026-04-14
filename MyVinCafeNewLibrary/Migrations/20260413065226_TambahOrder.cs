using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyVinCafeNewLibrary.Migrations
{
    /// <inheritdoc />
    public partial class TambahOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    IdOrder = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TanggalOrder = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalHarga = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdMenu = table.Column<int>(type: "int", nullable: false),
                    UserModelIduser = table.Column<int>(type: "int", nullable: true),
                    MenuModelsIdMenu = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.IdOrder);
                    table.ForeignKey(
                        name: "FK_Orders_Menus_MenuModelsIdMenu",
                        column: x => x.MenuModelsIdMenu,
                        principalTable: "Menus",
                        principalColumn: "IdMenu");
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserModelIduser",
                        column: x => x.UserModelIduser,
                        principalTable: "Users",
                        principalColumn: "Iduser");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MenuModelsIdMenu",
                table: "Orders",
                column: "MenuModelsIdMenu");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserModelIduser",
                table: "Orders",
                column: "UserModelIduser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
