using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Domain.Migrations
{
    public partial class PopulateStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Description" },
                values: new object[,]
                {
                    { "Analysed" },
                    { "Matched" },
                    { "Finalized" }
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"Status\"");
        }
    }
}