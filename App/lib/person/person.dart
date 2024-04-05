class Person {
  String? id;
  String name;
  String department;
  String? phone;
  String? email;

  Person(
      {this.id,
      required this.name,
      required this.department,
      this.phone,
      this.email});

  static Person fromMap(Map<String, dynamic> map) {
    return Person(id: map['id'], name: map['name'], department: map['department'], phone: map['phone'], email: map['email']);
  }
}