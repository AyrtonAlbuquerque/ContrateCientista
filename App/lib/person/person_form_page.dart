import 'package:app/person/person.dart';
import 'package:flutter/material.dart';

class PersonFormPage extends StatelessWidget {
  PersonFormPage({Key? key, required this.person}) : super(key: key);

  final Person person;
  final _formKey = GlobalKey<FormState>();
  final TextEditingController nameController = TextEditingController();
  final TextEditingController departmentController = TextEditingController();
  final TextEditingController emailController = TextEditingController();
  final TextEditingController phoneController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    nameController.text = person.name;
    departmentController.text = person.departament;
    emailController.text = person.email;
    phoneController.text = person.phone ?? '';
    return Container(
        alignment: Alignment.topLeft,
        child: Column(mainAxisAlignment: MainAxisAlignment.start, children: [
          const Row(children: [
            Padding(
                padding: EdgeInsets.symmetric(horizontal: 16, vertical: 16),
                child: Text('Responsável',
                    style: TextStyle(fontWeight: FontWeight.bold),
                    textAlign: TextAlign.start))
          ]),
          Form(
            key: _formKey,
            child:
                Column(mainAxisAlignment: MainAxisAlignment.center, children: [
              const Text('Nome *'),
              Padding(
                padding:
                    const EdgeInsets.symmetric(horizontal: 24, vertical: 8),
                child: TextFormField(
                  decoration:
                      const InputDecoration(border: OutlineInputBorder()),
                  controller: nameController,
                  validator: (value) {
                    if (value == null || value.isEmpty) {
                      return 'Por favor, insira um nome';
                    }
                    return null;
                  },
                  onChanged: (value) {
                    person.name = value;
                  },
                ),
              ),
              const Text('Departamento'),
              Padding(
                padding:
                    const EdgeInsets.symmetric(horizontal: 24, vertical: 8),
                child: TextFormField(
                  decoration:
                      const InputDecoration(border: OutlineInputBorder()),
                  controller: departmentController,
                  onChanged: (value) {
                    person.departament = value;
                  },
                ),
              ),
              const Text('Email'),
              Padding(
                padding:
                    const EdgeInsets.symmetric(horizontal: 24, vertical: 8),
                child: TextFormField(
                    decoration:
                        const InputDecoration(border: OutlineInputBorder()),
                    controller: emailController,
                    onChanged: (value) {
                      person.email = value;
                    }),
              ),
              const Text('Telefone'),
              Padding(
                padding:
                    const EdgeInsets.symmetric(horizontal: 24, vertical: 8),
                child: TextFormField(
                    decoration:
                        const InputDecoration(border: OutlineInputBorder()),
                    controller: phoneController,
                    onChanged: (value) {
                      person.phone = value;
                    }),
              ),
            ]),
          ),
        ]));
  }
}
