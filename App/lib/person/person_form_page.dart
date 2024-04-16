import 'package:flutter/material.dart';

class PersonFormPage extends StatelessWidget {
  PersonFormPage(
      {Key? key,
      required this.nameController,
      required this.departmentController,
      required this.emailController,
      required this.phoneController})
      : super(key: key);

  final _formKey = GlobalKey<FormState>();
  final TextEditingController nameController;
  final TextEditingController departmentController;
  final TextEditingController emailController;
  final TextEditingController phoneController;

  @override
  Widget build(BuildContext context) {
    return Container(
        alignment: Alignment.topLeft,
        child: Column(mainAxisAlignment: MainAxisAlignment.start, children: [
          const Padding(
              padding: EdgeInsets.only(top: 12, bottom: 12),
              child: Text('Responsável', style: TextStyle(fontWeight: FontWeight.bold), textAlign: TextAlign.start)),
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
                ),
              ),
              const Text('Departamento'),
              Padding(
                padding:
                    const EdgeInsets.symmetric(horizontal: 24, vertical: 8),
                child: TextFormField(
                    decoration:
                        const InputDecoration(border: OutlineInputBorder()),
                    controller: departmentController),
              ),
              const Text('Email'),
              Padding(
                padding:
                    const EdgeInsets.symmetric(horizontal: 24, vertical: 8),
                child: TextFormField(
                    decoration:
                        const InputDecoration(border: OutlineInputBorder()),
                    controller: emailController),
              ),
              const Text('Telefone'),
              Padding(
                padding:
                    const EdgeInsets.symmetric(horizontal: 24, vertical: 8),
                child: TextFormField(
                    decoration:
                        const InputDecoration(border: OutlineInputBorder()),
                    controller: phoneController),
              ),
            ]),
          ),
        ]));
  }
}
