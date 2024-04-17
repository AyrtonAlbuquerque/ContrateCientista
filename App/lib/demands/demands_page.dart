import 'package:app/demands/demand_form_page.dart';
import 'package:app/demands/demand.dart';
import 'package:app/demands/demand_details_page.dart';
import 'package:app/labs/lab.dart';
import 'package:flutter/material.dart';

List<Map<String, dynamic>> listOfLabs = [
  {
    'id': '9600f5b9-491a-455a-b43c-4552e7655947',
    'name': 'Laboratório de Luminescência Estimulada e Dosimetria',
    'code': 'LLED',
    'responsibleId': '2',
    'addressId': '2',
    'description':
        'Pesquisa#Ensino: Desenvolvimento de instrumentação e detectores luminescentes para medidas de radiação ionizante',
    'certificates': 'CNEN',
    'foundationDate': '2013-2018',
    'match': 98
  }
];
List<ElegibleLabs> labs = listOfLabs.map((map) => ElegibleLabs.fromMap(map)).toList();

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
    'keywords': 'keywordA, keywordB, keywordC',
    'labs': labs
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

List<DemandDetail> demands = listOfDemands.map((map) => DemandDetail.fromMap(map)).toList();

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
                            builder: (context) => DemandFormPage()),
                      );
                    }),
              )
            ],
            DataTable(
              columns: <DataColumn>[
                const DataColumn(
                  label: Expanded(
                    child: Text(
                      'Título',
                      style: TextStyle(fontStyle: FontStyle.italic),
                    ),
                  ),
                ),
                if (isLab)
                  const DataColumn(
                    label: Expanded(
                      child: Text(
                        'Corporação',
                        style: TextStyle(fontStyle: FontStyle.italic),
                      ),
                    ),
                  ),
                const DataColumn(
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
                        if (isLab)
                          DataCell(
                            Text(
                              e.company,
                              style: const TextStyle(
                                fontStyle: FontStyle.italic,
                              ),
                            ),
                          ),
                        DataCell(Row(children: [
                          IconButton(
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
                          ),
                          if (!isLab && e.labs.isNotEmpty)
                            IconButton(
                              icon: const Icon(Icons.edit_outlined),
                              onPressed: () {
                                Navigator.push(
                                  context,
                                  MaterialPageRoute(
                                      builder: (context) => DemandFormPage(
                                            demand: e,
                                          )),
                                );
                              },
                            )
                        ])),
                      ],
                    ),
                  )
                  .toList(),
            )
          ],
        ));
  }
}
