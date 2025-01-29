import 'package:app/labs/lab.dart';
import 'package:app/labs/lab_form_page.dart';
import 'package:app/labs/labs_service.dart';
import 'package:app/match/match_page.dart';
import 'package:flutter/material.dart';

class LabHomePage extends StatefulWidget {
  LabHomePage();

  @override
  State<StatefulWidget> createState() => LabHomePageState();
}

class LabHomePageState extends State {
  LabHomePageState();

  Lab? lab;

  @override
  void initState() {
    super.initState();
    getPostsFromApi();
  }

  Future<void> getPostsFromApi() async {
    try {
      lab = await ApiLabService.getLab();
      setState(() {});
    } catch (e) {
      debugPrint('Exception: $e');
    }
  }

  @override
  Widget build(BuildContext context) {
    String initialLetter = lab != null ? lab!.name[0] : '';
    return Scaffold(
      appBar: AppBar(
        title: const Text('Laboratório'),
        backgroundColor: const Color.fromARGB(255, 255, 166, 0),
      ),
      body: Center(
          child: ListView(padding: const EdgeInsets.only(top: 30), children: [
        Row(
          mainAxisAlignment: MainAxisAlignment.spaceEvenly,
          children: [
            TextButton(
                style: ButtonStyle(
                  shape: MaterialStatePropertyAll<RoundedRectangleBorder>(
                      RoundedRectangleBorder(
                          borderRadius: BorderRadius.circular(18.0),
                          side: const BorderSide(
                              color: Color.fromARGB(255, 255, 166, 0)))),
                  backgroundColor: const MaterialStatePropertyAll(
                      Color.fromARGB(255, 255, 166, 0)),
                  minimumSize: const MaterialStatePropertyAll(Size.square(200)),
                ),
                child: const Column(
                  children: [
                    Icon(Icons.content_paste_search_outlined, size: 70),
                    Text('Matches')
                  ],
                ),
                onPressed: () {
                  Navigator.push(
                    context,
                    MaterialPageRoute(
                        builder: (context) => MatchPage(
                              isLab: true,
                            )),
                  );
                }),
            TextButton(
                style: ButtonStyle(
                  shape: MaterialStatePropertyAll<RoundedRectangleBorder>(
                      RoundedRectangleBorder(
                          borderRadius: BorderRadius.circular(18.0),
                          side: const BorderSide(
                              color: Color.fromARGB(255, 255, 166, 0)))),
                  backgroundColor: const MaterialStatePropertyAll(
                      Color.fromARGB(255, 255, 166, 0)),
                  minimumSize: const MaterialStatePropertyAll(Size.square(200)),
                ),
                child: const Column(
                  children: [
                    Icon(Icons.supervisor_account_outlined, size: 70),
                    Text('Perfil')
                  ],
                ),
                onPressed: () {
                  Navigator.push(
                    context,
                    MaterialPageRoute(
                        builder: (context) => LabFormPage(
                              lab: lab,
                            )),
                  );
                }),
          ],
        ),
      ])),
      drawer: Drawer(
        child: ListView(
          padding: EdgeInsets.zero,
          children: [
            UserAccountsDrawerHeader(
              accountEmail: Text(lab?.responsible.email ?? ''),
              accountName: Text(lab?.name ?? ''),
              currentAccountPicture: CircleAvatar(
                child: Text(initialLetter),
              ),
            ),
            ListTile(
              leading: const Icon(
                Icons.home,
              ),
              title: const Text('Matches'),
              onTap: () {
                Navigator.pop(context);
                Navigator.push(
                  context,
                  MaterialPageRoute(
                      builder: (context) => MatchPage(isLab: true)),
                );
              },
            ),
            ListTile(
              leading: const Icon(
                Icons.person_outline,
              ),
              title: const Text('Perfil'),
              onTap: () {
                Navigator.pop(context);
                Navigator.push(
                  context,
                  MaterialPageRoute(
                      builder: (context) => LabFormPage(lab: lab)),
                );
              },
            ),
          ],
        ),
      ),
    );
  }
}
