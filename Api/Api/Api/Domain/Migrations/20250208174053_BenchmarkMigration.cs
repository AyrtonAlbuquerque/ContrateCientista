using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api.Api.Domain.Migrations
{
    /// <inheritdoc />
    public partial class BenchmarkMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Laboratory = table.Column<int>(type: "integer", nullable: false),
                    Demand = table.Column<int>(type: "integer", nullable: false),
                    Intelligence = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Score = table.Column<decimal>(type: "numeric", nullable: false),
                    Time = table.Column<long>(type: "bigint", nullable: false),
                    WordCount = table.Column<int>(type: "integer", nullable: false),
                    KeywordCount = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tests");
        }
    }
}
