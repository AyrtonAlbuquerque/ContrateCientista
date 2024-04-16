import 'package:flutter/material.dart';

class AddressFormPage extends StatelessWidget {
  AddressFormPage(
      {Key? key,
      required this.streetController,
      required this.numberController,
      required this.neighborhoodController,
      required this.cityController,
      required this.stateController,
      required this.countryController,
      required this.extraController})
      : super(key: key);

  final _formKey = GlobalKey<FormState>();
  final TextEditingController streetController;
  final TextEditingController numberController;
  final TextEditingController neighborhoodController;
  final TextEditingController cityController;
  final TextEditingController stateController;
  final TextEditingController countryController;
  final TextEditingController extraController;

  @override
  Widget build(BuildContext context) {
    return Container(
      alignment: Alignment.topLeft,
      child: Column(children: [
        const Padding(
            padding: EdgeInsets.only(top: 12, bottom: 12),
            child: Text('Endereço', style: TextStyle(fontWeight: FontWeight.bold))),
        Form(
          key: _formKey,
          child: Column(mainAxisAlignment: MainAxisAlignment.center, children: [
            const Text('Rua *'),
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 24, vertical: 8),
              child: TextFormField(
                decoration: const InputDecoration(border: OutlineInputBorder()),
                controller: streetController,
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return 'Por favor, insira a rua';
                  }
                  return null;
                },
              ),
            ),
            const Text('Numero *'),
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 24, vertical: 8),
              child: TextFormField(
                  decoration:
                      const InputDecoration(border: OutlineInputBorder()),
                  controller: numberController,
                  obscureText: true,
                  validator: (value) {
                    if (value == null || value.isEmpty) {
                      return 'Por favor, insira o número';
                    }
                    return null;
                  }),
            ),
            const Text('Bairro *'),
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 24, vertical: 8),
              child: TextFormField(
                  decoration:
                      const InputDecoration(border: OutlineInputBorder()),
                  controller: neighborhoodController,
                  obscureText: true,
                  validator: (value) {
                    if (value == null || value.isEmpty) {
                      return 'Por favor, insira o bairro';
                    }
                    return null;
                  }),
            ),
            const Text('Cidade *'),
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 24, vertical: 8),
              child: TextFormField(
                  decoration:
                      const InputDecoration(border: OutlineInputBorder()),
                  controller: cityController,
                  obscureText: true,
                  validator: (value) {
                    if (value == null || value.isEmpty) {
                      return 'Por favor, insira a cidade';
                    }
                    return null;
                  }),
            ),
            const Text('Estado *'),
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 24, vertical: 8),
              child: TextFormField(
                decoration: const InputDecoration(border: OutlineInputBorder()),
                controller: stateController,
                obscureText: true,
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return 'Por favor, insira o estado';
                  }
                  return null;
                },
              ),
            ),
            const Text('País *'),
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 24, vertical: 8),
              child: TextFormField(
                decoration: const InputDecoration(border: OutlineInputBorder()),
                controller: countryController,
                obscureText: true,
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return 'Por favor, insira o país';
                  }
                  return null;
                },
              ),
            ),
            const Text('Complemento'),
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 24, vertical: 8),
              child: TextFormField(
                  decoration:
                      const InputDecoration(border: OutlineInputBorder()),
                  controller: extraController,
                  obscureText: true),
            ),
          ]),
        )
      ]),
    );
  }
}
