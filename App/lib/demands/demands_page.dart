import 'package:app/demands/demand_form_page.dart';
import 'package:app/demands/demand.dart';
import 'package:app/demands/demand_details_page.dart';
import 'package:app/demands/demand_service.dart';
import 'package:app/labs/lab.dart';
import 'package:flutter/material.dart';

class DemandsPage extends StatefulWidget {
  DemandsPage({required this.isLab});
  final bool isLab;

  @override
  State<StatefulWidget> createState() => DemandsPageState(isLab: isLab);
}

List<Demand> demands = [];

class DemandsPageState extends State {
  DemandsPageState({required this.isLab});
  final bool isLab;

  @override
  void initState() {
    super.initState();
    getPostsFromApi();
  }
  Future<void> getPostsFromApi() async {
    try {
      demands = (await ApiDemandService.getDemand())!;
      // Update the state to rebuild the UI with the new data
      setState(() {});
    } catch (e) {
      debugPrint('Exception: $e');
    }
  }

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
                              'TODO',
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
                                          demandId: e.id,
                                          isLab: isLab,
                                        )),
                              );
                            },
                          ),
                          if (!isLab)
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
