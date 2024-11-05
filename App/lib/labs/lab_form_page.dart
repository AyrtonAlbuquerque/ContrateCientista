import 'package:app/address/address.dart';
import 'package:app/address/address_form_page.dart';
import 'package:app/equipments/equipments.dart';
import 'package:app/equipments/equipments_page.dart';
import 'package:app/home/lab_home_page.dart';
import 'package:app/labs/lab.dart';
import 'package:app/labs/labs_service.dart';
import 'package:app/login/login_page.dart';
import 'package:app/person/person.dart';
import 'package:app/person/person_form_page.dart';
import 'package:app/social-medias/social_media.dart';
import 'package:app/social-medias/social_medias_page.dart';
import 'package:app/softwares/software.dart';
import 'package:app/softwares/softwares_page.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';

var responsible = Person(name: '', department: '', email: '');
var address = Address(
    street: '', number: 0, neighborhood: '', city: '', state: '', country: '');
List<SocialMedia> socialMedias = [];
List<Software> softwares = [];
List<Equipment> equipments = [];

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
  final TextEditingController keywordsController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    if (lab != null) {
      nameController.text = lab!.name;
      descriptionController.text = lab!.description;
      codeController.text = lab!.code;
      certificatesController.text = lab!.certificates ?? '';
      foundationDateController.text = lab!.foundationDate;
      keywordsController.text = lab?.keywords.join(', ') ?? '';
      responsible = lab!.responsible;
      address = lab!.address;
      socialMedias = lab!.socialMedias ?? [];
      softwares = lab!.softwares ?? [];
      equipments = lab!.equipments ?? [];
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
          const Text('Palavras-chave (separadas por vírgula) *'),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 16),
            child: TextFormField(
              decoration: const InputDecoration(border: OutlineInputBorder()),
              controller: keywordsController,
              validator: (value) {
                if (value == null || value.isEmpty) {
                  return 'Por favor, insira as palavras-chave';
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
              onPressed: () async {
                if (_formKey.currentState!.validate()) {
                  List<String> keywords = keywordsController.text.split(', ');
                  if (lab != null) {
                    await ApiLabService.updateLab(
                        nameController.text,
                        codeController.text,
                        descriptionController.text,
                        certificatesController.text,
                        foundationDateController.text,
                        keywords,
                        responsible,
                        address,
                        socialMedias,
                        softwares,
                        equipments);
                    Navigator.push(
                      context,
                      MaterialPageRoute(builder: (context) => LabHomePage()),
                    );
                  } else {
                    await ApiLabService.createLab(
                        login,
                        password,
                        nameController.text,
                        codeController.text,
                        descriptionController.text,
                        certificatesController.text,
                        foundationDateController.text,
                        keywords,
                        responsible,
                        address,
                        socialMedias,
                        softwares,
                        equipments);
                    // Navigator.push(
                    //   context,
                    //   MaterialPageRoute(
                    //       builder: (context) => LoginPage(title: 'Login')),
                    // );
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
