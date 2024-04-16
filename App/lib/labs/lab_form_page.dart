import 'package:app/address/address_form_page.dart';
import 'package:app/equipments/equipment_form_page.dart';
import 'package:app/person/person_form_page.dart';
import 'package:app/social-medias/social_media_form_page.dart';
import 'package:app/softwares/software_form_page.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';

class LabFormPage extends StatelessWidget {
  LabFormPage({Key? key, this.login, this.password, this.id}) : super(key: key);

  final String? login;
  final String? password;
  final String? id;

  final _formKey = GlobalKey<FormState>();
  final TextEditingController nameController = TextEditingController();
  final TextEditingController codeController = TextEditingController();
  final TextEditingController descriptionController = TextEditingController();
  final TextEditingController certificatesController = TextEditingController();
  final TextEditingController foundationDateController =
      TextEditingController();

  final TextEditingController personNameController = TextEditingController();
  final TextEditingController personDepartmentController =
      TextEditingController();
  final TextEditingController personEmailController = TextEditingController();
  final TextEditingController personPhoneController = TextEditingController();

  final TextEditingController streetController = TextEditingController();
  final TextEditingController numberController = TextEditingController();
  final TextEditingController neighborhoodController = TextEditingController();
  final TextEditingController cityController = TextEditingController();
  final TextEditingController stateController = TextEditingController();
  final TextEditingController countryController = TextEditingController();
  final TextEditingController extraController = TextEditingController();

  final TextEditingController labNameController = TextEditingController();
  final TextEditingController labDescriptionController =
      TextEditingController();
  final TextEditingController labAreaController = TextEditingController();

  final TextEditingController softwareNameController = TextEditingController();
  final TextEditingController softwareDescriptionController =
      TextEditingController();
  final TextEditingController softwareAreaController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(id != null ? 'Laboratório' : 'Criar conta de laboratório'),
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
          const Text('Código'),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 16),
            child: TextFormField(
                decoration: const InputDecoration(border: OutlineInputBorder()),
                controller: codeController),
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
          PersonFormPage(
              nameController: personNameController,
              departmentController: personDepartmentController,
              emailController: personEmailController,
              phoneController: personPhoneController),
          AddressFormPage(streetController: streetController, numberController: numberController, neighborhoodController: neighborhoodController, cityController: cityController, stateController: stateController, countryController: countryController, extraController: extraController),
          // EquipmentFormPage(nameController: labNameController, descriptionController: labDescriptionController, areaController: labAreaController),
          // SocialMediaFormPage(typeController: typeController, linkController: linkController),
          // SoftwareFormPage(nameController: softwareNameController, descriptionController: softwareDescriptionController, areaController: softwareAreaController),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 16),
            child: ElevatedButton(
              child: const Text('Salvar'),
              onPressed: () {
                if (_formKey.currentState!.validate()) {
                  if (id != null) {
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
