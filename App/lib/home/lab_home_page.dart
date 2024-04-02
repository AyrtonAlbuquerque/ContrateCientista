import 'package:app/demands/demands_page.dart';
import 'package:app/settings/settings_page.dart';
import 'package:flutter/material.dart';

class LabHomePage extends StatelessWidget {
  const LabHomePage({Key? key, required this.login}) : super(key: key);
  final String login;

  // TODO: busca dados do usuario
  // TODO: busca demandas que o laboratorio logado é elegivel
  // TODO: adicionar menu com dados do laboratorio para edicao

  @override
  Widget build(BuildContext context) {
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
        // Important: Remove any padding from the ListView.
        padding: EdgeInsets.zero,
        children: [
          const UserAccountsDrawerHeader(
            accountEmail: Text("user@mail.com"),
            accountName: Text("Seu zé"),
            currentAccountPicture: CircleAvatar(
              child: Text("SZ"),
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
              Icons.train,
            ),
            title: const Text('Configurações'),
            onTap: () {
              Navigator.pop(context);
              Navigator.push(
                context,
                MaterialPageRoute(
                  builder: (context) => const SettingsPage(
                    title: 'Configurações',
                  )),
              );
            },
          ),
        ],
      ),
    ),
    );
  }
}
