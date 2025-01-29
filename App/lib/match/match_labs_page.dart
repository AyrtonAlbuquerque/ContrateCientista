import 'package:app/match/match.dart';
import 'package:app/match/match_details_page.dart';
import 'package:app/match/match_service.dart';
import 'package:flutter/material.dart';

class MatchLabsPage extends StatefulWidget {
  MatchLabsPage({required this.demandId});
  final int demandId;

  @override
  State<StatefulWidget> createState() => MatchLabsPageState(demandId: demandId);
}

List<Match> matches = [];

class MatchLabsPageState extends State {
  MatchLabsPageState({required this.demandId});
  final int demandId;

  @override
  void initState() {
    super.initState();
    getPostsFromApi();
  }

  Future<void> getPostsFromApi() async {
    try {
      matches = (await ApiMatchService.getMatches())!.where((i) => i.demand.id == demandId).toList();
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
          title: const Text('Laboratórios'),
          backgroundColor: const Color.fromARGB(255, 255, 166, 0),
        ),
        body: ListView(
          children: [
            DataTable(
              dataRowMaxHeight: double.infinity,
              columns: const <DataColumn>[
                DataColumn(
                  label: Expanded(
                    child: Text(
                      'Name',
                      style: TextStyle(fontStyle: FontStyle.italic),
                    ),
                  ),
                ),
                DataColumn(
                  label: Expanded(
                    child: Text(
                      'Score',
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
                            e.laboratory.name,
                            style: const TextStyle(
                              fontStyle: FontStyle.italic,
                            ),
                          ),
                        ),
                        DataCell(
                          Text(
                            e.score.toStringAsFixed(2),
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
                                          matchId: e.id
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
