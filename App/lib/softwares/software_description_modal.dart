import 'package:app/softwares/software.dart';
import 'package:flutter/material.dart';

class SoftwareDetailsPage extends StatelessWidget {
  SoftwareDetailsPage({Key? key, required this.software})
      : super(key: key);
  final Software software;

  @override
  Widget build(BuildContext context) {
    return Center(
      child: ListView(shrinkWrap: true, children: [
        Padding(
          padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 20),
          child: Text(
            software.name,
            style: const TextStyle(fontSize: 24, fontWeight: FontWeight.bold),
          ),
        ),
        Padding(
          padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 20),
          child: Text(software.description ?? ''),
        )
      ]),
    );
  }
}
