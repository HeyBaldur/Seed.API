using Microsoft.EntityFrameworkCore.Migrations;

namespace Seed.API.Migrations
{
    public partial class DimSolutionFiltersUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DimSolutionFilters_DimSolutions_DimSolutionId",
                table: "DimSolutionFilters");

            migrationBuilder.AlterColumn<int>(
                name: "DimSolutionId",
                table: "DimSolutionFilters",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DimSolutionFilters_DimSolutions_DimSolutionId",
                table: "DimSolutionFilters",
                column: "DimSolutionId",
                principalTable: "DimSolutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DimSolutionFilters_DimSolutions_DimSolutionId",
                table: "DimSolutionFilters");

            migrationBuilder.AlterColumn<int>(
                name: "DimSolutionId",
                table: "DimSolutionFilters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DimSolutionFilters_DimSolutions_DimSolutionId",
                table: "DimSolutionFilters",
                column: "DimSolutionId",
                principalTable: "DimSolutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
