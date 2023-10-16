﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Domain.Migrations
{
    public partial class PopulateEquipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Name", "Description", "Area", "LaboratoryId" },
                values: new object[,]
                {
                    { "Sistema homemade de produção de nanomateriais", "", "", 1 },
                    { "Sistema homemade de deposição de nanomateriais: spin coater e dip-coater", "", "", 1 },
                    { "Placa aquecedora (ambiente 400oC)", "", "", 1 },
                    { "Almoxarifado de produtos químicos: grafite, ácido sulfúrico, ácido fluorídrico, ácido clorídrico, ácido fosfórico, permaganato de potássio, nitrato de sódio, peróxido de hidrogênio", "", "", 1 },
                    { "Sistema de medidas elétricas MyRio, MyDAQ e van de Pauw", "", "", 1 },
                    { "Sistema eletrônico de multiprocessamento Arduíno, Raspberry e Tiva", "", "", 1 },
                    { "Leitor OSL", "", "", 2 },
                    { "TL homemade", "", "", 2 },
                    { "Detectores OSL", "", "", 2 },
                    { "TL", "", "", 2 },
                    { "Laser de argônio com emissão contínua operando com comprimento de onda de 244 nm", "", "", 3 },
                    { "Laser excímero ArF com emissão pulsada de até 500 Hz e comprimento de onda em 193 nm", "", "", 3 },
                    { "Laser de femtosegundos Ti:Sa com emissão pulsada (kHz) em comprimento de onda de 800 nm que possui amplificador ótico paramétrico ultrarápido, pulsos de femtosegundos", "", "", 3 },
                    { "analisador de espectros óticos cobrindo a faixa de 200 nm - 2400 nm", "", "", 3 },
                    { "analisador Vetorial Ótico, faixa de operação na banda C (1525 – 1610 nm)", "", "", 3 },
                    { "analisador Vetorial de Redes", "", "", 3 },
                    { "Cluster = 10 máquinas de alto desempenho, 40 nós", "", "", 4 },
                    { "Computadores de alto desempenho (5 máquinas)", "", "", 5 },
                    { "Microscópio com câmera", "", "", 5 },
                    { "Analisador Metabólico", "", "", 7 },
                    { "Analisador Bioquímico", "", "", 7 },
                    { "centrífuga", "", "", 7 },
                    { "plataforma de força", "", "", 7 },
                    { "freezer", "", "", 7 },
                    { "esteira laboratorial", "", "", 7 },
                    { "Raman pontual sólida e líquida", "", "", 9 },
                    { "Sensores de fibras ópticas", "", "", 9 },
                    { "Analisador Bioquímico", "", "", 10 },
                    { "Celulares", "", "", 11 },
                    { "Fotocélula", "", "", 12 },
                    { "tapete de salto", "", "", 12 },
                    { "Apenas bens de consumo, como colchonetes", "", "", 13 },
                    { "40 Acelerômetros Actigraph", "", "", 15 },
                    { "40 PGS", "", "", 15 },
                    { "ELETROMIÓGRAFO COM 8 CANAIS POR TELEMETRIA E COM ACESSORIOS E SINCRONISMO PARA: DINAMOMETRO TRAÇÃO COMPRESSÃO E ACELEROMETRO 3 EIXOS X, Y,Z", "", "", 16 },
                    { "PLATAFORMA DE FORÇA", "", "", 16 },
                    { "ESTEIRA ERGOMETRICA PARA AVALIAÇÃO., MOTOR AC.3", "", "", 16 },
                    { "2 MICROCOMPUTADOR, C/PROC.SOQUETE 775, PENTIUM (TORRE DE COMPUTADOR)", "", "", 16 },
                    { "4 CAMERA FILMADORA DIGITAL GOPRO,COM FOTOS DE 12 M", "", "", 16 },
                    { "AGITADOR DE TUBOS POR VIBRAÇÃO TIPO VORTEX.COM", "", "", 16 },
                    { "BANHO MARIA AGITADOR, COM MOVIMENTO RECIPROCO DU", "", "", 16 },
                    { "Detectores Radonio", "", "", 17 },
                    { "Alphaguard", "", "", 17 },
                    { "Kits equipamentos XRF", "", "", 17 },
                    { "leitora de TLD", "", "", 17 },
                    { "Forno a Vácuo", "", "", 17 },
                    { "Kits de câmaras de ionização", "", "", 17 },
                    { "Geiger", "", "", 17 },
                    { "Detector de raios gama e neutrons", "", "", 17 },
                    { "Trocadores de calor", "", "", 18 },
                    { "aquecedores de agua", "", "", 18 },
                    { "Robô de serviços", "", "", 19 },
                    { "Multipotenciostato Ivium", "", "", 20 },
                    { "FZG ENGRENAGENS", "", "", 21 },
                    { "EFICIENCIA DE ROLAMENTOS", "", "", 21 },
                    { "FADIGA DE CONTATO", "", "", 21 },
                    { "Máquina universal de ensaios mecânicos MTS-810", "", "", 22 },
                    { "Máquina universal de ensaios mecânicos EMIC DL10000", "", "", 22 },
                    { "Durômetro EMCO", "", "", 22 },
                    { "torno de relojoeiro", "", "", 23 },
                    { "CNC fresa", "", "", 23 },
                    { "dispermat", "", "", 23 },
                    { "impressora de filamento", "", "", 23 },
                    { "Cluster de processamento", "", "", 24 },
                    { "Instrumento de ultrassom - Panther", "", "", 25 },
                    { "Mesa ótica", "", "", 25 },
                    { "Tanque de imersão 1000l - teste de ultrassom", "", "", 25 },
                    { "Plataforma de teste de inspeção de solda ultrassom", "", "", 25 },
                    { "Ultrassom - Omniscam", "", "", 26 },
                    { "Equipamentos eletrônicos de bancadas (osciloscópio, analisador de espectro, analisador lógico, fontes, frequencímetros, etc.)", "", "", 26 },
                    { "Equipamentos didáticos", "", "", 28 },
                    { "Reometros", "", "", 30 },
                    { "Micro calorimetro DSC 120ºC 1000bar", "", "", 30 },
                    { "célula de pressão 300ºC 1000bar", "", "", 30 },
                    { "Sistema interferométrico para gravação de dispositivos fotoretrativos", "", "", 32 },
                    { "Unidades de medição para sensores de fibra ótica (distribuído e quase distribuído)", "", "", 32 },
                    { "Máquina de emenda por fusão para fibras especiais", "", "", 32 },
                    { "Medidor de impedância", "", "", 33 },
                    { "Linha de produção de placas e circuitos", "", "", 36 },
                    { "Tratamento de superfície", "", "", 36 },
                    { "Impressora 3D", "", "", 36 },
                    { "Linha de montagem de placas SMD", "", "", 36 },
                    { "Roto-evaporador", "", "", 37 },
                    { "Balança analítica", "", "", 37 },
                    { "condutivimetro", "", "", 37 },
                    { "phmetro", "", "", 37 },
                    { "hotplate", "", "", 37 },
                    { "estufa", "", "", 37 },
                    { "osmose reversa", "", "", 37 },
                    { "Potenciostato", "", "", 38 },
                    { "Reator", "", "", 38 },
                    { "Micro-balança de quartzo", "", "", 38 },
                    { "Extrusora monorosca e duplarosca", "", "", 39 },
                    { "Misturadora intensivo", "", "", 39 },
                    { "calandra roll-to-roll", "", "", 39 },
                    { "Injetora", "", "", 39 },
                    { "misturador", "", "", 39 },
                    { "Espectrofotômetro UV-Vis", "", "", 40 },
                    { "Espectrofotômetro", "", "", 41 },
                    { "centrífufas", "", "", 41 },
                    { "autoclave", "", "", 41 },
                    { "Reômetro", "", "", 41 },
                    { "Microscópio optico", "", "", 41 },
                    { "computadores", "", "", 42 },
                    { "Cromatógrafo gasoso com detector por espectrometria de massas tandem", "", "", 43 },
                    { "Cromatógrafo gasoso com detector por ionização em chama e condutividade térmica", "", "", 43 },
                    { "ultrafreezer", "", "", 43 },
                    { "leitora de microplacas", "", "", 43 },
                    { "cromatógrafos líquidos com detectores de arranjo de diodos e de fluorescência", "", "", 43 },
                    { "espectrofotômetro UV-Vis", "", "", 43 },
                    { "liofilizador", "", "", 43 },
                    { "centrífuga refrigerada, agitador orbital como são vários equipamentos", "", "", 43 },
                    { "Cromatógrafo Gasoso com detector FID", "", "", 44 },
                    { "cromatógrafo gasoso com detector MSMS", "", "", 44 },
                    { "cromatografia líquida com detecto DEA", "", "", 44 },
                    { "cromatografia líquida com detector MSMS", "", "", 44 },
                    { "liofilizador", "", "", 44 },
                    { "Prensa hidráulica aquecida MA 098A", "", "", 45 },
                    { "estufa de secagem", "", "", 45 },
                    { "balança semi analítica", "", "", 45 },
                    { "desktop Dell", "", "", 45 },
                    { "Sistema estereoscópico PIV da DantecDynamics", "", "", 46 },
                    { "Equipamento de densitometria", "", "", 47 },
                    { "televisao", "", "", 48 },
                    { "equipamento de termo imagens", "", "", 48 },
                    { "COMPUTADORES", "", "", 49 },
                    { "Ensaio de desgaste de engrenagens - FZG", "", "", 50 },
                    { "Máquina de ensaios de fadiga de contato tipo esfera-plano", "", "", 50 },
                    { "Ensaio de eficiência de rolamentos", "", "", 50 },
                    { "Baropodômetro", "", "", 52 },
                    { "espirômetro", "", "", 52 },
                    { "eletromiográfo", "", "", 52 },
                    { "câmera termográfica", "", "", 52 },
                    { "impressoras 3d", "", "", 55 },
                    { "notebook", "", "", 55 },
                    { "televisão", "", "", 55 },
                    { "Myoware", "", "", 55 },
                    { "EMG system", "", "", 55 },
                    { "Calorimetria Indireta", "", "", 57 },
                    { "Plataforma de Força", "", "", 57 },
                    { "Analisador Bioquímico-centrífuga-freezer", "", "", 57 },
                    { "esteira laboratorial", "", "", 57 },
                    { "Extrusora monorosca", "", "", 58 },
                    { "extrusora dupla rosca", "", "", 58 },
                    { "injetora", "", "", 58 },
                    { "calandra", "", "", 58 },
                    { "misturador intensivo", "", "", 58 },
                    { "Equipamentos para caracterização ótica e eletrica", "", "", 59 },
                    { "Traçador de curva I/V", "", "", 60 },
                    { "Fonte simuladora de painel FV", "", "", 60 },
                    { "Equipamentos de medição", "", "", 60 },
                    { "estufas", "", "", 61 },
                    { "placas de agitação e aquecimento", "", "", 61 },
                    { "Computadores", "", "", 62 },
                    { "Argamassadeira", "", "", 64 },
                    { "Arbitrary Waveform Generator", "", "", 65 },
                    { "Keysight M8195A (2011)", "", "", 65 },
                    { "Digital Storage Oscilloscope, Keysight, DSO91204A", "", "", 65 },
                    { "Vector Network Analyzer", "", "", 65 },
                    { "Keysight  ENA 5071C", "", "", 65 },
                    { "Potenciostado Palmsens", "", "", 68 },
                    { "Potenciosatato Gamry", "", "", 68 },
                    { "APARELHO DE RAIO-X", "", "", 69 },
                    { "EQUIPAMENTO DE RAIO-X ODONTOLÓGICO", "", "", 69 },
                    { "EQUIPAMENTO FIXO DE RAIO X PANORÂMICO PARA MANDÍBULA E FACE", "", "", 69 },
                    { "peças anatômicas", "", "", 70 },
                    { "computador", "", "", 72 },
                    { "TELESCOPIO, DYNAMAX 8, COM ACESSÓRIOS", "", "", 73 },
                    { "TELESCÓPIO SCHMIDT-CASSEGRAIN 8” AUTOMATIZADO C", "", "", 73 },
                    { "CÂMERA FOTOGRÁFICA DIGITAL COM LENTE OBJETIVA", "", "", 73 },
                    { "TELESCÓPIO SKY-WATCHER DOBSONIANO 25", "", "", 73 },
                    { "cromatógrafo de íons", "", "", 74 },
                    { "cromatógrafo gasoso", "", "", 74 },
                    { "analisador de área superficial", "", "", 74 },
                    { "Equipamento para dispersão de misturas (dispermat)", "", "", 76 },
                    { "bomba de vácuo de palheta", "", "", 76 },
                    { "torno de bancada", "", "", 76 },
                    { "impressora 3D", "", "", 76 },
                    { "Tribômetro universal", "", "", 77 },
                    { "Equipamentos de última geração para a monitoração de escoamentos multifásicos", "", "", 78 },
                    { "Câmaras de alta velocidade", "", "", 78 },
                    { "wire mesh sensor", "", "", 78 },
                    { "PIV", "", "", 78 },
                    { "LDV", "", "", 78 },
                    { "banhos termostáticos", "", "", 78 },
                    { "bombas de alta pressão", "", "", 78 },
                    { "PolyJet Eden 250, da Stratasys", "", "", 79 },
                    { "FDM Vantage I da Stratasys", "", "", 79 },
                    { "FDM uPrint SE, da Stratasys", "", "", 79 },
                    { "Binder Jetting Z-Corp Z330 da Stratasys", "", "", 79 },
                    { "DuraPrinter E1: Extrusão de Cerâmica", "", "", 79 },
                    { "Impressora Ender 3", "", "", 79 },
                    { "Impressora Ender 5 Pro", "", "", 79 },
                    { "Impressora DLP Photon S", "", "", 79 },
                    { "Impressora DLP Anycubic", "", "", 79 },
                    { "Impressora DLP Photon", "", "", 79 },
                    { "Next Engine Desktop 3D scanner", "", "", 79 },
                    { "Forno mufla Nabertherm HTC 08/16 with Controller C 450, 1600°C, 13,0 kW, 8 liters, 170 x 290 x 170 mm, com controlador microprocessado", "", "", 79 },
                    { "Forno mufla laboratorial Jung, 1300°C, 23 Litros", "", "", 79 },
                    { "Liofilizador de bancada Terroni", "", "", 79 },
                    { "Dispersor ultrassônico Sonicador VCX-750", "", "", 79 },
                    { "Reômetro RST - SST Soft Solidstester with VT-40-20", "", "", 79 },
                    { "Câmara climática Climacell 111 EVO", "", "", 79 },
                    { "Misturador magnético (Fisherbrand) Isotemp™ RT Advanced Hotplate Stirrer", "", "", 79 },
                    { "Estufa com circulação e renovação de ar Eth", "", "", 79 },
                    { "Tribômetro roda de borracha", "", "", 81 }
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"Equipment\"");
        }
    }
}
