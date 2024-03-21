import 'package:flutter/material.dart';
import 'package:app/labs/lab_details_page.dart';

class Demand {
  String title;
  String company;
  String description;
  String department;
  String benefits;
  String details;
  String restrictions;
  String keywords;

  Demand(
      {required this.title,
      required this.company,
      required this.description,
      required this.department,
      required this.benefits,
      required this.details,
      required this.restrictions,
      required this.keywords});
}

class DemandDetailsPage extends StatelessWidget {
  DemandDetailsPage({Key? key, required this.demand, required this.isLab})
      : super(key: key);
  final Demand demand;
  final bool isLab;

  List<Map<String,dynamic>> labs = [
    {
      'name': 'Laboratório de Luminescência Estimulada e Dosimetria',
      'code':'LLED',
      'responsibleId': '2',
      'addressId': '2',
      'description': 'Pesquisa#Ensino: Desenvolvimento de instrumentação e detectores luminescentes para medidas de radiação ionizante',
      'certificates': 'CNEN',
      'foundationDate': '2013-2018',
    },
    {
      'name': 'Laboratório Multiusuário de Fotônica',
      'code':'Multi-FOTON',
      'responsibleId': '3',
      'addressId': '3',
      'description': 'Tem como política a realização de ações e atividades na área de conhecimento denominada Fotônica, tendo como objetivos gerais o apoio ao ensino, à pesquisa, ao desenvolvimento tecnológico, à inovação e à prestação de serviços à comunidade interna e externa. O Multi-Foton se distingue pela competência na área de ensaios em dispositivos, componentes, módulos e sistemas orientados a projetos de sensores e de comunicações no domínio ótico, com especial destaque para ensaios em fibras óticas',
      'certificates': '',
      'foundationDate': '2008-2013',
    },
    {
      'name': 'Laboratório de Física Computacional',
      'code':'C0D3',
      'responsibleId': '4',
      'addressId': '4',
      'description': 'Pesquisa. Simulação de redes complexas. Cálculo de estrutura eletrônica. Espalhamento de reações nucleares. Dinâmica molecular',
      'certificates': '',
      'foundationDate': '2008-2013',
    }
  ];


  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Demandas > Detalhes'),
        backgroundColor: const Color.fromARGB(255, 255, 166, 0),
      ),
      body: Center(
        child: ListView(
          shrinkWrap: true,
          children: [
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 0),
            child: Text(
              demand.title,
              style: const TextStyle(fontSize: 24, fontWeight: FontWeight.bold),
            ),
          ),
          if (isLab) ...[
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 16),
              child: ElevatedButton(
                  child: const Text('Responder demanda'), onPressed: () {}),
            )
          ],
          const Padding(
            padding: EdgeInsets.symmetric(horizontal: 16, vertical: 16),
            child: Text(
              'Descrição',
              style: TextStyle(fontWeight: FontWeight.bold),
            ),
          ),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 0),
            child: Text(demand.description),
          ),
          Row(
            children: [
              Column(
                children: [
                  const Padding(
                    padding: EdgeInsets.symmetric(horizontal: 16, vertical: 16),
                    child: Text(
                      'Organização',
                      style: TextStyle(fontWeight: FontWeight.bold),
                    ),
                  ),
                  Padding(
                    padding:
                        const EdgeInsets.symmetric(horizontal: 16, vertical: 0),
                    child: Text(demand.company),
                  ),
                ],
              ),
              const Spacer(),
              Column(
                children: [
                  const Padding(
                    padding: EdgeInsets.symmetric(horizontal: 16, vertical: 16),
                    child: Text(
                      'Departamento',
                      style: TextStyle(fontWeight: FontWeight.bold),
                    ),
                  ),
                  Padding(
                    padding:
                        const EdgeInsets.symmetric(horizontal: 16, vertical: 0),
                    child: Text(demand.department),
                  ),
                ],
              )
            ],
          ),
          const Padding(
            padding: EdgeInsets.symmetric(horizontal: 16, vertical: 16),
            child: Text(
              'Benfícios',
              style: TextStyle(fontWeight: FontWeight.bold),
            ),
          ),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 0),
            child: Text(demand.benefits),
          ),
          const Padding(
            padding: EdgeInsets.symmetric(horizontal: 16, vertical: 16),
            child: Text(
              'Detalhes',
              style: TextStyle(fontWeight: FontWeight.bold),
            ),
          ),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 0),
            child: Text(demand.details),
          ),
          const Padding(
            padding: EdgeInsets.symmetric(horizontal: 16, vertical: 16),
            child: Text(
              'Restrições',
              style: TextStyle(fontWeight: FontWeight.bold),
            ),
          ),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 0),
            child: Text(demand.restrictions),
          ),
          const Padding(
            padding: EdgeInsets.symmetric(horizontal: 16, vertical: 16),
            child: Text(
              'Palavras-chave',
              style: TextStyle(fontWeight: FontWeight.bold),
            ),
          ),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 0),
            child: Text(demand.keywords),
          ),
          if (!isLab) ...[
            ListView(
              shrinkWrap: true,
              physics: ClampingScrollPhysics(),
              children: [
                DataTable(
                  columns: const <DataColumn>[
                    DataColumn(
                      label: Expanded(
                        child: Text(
                          'Nome',
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
                  rows: labs
                      .map(
                        (e) => DataRow(
                          cells: [
                            DataCell(
                              Text(
                                e['name'],
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
                                      builder: (context) => LabDetailsPage(
                                            lab: Lab(
                                                name: e['name'],
                                                code: e['code'],
                                                responsibleId: e['responsibleId'],
                                                addressId: e['addressId'],
                                                description: e['description'],
                                                certificates: e['certificates'],
                                                foundationDate: e['foundationDate']
                                            ),
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
            )
          ],
          const SizedBox(height: 50),
        ]),
      ),
    );
  }
}
