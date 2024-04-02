import 'package:app/address/address.dart';
import 'package:flutter/material.dart';

class AddressDetailsPage extends StatelessWidget {
  AddressDetailsPage({Key? key, required this.addressId, required this.isLab})
      : super(key: key);
  final String addressId;
  final bool isLab;

  final Address address = Address(
      id: 'ae6f5db2-0e44-4a0f-b60a-bf6956d7604e',
      street: 'Av. Sete de Setembro',
      number: '3165',
      neighborhood: 'Rebouças',
      city: 'Curitiba',
      state: 'Parana',
      country: 'Brasil');

  @override
  Widget build(BuildContext context) {
    return ListView(shrinkWrap: true, children: [
      const Padding(
        padding: EdgeInsets.symmetric(horizontal: 16, vertical: 16),
        child: Text(
          'Endereço',
          style: TextStyle(fontWeight: FontWeight.bold),
        ),
      ),
      Padding(
        padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 0),
        child: Text(
          [
            address.street,
            address.number,
            address.neighborhood,
            address.city,
            address.state,
            address.country
          ].join(', '),
          style: const TextStyle(fontSize: 16),
        ),
      ),
    ]);
  }
}
