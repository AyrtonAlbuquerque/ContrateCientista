import 'package:app/address/address.dart';
import 'package:app/equipments/equipments.dart';
import 'package:app/person/person.dart';
import 'package:app/social-medias/social_media.dart';
import 'package:app/softwares/software.dart';

class Lab {
  String? id;
  String name;
  String code;
  String responsibleId;
  String addressId;
  String description;
  String certificates;
  String foundationDate;
  List<Equipment>? equipments;
  List<SocialMedia>? socialMedias;
  List<Software>? softwares;

  Lab(
      {this.id,
      required this.name,
      required this.code,
      required this.responsibleId,
      required this.addressId,
      required this.description,
      required this.certificates,
      required this.foundationDate,
      this.equipments,
      this.socialMedias,
      this.softwares});

  static Lab fromMap(Map<String, dynamic> map) {
    return Lab(
        id: map['id'],
        name: map['name'],
        code: map['code'],
        responsibleId: map['responsibleId'],
        addressId: map['addressId'],
        description: map['description'],
        certificates: map['certificates'],
        foundationDate: map['foundationDate'],
        equipments: map['equipments'],
        socialMedias: map['socialMedias'],
        softwares: map['softwares']);
  }
}

class ElegibleLabs extends Lab {
  ElegibleLabs(
      {super.id,
      required super.name,
      required super.code,
      required super.responsibleId,
      required super.addressId,
      required super.description,
      required super.certificates,
      required super.foundationDate});
}
