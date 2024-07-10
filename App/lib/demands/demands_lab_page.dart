import 'package:app/demands/demand.dart';
import 'package:app/demands/match_details_page.dart';
import 'package:app/demands/match_service.dart';
import 'package:flutter/material.dart';

class DemandsLabPage extends StatefulWidget {
  DemandsLabPage();

  @override
  State<StatefulWidget> createState() => DemandsLabPageState();
}

List<Match> matches = [];

class DemandsLabPageState extends State {
  DemandsLabPageState();

  @override
  void initState() {
    super.initState();
    getPostsFromApi();
  }

  Future<void> getPostsFromApi() async {
    try {
      matches = (await ApiMatchService.getMatches())!;
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
          title: const Text('Demandas'),
          backgroundColor: const Color.fromARGB(255, 255, 166, 0),
        ),
        body: ListView(
          children: [
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
                      'Detalhes',
                      style: TextStyle(fontStyle: FontStyle.italic),
                    ),
                  ),
                ),
              ],
              rows: matches
                  .map(
                    (e) => DataRow(
                      cells: [
                        DataCell(
                          Text(
                            e.demand.title,
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
                                    builder: (context) => MatchDetailsPage(
                                          matchId: e.id,
                                        )),
                              );
                            },
                          ),
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
