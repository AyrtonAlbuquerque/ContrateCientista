import 'package:app/demands/demand.dart';
import 'package:app/labs/lab.dart';
import 'package:flutter/material.dart';
import 'package:app/labs/labs_page.dart';

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
  },
  {
    'id': '6ae117b5-4891-4778-a2fe-b06100027441',
    'name': 'Laboratório de Física Computacional',
    'code': 'C0D3',
    'responsibleId': '4',
    'addressId': '4',
    'description':
        'Pesquisa. Simulação de redes complexas. Cálculo de estrutura eletrônica. Espalhamento de reações nucleares. Dinâmica molecular',
    'certificates': '',
    'foundationDate': '2008-2013',
    'match': 76
  }
];
List<ElegibleLabs> labs = listOfLabs.map((map) => ElegibleLabs.fromMap(map)).toList();
DemandDetail demand = DemandDetail(
    id: '8f779a42-0fd7-4dad-8511-7d97b648afe6',
    title: 'Revestimento regenerativo para peças metálicas',
    company: 'Empresa B',
    description:
        'A literatura mostra a utilização de revestimento regenerativo como alternativa aos métodos de pintura convencional e galvanizada, o que pode ser uma oportunidade interessante para a qualidade percebida das nossas peças metálicas. Para avaliar essa possibilidade, propõe-se fazer um estudo comparativo entre peças pintadas com revestimento regenerativo, pintura convencional e galvanização e verificar se possuem desempenho similar.',
    department: 'DE-TC',
    benefits:
        'Redução de custos; Maior facilidade no processo de pintura; Maior durabilidade',
    details:
        'Formação: Graduação em Engenharia Mecânica, Engenharia de Materiais ou Engenharia Química. Pré-requisitos em conhecimentos específicos: Conhecimento em métodos de pintura; Idiomas: Inglês, francês será um diferencial.',
    restrictions:
        'A literatura mostra a utilização de revestimento regenerativo como alternativa aos métodos de pintura convencional e galvanizada, o que pode ser uma oportunidade interessante para a qualidade percebida das nossas peças metálicas. Para avaliar essa possibilidade, propõe-se fazer um estudo comparativo entre peças pintadas com revestimento regenerativo, pintura convencional e galvanização e verificar se possuem desempenho similar.',
    keywords: 'keywordA, keywordB, keywordC',
    eligibleLabs: labs);


class DemandDetailsPage extends StatelessWidget {
  DemandDetailsPage({Key? key, required this.demandId, required this.isLab})
      : super(key: key);
  final String demandId;
  final bool isLab;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Demandas > Detalhes'),
        backgroundColor: const Color.fromARGB(255, 255, 166, 0),
      ),
      body: SingleChildScrollView(
          child: Column(children: [
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
        if (!isLab) ...[LabsPage(elegibleLabs: demand.labs, isLab: isLab)],
        const SizedBox(height: 50),
      ])),
    );
  }
}
