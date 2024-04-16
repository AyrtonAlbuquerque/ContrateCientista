import 'package:app/social-medias/social_media.dart';
import 'package:flutter/material.dart';
import 'package:url_launcher/url_launcher.dart';

class SocialMediasPage extends StatelessWidget {
  SocialMediasPage({Key? key, required this.socialMedias, required this.isLab})
      : super(key: key);
  final List<SocialMedia> socialMedias;
  final bool isLab;

  @override
  Widget build(BuildContext context) {
    return SizedBox(
        height: 200,
        child: ListView(
          children: [
            const Padding(
                padding: EdgeInsets.only(left: 16, top: 16),
                child: Text('Redes sociais',
                    style: TextStyle(fontWeight: FontWeight.bold))),
            ...socialMedias
                .map(
                  (e) => ListTile(
                      title: InkWell(
                    child: Padding(
                      padding: const EdgeInsets.all(16.0),
                      child: Text(
                        e.type,
                        style: const TextStyle(
                          // color: Colors.blue,
                          decoration: TextDecoration.underline,
                        ),
                      ),
                    ),
                    onTap: () => launchUrlString(e.link),
                  )),
                )
                .toList(),
          ],
        ));
  }

  launchUrlString(url) async {
    Uri _url = Uri.parse(url);
    await launchUrl(_url);
  }
}
