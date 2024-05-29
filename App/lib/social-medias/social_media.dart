class SocialMedia {
  String? id;
  String? type;
  String link;

  SocialMedia(
      {this.id,
      this.type,
      required this.link});

  static SocialMedia fromMap(Map<String, dynamic> map) {
    return SocialMedia(
        id: map['id'],
        type: map['type'],
        link: map['link']);
  }
}
