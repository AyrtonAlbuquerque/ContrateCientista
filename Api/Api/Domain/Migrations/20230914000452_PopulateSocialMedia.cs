using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Domain.Migrations
{
    /// <inheritdoc />
    public partial class PopulateSocialMedia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SocialMedia",
                columns: new[] { "Id", "Type", "Link", "Laboratory" },
                values: new object[,]
                {
                    { 1, "", "https://utfpr.curitiba.br/extensao/2021/09/01/tfesp/", 11 },
                    { 2, "", "portal.utfpr.edu.br", 18 },
                    { 3, "", "conveniar.funtefpr.org.br", 18 },
                    { 4, "", "laser.dainf.ct.utfpr.edu.br", 19 },
                    { 5, "", "labic.utfpr.edu.br", 24 },
                    { 6, "", "Dentro do site do CPGEI. auspex.xyz", 25 },
                    { 7, "", "Dentro do CPGEI (desatualizada)", 26 },
                    { 8, "", "Dentro da página do DAMAT", 29 },
                    { 9, "", "https://cernn.com.br/", 30 },
                    { 10, "", "https://www.facebook.com/cernn.utfpr", 30 },
                    { 11, "", "https://www.instagram.com/cernn_utfpr/", 30 },
                    { 12, "", "https://www.linkedin.com/company/centro-de-pesquisa-em-reologia-e-fluidos-nao-newtonianos/", 30 },
                    { 13, "", "https://utfpr.curitiba.br/damat/laboratorios/", 31 },
                    { 14, "", "http://paginapessoal.utfpr.edu.br/jeanccs/labeso", 32 },
                    { 15, "", "Divulgação pelo PET Eletrônica", 34 },
                    { 16, "", "Comitê de laboratórios Multiusuários", 35 },
                    { 17, "", "Instagram, @laprebb_utfpr", 41 },
                    { 18, "", "www.arquivoarquitetura.com", 42 },
                    { 19, "", "https://portal.utfpr.edu.br/ct/lameaa", 43 },
                    { 20, "", "http://www.utfpr.edu.br/pesquisa-e-pos-graduacao/laboratorios-multiusuarios/laboratorios/laboratorio-multiusuario-de-equipamentos-e-analises-ambientais-lameaa/administracao", 44 },
                    { 21, "", "https://cernn.com.br/", 46 },
                    { 22, "", "https://www.facebook.com/LabdenPesquisas", 47 },
                    { 23, "", "https://laerg.ct.utfpr.edu.br/contato/", 52 },
                    { 24, "", "http://ppgem.geppg.ct.utfpr.edu.br/pub/bscw.cgi/24892", 54 },
                    { 25, "", "https://www.instagram.com/biotecautfpr/", 55 },
                    { 26, "", "https://dr-andreia-g-macedo-personal-page.webnode.page/", 59 },
                    { 27, "", "https://utfpr.curitiba.br/labens/", 60 },
                    { 28, "", "http://www.utfpr.edu.br/cursos/coordenacoes/stricto-sensu/cpgei/area-academica/laboratorios/companat", 62 },
                    { 29, "", "labecotox.comunidades.net", 71 },
                    { 30, "", "https://cautec.ct.utfpr.edu.br/", 73 },
                    { 31, "", "Perfil no Linkedin", 77 },
                    { 32, "", "https://nuem.ct.utfpr.edu.br", 78 }
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SocialMedia",
                keyColumn: "Id",
                keyValues: new object[]
                {
                    1,  2,  3,  4,  5,  6,  7,  8,  9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23,
                    24, 25, 26, 27, 28, 29, 30, 31, 32
                }
            );
        }
    }
}
