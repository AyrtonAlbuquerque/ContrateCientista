import 'package:app/match/match.dart';
import 'package:app/match/match_details_page.dart';
import 'package:app/match/match_lab_details_page.dart';
import 'package:app/match/match_service.dart';
import 'package:flutter/material.dart';

class MatchPage extends StatefulWidget {
  MatchPage({required this.isLab});
  final bool isLab;

  @override
  State<StatefulWidget> createState() => MatchPageState(isLab: isLab);
}

List<Match> matches = [];

class MatchPageState extends State {
  MatchPageState({required this.isLab});
  final bool isLab;

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
          title: const Text('Match'),
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
                              if (isLab) {
                                Navigator.push(
                                  context,
                                  MaterialPageRoute(
                                      builder: (context) => MatchLabDetailsPage(
                                            matchId: e.id
                                          )),
                                );
                              } else {
                                Navigator.push(
                                  context,
                                  MaterialPageRoute(
                                      builder: (context) => MatchDetailsPage(
                                            matchId: e.id
                                          )),
                                );
                              }
                              
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
