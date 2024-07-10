import 'package:app/address/address_details_page.dart';
import 'package:app/equipments/equipments_page.dart';
import 'package:app/labs/lab.dart';
import 'package:app/person/person_details_page.dart';
import 'package:app/social-medias/social_medias_page.dart';
import 'package:app/softwares/softwares_page.dart';
import 'package:flutter/material.dart';

Lab? lab;

class LabDetailsPage extends StatelessWidget {
  LabDetailsPage({Key? key, required this.labId, required this.isLab})
      : super(key: key);
  final int labId;
  final bool isLab;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Laboratórios > Detalhes'),
        backgroundColor: const Color.fromARGB(255, 255, 166, 0),
      ),
      body: SingleChildScrollView(
          child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 0),
            child: Text(
              lab?.name ?? '',
              style: const TextStyle(fontSize: 24, fontWeight: FontWeight.bold),
            ),
          ),
          const Padding(
            padding: EdgeInsets.symmetric(horizontal: 16, vertical: 16),
            child: Text(
              'Descrição',
              style: TextStyle(fontWeight: FontWeight.bold),
            ),
          ),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 0),
            child: Text(lab?.description ?? ''),
          ),
          const Padding(
            padding: EdgeInsets.symmetric(horizontal: 16, vertical: 16),
            child: Text(
              'Certificados',
              style: TextStyle(fontWeight: FontWeight.bold),
            ),
          ),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 0),
            child: Text(lab?.certificates ?? ''),
          ),
          const Padding(
            padding: EdgeInsets.symmetric(horizontal: 16, vertical: 16),
            child: Text(
              'Fundado em',
              style: TextStyle(fontWeight: FontWeight.bold),
            ),
          ),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 0),
            child: Text(lab?.foundationDate ?? ''),
          ),
          AddressDetailsPage(address: lab?.address, isLab: isLab),
          if (lab != null)
            PersonDetailsPage(
                title: 'Responsável', person: lab!.responsible, isLab: isLab),
          if (lab?.equipments != null)
            EquipmentsPage(equipments: lab?.equipments ?? [], isLab: isLab),
          if (lab?.socialMedias != null)
            SocialMediasPage(
                socialMedias: lab?.socialMedias ?? [], isLab: isLab),
          if (lab?.softwares != null)
            SoftwaresPage(softwares: lab?.softwares ?? [], isLab: isLab)
        ],
      )),
    );
  }
}
