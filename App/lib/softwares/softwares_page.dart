import 'package:app/softwares/software.dart';
import 'package:app/softwares/software_description_modal.dart';
import 'package:app/softwares/software_form_page.dart';
import 'package:flutter/material.dart';

class SoftwaresPage extends StatefulWidget {
  final List<Software> softwares;
  final bool isLab;
  final bool create;
  const SoftwaresPage(
      {Key? key,
      required this.softwares,
      required this.isLab,
      this.create = false});
  @override
  State<SoftwaresPage> createState() => _SoftwaresPageState();
}

class _SoftwaresPageState extends State<SoftwaresPage> {
  @override
  Widget build(BuildContext context) {
    return ListView(
      shrinkWrap: true,
      children: [
        Row(children: [
        const Padding(
          padding: EdgeInsets.only(left: 16, top: 16),
          child:
              Text('Softwares', style: TextStyle(fontWeight: FontWeight.bold)),
        ),
        if (widget.isLab)
          IconButton(
            icon: const Icon(Icons.add_circle_outline),
            onPressed: () async {
              TextEditingController nameController = TextEditingController();
              TextEditingController descriptionController =
                  TextEditingController();
              TextEditingController areaController = TextEditingController();
              final res = await showModalBottomSheet(
                context: context,
                builder: (BuildContext context) {
                  return SoftwareFormPage(
                      nameController: nameController,
                      descriptionController: descriptionController,
                      areaController: areaController);
                },
              );
              if (res != null && res) {
                Software software = Software.fromMap({
                  'name': nameController.text,
                  'description': descriptionController.text,
                  'area': areaController.text
                });
                if (!widget.create) {
                  // TODO: create new area
                }
                setState(() {
                  widget.softwares.add(software);
                });
              }
            },
          ),
        ]),
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
          rows: widget.softwares
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
                            return SoftwareDetailsPage(software: e);
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
                                return SoftwareFormPage(
                                    nameController: nameController,
                                    descriptionController:
                                        descriptionController,
                                    areaController: areaController);
                              },
                            );
                            if (res != null && res) {
                              Software software = Software.fromMap({
                                'name': nameController.text,
                                'description': descriptionController.text,
                                'area': areaController.text
                              });
                              if (!widget.create) {
                                // TODO: edit software
                              }
                              setState(() {
                                e = software; // TODO: fix edit
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
                              widget.softwares.remove(e);
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
