using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nover.CMS.Migrations
{
    /// <inheritdoc />
    public partial class addtablemenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "n_MenuItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InAdministration = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlMvc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlBlazor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlAngular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Permission = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Target = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false),
                    LResourceTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LResourceTypeAssemblyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_n_MenuItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_n_MenuItems_n_MenuItems_ParentId",
                        column: x => x.ParentId,
                        principalTable: "n_MenuItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_n_MenuItems_ParentId",
                table: "n_MenuItems",
                column: "ParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "n_MenuItems");
        }
    }
}
