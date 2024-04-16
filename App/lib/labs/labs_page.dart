import 'package:app/labs/lab.dart';
import 'package:flutter/material.dart';
import 'package:app/labs/lab_details_page.dart';

class LabsPage extends StatelessWidget {
  LabsPage(
      {Key? key, required this.labs, required this.isLab, required this.title})
      : super(key: key);
  final List<Lab> labs;
  final bool isLab;
  final String title;

  @override
  Widget build(BuildContext context) {
    return SizedBox(
        height: 200,
        child: ListView(
          shrinkWrap: true,
          physics: ClampingScrollPhysics(),
          children: [
            Padding(
                padding:
                    const EdgeInsets.only(left: 16, top: 16),
                child: Text(title,
                    style: const TextStyle(fontWeight: FontWeight.bold))),
            DataTable(
              columns: <DataColumn>[
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
              ],
              rows: labs
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
                        if (!isLab) ...[
                          DataCell(
                            Text(
                              '98',
                              style: const TextStyle(
                                fontStyle: FontStyle.italic,
                              ),
                            ),
                          )
                        ]
                      ],
                    ),
                  )
                  .toList(),
            )
          ],
        ));
  }
}
