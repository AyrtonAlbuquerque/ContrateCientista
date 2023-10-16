using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Domain.Migrations
{
    public partial class PopulatePerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Name", "Department", "Phone", "Email" },
                values: new object[,]
                {
                    { "Emilson Ribeiro Viana Junior", "DAFIS-CT", "41998721336", "" },
                    { "Anna Luiza Malthez", "", "", "" },
                    { "Hilda Abe", "", "", "" },
                    { "Rafael Carvalho Barreto", "", "", "" },
                    { "Marcelo Antoniassi", "DAFIS", "41988943433.", "" },
                    { "Walmor Cardoso Godoi", "DAFIS", "", "walmorgodoi@utfpr.edu.br" },
                    { "Profa Maressa P. Krause Mocellin", "", "", "" },
                    { "Gilmar Afonso", "DAEFI/PPGEF", "", "gafonso@utfpr.edu.br" },
                    { "Fabris", "Dafis", "", "" },
                    { "Lutas e Rendimento Esportivo", "", "", "" },
                    { "Anderson", "DAEFI", "", "acpaulo@utfpr.edu.br" },
                    { "Elto Legnani", "", "", "" },
                    { "Daniela Kuhn", "DAEFI", "", "danielakuhn@utfpr.edu.br" },
                    { "Márcio José Kerkoski", "", "", "" },
                    { "Ciro Romelio Rodriguez Añez", "DAEFI", "99986-9651", "" },
                    { "Laboratório de Biomecânica do Movimento", "Neoville Lab-06", "", "" },
                    { "Sergei", "", "", "" },
                    { "Monica Schwarz", "DAEFI", "", "" },
                    { "João Fabri", "", "", "" },
                    { "Paulo César Borges", "DAMEC", "", "pborges@utfpr.edu.br" },
                    { "Carlos Henrique Da Silva", "", "", "" },
                    { "", "Laboratório de Ensaios Mecânicos - DAMEC", "", "" },
                    { "", "EL-002", "", "" },
                    { "Heitor Silverio Lopes", "", "", "" },
                    { "Daniel Pipa", "", "", "" },
                    { "Jorge Alberto Lens", "", "", "" },
                    { "João Luis Gonçalves", "", "", "" },
                    { "Cezar Negrão", "DAMEC / PPGEM", "", "" },
                    { "Luciana Schreiner", "", "", "" },
                    { "Jean Carlos Cardozo da Silva", "", "", "" },
                    { "Paulo José Abatti", "", "", "" },
                    { "Bertoldo Schneider Jr", "", "", "" },
                    { "Sérgio Francisco Pichorim", "", "", "" },
                    { "Bertoldo Schneider Jr", "", "", "" },
                    { "Ilda Abe", "", "", "" },
                    { "Fernando Castaldo", "", "", "" },
                    { "Renata", "", "", "" },
                    { "Luiz", "", "", "" },
                    { "Juliana Kloss", "DAQBI", "", "" },
                    { "", "Grupo de Pesquisa em Nanomateriais - DAQBi", "", "" },
                    { "Gustavo Henrique Couto", "DAQBI", "4198805-9498", "" },
                    { "Giceli Portela", "", "", "" },
                    { "", "Laboratório Multiusuários de Equipamentos e Análises Ambientais; Laboratório de Estudos Avançados em Química Ambiental", "", "" },
                    { "Júlio César Rodrigues de Azevedo", "", "", "" },
                    { "Ugo Leandro Belini", "", "", "" },
                    { "Admilson Teixeira Franco", "Damec", "999810152", "" },
                    { "Prof. Oslei de Matos", "", "", "" },
                    { "Gilson Satto", "", "", "" },
                    { "Tatiana Maria Cecy Gadda", "DACOC", " 41 987845335", "" },
                    { "Carlos Henrique da Silva", "", "", "" },
                    { "Marcelo Lambach", "", "", "" },
                    { "", "PPGEB - DAELN", "", "" },
                    { "Cristiane Pilissão", "DAQBI", "41991414849", "" },
                    { "Milton Borsato", "PPGEM-CT", "Ramal 6889", "" },
                    { "José Jair Mendes Júnior", "CPGEI/PPGEB", "", "jjjunior@professores.utfpr.edu.br" },
                    { "Marco Antonio Luersen", "PPGEM-CT/DAMEC-CT", "", "luersen@utfpr.edu.br" },
                    { "Maressa P Krause Mocellin", "DAEFI", "", "" },
                    { "Juliana Regina Kloss", "DAQBI", " (41) 3279-6875", "" },
                    { "Andreia Gerniski Macedo", "", "", "" },
                    { "", "Laboratório de Energia Solar LABENS - DAELT", "", "" },
                    { "Dayane Mey Reis", "DAQBi", "", "dayane@utfpr.edu.br" },
                    { "Ricardo Lüders", "DAINF-CT", "", "luders@utfpr.edu.br" },
                    { "André Nagalli", "", "", "" },
                    { "Wellington Mazer", "DACOC", "", "" },
                    { "Alexandre de Almeida Prado Pohl", "", "", "" },
                    { "Marilene Zazula Beatriz", "DAFCH e PPGTE", "41 984152233;", "" },
                    { "Gilson Sato", "PPGEB", "", "sato@utfpr.edu.br" },
                    { "Paulo César Borges", "", "", "" },
                    { "Edney Milhoretto", "DAFIS", "", "edneymilhoretto@utfpr.edu.br" },
                    { "Kátia Elisa Prus Pinho", "", "", "" },
                    { "Profa. Wanessa Ramsdorf Nagata", "DAQBI", "996036865", "" },
                    { "Charlie Antoni Miquelin", "", "", "" },
                    { "Felipe Braga Ribas", "DAFIS", "", "fribas@utfpr.edu.br" },
                    { "Karina Querne de Carvalho Passig", "DACOC", "999119726", "" },
                    { "Ohara Kerusauskas Rayel", "PPGSE-CT", "", "oharakr@utfpr.edu.br" },
                    { "Lucas Freitas Berti", "", "", "" },
                    { "Giuseppe Pintaude", "", "", "" },
                    { "Rigoberto E. M. Morales", "DAMEC", "(41) 99227-0980", "rmorales@utfpr.edu.br" },
                    { "Neri Volpato", "DAMEC/PPGEM", "3279 6546", "" },
                    { "Jonas Golart", "DAQBI", "ramal 6822", "" },
                    { "iago Cousseau", "DAMEC/PPGEM", "987245454", "" },
                    { "", "Laboratório de Análise Conformacional e Recursos Renováveis/EF-101", "", "" },
                    { "Cesar Augusto Tacla", "CPGEI", "", "tacla@utfpr.edu.br" }
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"Person\"");
        }
    }
}
