import 'package:app/equipments/equipments.dart';
import 'package:flutter/material.dart';

class EquipmentDetailsPage extends StatelessWidget {
  EquipmentDetailsPage({Key? key, required this.equipment})
      : super(key: key);
  final Equipment equipment;

  @override
  Widget build(BuildContext context) {
    return Center(
      child: ListView(shrinkWrap: true, children: [
        Padding(
          padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 20),
          child: Text(
            equipment.name,
            style: const TextStyle(fontSize: 24, fontWeight: FontWeight.bold),
          ),
        ),
        Padding(
          padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 20),
          child: Text(equipment.description),
        ),
      ]),
    );
  }
}
