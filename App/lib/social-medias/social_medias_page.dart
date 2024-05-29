import 'package:app/social-medias/social_media.dart';
import 'package:app/social-medias/social_media_form_page.dart';
import 'package:flutter/material.dart';
import 'package:url_launcher/url_launcher.dart';

class SocialMediasPage extends StatefulWidget {
  final List<SocialMedia> socialMedias;
  final bool isLab;
  final bool create;
  const SocialMediasPage(
      {Key? key,
      required this.socialMedias,
      required this.isLab,
      this.create = false});
  @override
  State<SocialMediasPage> createState() => _SocialMediasPageState();
}

class _SocialMediasPageState extends State<SocialMediasPage> {
  @override
  Widget build(BuildContext context) {
    return ListView(
      shrinkWrap: true,
      children: [
        Row(
          children: [
            const Padding(
              padding: EdgeInsets.symmetric(horizontal: 16, vertical: 16),
              child: Text('Redes Sociais',
                  style: TextStyle(fontWeight: FontWeight.bold)),
            ),
            if (widget.isLab)
              IconButton(
                icon: const Icon(Icons.add_circle_outline),
                onPressed: () async {
                  TextEditingController typeController =
                      TextEditingController();
                  TextEditingController linkController =
                      TextEditingController();
                  final res = await showModalBottomSheet(
                    context: context,
                    builder: (BuildContext context) {
                      return SocialMediaFormPage(
                          typeController: typeController,
                          linkController: linkController);
                    },
                  );
                  if (res != null && res) {
                    SocialMedia socialMedia = SocialMedia.fromMap({
                      'type': typeController.text,
                      'link': linkController.text
                    });
                    if (!widget.create) {
                      // TODO: create new social media
                    }
                    setState(() {
                      widget.socialMedias.add(socialMedia);
                    });
                  }
                },
              )
          ],
        ),
        ...widget.socialMedias
            .map(
              (e) => Row(children: [
                InkWell(
                  child: Padding(
                    padding: const EdgeInsets.all(16.0),
                    child: Text(
                      e.type ?? '',
                      style: const TextStyle(
                        decoration: TextDecoration.underline,
                      ),
                    ),
                  ),
                  onTap: () => launchUrlString(e.link),
                ),
                if (widget.isLab) ...[
                  Spacer(),
                  IconButton(
                    icon: const Icon(Icons.edit_outlined),
                    onPressed: () async {
                      TextEditingController typeController =
                          TextEditingController(text: e.type);
                      TextEditingController linkController =
                          TextEditingController(text: e.link);
                      final res = await showModalBottomSheet(
                        context: context,
                        builder: (BuildContext context) {
                          return SocialMediaFormPage(
                              typeController: typeController,
                              linkController: linkController);
                        },
                      );
                      if (res != null && res) {
                        SocialMedia socialMedia = SocialMedia.fromMap({
                          'type': typeController.text,
                          'link': linkController.text
                        });
                        if (!widget.create) {
                          // TODO: create new social media
                        }
                        setState(() {
                          e = socialMedia; // TODO: fix edit
                        });
                      }
                    },
                  ),
                  IconButton(
                    icon: const Icon(Icons.delete_outline),
                    onPressed: () {
                      if (!widget.create) {
                        // TODO: remove social media
                      }
                      setState(() {
                        widget.socialMedias.remove(e);
                      });
                    },
                  )
                ]
              ]),
            )
            .toList(),
      ],
    );
  }

  launchUrlString(url) async {
    Uri _url = Uri.parse(url);
    await launchUrl(_url);
  }
}
