﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Seed.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DimEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimEmployees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DimSolutions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DescriptionSub = table.Column<string>(nullable: true),
                    PhotoUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimSolutions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DimSolutionFilters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    FilterLevel = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SolutionId = table.Column<int>(nullable: false),
                    DimSolutionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimSolutionFilters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DimSolutionFilters_DimSolutions_DimSolutionId",
                        column: x => x.DimSolutionId,
                        principalTable: "DimSolutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DimSolutionFilters_DimSolutionId",
                table: "DimSolutionFilters",
                column: "DimSolutionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DimEmployees");

            migrationBuilder.DropTable(
                name: "DimSolutionFilters");

            migrationBuilder.DropTable(
                name: "DimSolutions");
        }
    }
}
