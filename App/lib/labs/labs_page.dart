import 'package:app/labs/lab.dart';
import 'package:flutter/material.dart';
import 'package:app/labs/lab_details_page.dart';

class LabsPage extends StatelessWidget {
  const LabsPage({Key? key, required this.isLab, this.labs, this.elegibleLabs})
      : super(key: key);
  final List<Lab>? labs;
  final List<ElegibleLabs>? elegibleLabs;
  final bool isLab;

  @override
  Widget build(BuildContext context) {
    List<DataRow> rows = [];
    if (labs != null) {
      rows = labs!
          .map(
            (e) => DataRow(
              cells: [
                DataCell(
                  Text(
                    e.name,
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
                                labId: e.id ?? '',
                                isLab: isLab,
                              )),
                    );
                  },
                ))
              ],
            ),
          )
          .toList();
    } else if (elegibleLabs != null) {
      rows = elegibleLabs!
          .map(
            (e) => DataRow(
              cells: [
                DataCell(
                  Text(
                    e.name,
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
                                labId: e.id ?? '',
                                isLab: isLab,
                              )),
                    );
                  },
                )),
                DataCell(
                  Text(
                    e.match.toString(),
                    style: const TextStyle(
                      fontStyle: FontStyle.italic,
                    ),
                  ),
                )
              ],
            ),
          )
          .toList();
    }
    return ListView(shrinkWrap: true, children: [
      Padding(
          padding: const EdgeInsets.only(left: 16, top: 16),
          child: Text(labs != null ? 'Laboratórios' : 'Laboratórios Elegíveis',
              style: const TextStyle(fontWeight: FontWeight.bold))),
      DataTable(columns: <DataColumn>[
        const DataColumn(
          label: Expanded(
            child: Text(
              'Nome',
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
        if (!isLab) ...[
          const DataColumn(
            label: Expanded(
              child: Text(
                'Afinidade',
                style: TextStyle(fontStyle: FontStyle.italic),
              ),
            ),
          )
        ]
      ], rows: rows)
    ]);
  }
}
