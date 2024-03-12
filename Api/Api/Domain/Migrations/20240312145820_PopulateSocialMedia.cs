using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Domain.Migrations
{
    public partial class PopulateSocialMedia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SocialMedia",
                columns: new[] { "Type", "Link", "LaboratoryId" },
                values: new object[,]
                {
                    { "", "https://utfpr.curitiba.br/extensao/2021/09/01/tfesp/", 11 },
                    { "", "portal.utfpr.edu.br", 18 },
                    { "", "conveniar.funtefpr.org.br", 18 },
                    { "", "laser.dainf.ct.utfpr.edu.br", 19 },
                    { "", "labic.utfpr.edu.br", 24 },
                    { "", "Dentro do site do CPGEI. auspex.xyz", 25 },
                    { "", "Dentro do CPGEI (desatualizada)", 26 },
                    { "", "Dentro da página do DAMAT", 29 },
                    { "", "https://cernn.com.br/", 30 },
                    { "", "https://www.facebook.com/cernn.utfpr", 30 },
                    { "", "https://www.instagram.com/cernn_utfpr/", 30 },
                    { "", "https://www.linkedin.com/company/centro-de-pesquisa-em-reologia-e-fluidos-nao-newtonianos/", 30 },
                    { "", "https://utfpr.curitiba.br/damat/laboratorios/", 31 },
                    { "", "http://paginapessoal.utfpr.edu.br/jeanccs/labeso", 32 },
                    { "", "Divulgação pelo PET Eletrônica", 34 },
                    { "", "Comitê de laboratórios Multiusuários", 35 },
                    { "", "Instagram, @laprebb_utfpr", 41 },
                    { "", "www.arquivoarquitetura.com", 42 },
                    { "", "https://portal.utfpr.edu.br/ct/lameaa", 43 },
                    { "", "http://www.utfpr.edu.br/pesquisa-e-pos-graduacao/laboratorios-multiusuarios/laboratorios/laboratorio-multiusuario-de-equipamentos-e-analises-ambientais-lameaa/administracao", 44 },
                    { "", "https://cernn.com.br/", 46 },
                    { "", "https://www.facebook.com/LabdenPesquisas", 47 },
                    { "", "https://laerg.ct.utfpr.edu.br/contato/", 52 },
                    { "", "http://ppgem.geppg.ct.utfpr.edu.br/pub/bscw.cgi/24892", 54 },
                    { "", "https://www.instagram.com/biotecautfpr/", 55 },
                    { "", "https://dr-andreia-g-macedo-personal-page.webnode.page/", 59 },
                    { "", "https://utfpr.curitiba.br/labens/", 60 },
                    { "", "http://www.utfpr.edu.br/cursos/coordenacoes/stricto-sensu/cpgei/area-academica/laboratorios/companat", 62 },
                    { "", "labecotox.comunidades.net", 71 },
                    { "", "https://cautec.ct.utfpr.edu.br/", 73 },
                    { "", "Perfil no Linkedin", 77 },
                    { "", "https://nuem.ct.utfpr.edu.br", 78 }
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"SocialMedia\"");
        }
    }
}
