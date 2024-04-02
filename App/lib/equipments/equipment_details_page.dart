import 'package:app/equipments/equipments.dart';
import 'package:flutter/material.dart';

class EquipmentDetailsPage extends StatelessWidget {
  EquipmentDetailsPage({Key? key, required this.equipment, required this.isLab})
      : super(key: key);
  final Equipment equipment;
  final bool isLab;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Laboratórios > Equipamentos'),
        backgroundColor: const Color.fromARGB(255, 255, 166, 0),
      ),
      body: Center(
        child: ListView(shrinkWrap: true, children: [
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 0),
            child: Text(
              equipment.name,
              style: const TextStyle(fontSize: 24, fontWeight: FontWeight.bold),
            ),
          ),
          const Padding(
            padding: EdgeInsets.symmetric(horizontal: 16, vertical: 16),
            child: Text(
              'Área',
              style: TextStyle(fontWeight: FontWeight.bold),
            ),
          ),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 0),
            child: Text(equipment.area),
          ),
          const Padding(
            padding: EdgeInsets.symmetric(horizontal: 16, vertical: 16),
            child: Text(
              'Descrição',
              style: TextStyle(fontWeight: FontWeight.bold),
            ),
          ),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 0),
            child: Text(equipment.description),
          ),
        ]),
      ),
    );
  }
}
