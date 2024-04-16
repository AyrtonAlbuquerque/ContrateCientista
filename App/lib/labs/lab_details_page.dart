import 'package:app/address/address_details_page.dart';
import 'package:app/equipments/equipments.dart';
import 'package:app/equipments/equipments_page.dart';
import 'package:app/labs/lab.dart';
import 'package:app/person/person_details_page.dart';
import 'package:app/social-medias/social_media.dart';
import 'package:app/social-medias/social_medias_page.dart';
import 'package:app/softwares/software.dart';
import 'package:app/softwares/softwares_page.dart';
import 'package:flutter/material.dart';

class LabDetailsPage extends StatelessWidget {
  LabDetailsPage({Key? key, required this.labId, required this.isLab})
      : super(key: key);
  final String labId;
  final bool isLab;

  final Lab lab = Lab(
    id: '9600f5b9-491a-455a-b43c-4552e7655947',
    name: 'Laboratório de Luminescência Estimulada e Dosimetria',
    code: 'LLED',
    responsibleId: '2',
    addressId: '2',
    description:
        'Pesquisa#Ensino: Desenvolvimento de instrumentação e detectores luminescentes para medidas de radiação ionizante',
    certificates: 'CNEN',
    foundationDate: '2013-2018',
    equipments: [Equipment(
      id: '51148a43-0a2c-46be-bb18-90f73798614e',
      name: 'Tribômetro roda de borracha',
      area: 'Area 1',
      description: 'Nunca é demais lembrar o peso e o significado destes problemas, uma vez que o consenso sobre a necessidade de qualificação prepara-nos para enfrentar situações atípicas decorrentes do levantamento das variáveis envolvidas.'
      )],
    socialMedias: [SocialMedia(type: 'Instagram', link: 'https://www.instagram.com/')],
    softwares: [Software(name: 'Matlab', description: 'Todavia, a consolidação das estruturas afeta positivamente a correta previsão do fluxo de informações.', area: 'Area 2')]
  );

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Laboratórios > Detalhes'),
        backgroundColor: const Color.fromARGB(255, 255, 166, 0),
      ),
      body: Center(
        child: ListView(shrinkWrap: true, children: [
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 0),
            child: Text(
              lab.name,
              style: const TextStyle(fontSize: 24, fontWeight: FontWeight.bold),
            ),
          ),
          const Padding(
            padding: EdgeInsets.symmetric(horizontal: 16, vertical: 16),
            child: Text(
              'Código',
              style: TextStyle(fontWeight: FontWeight.bold),
            ),
          ),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 0),
            child: Text(lab.code),
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
            child: Text(lab.description),
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
            child: Text(lab.certificates),
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
            child: Text(lab.foundationDate),
          ),
          AddressDetailsPage(addressId: lab.addressId, isLab: isLab),
          PersonDetailsPage(
              title: 'Responsável', personId: lab.responsibleId, isLab: isLab),
          if (lab.equipments != null) ...[EquipmentsPage(equipments: lab.equipments ?? [], isLab: isLab)],
          if (lab.socialMedias != null) ...[SocialMediasPage(socialMedias: lab.socialMedias ?? [], isLab: isLab)],
          if (lab.softwares != null) ...[SoftwaresPage(softwares: lab.softwares ?? [], isLab: isLab)]
        ]),
      ),
    );
  }
}
