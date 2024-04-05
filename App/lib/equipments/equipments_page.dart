import 'package:app/equipments/equipment_details_page.dart';
import 'package:app/equipments/equipments.dart';
import 'package:flutter/material.dart';

class EquipmentsPage extends StatelessWidget {
  EquipmentsPage({Key? key, required this.equipments, required this.isLab})
      : super(key: key);
  final List<Equipment> equipments;
  final bool isLab;

  @override
  Widget build(BuildContext context) {
    return SizedBox(
        height: 200,
        child: ListView(
          children: [
            const Padding(
                padding: EdgeInsets.symmetric(horizontal: 16, vertical: 0),
                child: Text('Equipamentos',
                    style: TextStyle(fontWeight: FontWeight.bold))),
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
              rows: equipments
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
                                  builder: (context) => EquipmentDetailsPage(
                                        equipment: e,
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
