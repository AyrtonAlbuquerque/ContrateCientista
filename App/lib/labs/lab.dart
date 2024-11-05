import 'package:app/address/address.dart';
import 'package:app/equipments/equipments.dart';
import 'package:app/person/person.dart';
import 'package:app/social-medias/social_media.dart';
import 'package:app/softwares/software.dart';

class Lab {
  int? id;
  String name;
  String description;
  String code;
  String? certificates;
  List<String> keywords;
  String foundationDate;
  Person responsible;
  Address address;
  List<Equipment>? equipments;
  List<SocialMedia>? socialMedias;
  List<Software>? softwares;

  Lab(
      {this.id,
      required this.name,
      required this.description,
      this.certificates,
      required this.code,
      required this.keywords,
      required this.foundationDate,
      required this.responsible,
      required this.address,
      this.equipments,
      this.socialMedias,
      this.softwares});

  static Lab fromMap(Map<String, dynamic> map) {
    List<String> keywords = List<String>.from(map['keywords'] as List);
    List<Equipment> equipments = [];
    for (final item in map['equipments']) {
      equipments.add(Equipment.fromMap(item));
    }
    List<SocialMedia> socialMedias = [];
    for (final item in map['socialMedias']) {
      socialMedias.add(SocialMedia.fromMap(item));
    }
    List<Software> softwares = [];
    for (final item in map['softwares']) {
      softwares.add(Software.fromMap(item));
    }
    return Lab(
        id: map['id'],
        name: map['name'],
        description: map['description'],
        code: map['code'],
        certificates: map['certificates'],
        keywords: keywords,
        foundationDate: map['foundationDate'],
        responsible: Person.fromMap(map['responsible']),
        address: Address.fromMap(map['address']),
        equipments: equipments,
        socialMedias: socialMedias,
        softwares: softwares);
  }
}

class ElegibleLabs extends Lab {
  double match;
  ElegibleLabs(
      {super.id,
      required super.name,
      required super.description,
      required super.code,
      required super.certificates,
      required super.keywords,
      required super.foundationDate,
      required this.match,
      required super.responsible,
      required super.address,
      super.equipments,
      super.socialMedias,
      super.softwares});

  static ElegibleLabs fromMap(Map<String, dynamic> map) {
    return ElegibleLabs(
        id: map['id'],
        name: map['name'],
        description: map['description'],
        code: map['code'],
        certificates: map['certificates'],
        keywords: map['keywords'],
        foundationDate: map['foundationDate'],
        responsible: map['responsible'],
        address: map['address'],
        match: map['match'],
        equipments: map['equipments'],
        socialMedias: map['socialMedias'],
        softwares: map['softwares']);
  }
}
