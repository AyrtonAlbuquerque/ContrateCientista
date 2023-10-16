using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Domain.Migrations
{
    public partial class PopulateCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Name", "Cnpj", "Description" },
                values: new object[,]
                {
                    { "EmpresaA", "50502732000158", "" },
                    { "EmpresaB", "53816254000149", "" },
                    { "EmpresaC", "08965751000154", "" },
                    { "EmpresaD", "83062335000161", "" },
                    { "EmpresaE", "44271759000184", "" },
                    { "EmpresaF", "78963024000133", "" },
                    { "EmpresaG", "19501958000194", "" },
                    { "EmpresaH", "35967283000120", "" },
                    { "EmpresaI", "29930146000118", "" },
                    { "EmpresaJ", "35375148000195", "" },
                    { "EmpresaK", "13937114000104", "" },
                    { "EmpresaL", "76892299000106", "" },
                    { "EmpresaM", "61605602000167", "" }
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"Company\"");
        }
    }
}
