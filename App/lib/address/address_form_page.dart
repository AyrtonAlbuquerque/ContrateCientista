import 'package:app/address/address.dart';
import 'package:flutter/material.dart';

class AddressFormPage extends StatelessWidget {
  AddressFormPage({Key? key, required this.address}) : super(key: key);

  final Address address;

  final _formKey = GlobalKey<FormState>();
  final TextEditingController streetController = TextEditingController();
  final TextEditingController numberController = TextEditingController();
  final TextEditingController neighborhoodController = TextEditingController();
  final TextEditingController cityController = TextEditingController();
  final TextEditingController stateController = TextEditingController();
  final TextEditingController countryController = TextEditingController();
  final TextEditingController extraController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    streetController.text = address.street;
    numberController.text = address.number.toString();
    neighborhoodController.text = address.neighborhood;
    cityController.text = address.city;
    stateController.text = address.state;
    countryController.text = address.country;
    extraController.text = address.extra ?? '';
    return Container(
      alignment: Alignment.topLeft,
      child: Column(children: [
        const Row(children: [
          Padding(
              padding: EdgeInsets.symmetric(horizontal: 16, vertical: 16),
              child: Text('Endereço',
                  style: TextStyle(fontWeight: FontWeight.bold),
                  textAlign: TextAlign.start))
        ]),
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
                onChanged: (value) {
                  address.street = value;
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
                  validator: (value) {
                    if (value == null || value.isEmpty) {
                      return 'Por favor, insira o número';
                    }
                    return null;
                  },
                  onChanged: (value) {
                    address.number = int.parse(value);
                  }),
            ),
            const Text('Bairro *'),
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 24, vertical: 8),
              child: TextFormField(
                  decoration:
                      const InputDecoration(border: OutlineInputBorder()),
                  controller: neighborhoodController,
                  validator: (value) {
                    if (value == null || value.isEmpty) {
                      return 'Por favor, insira o bairro';
                    }
                    return null;
                  },
                  onChanged: (value) {
                    address.neighborhood = value;
                  }),
            ),
            const Text('Cidade *'),
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 24, vertical: 8),
              child: TextFormField(
                  decoration:
                      const InputDecoration(border: OutlineInputBorder()),
                  controller: cityController,
                  validator: (value) {
                    if (value == null || value.isEmpty) {
                      return 'Por favor, insira a cidade';
                    }
                    return null;
                  },
                  onChanged: (value) {
                    address.city = value;
                  }),
            ),
            const Text('Estado *'),
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 24, vertical: 8),
              child: TextFormField(
                decoration: const InputDecoration(border: OutlineInputBorder()),
                controller: stateController,
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return 'Por favor, insira o estado';
                  }
                  return null;
                },
                onChanged: (value) {
                  address.state = value;
                },
              ),
            ),
            const Text('País *'),
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 24, vertical: 8),
              child: TextFormField(
                decoration: const InputDecoration(border: OutlineInputBorder()),
                controller: countryController,
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return 'Por favor, insira o país';
                  }
                  return null;
                },
                onChanged: (value) {
                  address.country = value;
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
                  onChanged: (value) {
                    address.extra = value;
                  }),
            ),
          ]),
        )
      ]),
    );
  }
}
