using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Domain.Migrations
{
    /// <inheritdoc />
    public partial class PopulatePerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Name", "Department", "Phone", "Email" },
                values: new object[,]
                {
                    { 1, "Emilson Ribeiro Viana Junior", "DAFIS-CT", "41998721336", "" },
                    { 2, "Anna Luiza Malthez", "", "", "" },
                    { 3, "Hilda Abe", "", "", "" },
                    { 4, "Rafael Carvalho Barreto", "", "", "" },
                    { 5, "Marcelo Antoniassi", "DAFIS", "41988943433.", "" },
                    { 6, "Walmor Cardoso Godoi", "DAFIS", "", "walmorgodoi@utfpr.edu.br" },
                    { 7, "Profa Maressa P. Krause Mocellin", "", "", "" },
                    { 8, "Gilmar Afonso", "DAEFI/PPGEF", "", "gafonso@utfpr.edu.br" },
                    { 9, "Fabris", "Dafis", "", "" },
                    { 10, "Lutas e Rendimento Esportivo", "", "", "" },
                    { 11, "Anderson", "DAEFI", "", "acpaulo@utfpr.edu.br" },
                    { 12, "Elto Legnani", "", "", "" },
                    { 13, "Daniela Kuhn", "DAEFI", "", "danielakuhn@utfpr.edu.br" },
                    { 14, "Márcio José Kerkoski", "", "", "" },
                    { 15, "Ciro Romelio Rodriguez Añez", "DAEFI", "99986-9651", "" },
                    { 16, "Laboratório de Biomecânica do Movimento", "Neoville Lab-06", "", "" },
                    { 17, "Sergei", "", "", "" },
                    { 18, "Monica Schwarz", "DAEFI", "", "" },
                    { 19, "João Fabri", "", "", "" },
                    { 20, "Paulo César Borges", "DAMEC", "", "pborges@utfpr.edu.br" },
                    { 21, "CARLOS HENRIQUE DA SILVA", "", "", "" },
                    { 22, "", "Laboratório de Ensaios Mecânicos - DAMEC", "", "" },
                    { 23, "", "EL-002", "", "" },
                    { 24, "Heitor Silverio Lopes", "", "", "" },
                    { 25, "Daniel Pipa", "", "", "" },
                    { 26, "Jorge Alberto Lens", "", "", "" },
                    { 27, "João Luis Gonçalves", "", "", "" },
                    { 28, "Cezar Negrão", "DAMEC / PPGEM", "", "" },
                    { 29, "Luciana Schreiner", "", "", "" },
                    { 30, "Jean Carlos Cardozo da Silva", "", "", "" },
                    { 31, "Paulo José Abatti", "", "", "" },
                    { 32, "Bertoldo Schneider Jr", "", "", "" },
                    { 33, "Sérgio Francisco Pichorim", "", "", "" },
                    { 34, "Bertoldo Schneider Jr", "", "", "" },
                    { 35, "Ilda Abe", "", "", "" },
                    { 36, "Fernando Castaldo", "", "", "" },
                    { 37, "Renata", "", "", "" },
                    { 38, "Luiz", "", "", "" },
                    { 39, "Juliana Kloss", "DAQBI", "", "" },
                    { 40, "", "Grupo de Pesquisa em Nanomateriais - DAQBi", "", "" },
                    { 41, "Gustavo Henrique Couto", "DAQBI", "4198805-9498", "" },
                    { 42, "Giceli Portela", "", "", "" },
                    { 43, "", "Laboratório Multiusuários de Equipamentos e Análises Ambientais; Laboratório de Estudos Avançados em Química Ambiental", "", "" },
                    { 44, "Júlio César Rodrigues de Azevedo", "", "", "" },
                    { 45, "Ugo Leandro Belini", "", "", "" },
                    { 46, "Admilson Teixeira Franco", "Damec", "999810152", "" },
                    { 47, "Prof. Oslei de Matos", "", "", "" },
                    { 48, "Gilson Satto", "", "", "" },
                    { 49, "Tatiana Maria Cecy Gadda", "DACOC", " 41 987845335", "" },
                    { 50, "Carlos Henrique da Silva", "", "", "" },
                    { 51, "Marcelo Lambach", "", "", "" },
                    { 52, "", "PPGEB - DAELN", "", "" },
                    { 53, "Cristiane Pilissão", "DAQBI", "41991414849", "" },
                    { 54, "Milton Borsato", "PPGEM-CT", "Ramal 6889", "" },
                    { 55, "José Jair Mendes Júnior", "CPGEI/PPGEB", "", "jjjunior@professores.utfpr.edu.br" },
                    { 56, "Marco Antonio Luersen", "PPGEM-CT/DAMEC-CT", "", "luersen@utfpr.edu.br" },
                    { 57, "Maressa P Krause Mocellin", "DAEFI", "", "" },
                    { 58, "Juliana Regina Kloss", "DAQBI", " (41) 3279-6875", "" },
                    { 59, "Andreia Gerniski Macedo", "", "", "" },
                    { 60, "", "Laboratório de Energia Solar LABENS - DAELT", "", "" },
                    { 61, "Dayane Mey Reis", "DAQBi", "", "dayane@utfpr.edu.br" },
                    { 62, "Ricardo Lüders", "DAINF-CT", "", "luders@utfpr.edu.br" },
                    { 63, "André Nagalli", "", "", "" },
                    { 64, "Wellington Mazer", "DACOC", "", "" },
                    { 65, "Alexandre de Almeida Prado Pohl", "", "", "" },
                    { 66, "Marilene Zazula Beatriz", "DAFCH e PPGTE", "41 984152233;", "" },
                    { 67, "Gilson Sato", "PPGEB", "", "sato@utfpr.edu.br" },
                    { 68, "Paulo César Borges", "", "", "" },
                    { 69, "Edney Milhoretto", "DAFIS", "", "edneymilhoretto@utfpr.edu.br" },
                    { 70, "Kátia Elisa Prus Pinho", "", "", "" },
                    { 71, "Profa. Wanessa Ramsdorf Nagata", "DAQBI", "996036865", "" },
                    { 72, "Charlie Antoni Miquelin", "", "", "" },
                    { 73, "Felipe Braga Ribas", "DAFIS", "", "fribas@utfpr.edu.br" },
                    { 74, "Karina Querne de Carvalho Passig", "DACOC", "999119726", "" },
                    { 75, "Ohara Kerusauskas Rayel", "PPGSE-CT", "", "oharakr@utfpr.edu.br" },
                    { 76, "Lucas Freitas Berti", "", "", "" },
                    { 77, "Giuseppe Pintaude", "", "", "" },
                    { 78, "Rigoberto E. M. Morales", "DAMEC", "(41) 99227-0980", "rmorales@utfpr.edu.br" },
                    { 79, "Neri Volpato", "DAMEC/PPGEM", "3279 6546", "" },
                    { 80, "Jonas Golart", "DAQBI", "ramal 6822", "" },
                    { 81, "iago Cousseau", "DAMEC/PPGEM", "987245454", "" },
                    { 82, "", "Laboratório de Análise Conformacional e Recursos Renováveis/EF-101", "", "" },
                    { 83, "Cesar Augusto Tacla", "CPGEI", "", "tacla@utfpr.edu.br" }
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Person",
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
