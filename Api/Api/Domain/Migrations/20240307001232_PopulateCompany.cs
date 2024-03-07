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
                columns: new[] { "Name", "Cnpj", "Email", "Description" },
                values: new object[,]
                {
                    { "EmpresaA", "50502732000158", "empresa.a@gmail.com", "" },
                    { "EmpresaB", "53816254000149", "empresa.b@gmail.com", "" },
                    { "EmpresaC", "08965751000154", "empresa.c@gmail.com", "" },
                    { "EmpresaD", "83062335000161", "empresa.d@gmail.com", "" },
                    { "EmpresaE", "44271759000184", "empresa.e@gmail.com", "" },
                    { "EmpresaF", "78963024000133", "empresa.f@gmail.com", "" },
                    { "EmpresaG", "19501958000194", "empresa.g@gmail.com", "" },
                    { "EmpresaH", "35967283000120", "empresa.h@gmail.com", "" },
                    { "EmpresaI", "29930146000118", "empresa.i@gmail.com", "" },
                    { "EmpresaJ", "35375148000195", "empresa.j@gmail.com", "" },
                    { "EmpresaK", "13937114000104", "empresa.k@gmail.com", "" },
                    { "EmpresaL", "76892299000106", "empresa.l@gmail.com", "" },
                    { "EmpresaM", "61605602000167", "empresa.m@gmail.com", "" }
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"Company\"");
        }
    }
}