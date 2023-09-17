using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Domain.Migrations
{
    /// <inheritdoc />
    public partial class PopulateAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "Street", "Number", "Neighborhood", "City", "State", "Country", "Extra" },
                values: new object[,]
                {
                    { 1, "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "" },
                    { 2, "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "CN-S06db" },
                    { 3, "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "" },
                    { 4, "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "" },
                    { 5, "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "" },
                    { 6, "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "NS03" },
                    { 7, "R. Pedro Gusso", "2601", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { 8, "R. Pedro Gusso", "2601", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { 9, "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil" , ""},
                    { 10, "R. Pedro Gusso", "2601", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { 11, "R. Pedro Gusso", "2601", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "Neoville Lab-03" },
                    { 12, "R. Pedro Gusso", "2601", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { 13, "R. Pedro Gusso", "2601", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { 14, "R. Pedro Gusso", "2601", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { 15, "R. Pedro Gusso", "2601", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "Laboratório número 4" },
                    { 16, "R. Pedro Gusso", "2601", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "Neoville Lab-06" },
                    { 17, "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "" },
                    { 18, "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "CS007" },
                    { 19, "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "" },
                    { 20, "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "EK210" },
                    { 21, "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { 22, "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "Sala EM005" },
                    { 23, "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "EL-002" },
                    { 24, "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "" },
                    { 25, "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "" },
                    { 26, "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "" },
                    { 27, "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "" },
                    { 28, "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "" },
                    { 29, "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "" },
                    { 30, "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { 31, "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "" },
                    { 32, "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "Bloco D, Sala 13/CITEC" },
                    { 33, "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "" },
                    { 34, "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "" },
                    { 35, "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "" },
                    { 36, "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "" },
                    { 37, "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { 38, "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "bloco F" },
                    { 39, "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { 40, "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "EC112" },
                    { 41, "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "sala EC-305" },
                    { 42, "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "Bloco A - sala 002" },
                    { 43, "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { 44, "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { 45, "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "sala CG001b" },
                    { 46, "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { 47, "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "" },
                    { 48, "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "" },
                    { 49, "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "localizado no corredor da capela" },
                    { 50, "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "Sala EM-007" },
                    { 51, "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { 52, "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "Bloco V3" },
                    { 53, "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { 54, "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "EM-304" },
                    { 55, "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "CF-001b" },
                    { 56, "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "EM-308" },
                    { 57, "R. Pedro Gusso", "2601", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { 58, "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "ecovile Bloco F terreo EF-003" },
                    { 59, "R. Pedro Gusso", "2601", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { 60, "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "CA-009" },
                    { 61, "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "Bloco C, primeiro andar" },
                    { 62, "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "sala CC306" },
                    { 63, "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { 64, "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "EA 007" },
                    { 65, "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "" },
                    { 66, "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { 67, "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "" },
                    { 68, "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { 69, "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "sala CN-018" },
                    { 70, "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "Sala CN-133" },
                    { 71, "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "EF 001" },
                    { 72, "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "Sala CN-130" },
                    { 73, "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "CF-002" },
                    { 74, "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "subsolo bloco IJ" },
                    { 75, "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "CT-107" },
                    { 76, "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { 77, "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "EK-207" },
                    { 78, "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "Bloco N" },
                    { 79, "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "EM101" },
                    { 80, "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { 81, "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { 82, "R. Dep. Heitor Alencar Furtado", "5000", "Cidade Industrial de Curitiba", "Curitiba", "Parana", "Brasil", "" },
                    { 83, "Av. Sete de Setembro", "3165", "Rebouças", "Curitiba", "Parana", "Brasil", "CB307" }

                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValues: new object[]
                {
                    1,  2,  3,  4,  5,  6,  7,  8,  9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23,
                    24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46,
                    47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69,
                    70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83
                }
            );
        }
    }
}
