using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Domain.Migrations
{
    /// <inheritdoc />
    public partial class PopulateSoftware : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Software",
                columns: new[] { "Id", "Name", "Description", "Area", "Laboratory" },
                values: new object[,]
                {
                    { 1, "LabView 2014", "", "", 1 },
                    { 2, "Matlab", "institucional", "", 1 },
                    { 3, "Matlab", "institucional", "", 2 },
                    { 4, "Sens-Tech Counter", "", "", 2 },
                    { 5, "Time", "próprio, utilizado no Leitor OSL/TL", "", 2 },
                    { 6, "COMSOL", "", "", 3 },
                    { 7, "SciDavis", "", "", 3 },
                    { 8, "Software embarcado OSA", "", "", 3 },
                    { 9, "Linux", "", "", 4 },
                    { 10, "GROMACS", "", "", 4 },
                    { 11, "GAUSSIAN", "", "", 4 },
                    { 12, "GEANT", "", "", 4 },
                    { 13, "ROOT", "", "", 4 },
                    { 14, "Matlab", "institucional", "", 5 },
                    { 15, "Python", "", "", 5 },
                    { 16, "XRMC", "", "", 5 },
                    { 17, "MCNP", "", "", 5 },
                    { 18, "Ansys Twin Builder", "", "", 6 },
                    { 19, "Ansys Fluid", "", "", 6 },
                    { 20, "Ansys UTFPR", "", "", 6 },
                    { 21, "Pyton", "", "", 6 },
                    { 22, "Simulação 3D", "", "", 6 },
                    { 23, "Origin", "", "", 9 },
                    { 24, "Longo match", "free", "", 12 },
                    { 25, "Mathematica", "", "", 17 },
                    { 26, "MATLAB", "", "", 17 },
                    { 27, "específico dos equipamentos", "", "", 17 },
                    { 28, "windows XP devido compatibilidade com equipamentos", "", "", 17 },
                    { 29, "Matlab", "", "", 19 },
                    { 30, "Software para análise de corrosão", "", "", 20 },
                    { 31, "WEIBULL ++", "", "", 21 },
                    { 32, "Softwares que acompanham os equipamentos", "", "", 22 },
                    { 33, "Software livre", "", "", 24 },
                    { 34, "Simulador de ultrassom - SIVA", "", "", 25 },
                    { 35, "Tomoview", "", "", 26 },
                    { 36, "MATLAB", "", "", 29 },
                    { 37, "LaTeX", "", "", 29 },
                    { 38, "Geogebra", "", "", 29 },
                    { 39, "ANSYS", "", "", 30 },
                    { 40, "ROCKY", "", "", 30 },
                    { 41, "LabView", "", "", 30 },
                    { 42, "Software livre", "", "", 32 },
                    { 43, "Software RMN (ACD-Lab)", "", "", 37 },
                    { 44, "REA", "", "", 38 },
                    { 45, "livres", "", "", 42 },
                    { 46, "uso do Autocad com licença gratuita do estudante", "", "", 42 },
                    { 47, "Studio Dynamics da Dantec", "", "", 46 },
                    { 48, "SIM  Weibull ++ EngCalc", "livre de produção interna", "", 50 },
                    { 49, "Enterprise Architect", "", "", 54 },
                    { 50, "Ansys", "", "", 54 },
                    { 51, "ModeFrontier", "", "", 54 },
                    { 52, "Docker", "", "", 54 },
                    { 53, "Anaconda", "", "", 54 },
                    { 54, "Metabase", "", "", 54 },
                    { 55, "MySQL", "", "", 54 },
                    { 56, "Node-RED", "", "", 54 },
                    { 57, "Mosquitto", "", "", 54 },
                    { 58, "Jupiter", "", "", 54 },
                    { 59, "versão estudante Solid works", "", "", 55 },
                    { 60, "versão estudante Simplify 3D", "", "", 55 },
                    { 61, "Ultimaker Cura", "", "", 55 },
                    { 62, "IDE Arduino", "", "", 55 },
                    { 63, "VS CODE", "", "", 55 },
                    { 64, "OpenSCAD", "", "", 55 },
                    { 65, "PSpice", "", "", 55 },
                    { 66, "Ansys", "acadêmico", "", 56 },
                    { 67, "R", "", "", 56 },
                    { 68, "Matlab", "", "", 56 },
                    { 69, "RADIASOL", "", "", 60 },
                    { 70, "Matlab", "", "", 62 },
                    { 71, "Simio", "", "", 62 },
                    { 72, "VISSIM", "", "", 62 },
                    { 73, "Ambientes de desenvolvimento de software (C, C++, Python)", "", "", 62 },
                    { 74, "Comsol Multiphysics", "", "", 65 },
                    { 75, "APEX", "", "", 65 },
                    { 76, "Matlab", "", "", 72 },
                    { 77, "ANSYS-CFD", "", "", 78 },
                    { 78, "Softwares livres de controle dos equipamentos", "", "", 81 }
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Software",
                keyColumn: "Id",
                keyValues: new object[]
                {
                    1,  2,  3,  4,  5,  6,  7,  8,  9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23,
                    24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46,
                    47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69,
                    70, 71, 72, 73, 74, 75, 76, 77, 78
                }
            );
        }
    }
}
