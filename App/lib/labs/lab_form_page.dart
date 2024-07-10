import 'package:app/address/address.dart';
import 'package:app/address/address_form_page.dart';
import 'package:app/equipments/equipments_page.dart';
import 'package:app/labs/lab.dart';
import 'package:app/labs/labs_service.dart';
import 'package:app/login/login_page.dart';
import 'package:app/person/person.dart';
import 'package:app/person/person_form_page.dart';
import 'package:app/social-medias/social_media.dart';
import 'package:app/social-medias/social_medias_page.dart';
import 'package:app/softwares/softwares_page.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';

var responsible = Person(name: '', departament: '', email: '');
var address = Address(
    street: '', number: 0, neighborhood: '', city: '', state: '', country: '');
var socialMedias = [SocialMedia(link: '')];
//softwares
//equipments

class LabFormPage extends StatelessWidget {
  LabFormPage({Key? key, this.login, this.password, this.lab})
      : super(key: key);

  final String? login;
  final String? password;
  final Lab? lab;

  final _formKey = GlobalKey<FormState>();
  final TextEditingController nameController = TextEditingController();
  final TextEditingController codeController = TextEditingController();
  final TextEditingController descriptionController = TextEditingController();
  final TextEditingController certificatesController = TextEditingController();
  final TextEditingController foundationDateController =
      TextEditingController();

  @override
  Widget build(BuildContext context) {
    if (lab != null) {
      nameController.text = lab!.name;
      descriptionController.text = lab!.description;
      codeController.text = lab!.code;
      certificatesController.text = lab!.certificates ?? '';
      foundationDateController.text = lab!.foundationDate;
      responsible = lab!.responsible;
      address = lab!.address;
      socialMedias = lab!.socialMedias ?? [];
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
          const Text('Código *'),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 16),
            child: TextFormField(
              decoration: const InputDecoration(border: OutlineInputBorder()),
              controller: codeController,
              validator: (value) {
                if (value == null || value.isEmpty) {
                  return 'Por favor, insira um código';
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
              equipments: lab?.equipments ?? [],
              isLab: true,
              create: lab == null),
          SoftwaresPage(
              softwares: lab?.softwares ?? [],
              isLab: true,
              create: lab == null),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 16),
            child: ElevatedButton(
              child: const Text('Salvar'),
              onPressed: () {
                if (_formKey.currentState!.validate()) {
                  if (lab != null) {
                    // TODO: atualizar lab
                  } else {
                    ApiLabService.createLab(
                        nameController.text,
                        codeController.text,
                        descriptionController.text,
                        certificatesController.text,
                        foundationDateController.text,
                        responsible);
                    Navigator.push(
                      context,
                      MaterialPageRoute(
                          builder: (context) => LoginPage(title: 'Login')),
                    );
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
