import 'dart:html';

import 'package:app/companies/company.dart';
import 'package:app/companies/company_form_page.dart';
import 'package:app/companies/company_service.dart';
import 'package:app/demands/demands_page.dart';
import 'package:app/match/match_page.dart';
import 'package:flutter/material.dart';

class CompHomePage extends StatefulWidget {
  CompHomePage();

  @override
  State<StatefulWidget> createState() => CompHomePageState();
}

class CompHomePageState extends State {
  CompHomePageState();

  Company? company;

  @override
  void initState() {
    super.initState();
    getPostsFromApi();
  }

  Future<void> getPostsFromApi() async {
    try {
      company = await ApiCompanyService.getCompany();
      // Update the state to rebuild the UI with the new data
      setState(() {});
    } catch (e) {
      debugPrint('Exception: $e');
    }
  }

  @override
  Widget build(BuildContext context) {
    String initialLetter = company != null ? company!.name[0] : '';
    return Scaffold(
      appBar: AppBar(
        title: const Text('Organização'),
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
                    Text('Demandas')
                  ],
                ),
                onPressed: () {
                  Navigator.push(
                    context,
                    MaterialPageRoute(builder: (context) => DemandsPage()),
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
                    Text('Matches')
                  ],
                ),
                onPressed: () {
                  Navigator.push(
                    context,
                    MaterialPageRoute(
                        builder: (context) => MatchPage(
                              isLab: false,
                            )),
                  );
                }),
          ],
        ),
        const SizedBox(height: 30),
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
                    Icon(Icons.person_outline, size: 70),
                    Text('Perfil')
                  ],
                ),
                onPressed: () {
                  Navigator.push(
                    context,
                    MaterialPageRoute(
                        builder: (context) => CompanyFormPage(
                              company: company,
                            )),
                  );
                }),
          ],
        )
      ])),
      drawer: Drawer(
        child: ListView(
          padding: EdgeInsets.zero,
          children: [
            UserAccountsDrawerHeader(
              accountEmail: Text(company?.email ?? ''),
              accountName: Text(company?.name ?? ''),
              currentAccountPicture: CircleAvatar(
                child: Text(initialLetter),
              ),
            ),
            ListTile(
              leading: const Icon(
                Icons.content_paste_search_outlined,
              ),
              title: const Text('Demandas'),
              onTap: () {
                Navigator.pop(context);
                Navigator.push(
                  context,
                  MaterialPageRoute(builder: (context) => DemandsPage()),
                );
              },
            ),
            ListTile(
              leading: const Icon(
                Icons.supervisor_account_outlined,
              ),
              title: const Text('Matches'),
              onTap: () {
                Navigator.pop(context);
                Navigator.push(
                  context,
                  MaterialPageRoute(
                      builder: (context) => MatchPage(isLab: false)),
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
                      builder: (context) => CompanyFormPage(company: company),
                    ));
              },
            ),
          ],
        ),
      ),
    );
  }
}
