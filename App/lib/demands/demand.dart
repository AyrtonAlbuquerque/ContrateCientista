import 'package:app/labs/lab.dart';

class Demand {
  String? id;
  String title;
  String company;
  String description;
  String department;
  String benefits;
  String details;
  String restrictions;
  String keywords;

  Demand(
      {this.id,
      required this.title,
      required this.company,
      required this.description,
      required this.department,
      required this.benefits,
      required this.details,
      required this.restrictions,
      required this.keywords});

  static Demand fromMap(Map<String, dynamic> map) {
    return Demand(id: map['id'], title: map['title'], company: map['company'], description: map['description'], department: map['department'], benefits: map['benefits'], details: map['details'], restrictions: map['restrictions'], keywords: map['keywords']);
  }
}

class DemandDetail extends Demand {
  List<ElegibleLabs> labs;
  DemandDetail(
      {super.id,
      required super.title,
      required super.company,
      required super.description,
      required super.department,
      required super.benefits,
      required super.details,
      required super.restrictions,
      required super.keywords,
      List<ElegibleLabs>? eligibleLabs}): labs = eligibleLabs ?? [];
    static DemandDetail fromMap(Map<String, dynamic> map) {
      return DemandDetail(id: map['id'], title: map['title'], company: map['company'], description: map['description'], department: map['department'], benefits: map['benefits'], details: map['details'], restrictions: map['restrictions'], keywords: map['keywords'], eligibleLabs: map['labs']);
  }
}
