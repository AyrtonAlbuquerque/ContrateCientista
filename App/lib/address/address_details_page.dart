import 'package:app/address/address.dart';
import 'package:flutter/material.dart';

class AddressDetailsPage extends StatelessWidget {
  AddressDetailsPage({Key? key, this.address, required this.isLab})
      : super(key: key);
  final Address? address;
  final bool isLab;

  @override
  Widget build(BuildContext context) {
    return Column(crossAxisAlignment: CrossAxisAlignment.start, children: [
      const Center(
        child: Padding(
        padding: EdgeInsets.symmetric(horizontal: 0, vertical: 16),
        child: Text(
          'Endereço',
          style: TextStyle(fontWeight: FontWeight.bold),
        ),
      )
      ),
      Center(
        child: Text(
          [
            address?.street,
            address?.number,
            address?.neighborhood,
            address?.city,
            address?.state,
            address?.country
          ].join(', '),
          style: const TextStyle(fontSize: 16),
        ),
      ),
    ]);
  }
}
