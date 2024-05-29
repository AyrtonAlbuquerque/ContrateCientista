import 'package:app/address/address.dart';
import 'package:app/address/address_form_page.dart';
import 'package:app/equipments/equipments.dart';
import 'package:app/equipments/equipments_page.dart';
import 'package:app/labs/lab.dart';
import 'package:app/person/person.dart';
import 'package:app/person/person_form_page.dart';
import 'package:app/social-medias/social_media.dart';
import 'package:app/social-medias/social_medias_page.dart';
import 'package:app/softwares/software.dart';
import 'package:app/softwares/softwares_page.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';

class LabFormPage extends StatelessWidget {
  LabFormPage({Key? key, this.login, this.password, this.lab})
      : super(key: key);

  final String? login;
  final String? password;
  final Lab? lab;

  final _formKey = GlobalKey<FormState>();
  final TextEditingController nameController = TextEditingController();
  final TextEditingController descriptionController = TextEditingController();
  final TextEditingController certificatesController = TextEditingController();
  final TextEditingController foundationDateController =
      TextEditingController();

  Person? responsible;
  Address? address;
  List<Equipment> equipments = [];
  List<SocialMedia> socialMedias = [];
  List<Software> softwares = [];

  @override
  Widget build(BuildContext context) {
    if (lab != null) {
      nameController.text = lab!.name;
      descriptionController.text = lab!.description;
      certificatesController.text = lab!.certificates ?? '';
      foundationDateController.text = lab!.foundationDate;
      // TODO: busca address
      address = Address(
          id: 'ae6f5db2-0e44-4a0f-b60a-bf6956d7604e',
          street: 'Av. Sete de Setembro',
          number: 3165,
          neighborhood: 'Rebouças',
          city: 'Curitiba',
          state: 'Parana',
          country: 'Brasil');
      // TODO: busca responsavel
      responsible = Person(
          id: '6f344ab8-956b-4604-8697-54550a09fabf',
          name: 'Walmor Cardoso Godoi',
          departament: 'DAFIS',
          email: 'walmorgodoi@utfpr.edu.br',
          phone: '');
    }
    return Scaffold(
      appBar: AppBar(
        title: Text(lab != null ? 'Laboratório' : 'Criar conta de laboratório'),
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
          const Text('Descrição'),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 16),
            child: TextFormField(
                decoration: const InputDecoration(border: OutlineInputBorder()),
                controller: descriptionController),
          ),
          const Text('Certificados'),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 16),
            child: TextFormField(
                decoration: const InputDecoration(border: OutlineInputBorder()),
                controller: certificatesController),
          ),
          const Text('Data de fundação *'),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 16),
            child: TextFormField(
              decoration: const InputDecoration(border: OutlineInputBorder()),
              controller: foundationDateController,
              onTap: () async {
                DateTime? date;
                FocusScope.of(context).requestFocus(new FocusNode());
                date = await showDatePicker(
                    context: context,
                    firstDate: DateTime(1900),
                    lastDate: DateTime.now());
                foundationDateController.text =
                    date != null ? DateFormat('dd/MM/yyyy').format(date) : '';
              },
              validator: (value) {
                if (value == null || value.isEmpty) {
                  return 'Por favor, insira uma data de fundação';
                }
                return null;
              },
            ),
          ),
          PersonFormPage(person: responsible),
          AddressFormPage(address: address),
          SocialMediasPage(
              socialMedias: socialMedias, isLab: true, create: lab == null),
          EquipmentsPage(
              equipments: equipments, isLab: true, create: lab == null),
          SoftwaresPage(softwares: softwares, isLab: true, create: lab == null),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 16),
            child: ElevatedButton(
              child: const Text('Salvar'),
              onPressed: () {
                if (_formKey.currentState!.validate()) {
                  if (lab != null) {
                    // TODO: atualizar lab
                  } else {
                    // TODO: criar lab
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
