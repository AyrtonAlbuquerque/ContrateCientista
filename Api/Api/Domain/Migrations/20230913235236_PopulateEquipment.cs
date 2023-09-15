﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Domain.Migrations
{
    /// <inheritdoc />
    public partial class PopulateCertificate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Name", "Description", "Area", "Laboratory" },
                values: new object[,]
                {
                    { 1, "Sistema homemade de produção de nanomateriais", "", "", 1 },
                    { 2, "Sistema homemade de deposição de nanomateriais: spin coater e dip-coater", "", "", 1 },
                    { 3, "Placa aquecedora (ambiente 400oC)", "", "", 1 },
                    { 4, "Almoxarifado de produtos químicos: grafite, ácido sulfúrico, ácido fluorídrico, ácido clorídrico, ácido fosfórico, permaganato de potássio, nitrato de sódio, peróxido de hidrogênio", "", "", 1 },
                    { 5, "Sistema de medidas elétricas MyRio, MyDAQ e van de Pauw", "", "", 1 },
                    { 6, "Sistema eletrônico de multiprocessamento Arduíno, Raspberry e Tiva", "", "", 1 },
                    { 7, "Leitor OSL", "", "", 2 },
                    { 8, "TL homemade", "", "", 2 },
                    { 9, "Detectores OSL", "", "", 2 },
                    { 10, "TL", "", "", 2 },
                    { 11, "Laser de argônio com emissão contínua operando com comprimento de onda de 244 nm", "", "", 3 },
                    { 12, "Laser excímero ArF com emissão pulsada de até 500 Hz e comprimento de onda em 193 nm", "", "", 3 },
                    { 13, "Laser de femtosegundos Ti:Sa com emissão pulsada (kHz) em comprimento de onda de 800 nm que possui amplificador ótico paramétrico ultrarápido, pulsos de femtosegundos", "", "", 3 },
                    { 14, "analisador de espectros óticos cobrindo a faixa de 200 nm - 2400 nm", "", "", 3 },
                    { 15, "analisador Vetorial Ótico, faixa de operação na banda C (1525 – 1610 nm)", "", "", 3 },
                    { 16, "analisador Vetorial de Redes", "", "", 3 },
                    { 17, "Cluster = 10 máquinas de alto desempenho, 40 nós", "", "", 4 },
                    { 18, "Computadores de alto desempenho (5 máquinas)", "", "", 5 },
                    { 19, "Microscópio com câmera", "", "", 5 },
                    { 20, "Analisador Metabólico", "", "", 7 },
                    { 21, "Analisador Bioquímico", "", "", 7 },
                    { 22, "centrífuga", "", "", 7 },
                    { 23, "plataforma de força", "", "", 7 },
                    { 24, "freezer", "", "", 7 },
                    { 25, "esteira laboratorial", "", "", 7 },
                    { 26, "Raman pontual sólida e líquida", "", "", 9 },
                    { 27, "Sensores de fibras ópticas", "", "", 9 },
                    { 28, "Analisador Bioquímico", "", "", 10 },
                    { 29, "Celulares", "", "", 11 },
                    { 30, "Fotocélula", "", "", 12 },
                    { 31, "tapete de salto", "", "", 12 },
                    { 32, "Apenas bens de consumo, como colchonetes", "", "", 13 },
                    { 33, "40 Acelerômetros Actigraph", "", "", 15 },
                    { 34, "40 PGS", "", "", 15 },
                    { 35, "ELETROMIÓGRAFO COM 8 CANAIS POR TELEMETRIA E COM ACESSORIOS E SINCRONISMO PARA: DINAMOMETRO TRAÇÃO COMPRESSÃO E ACELEROMETRO 3 EIXOS X, Y,Z", "", "", 16 },
                    { 36, "PLATAFORMA DE FORÇA", "", "", 16 },
                    { 37, "ESTEIRA ERGOMETRICA PARA AVALIAÇÃO., MOTOR AC.3", "", "", 16 },
                    { 38, "2 MICROCOMPUTADOR, C/PROC.SOQUETE 775, PENTIUM (TORRE DE COMPUTADOR)", "", "", 16 },
                    { 39, "4 CAMERA FILMADORA DIGITAL GOPRO,COM FOTOS DE 12 M", "", "", 16 },
                    { 40, "AGITADOR DE TUBOS POR VIBRAÇÃO TIPO VORTEX.COM", "", "", 16 },
                    { 41, "BANHO MARIA AGITADOR, COM MOVIMENTO RECIPROCO DU", "", "", 16 },
                    { 42, "Detectores Radonio", "", "", 17 },
                    { 43, "Alphaguard", "", "", 17 },
                    { 44, "Kits equipamentos XRF", "", "", 17 },
                    { 45, "leitora de TLD", "", "", 17 },
                    { 46, "Forno a Vácuo", "", "", 17 },
                    { 47, "Kits de câmaras de ionização", "", "", 17 },
                    { 48, "Geiger", "", "", 17 },
                    { 49, "Detector de raios gama e neutrons", "", "", 17 },
                    { 50, "Trocadores de calor", "", "", 18 },
                    { 51, "aquecedores de agua", "", "", 18 },
                    { 52, "Robô de serviços", "", "", 19 },
                    { 53, "Multipotenciostato Ivium", "", "", 20 },
                    { 54, "FZG ENGRENAGENS", "", "", 21 },
                    { 55, "EFICIENCIA DE ROLAMENTOS", "", "", 21 },
                    { 56, "FADIGA DE CONTATO", "", "", 21 },
                    { 57, "Máquina universal de ensaios mecânicos MTS-810", "", "", 22 },
                    { 58, "Máquina universal de ensaios mecânicos EMIC DL10000", "", "", 22 },
                    { 59, "Durômetro EMCO", "", "", 22 },
                    { 60, "torno de relojoeiro", "", "", 23 },
                    { 61, "CNC fresa", "", "", 23 },
                    { 62, "dispermat", "", "", 23 },
                    { 63, "impressora de filamento", "", "", 23 },
                    { 64, "Cluster de processamento", "", "", 24 },
                    { 65, "Instrumento de ultrassom - Panther", "", "", 25 },
                    { 66, "Mesa ótica", "", "", 25 },
                    { 67, "Tanque de imersão 1000l - teste de ultrassom", "", "", 25 },
                    { 68, "Plataforma de teste de inspeção de solda ultrassom", "", "", 25 },
                    { 69, "Ultrassom - Omniscam", "", "", 26 },
                    { 70, "Equipamentos eletrônicos de bancadas (osciloscópio, analisador de espectro, analisador lógico, fontes, frequencímetros, etc.)", "", "", 26 },
                    { 71, "Equipamentos didáticos", "", "", 28 },
                    { 72, "Reometros", "", "", 30 },
                    { 73, "Micro calorimetro DSC 120ºC 1000bar", "", "", 30 },
                    { 74, "célula de pressão 300ºC 1000bar", "", "", 30 },
                    { 75, "Sistema interferométrico para gravação de dispositivos fotoretrativos", "", "", 32 },
                    { 76, "Unidades de medição para sensores de fibra ótica (distribuído e quase distribuído)", "", "", 32 },
                    { 77, "Máquina de emenda por fusão para fibras especiais", "", "", 32 },
                    { 78, "Medidor de impedância", "", "", 33 },
                    { 79, "Linha de produção de placas e circuitos", "", "", 36 },
                    { 80, "Tratamento de superfície", "", "", 36 },
                    { 81, "Impressora 3D", "", "", 36 },
                    { 82, "Linha de montagem de placas SMD", "", "", 36 },
                    { 83, "Roto-evaporador", "", "", 37 },
                    { 84, "Balança analítica", "", "", 37 },
                    { 85, "condutivimetro", "", "", 37 },
                    { 86, "phmetro", "", "", 37 },
                    { 87, "hotplate", "", "", 37 },
                    { 88, "estufa", "", "", 37 },
                    { 89, "osmose reversa", "", "", 37 },
                    { 90, "Potenciostato", "", "", 38 },
                    { 91, "Reator", "", "", 38 },
                    { 92, "Micro-balança de quartzo", "", "", 38 },
                    { 93, "Extrusora monorosca e duplarosca", "", "", 39 },
                    { 94, "Misturadora intensivo", "", "", 39 },
                    { 95, "calandra roll-to-roll", "", "", 39 },
                    { 96, "Injetora", "", "", 39 },
                    { 97, "misturador", "", "", 39 },
                    { 98, "Espectrofotômetro UV-Vis", "", "", 40 },
                    { 99, "Espectrofotômetro", "", "", 41 },
                    { 100, "centrífufas", "", "", 41 },
                    { 101, "autoclave", "", "", 41 },
                    { 102, "Reômetro", "", "", 41 },
                    { 103, "Microscópio optico", "", "", 41 },
                    { 104, "computadores", "", "", 42 },
                    { 105, "Cromatógrafo gasoso com detector por espectrometria de massas tandem", "", "", 43 },
                    { 106, "Cromatógrafo gasoso com detector por ionização em chama e condutividade térmica", "", "", 43 },
                    { 107, "ultrafreezer", "", "", 43 },
                    { 108, "leitora de microplacas", "", "", 43 },
                    { 109, "cromatógrafos líquidos com detectores de arranjo de diodos e de fluorescência", "", "", 43 },
                    { 110, "espectrofotômetro UV-Vis", "", "", 43 },
                    { 111, "liofilizador", "", "", 43 },
                    { 112, "centrífuga refrigerada, agitador orbital como são vários equipamentos", "", "", 43 },
                    { 113, "Cromatógrafo Gasoso com detector FID", "", "", 44 },
                    { 114, "cromatógrafo gasoso com detector MSMS", "", "", 44 },
                    { 115, "cromatografia líquida com detecto DEA", "", "", 44 },
                    { 116, "cromatografia líquida com detector MSMS", "", "", 44 },
                    { 117, "liofilizador", "", "", 44 },
                    { 118, "Prensa hidráulica aquecida MA 098A", "", "", 45 },
                    { 119, "estufa de secagem", "", "", 45 },
                    { 120, "balança semi analítica", "", "", 45 },
                    { 121, "desktop Dell", "", "", 45 },
                    { 122, "Sistema estereoscópico PIV da DantecDynamics", "", "", 46 },
                    { 123, "Equipamento de densitometria", "", "", 47 },
                    { 124, "televisao", "", "", 48 },
                    { 125, "equipamento de termo imagens", "", "", 48 },
                    { 126, "COMPUTADORES", "", "", 49 },
                    { 127, "Ensaio de desgaste de engrenagens - FZG", "", "", 50 },
                    { 128, "Máquina de ensaios de fadiga de contato tipo esfera-plano", "", "", 50 },
                    { 129, "Ensaio de eficiência de rolamentos", "", "", 50 },
                    { 130, "Baropodômetro", "", "", 52 },
                    { 131, "espirômetro", "", "", 52 },
                    { 132, "eletromiográfo", "", "", 52 },
                    { 133, "câmera termográfica", "", "", 52 },
                    { 134, "impressoras 3d", "", "", 55 },
                    { 135, "notebook", "", "", 55 },
                    { 136, "televisão", "", "", 55 },
                    { 137, "Myoware", "", "", 55 },
                    { 138, "EMG system", "", "", 55 },
                    { 139, "Calorimetria Indireta", "", "", 57 },
                    { 140, "Plataforma de Força", "", "", 57 },
                    { 141, "Analisador Bioquímico-centrífuga-freezer", "", "", 57 },
                    { 142, "esteira laboratorial", "", "", 57 },
                    { 143, "Extrusora monorosca", "", "", 58 },
                    { 144, "extrusora dupla rosca", "", "", 58 },
                    { 145, "injetora", "", "", 58 },
                    { 146, "calandra", "", "", 58 },
                    { 147, "misturador intensivo", "", "", 58 },
                    { 148, "Equipamentos para caracterização ótica e eletrica", "", "", 59 },
                    { 149, "Traçador de curva I/V", "", "", 60 },
                    { 150, "Fonte simuladora de painel FV", "", "", 60 },
                    { 151, "Equipamentos de medição", "", "", 60 },
                    { 152, "estufas", "", "", 61 },
                    { 153, "placas de agitação e aquecimento", "", "", 61 },
                    { 154, "Computadores", "", "", 62 },
                    { 155, "Argamassadeira", "", "", 64 },
                    { 156, "Arbitrary Waveform Generator", "", "", 65 },
                    { 157, "Keysight M8195A (2011)", "", "", 65 },
                    { 158, "Digital Storage Oscilloscope, Keysight, DSO91204A", "", "", 65 },
                    { 159, "Vector Network Analyzer", "", "", 65 },
                    { 160, "Keysight  ENA 5071C", "", "", 65 },
                    { 161, "Potenciostado Palmsens", "", "", 68 },
                    { 162, "Potenciosatato Gamry", "", "", 68 },
                    { 163, "APARELHO DE RAIO-X", "", "", 69 },
                    { 164, "EQUIPAMENTO DE RAIO-X ODONTOLÓGICO", "", "", 69 },
                    { 165, "EQUIPAMENTO FIXO DE RAIO X PANORÂMICO PARA MANDÍBULA E FACE", "", "", 69 },
                    { 166, "peças anatômicas", "", "", 70 },
                    { 167, "computador", "", "", 72 },
                    { 168, "TELESCOPIO, DYNAMAX 8, COM ACESSÓRIOS", "", "", 73 },
                    { 169, "TELESCÓPIO SCHMIDT-CASSEGRAIN 8” AUTOMATIZADO C", "", "", 73 },
                    { 170, "CÂMERA FOTOGRÁFICA DIGITAL COM LENTE OBJETIVA", "", "", 73 },
                    { 171, "TELESCÓPIO SKY-WATCHER DOBSONIANO 25", "", "", 73 },
                    { 172, "cromatógrafo de íons", "", "", 74 },
                    { 173, "cromatógrafo gasoso", "", "", 74 },
                    { 174, "analisador de área superficial", "", "", 74 },
                    { 175, "Equipamento para dispersão de misturas (dispermat)", "", "", 76 },
                    { 176, "bomba de vácuo de palheta", "", "", 76 },
                    { 177, "torno de bancada", "", "", 76 },
                    { 178, "impressora 3D", "", "", 76 },
                    { 179, "Tribômetro universal", "", "", 77 },
                    { 180, "Equipamentos de última geração para a monitoração de escoamentos multifásicos", "", "", 78 },
                    { 181, "Câmaras de alta velocidade", "", "", 78 },
                    { 182, "wire mesh sensor", "", "", 78 },
                    { 183, "PIV", "", "", 78 },
                    { 184, "LDV", "", "", 78 },
                    { 185, "banhos termostáticos", "", "", 78 },
                    { 186, "bombas de alta pressão", "", "", 78 },
                    { 187, "PolyJet Eden 250, da Stratasys", "", "", 79 },
                    { 188, "FDM Vantage I da Stratasys", "", "", 79 },
                    { 189, "FDM uPrint SE, da Stratasys", "", "", 79 },
                    { 190, "Binder Jetting Z-Corp Z330 da Stratasys", "", "", 79 },
                    { 191, "DuraPrinter E1: Extrusão de Cerâmica", "", "", 79 },
                    { 192, "Impressora Ender 3", "", "", 79 },
                    { 193, "Impressora Ender 5 Pro", "", "", 79 },
                    { 194, "Impressora DLP Photon S", "", "", 79 },
                    { 195, "Impressora DLP Anycubic", "", "", 79 },
                    { 196, "Impressora DLP Photon", "", "", 79 },
                    { 197, "Next Engine Desktop 3D scanner", "", "", 79 },
                    { 198, "Forno mufla Nabertherm HTC 08/16 with Controller C 450, 1600°C, 13,0 kW, 8 liters, 170 x 290 x 170 mm, com controlador microprocessado", "", "", 79 },
                    { 199, "Forno mufla laboratorial Jung, 1300°C, 23 Litros", "", "", 79 },
                    { 200, "Liofilizador de bancada Terroni", "", "", 79 },
                    { 201, "Dispersor ultrassônico Sonicador VCX-750", "", "", 79 },
                    { 202, "Reômetro RST - SST Soft Solidstester with VT-40-20", "", "", 79 },
                    { 203, "Câmara climática Climacell 111 EVO", "", "", 79 },
                    { 204, "Misturador magnético (Fisherbrand) Isotemp™ RT Advanced Hotplate Stirrer", "", "", 79 },
                    { 205, "Estufa com circulação e renovação de ar Eth", "", "", 79 },
                    { 206, "Tribômetro roda de borracha", "", "", 81 }
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
                    1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23,
                    24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44,
                    45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65,
                    66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
                    87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106,
                    107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 123,
                    124, 125, 126, 127, 128, 129, 130, 131, 132, 133, 134, 135, 136, 137, 138, 139, 140,
                    141, 142, 143, 144, 145, 146, 147, 148, 149, 150, 151, 152, 153, 154, 155, 156, 157,
                    158, 159, 160, 161, 162, 163, 164, 165, 166, 167, 168, 169, 170, 171, 172, 173, 174,
                    175, 176, 177, 178, 179, 180, 181, 182, 183, 184, 185, 186, 187, 188, 189, 190, 191,
                    192, 193, 194, 195, 196, 197, 198, 199, 200, 201, 202, 203, 204, 205, 206,
                }
            );
        }
    }
}
