﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyMe.Modules.Investments.Core.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Investments_Module_AddContributors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvestmentContributors",
                schema: "investments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InvestmentComponentId = table.Column<Guid>(type: "uuid", nullable: false),
                    InvestmentContributorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentContributors", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvestmentContributors",
                schema: "investments");
        }
    }
}
