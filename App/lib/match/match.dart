import 'package:app/address/address.dart';
import 'package:app/equipments/equipments.dart';
import 'package:app/person/person.dart';
import 'package:app/social-medias/social_media.dart';
import 'package:app/softwares/software.dart';

class MatchDemand {
  int id;
  String title;
  String? description;
  String? department;
  String? benefits;
  String? details;
  String? restrictions;
  List<String>? keywords;

  MatchDemand(
      {required this.id,
      required this.title,
      this.description,
      this.department,
      this.benefits,
      this.restrictions,
      this.keywords});

  static MatchDemand fromMap(Map<String, dynamic> map) {
    List<String>? keywords;
    if (map['keywords'] != null) {
      keywords = List<String>.from(map['keywords'] as List);
    }
    return MatchDemand(id: map['id'], title: map['title'], description: map['description'], department: map['department'], benefits: map['benefits'], restrictions: map['restrictions'], keywords: keywords);
  }
}

class MatchLab {
  int? id;
  String name;
  String? description;
  String? code;
  String? certificates;
  String? foundationDate;
  Person? responsible;
  Address? address;
  List<Equipment>? equipments;
  List<SocialMedia>? socialMedias;
  List<Software>? softwares;

  MatchLab(
      {this.id,
      required this.name,
      this.description,
      this.certificates,
      this.code,
      this.foundationDate,
      this.responsible,
      this.address,
      this.equipments,
      this.socialMedias,
      this.softwares});

  static MatchLab fromMap(Map<String, dynamic> map) {
    List<Equipment> equipments = [];
    if (map['equipments'] != null) {
      print('equipments');
      for (final item in map['equipments']) {
        equipments.add(Equipment.fromMap(item));
      }
    }
    List<SocialMedia> socialMedias = [];
    if (map['socialMedias'] != null) {
      print('socialMedias');
      for (final item in map['socialMedias']) {
        socialMedias.add(SocialMedia.fromMap(item));
      }
    }
    List<Software> softwares = [];
    if (map['softwares'] != null) {
      for (final item in map['softwares']) {
        softwares.add(Software.fromMap(item));
      }
    }
    Person? responsible;
    if (map['responsible'] != null) {
      responsible = Person.fromMap(map['responsible']);
    }
    Address? address;
    if (map['responsible'] != null) {
      address = Address.fromMap(map['address']);
    }
    return MatchLab(
        id: map['id'],
        name: map['name'],
        description: map['description'],
        code: map['code'],
        certificates: map['certificates'],
        foundationDate: map['foundationDate'],
        responsible: responsible,
        address: address,
        equipments: equipments,
        socialMedias: socialMedias,
        softwares: softwares);
  }
}

class Match {
  int id;
  double score;
  bool liked;
  MatchDemand demand;
  MatchLab laboratory;

  Match(
      {required this.id,
      required this.score,
      required this.liked,
      required this.demand,
      required this.laboratory});

  static Match fromMap(Map<String, dynamic> map) {
    MatchDemand demand = MatchDemand.fromMap(map['demand']);
    MatchLab laboratory = MatchLab.fromMap(map['laboratory']);

    return Match(id: map['id'], score: map['score'], liked: map['liked'], demand: demand, laboratory: laboratory);
  }
}