import 'package:app/demands/create_demand_page.dart';
import 'package:app/demands/demand.dart';
import 'package:app/demands/demand_details_page.dart';
import 'package:flutter/material.dart';

List<Map<String, dynamic>> listOfDemands = [
  {
    'id': '8f779a42-0fd7-4dad-8511-7d97b648afe6',
    'title': 'Revestimento regenerativo para peças metálicas',
    'company': 'Empresa B',
    'description':
        'A literatura mostra a utilização de revestimento regenerativo como alternativa aos métodos de pintura convencional e galvanizada, o que pode ser uma oportunidade interessante para a qualidade percebida das nossas peças metálicas. Para avaliar essa possibilidade, propõe-se fazer um estudo comparativo entre peças pintadas com revestimento regenerativo, pintura convencional e galvanização e verificar se possuem desempenho similar.',
    'department': 'DE-TC',
    'benefits':
        'Redução de custos; Maior facilidade no processo de pintura; Maior durabilidade',
    'details':
        'Formação: Graduação em Engenharia Mecânica, Engenharia de Materiais ou Engenharia Química. Pré-requisitos em conhecimentos específicos: Conhecimento em métodos de pintura; Idiomas: Inglês, francês será um diferencial.',
    'restrictions':
        'A literatura mostra a utilização de revestimento regenerativo como alternativa aos métodos de pintura convencional e galvanizada, o que pode ser uma oportunidade interessante para a qualidade percebida das nossas peças metálicas. Para avaliar essa possibilidade, propõe-se fazer um estudo comparativo entre peças pintadas com revestimento regenerativo, pintura convencional e galvanização e verificar se possuem desempenho similar.',
    'keywords': 'keywordA, keywordB, keywordC'
  },
  {
    'id': 'faebbf1e-39ac-4b6d-b30b-e1baa585be10',
    'title':
        'Compatibilidade de combustíveis com revestimentos organometálicos',
    'company': 'Empresa A',
    'description':
        'É conhecida pela indústria automobilística o uso de revestimento organometálico+ chapas pré revestida em ZnFe em tanques de combustível metálicos. Para melhorar o desempenho desse produto, propõe-se fazer um estudo aprofundado de compatibilidade para identificar potenciais substâncias (adulterações do combustível) que podem atacar este revestimento e sugerir melhorias no produto que possam aumentar sua resistência. ',
    'department': 'DE-TC',
    'benefits': 'Aumento na qualidade percebida; Maior durabilidade',
    'details':
        'Formação: Graduação em Engenharia Mecânica, Engenharia de Materiais, Química ou Engenharia Química. Pré-requisitos em conhecimentos específicos: Conhecimento sobre revestimentos; Idiomas: Inglês, francês será um diferencial.',
    'restrictions':
        'É conhecida pela indústria automobilística o uso de revestimento organometálico+ chapas pré revestida em ZnFe em tanques de combustível metálicos. Para melhorar o desempenho desse produto, propõe-se fazer um estudo aprofundado de compatibilidade para identificar potenciais substâncias (adulterações do combustível) que podem atacar este revestimento e sugerir melhorias no produto que possam aumentar sua resistência.',
    'keywords': 'keywordA, keywordB, keywordC'
  },
  {
    'id': '31007e48-ba02-48ba-bf27-8f759de51f6d',
    'title':
        'Estudo de influência da geometria do corpo de prova no ensaio de tração',
    'company': 'Empresa C',
    'description':
        'O TCR realizou um estudo para avaliar a possibilidade de utilizar corpos de prova com uma geometria diferentes em ensaios de tração.  Para conhecer o impacto dessa modificação nos próximos ensaios e manter o nível de comparação com os anteriores, torna-se necessário um estudo comparativo entre corpos cilíndricos e planos com material alumínio para avaliar as propriedades mecânicas (Rm, Rp0,2 e Al) no ensaio de tração segundo ISO6892.',
    'department': 'DE-TC',
    'benefits':
        'Manutenção da qualidade dos ensaios; Reduzir o risco no uso de diferentes geometrias na validação de peças.',
    'details':
        'Formação: Graduação em Engenharia Mecânica, Engenharia de Materiais ou Engenharia Química. Pré-requisitos em conhecimentos específicos: Conhecimento sobre ensaios mecânicos; Idiomas: Inglês, francês será um diferencial.',
    'restrictions':
        'O TCR realizou um estudo para avaliar a possibilidade de utilizar corpos de prova com uma geometria diferentes em ensaios de tração.  Para conhecer o impacto dessa modificação nos próximos ensaios e manter o nível de comparação com os anteriores, torna-se necessário um estudo comparativo entre corpos cilíndricos e planos com material alumínio para avaliar as propriedades mecânicas (Rm, Rp0,2 e Al) no ensaio de tração segundo ISO6892.',
    'keywords': 'keywordA, keywordB, keywordC'
  }
];
List<Demand> demands = listOfDemands.map((map) => Demand.fromMap(map)).toList();

class DemandsPage extends StatelessWidget {
  DemandsPage({Key? key, required this.isLab}) : super(key: key);
  final bool isLab;

//TODO: identificar demandas que ja tiveram match (se tiverem labs)
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          title: const Text('Demandas'),
          backgroundColor: const Color.fromARGB(255, 255, 166, 0),
        ),
        body: ListView(
          children: [
            if (!isLab) ...[
              Padding(
                padding:
                    const EdgeInsets.symmetric(horizontal: 16, vertical: 16),
                child: ElevatedButton(
                    child: const Text('Criar demanda'),
                    onPressed: () {
                      Navigator.push(
                        context,
                        MaterialPageRoute(
                            builder: (context) => CreateDemandPage()),
                      );
                    }),
              )
            ],
            DataTable(
              columns: const <DataColumn>[
                DataColumn(
                  label: Expanded(
                    child: Text(
                      'Título',
                      style: TextStyle(fontStyle: FontStyle.italic),
                    ),
                  ),
                ),
                DataColumn(
                  label: Expanded(
                    child: Text(
                      'Corporação',
                      style: TextStyle(fontStyle: FontStyle.italic),
                    ),
                  ),
                ),
                DataColumn(
                  label: Expanded(
                    child: Text(
                      'Detalhes',
                      style: TextStyle(fontStyle: FontStyle.italic),
                    ),
                  ),
                ),
              ],
              rows: demands
                  .map(
                    (e) => DataRow(
                      cells: [
                        DataCell(
                          Text(
                            e.title,
                            style: const TextStyle(
                              fontStyle: FontStyle.italic,
                            ),
                          ),
                        ),
                        DataCell(
                          Text(
                            e.company,
                            style: const TextStyle(
                              fontStyle: FontStyle.italic,
                            ),
                          ),
                        ),
                        DataCell(IconButton(
                          icon: const Icon(Icons.article_outlined),
                          onPressed: () {
                            Navigator.push(
                              context,
                              MaterialPageRoute(
                                  builder: (context) => DemandDetailsPage(
                                        demandId: e.id ?? '',
                                        isLab: isLab,
                                      )),
                            );
                          },
                        )),
                      ],
                    ),
                  )
                  .toList(),
            )
          ],
        ));
  }
}
