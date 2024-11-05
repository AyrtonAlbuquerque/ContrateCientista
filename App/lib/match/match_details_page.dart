import 'package:app/address/address_details_page.dart';
import 'package:app/equipments/equipments_page.dart';
import 'package:app/match/match_service.dart';
import 'package:app/match/match.dart';
import 'package:app/person/person_details_page.dart';
import 'package:app/social-medias/social_medias_page.dart';
import 'package:app/softwares/softwares_page.dart';
import 'package:flutter/material.dart';

Match? match;

class MatchDetailsPage extends StatefulWidget {
  MatchDetailsPage({required this.matchId});
  final int? matchId;

  @override
  State<StatefulWidget> createState() =>
      MatchDetailsPageState(matchId: matchId);
}

class MatchDetailsPageState extends State {
  MatchDetailsPageState({required this.matchId});
  final int? matchId;

  @override
  void initState() {
    super.initState();
    getPostsFromApi();
  }

  Future<void> getPostsFromApi() async {
    try {
      match = (await ApiMatchService.getMatchById(matchId))!;
      // Update the state to rebuild the UI with the new data
      setState(() {});
    } catch (e) {
      debugPrint('Exception: $e');
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Match > Detalhes'),
        backgroundColor: const Color.fromARGB(255, 255, 166, 0),
      ),
      body: SingleChildScrollView(
          child: Column(children: [
        Padding(
          padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 0),
          child: Text(
            match?.demand.title ?? '',
            style: const TextStyle(fontSize: 24, fontWeight: FontWeight.bold),
          ),
        ),
        const Padding(
          padding: EdgeInsets.symmetric(horizontal: 16, vertical: 16),
          child: Text(
            'Laboratório',
            style: TextStyle(fontWeight: FontWeight.bold),
          ),
        ),
        Padding(
          padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 0),
          child: Text(match?.laboratory.name ?? ''),
        ),
          const Padding(
            padding: EdgeInsets.symmetric(horizontal: 16, vertical: 16),
            child: Text(
              'Descrição',
              style: TextStyle(fontWeight: FontWeight.bold),
            ),
          ),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 0),
            child: Text(match?.laboratory.description ?? ''),
          ),
          const Padding(
            padding: EdgeInsets.symmetric(horizontal: 16, vertical: 16),
            child: Text(
              'Certificados',
              style: TextStyle(fontWeight: FontWeight.bold),
            ),
          ),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 0),
            child: Text(match?.laboratory.certificates ?? ''),
          ),
          const Padding(
            padding: EdgeInsets.symmetric(horizontal: 16, vertical: 16),
            child: Text(
              'Fundado em',
              style: TextStyle(fontWeight: FontWeight.bold),
            ),
          ),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 0),
            child: Text(match?.laboratory.foundationDate ?? ''),
          ),
          AddressDetailsPage(address: match?.laboratory.address, isLab: false),
          if (match != null && match!.laboratory.responsible != null)
            PersonDetailsPage(
                title: 'Responsável', person: match!.laboratory.responsible!, isLab: false),
          if (match?.laboratory.equipments != null)
            EquipmentsPage(equipments: match?.laboratory.equipments ?? [], isLab: false),
          if (match?.laboratory.socialMedias != null)
            SocialMediasPage(
                socialMedias: match?.laboratory.socialMedias ?? [], isLab: false),
          if (match?.laboratory.softwares != null)
            SoftwaresPage(softwares: match?.laboratory.softwares ?? [], isLab: false)
      ])),
    );
  }
}
