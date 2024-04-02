import 'package:app/softwares/software.dart';
import 'package:app/softwares/software_details_page.dart';
import 'package:flutter/material.dart';

class SoftwaresPage extends StatelessWidget {
  SoftwaresPage({Key? key, required this.softwares, required this.isLab})
      : super(key: key);
  final List<Software> softwares;
  final bool isLab;

  @override
  Widget build(BuildContext context) {
    return SizedBox(
        height: 200,
        child: ListView(
          children: [
            const Padding(
              padding: EdgeInsets.symmetric(horizontal: 16, vertical: 0),
              child: Text('Softwares',
                  style: TextStyle(fontWeight: FontWeight.bold)),
            ),
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
                      'Área',
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
                )
              ],
              rows: softwares
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
                        DataCell(
                          Text(
                            e.area,
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
                                  builder: (context) => SoftwareDetailsPage(
                                        software: e,
                                        isLab: isLab,
                                      )),
                            );
                          },
                        ))
                      ],
                    ),
                  )
                  .toList(),
            )
          ],
        ));
  }
}
