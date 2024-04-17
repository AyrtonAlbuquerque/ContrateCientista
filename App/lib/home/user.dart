import 'package:app/companies/company.dart';
import 'package:app/labs/lab.dart';

class User {
  String? id;
  String email;
  Company? company;
  Lab? lab;

  User(
      {this.id,
      required this.email,
      this.company,
      this.lab});

  static User fromMap(Map<String, dynamic> map) {
    return User(
        id: map['id'],
        email: map['email'],
        company: map['company'],
        lab: map['lab']);
  }
}
