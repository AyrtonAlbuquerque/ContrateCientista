import 'package:flutter/material.dart';

class CreateDemandPage extends StatelessWidget {
  CreateDemandPage({Key? key}) : super(key: key);

  final _formKey = GlobalKey<FormState>();
  final TextEditingController titleController = TextEditingController();
  final TextEditingController descriptionController = TextEditingController();
  final TextEditingController departmentController = TextEditingController();
  final TextEditingController benefitsController = TextEditingController();
  final TextEditingController detailsController = TextEditingController();
  final TextEditingController restrictionsController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Criar demanda'),
        backgroundColor: const Color.fromARGB(255, 255, 166, 0),
      ),
      body: Form(
        key: _formKey,
        child: Align(
          alignment: Alignment.center,
          child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              crossAxisAlignment: CrossAxisAlignment.center,
              children: [
                const Text('Título *'),
                Padding(
                  padding:
                      const EdgeInsets.symmetric(horizontal: 16, vertical: 16),
                  child: TextFormField(
                    decoration: const InputDecoration(
                        border: OutlineInputBorder()),
                    controller: titleController,
                    validator: (value) {
                      if (value == null || value.isEmpty) {
                        return 'Por favor, insira um título';
                      }
                      return null;
                    },
                  ),
                ),
                const Text('Descrição'),
                Padding(
                  padding:
                      const EdgeInsets.symmetric(horizontal: 16, vertical: 16),
                  child: TextFormField(
                    decoration: const InputDecoration(
                        border: OutlineInputBorder()),
                    controller: descriptionController,
                    obscureText: true,
                    validator: (value) {
                      if (value == null || value.isEmpty) {
                        return 'Por favor, insira uma descrição';
                      }
                      return null;
                    },
                  ),
                ),
                const Text('Departamento *'),
                Padding(
                  padding:
                      const EdgeInsets.symmetric(horizontal: 16, vertical: 16),
                  child: TextFormField(
                    decoration: const InputDecoration(
                        border: OutlineInputBorder()),
                    controller: descriptionController,
                    obscureText: true,
                    validator: (value) {
                      if (value == null || value.isEmpty) {
                        return 'Por favor, insira um departamento';
                      }
                      return null;
                    },
                  ),
                ),
                const Text('Benefícios *'),
                Padding(
                  padding:
                      const EdgeInsets.symmetric(horizontal: 16, vertical: 16),
                  child: TextFormField(
                    decoration: const InputDecoration(
                        border: OutlineInputBorder()),
                    controller: benefitsController,
                    obscureText: true,
                    validator: (value) {
                      if (value == null || value.isEmpty) {
                        return 'Por favor, insira os benefícios';
                      }
                      return null;
                    },
                  ),
                ),
                const Text('Detalhes *'),
                Padding(
                  padding:
                      const EdgeInsets.symmetric(horizontal: 16, vertical: 16),
                  child: TextFormField(
                    decoration: const InputDecoration(
                        border: OutlineInputBorder()),
                    controller: detailsController,
                    obscureText: true,
                    validator: (value) {
                      if (value == null || value.isEmpty) {
                        return 'Por favor, insira os detalhes';
                      }
                      return null;
                    },
                  ),
                ),
                const Text('Restrições'),
                Padding(
                  padding:
                      const EdgeInsets.symmetric(horizontal: 16, vertical: 16),
                  child: TextFormField(
                    decoration: const InputDecoration(
                        border: OutlineInputBorder()),
                    controller: restrictionsController,
                    obscureText: true,
                  ),
                ),
                Padding(
                  padding:
                      const EdgeInsets.symmetric(horizontal: 16, vertical: 16),
                  child: ElevatedButton(
                    child: const Text('Criar'),
                    onPressed: () {
                      if (_formKey.currentState!.validate()) {
                        // pega a company do usuario logado, e envia para o back
                      } else {
                        ScaffoldMessenger.of(context).showSnackBar(
                          const SnackBar(
                              content:
                                  Text('Por favor, preencha todos os campos')),
                        );
                      }
                    },
                  ),
                ),
              ]),
        ),
      ),
    );
  }
}
