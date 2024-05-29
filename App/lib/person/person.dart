class Person {
  String? id;
  String name;
  String departament;
  String? phone;
  String email;

  Person(
      {this.id,
      required this.name,
      required this.departament,
      this.phone,
      required this.email});

  static Person fromMap(Map<String, dynamic> map) {
    return Person(id: map['id'], name: map['name'], departament: map['departament'], phone: map['phone'], email: map['email']);
  }
}