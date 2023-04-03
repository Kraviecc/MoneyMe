using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyMe.Modules.Investments.Core.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Investments_Module_Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "investments");

            migrationBuilder.CreateTable(
                name: "Investments",
                schema: "investments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvestmentComponents",
                schema: "investments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InvestmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentComponents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvestmentComponents_Investments_InvestmentId",
                        column: x => x.InvestmentId,
                        principalSchema: "investments",
                        principalTable: "Investments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentComponents_InvestmentId",
                schema: "investments",
                table: "InvestmentComponents",
                column: "InvestmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvestmentComponents",
                schema: "investments");

            migrationBuilder.DropTable(
                name: "Investments",
                schema: "investments");
        }
    }
}
