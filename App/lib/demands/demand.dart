import 'package:app/labs/lab.dart';

class Demand {
  int? id;
  String title;
  String description;
  String? department;
  String? benefits;
  String? details;
  String? restrictions;
  List<String>? keywords;

  Demand(
      {this.id,
      required this.title,
      required this.description,
      this.department,
      this.benefits,
      this.details,
      this.restrictions,
      this.keywords});

  static Demand fromMap(Map<String, dynamic> map) {
    List<String> keywords = List<String>.from(map['keywords'] as List);

    return Demand(id: map['id'], title: map['title'], description: map['description'], department: map['department'], benefits: map['benefits'], details: map['details'], restrictions: map['restrictions'], keywords: keywords);
  }
}

class DemandDetail extends Demand {
  List<ElegibleLabs> labs;
  DemandDetail(
      {super.id,
      required super.title,
      required super.description,
      required super.department,
      required super.benefits,
      required super.restrictions,
      required super.keywords,
      List<ElegibleLabs>? eligibleLabs}): labs = eligibleLabs ?? [];
    static DemandDetail fromMap(Map<String, dynamic> map) {
      return DemandDetail(id: map['id'], title: map['title'], description: map['description'], department: map['department'], benefits: map['benefits'], restrictions: map['restrictions'], keywords: map['keywords'], eligibleLabs: map['labs']);
  }
}

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

class Match {
  int id;
  double score;
  bool liked;
  MatchDemand demand;

  Match(
      {required this.id,
      required this.score,
      required this.liked,
      required this.demand});

  static Match fromMap(Map<String, dynamic> map) {
    MatchDemand demand = MatchDemand.fromMap(map['demand']);

    return Match(id: map['id'], score: map['score'], liked: map['liked'], demand: demand);
  }
}