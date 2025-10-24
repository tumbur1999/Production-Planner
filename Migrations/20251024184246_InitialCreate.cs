using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductionPlanner.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductionPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Senin = table.Column<int>(type: "int", nullable: false),
                    Selasa = table.Column<int>(type: "int", nullable: false),
                    Rabu = table.Column<int>(type: "int", nullable: false),
                    Kamis = table.Column<int>(type: "int", nullable: false),
                    Jumat = table.Column<int>(type: "int", nullable: false),
                    Sabtu = table.Column<int>(type: "int", nullable: false),
                    Minggu = table.Column<int>(type: "int", nullable: false),
                    ImprovedSenin = table.Column<int>(type: "int", nullable: false),
                    ImprovedSelasa = table.Column<int>(type: "int", nullable: false),
                    ImprovedRabu = table.Column<int>(type: "int", nullable: false),
                    ImprovedKamis = table.Column<int>(type: "int", nullable: false),
                    ImprovedJumat = table.Column<int>(type: "int", nullable: false),
                    ImprovedSabtu = table.Column<int>(type: "int", nullable: false),
                    ImprovedMinggu = table.Column<int>(type: "int", nullable: false),
                    TotalProduction = table.Column<int>(type: "int", nullable: false),
                    WorkingDays = table.Column<int>(type: "int", nullable: false),
                    PlanType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValue: "Task2")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionPlans", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductionPlans");
        }
    }
}
