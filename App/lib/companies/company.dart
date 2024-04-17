class Company {
  String? id;
  String name;
  String cnpj;
  String email;
  String description;

  Company(
      {this.id,
      required this.name,
      required this.cnpj,
      required this.email,
      required this.description});

  static Company fromMap(Map<String, dynamic> map) {
    return Company(
        id: map['id'],
        name: map['name'],
        cnpj: map['cnpj'],
        email: map['email'],
        description: map['description']);
  }
}
