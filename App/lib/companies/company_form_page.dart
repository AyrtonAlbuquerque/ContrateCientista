import 'package:app/companies/company.dart';
import 'package:flutter/material.dart';

class CompanyFormPage extends StatelessWidget {
  CompanyFormPage({Key? key, this.login, this.password, this.company}) : super(key: key);

  final String? login;
  final String? password;
  final Company? company;

  final _formKey = GlobalKey<FormState>();
  final TextEditingController nameController = TextEditingController();
  final TextEditingController cnpjController = TextEditingController();
  final TextEditingController emailController = TextEditingController();
  final TextEditingController descriptionController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    if (company != null) {
      nameController.text = company!.name;
      cnpjController.text = company!.cnpj;
      emailController.text = company!.email;
      descriptionController.text = company!.description;
    }
    return Scaffold(
      appBar: AppBar(
        title: Text(company != null ? 'Organização' : 'Criar conta de organização'),
        backgroundColor: const Color.fromARGB(255, 255, 166, 0),
      ),
      body: SingleChildScrollView(
          child: Form(
        key: _formKey,
        child: Column(children: [
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
          const Text('CNPJ *'),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 16),
            child: TextFormField(
                decoration: const InputDecoration(border: OutlineInputBorder()),
                controller: cnpjController),
          ),
          const Text('Email *'),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 16),
            child: TextFormField(
                decoration: const InputDecoration(border: OutlineInputBorder()),
                controller: emailController),
          ),
          const Text('Descrição'),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 16),
            child: TextFormField(
                decoration: const InputDecoration(border: OutlineInputBorder()),
                controller: descriptionController),
          ),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 16),
            child: ElevatedButton(
              child: const Text('Salvar'),
              onPressed: () {
                if (_formKey.currentState!.validate()) {
                  if (company != null) {
                    // TODO: atualizar company
                  } else {
                    // TODO: criar company
                  }
                } else {
                  ScaffoldMessenger.of(context).showSnackBar(
                    const SnackBar(
                        content: Text(
                            'Por favor, preencha todos os campos obrigatórios')),
                  );
                }
              },
            ),
          ),
        ]),
      )),
    );
  }
}
