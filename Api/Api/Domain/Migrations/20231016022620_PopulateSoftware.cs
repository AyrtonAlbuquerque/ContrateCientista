using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Domain.Migrations
{
    public partial class PopulateSoftware : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Software",
                columns: new[] { "Name", "Description", "Area", "LaboratoryId" },
                values: new object[,]
                {
                    { "LabView 2014", "", "", 1 },
                    { "Matlab", "institucional", "", 1 },
                    { "Matlab", "institucional", "", 2 },
                    { "Sens-Tech Counter", "", "", 2 },
                    { "Time", "próprio, utilizado no Leitor OSL/TL", "", 2 },
                    { "COMSOL", "", "", 3 },
                    { "SciDavis", "", "", 3 },
                    { "Software embarcado OSA", "", "", 3 },
                    { "Linux", "", "", 4 },
                    { "GROMACS", "", "", 4 },
                    { "GAUSSIAN", "", "", 4 },
                    { "GEANT", "", "", 4 },
                    { "ROOT", "", "", 4 },
                    { "Matlab", "institucional", "", 5 },
                    { "Python", "", "", 5 },
                    { "XRMC", "", "", 5 },
                    { "MCNP", "", "", 5 },
                    { "Ansys Twin Builder", "", "", 6 },
                    { "Ansys Fluid", "", "", 6 },
                    { "Ansys UTFPR", "", "", 6 },
                    { "Pyton", "", "", 6 },
                    { "Simulação 3D", "", "", 6 },
                    { "Origin", "", "", 9 },
                    { "Longo match", "free", "", 12 },
                    { "Mathematica", "", "", 17 },
                    { "MATLAB", "", "", 17 },
                    { "específico dos equipamentos", "", "", 17 },
                    { "windows XP devido compatibilidade com equipamentos", "", "", 17 },
                    { "Matlab", "", "", 19 },
                    { "Software para análise de corrosão", "", "", 20 },
                    { "WEIBULL ++", "", "", 21 },
                    { "Softwares que acompanham os equipamentos", "", "", 22 },
                    { "Software livre", "", "", 24 },
                    { "Simulador de ultrassom - SIVA", "", "", 25 },
                    { "Tomoview", "", "", 26 },
                    { "MATLAB", "", "", 29 },
                    { "LaTeX", "", "", 29 },
                    { "Geogebra", "", "", 29 },
                    { "ANSYS", "", "", 30 },
                    { "ROCKY", "", "", 30 },
                    { "LabView", "", "", 30 },
                    { "Software livre", "", "", 32 },
                    { "Software RMN (ACD-Lab)", "", "", 37 },
                    { "REA", "", "", 38 },
                    { "livres", "", "", 42 },
                    { "uso do Autocad com licença gratuita do estudante", "", "", 42 },
                    { "Studio Dynamics da Dantec", "", "", 46 },
                    { "SIM  Weibull ++ EngCalc", "livre de produção interna", "", 50 },
                    { "Enterprise Architect", "", "", 54 },
                    { "Ansys", "", "", 54 },
                    { "ModeFrontier", "", "", 54 },
                    { "Docker", "", "", 54 },
                    { "Anaconda", "", "", 54 },
                    { "Metabase", "", "", 54 },
                    { "MySQL", "", "", 54 },
                    { "Node-RED", "", "", 54 },
                    { "Mosquitto", "", "", 54 },
                    { "Jupiter", "", "", 54 },
                    { "versão estudante Solid works", "", "", 55 },
                    { "versão estudante Simplify 3D", "", "", 55 },
                    { "Ultimaker Cura", "", "", 55 },
                    { "IDE Arduino", "", "", 55 },
                    { "VS CODE", "", "", 55 },
                    { "OpenSCAD", "", "", 55 },
                    { "PSpice", "", "", 55 },
                    { "Ansys", "acadêmico", "", 56 },
                    { "R", "", "", 56 },
                    { "Matlab", "", "", 56 },
                    { "RADIASOL", "", "", 60 },
                    { "Matlab", "", "", 62 },
                    { "Simio", "", "", 62 },
                    { "VISSIM", "", "", 62 },
                    { "Ambientes de desenvolvimento de software (C, C++, Python)", "", "", 62 },
                    { "Comsol Multiphysics", "", "", 65 },
                    { "APEX", "", "", 65 },
                    { "Matlab", "", "", 72 },
                    { "ANSYS-CFD", "", "", 78 },
                    { "Softwares livres de controle dos equipamentos", "", "", 81 }
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"Software\"");
        }
    }
}
