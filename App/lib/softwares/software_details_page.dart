import 'package:app/softwares/software.dart';
import 'package:flutter/material.dart';

class SoftwareDetailsPage extends StatelessWidget {
  SoftwareDetailsPage({Key? key, required this.software, required this.isLab})
      : super(key: key);
  final Software software;
  final bool isLab;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Laboratórios > Softwares'),
        backgroundColor: const Color.fromARGB(255, 255, 166, 0),
      ),
      body: Center(
        child: ListView(shrinkWrap: true, children: [
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 0),
            child: Text(
              software.name,
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
            child: Text(software.area),
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
            child: Text(software.description),
          )
        ]),
      ),
    );
  }
}
