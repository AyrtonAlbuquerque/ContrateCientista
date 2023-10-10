using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Domain.Migrations
{
    /// <inheritdoc />
    public partial class PopulateCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "Name", "Cnpj", "Description" },
                values: new object[,]
                {
                    { 1, "EmpresaA", "50502732000158", "" },
                    { 2, "EmpresaB", "53816254000149", "" },
                    { 3, "EmpresaC", "08965751000154", "" },
                    { 4, "EmpresaD", "83062335000161", "" },
                    { 5, "EmpresaE", "44271759000184", "" },
                    { 6, "EmpresaF", "78963024000133", "" },
                    { 7, "EmpresaG", "19501958000194", "" },
                    { 8, "EmpresaH", "35967283000120", "" },
                    { 9, "EmpresaI", "29930146000118", "" },
                    { 10, "EmpresaJ", "35375148000195", "" },
                    { 11, "EmpresaK", "13937114000104", "" },
                    { 12, "EmpresaL", "76892299000106", "" },
                    { 13, "EmpresaM", "61605602000167", "" }
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Demand",
                keyColumn: "Id",
                keyValues: new object[]
                {
                    1,  2,  3,  4,  5,  6,  7,  8,  9, 10, 11, 12, 13
                }
            );
        }
    }
}
