import 'package:app/demands/demand.dart';
import 'package:app/demands/demand_service.dart';
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

Demand? demand;

class DemandDetailsPage extends StatefulWidget {
  DemandDetailsPage({required this.demandId, required this.isLab});
  final int? demandId;
  final bool isLab;

  @override
  State<StatefulWidget> createState() => DemandDetailsPageState(demandId: demandId, isLab: isLab);
}

class DemandDetailsPageState extends State {
  DemandDetailsPageState({required this.demandId, required this.isLab});
  final int? demandId;
  final bool isLab;

  @override
  void initState() {
    super.initState();
    getPostsFromApi();
  }
  Future<void> getPostsFromApi() async {
    try {
      demand = (await ApiDemandService.getDemandById(demandId))!;
      // Update the state to rebuild the UI with the new data
      setState(() {});
    } catch (e) {
      debugPrint('Exception: $e');
    }
  }

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
            demand?.title ?? '',
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
          child: Text(demand?.description ?? ''),
        ),
        Row(
          children: [
            // Column(
            //   children: [
            //     const Padding(
            //       padding: EdgeInsets.symmetric(horizontal: 16, vertical: 16),
            //       child: Text(
            //         'Organização',
            //         style: TextStyle(fontWeight: FontWeight.bold),
            //       ),
            //     ),
            //     Padding(
            //       padding:
            //           const EdgeInsets.symmetric(horizontal: 16, vertical: 0),
            //       child: Text(demand.company),
            //     ),
            //   ],
            // ),
            // const Spacer(),
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
                  child: Text(demand?.department ?? ''),
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
          child: Text(demand?.benefits ?? ''),
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
          child: Text(demand?.details ?? ''),
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
          child: Text(demand?.restrictions ?? ''),
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
          child: Text(demand?.keywords?.join(', ') ?? ''),
        ),
        // if (!isLab) ...[LabsPage(elegibleLabs: demand.labs, isLab: isLab)],
        const SizedBox(height: 50),
      ])),
    );
  }
}
