class Address {
  String? id;
  String street;
  int number;
  String neighborhood;
  String city;
  String state;
  String country;
  String? extra;

  Address(
      {this.id,
      required this.street,
      required this.number,
      required this.neighborhood,
      required this.city,
      required this.state,
      required this.country,
      this.extra});

  static Address fromMap(Map<String, dynamic> map) {
    return Address(
        id: map['id'],
        street: map['street'],
        number: map['number'],
        neighborhood: map['neighborhood'],
        city: map['city'],
        state: map['state'],
        country: map['country'],
        extra: map['extra']);
  }
}
