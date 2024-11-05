import 'package:app/match/match.dart';
import 'package:app/match/match_service.dart';
import 'package:flutter/material.dart';

Match? match;

class MatchLabDetailsPage extends StatefulWidget {
  MatchLabDetailsPage({required this.matchId});
  final int? matchId;

  @override
  State<StatefulWidget> createState() =>
      MatchLabDetailsPageState(matchId: matchId);
}

class MatchLabDetailsPageState extends State {
  MatchLabDetailsPageState({required this.matchId});
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
            'Descrição',
            style: TextStyle(fontWeight: FontWeight.bold),
          ),
        ),
        Padding(
          padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 0),
          child: Text(match?.demand.description ?? ''),
        ),
        Row(
          children: [
            Column(
              children: [
                const Padding(
                  padding: EdgeInsets.symmetric(horizontal: 16, vertical: 16),
                  child: Text(
                    'Departamento',
                    style: TextStyle(fontWeight: FontWeight.bold),
                  ),
                ),
                Padding(
                  padding:
                      const EdgeInsets.symmetric(horizontal: 16, vertical: 0),
                  child: Text(match?.demand.department ?? ''),
                ),
              ],
            )
          ],
        ),
        const Padding(
          padding: EdgeInsets.symmetric(horizontal: 16, vertical: 16),
          child: Text(
            'Benfícios',
            style: TextStyle(fontWeight: FontWeight.bold),
          ),
        ),
        Padding(
          padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 0),
          child: Text(match?.demand.benefits ?? ''),
        ),
        const Padding(
          padding: EdgeInsets.symmetric(horizontal: 16, vertical: 16),
          child: Text(
            'Detalhes',
            style: TextStyle(fontWeight: FontWeight.bold),
          ),
        ),
        Padding(
          padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 0),
          child: Text(match?.demand.details ?? ''),
        ),
        const Padding(
          padding: EdgeInsets.symmetric(horizontal: 16, vertical: 16),
          child: Text(
            'Restrições',
            style: TextStyle(fontWeight: FontWeight.bold),
          ),
        ),
        Padding(
          padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 0),
          child: Text(match?.demand.restrictions ?? ''),
        ),
        const Padding(
          padding: EdgeInsets.symmetric(horizontal: 16, vertical: 16),
          child: Text(
            'Palavras-chave',
            style: TextStyle(fontWeight: FontWeight.bold),
          ),
        ),
        Padding(
          padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 0),
          child: Text(match?.demand.keywords?.join(', ') ?? ''),
        ),
        const SizedBox(height: 50),
      ])),
    );
  }
}
