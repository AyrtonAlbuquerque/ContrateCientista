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
      Padding(
        padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 16),
        child: Text(
          title,
          style: const TextStyle(fontWeight: FontWeight.bold),
        ),
      ),
      Padding(
        padding: const EdgeInsets.symmetric(horizontal: 32, vertical: 0),
        child: Text(
          person.name,
        ),
      ),
      const Padding(
        padding: EdgeInsets.symmetric(horizontal: 32, vertical: 16),
        child: Text(
          'Departamento',
          style: TextStyle(fontWeight: FontWeight.bold),
        ),
      ),
      Padding(
        padding: const EdgeInsets.symmetric(horizontal: 32, vertical: 0),
        child: Text(person.department ?? ''),
      ),
      if (person.email != '') ...[
        const Padding(
          padding: EdgeInsets.symmetric(horizontal: 32, vertical: 16),
          child: Text(
            'Email',
            style: TextStyle(fontWeight: FontWeight.bold),
          ),
        ),
        Padding(
          padding: const EdgeInsets.symmetric(horizontal: 32, vertical: 0),
          child: Text(person.email),
        )
      ],
      if (person.phone != null && person.phone != '') ...[
        const Padding(
          padding: EdgeInsets.symmetric(horizontal: 32, vertical: 16),
          child: Text(
            'Telefone',
            style: TextStyle(fontWeight: FontWeight.bold),
          ),
        ),
        Padding(
          padding: const EdgeInsets.symmetric(horizontal: 32, vertical: 0),
          child: Text(person.phone ?? ''),
        )
      ],
    ]);
  }
}
