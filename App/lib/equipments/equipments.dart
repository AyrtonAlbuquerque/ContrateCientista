class Equipment {
  String? id;
  String name;
  String? description;
  String? area;

  Equipment(
      {this.id,
      required this.name,
      this.description,
      this.area});

  static Equipment fromMap(Map<String, dynamic> map) {
    return Equipment(
        id: map['id'],
        name: map['name'],
        description: map['description'],
        area: map['area']);
  }
}
