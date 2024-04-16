import 'package:flutter/material.dart';

class SoftwareFormPage extends StatelessWidget {
  SoftwareFormPage(
      {Key? key,
      required this.nameController,
      required this.descriptionController,
      required this.areaController})
      : super(key: key);

  final _formKey = GlobalKey<FormState>();
  final TextEditingController nameController;
  final TextEditingController descriptionController;
  final TextEditingController areaController;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Form(
        key: _formKey,
        child: Column(mainAxisAlignment: MainAxisAlignment.center, children: [
          const Text('Nome *'),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 16),
            child: TextFormField(
              decoration: const InputDecoration(border: OutlineInputBorder()),
              controller: nameController,
              validator: (value) {
                if (value == null || value.isEmpty) {
                  return 'Por favor, insira um nome';
                }
                return null;
              },
            ),
          ),
          const Text('Descrição'),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 16),
            child: TextFormField(
                decoration: const InputDecoration(border: OutlineInputBorder()),
                controller: descriptionController),
          ),
          const Text('Área'),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 16),
            child: TextFormField(
                decoration: const InputDecoration(border: OutlineInputBorder()),
                controller: areaController),
          ),
        ]),
      ),
    );
  }
}
