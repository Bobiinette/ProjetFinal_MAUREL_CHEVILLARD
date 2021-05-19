using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetFinal_MAUREL_CHEVILLARD.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Freelance",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResidenceCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DayPrice = table.Column<int>(type: "int", nullable: false),
                    HourPrice = table.Column<int>(type: "int", nullable: false),
                    MonthPrice = table.Column<int>(type: "int", nullable: false),
                    TurnOver = table.Column<int>(type: "int", nullable: false),
                    NotKnowPrice = table.Column<bool>(type: "bit", nullable: false),
                    NetSalary = table.Column<int>(type: "int", nullable: false),
                    BrutSalary = table.Column<int>(type: "int", nullable: false),
                    MonthDuration = table.Column<int>(type: "int", nullable: false),
                    DayByMonthDuration = table.Column<int>(type: "int", nullable: false),
                    LessOneMonthDuration = table.Column<bool>(type: "bit", nullable: false),
                    Civility = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfidentialityPoliticAccepted = table.Column<bool>(type: "bit", nullable: false),
                    MarketingOfferAccepted = table.Column<bool>(type: "bit", nullable: false),
                    SimulationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Freelance", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Freelance");
        }
    }
}
