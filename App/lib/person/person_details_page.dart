import 'package:app/person/person.dart';
import 'package:flutter/material.dart';

class PersonDetailsPage extends StatelessWidget {
  PersonDetailsPage(
      {Key? key,
      required this.title,
      required this.person,
      required this.isLab})
      : super(key: key);
  final Person person;
  final String title;
  final bool isLab;

  @override
  Widget build(BuildContext context) {
    return Column(crossAxisAlignment: CrossAxisAlignment.start, children: [
      Center(
        child: Padding(
          padding: const EdgeInsets.symmetric(horizontal: 0, vertical: 16),
          child: Text(
            title,
            style: const TextStyle(fontWeight: FontWeight.bold),
          ),
        ),
      ),
      Center(
        child: Padding(
          padding: const EdgeInsets.symmetric(horizontal: 10, vertical: 0),
          child: Text(
            person.name,
          ),
        ),
      ),
      Center(
        child: Padding(
          padding: const EdgeInsets.symmetric(horizontal: 32, vertical: 0),
          child: Text('Departamento: ${person.department ?? ''}'),
        ),
      ),
      if (person.email != '') ...[
        Center(
            child: Padding(
          padding: const EdgeInsets.symmetric(horizontal: 32, vertical: 0),
          child: Text('Email: ${person.email}'),
        )),
      ],
      if (person.phone != null && person.phone != '') ...[
        Center(
            child: Padding(
          padding: const EdgeInsets.symmetric(horizontal: 32, vertical: 0),
          child: Text('Telefone: ${person.phone}'),
        ))
      ],
    ]);
  }
}
