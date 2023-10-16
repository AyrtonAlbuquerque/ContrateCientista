using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Domain.Migrations
{
    public partial class PopulateAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Street", "Number", "Neighborhood", "City", "State", "Country", "Extra" },
                values: new object[,]
                {
                    { "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "" },
                    { "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "CN-S06db" },
                    { "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "" },
                    { "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "" },
                    { "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "" },
                    { "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "NS03" },
                    { "R. Pedro Gusso", "2601", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { "R. Pedro Gusso", "2601", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil" , ""},
                    { "R. Pedro Gusso", "2601", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { "R. Pedro Gusso", "2601", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "Neoville Lab-03" },
                    { "R. Pedro Gusso", "2601", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { "R. Pedro Gusso", "2601", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { "R. Pedro Gusso", "2601", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { "R. Pedro Gusso", "2601", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "Laboratório número 4" },
                    { "R. Pedro Gusso", "2601", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "Neoville Lab-06" },
                    { "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "" },
                    { "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "CS007" },
                    { "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "" },
                    { "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "EK210" },
                    { "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "Sala EM005" },
                    { "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "EL-002" },
                    { "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "" },
                    { "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "" },
                    { "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "" },
                    { "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "" },
                    { "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "" },
                    { "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "" },
                    { "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "" },
                    { "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "Bloco D, Sala 13/CITEC" },
                    { "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "" },
                    { "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "" },
                    { "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "" },
                    { "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "" },
                    { "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "bloco F" },
                    { "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "EC112" },
                    { "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "sala EC-305" },
                    { "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "Bloco A - sala 002" },
                    { "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "sala CG001b" },
                    { "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "" },
                    { "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "" },
                    { "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "localizado no corredor da capela" },
                    { "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "Sala EM-007" },
                    { "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "Bloco V3" },
                    { "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "EM-304" },
                    { "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "CF-001b" },
                    { "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "EM-308" },
                    { "R. Pedro Gusso", "2601", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "ecovile Bloco F terreo EF-003" },
                    { "R. Pedro Gusso", "2601", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "CA-009" },
                    { "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "Bloco C, primeiro andar" },
                    { "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "sala CC306" },
                    { "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "EA 007" },
                    { "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "" },
                    { "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "" },
                    { "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "sala CN-018" },
                    { "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "Sala CN-133" },
                    { "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "EF 001" },
                    { "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "Sala CN-130" },
                    { "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "CF-002" },
                    { "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "subsolo bloco IJ" },
                    { "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "CT-107" },
                    { "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "EK-207" },
                    { "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "Bloco N" },
                    { "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "EM101" },
                    { "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "CB307" }

                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"Address\"");
        }
    }
}
