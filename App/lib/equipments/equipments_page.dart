import 'package:app/equipments/equipment_description_modal.dart';
import 'package:app/equipments/equipment_form_page.dart';
import 'package:app/equipments/equipments.dart';
import 'package:flutter/material.dart';

class EquipmentsPage extends StatefulWidget {
  final List<Equipment> equipments;
  final bool isLab;
  final bool create;
  const EquipmentsPage(
      {Key? key,
      required this.equipments,
      required this.isLab,
      this.create = false});
  @override
  State<EquipmentsPage> createState() => _EquipmentsPageState();
}

class _EquipmentsPageState extends State<EquipmentsPage> {
  @override
  Widget build(BuildContext context) {
    return ListView(
      shrinkWrap: true,
      children: [
        Row(
          children: [
            const Padding(
              padding: EdgeInsets.symmetric(horizontal: 16, vertical: 16),
              child: Text('Equipamentos',
                  style: TextStyle(fontWeight: FontWeight.bold)),
            ),
            if (widget.isLab)
              IconButton(
                icon: const Icon(Icons.add_circle_outline),
                onPressed: () async {
                  TextEditingController nameController =
                      TextEditingController();
                  TextEditingController descriptionController =
                      TextEditingController();
                  TextEditingController areaController =
                      TextEditingController();
                  final res = await showModalBottomSheet(
                    context: context,
                    builder: (BuildContext context) {
                      return EquipmentFormPage(
                          nameController: nameController,
                          descriptionController: descriptionController,
                          areaController: areaController);
                    },
                  );
                  if (res != null && res) {
                    Equipment equip = Equipment.fromMap({
                      'name': nameController.text,
                      'description': descriptionController.text,
                      'area': areaController.text
                    });
                    if (widget.create) {
                      // TODO: create new equipment
                    }
                    setState(() {
                      widget.equipments.add(equip);
                    });
                  }
                },
              )
          ],
        ),
        DataTable(
          dataRowMaxHeight: double.infinity,
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
                  'Área',
                  style: TextStyle(fontStyle: FontStyle.italic),
                ),
              ),
            ),
            const DataColumn(
              label: Expanded(
                child: Text(
                  'Descrição',
                  style: TextStyle(fontStyle: FontStyle.italic),
                ),
              ),
            ),
            if (widget.isLab)
              const DataColumn(
                label: Expanded(
                  child: Text(
                    'Ações',
                    style: TextStyle(fontStyle: FontStyle.italic),
                  ),
                ),
              ),
          ],
          rows: widget.equipments
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
                        e.area ?? '',
                        style: const TextStyle(
                          fontStyle: FontStyle.italic,
                        ),
                      ),
                    ),
                    DataCell(IconButton(
                      icon: const Icon(Icons.article_outlined),
                      onPressed: () {
                        showModalBottomSheet(
                          context: context,
                          builder: (BuildContext context) {
                            return EquipmentDetailsPage(equipment: e);
                          },
                        );
                      },
                    )),
                    if (widget.isLab)
                      DataCell(Row(children: [
                        IconButton(
                          icon: const Icon(Icons.edit_outlined),
                          onPressed: () async {
                            TextEditingController nameController =
                                TextEditingController(text: e.name);
                            TextEditingController descriptionController =
                                TextEditingController(text: e.description);
                            TextEditingController areaController =
                                TextEditingController(text: e.area);
                            final res = await showModalBottomSheet(
                              context: context,
                              builder: (BuildContext context) {
                                return EquipmentFormPage(
                                    nameController: nameController,
                                    descriptionController:
                                        descriptionController,
                                    areaController: areaController);
                              },
                            );
                            if (res != null && res) {
                              Equipment equip = Equipment.fromMap({
                                'name': nameController.text,
                                'description': descriptionController.text,
                                'area': areaController.text
                              });
                              if (!widget.create) {
                                // TODO: edit equipment
                              }
                              setState(() {
                                e = equip; // TODO: fix edit
                              });
                            }
                          },
                        ),
                        IconButton(
                          icon: const Icon(Icons.delete_outline),
                          onPressed: () {
                            if (!widget.create) {
                              // TODO: remove equipment
                            }
                            setState(() {
                              widget.equipments.remove(e);
                            });
                          },
                        )
                      ]))
                  ],
                ),
              )
              .toList(),
        )
      ],
    );
  }
}
