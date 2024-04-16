import 'package:flutter/material.dart';

class SocialMediaFormPage extends StatelessWidget {
  SocialMediaFormPage(
      {Key? key,
      required this.typeController,
      required this.linkController})
      : super(key: key);

  final _formKey = GlobalKey<FormState>();
  final TextEditingController typeController;
  final TextEditingController linkController;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Form(
        key: _formKey,
        child: Column(mainAxisAlignment: MainAxisAlignment.center, children: [
          const Text('Tipo *'),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 16),
            child: TextFormField(
              decoration: const InputDecoration(border: OutlineInputBorder()),
              controller: typeController,
              validator: (value) {
                if (value == null || value.isEmpty) {
                  return 'Por favor, insira um tipo';
                }
                return null;
              },
            ),
          ),
          const Text('Link *'),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 16),
            child: TextFormField(
                decoration: const InputDecoration(border: OutlineInputBorder()),
                controller: linkController,
              validator: (value) {
                if (value == null || value.isEmpty) {
                  return 'Por favor, insira um tipo';
                }
                return null;
              },),
          )
        ]),
      ),
    );
  }
}
