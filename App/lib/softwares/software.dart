class Software {
  String? id;
  String name;
  String description;
  String area;

  Software(
      {this.id,
      required this.name,
      required this.description,
      required this.area});

  static Software fromMap(Map<String, dynamic> map) {
    return Software(
        id: map['id'],
        name: map['name'],
        description: map['description'],
        area: map['area']);
  }
}
