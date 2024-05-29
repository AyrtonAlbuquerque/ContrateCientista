import 'package:app/demands/demands_page.dart';
import 'package:app/labs/lab.dart';
import 'package:app/labs/lab_form_page.dart';
import 'package:app/labs/labs_service.dart';
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
      // Update the state to rebuild the UI with the new data
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
      body: const Center(
        child: Text("HomePage"),
      ),
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
            title: const Text('Demandas'),
            onTap: () {
              Navigator.pop(context);
              Navigator.push(
                context,
                MaterialPageRoute(
                  builder: (context) => DemandsPage(isLab: true)),
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
