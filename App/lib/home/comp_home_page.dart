import 'package:app/companies/company.dart';
import 'package:app/companies/company_form_page.dart';
import 'package:app/demands/demands_page.dart';
import 'package:app/home/user.dart';
import 'package:app/settings/settings_page.dart';
import 'package:flutter/material.dart';

class CompHomePage extends StatelessWidget {
  CompHomePage({Key? key, required this.login}) : super(key: key);
  final String login;

  // TODO: busca dados do usuario
  // TODO: busca demandas do usuario logado
  User user = User(email: 'test@gmail.com', company: Company(name: 'Company Test', cnpj: '123435624341', email: 'test@gmail.com', description: 'Evidentemente, o comprometimento entre as equipes apresenta tendências no sentido de aprovar a manutenção das condições financeiras e administrativas exigidas.'));

  @override
  Widget build(BuildContext context) {
    List<String> allInitialLetters = user.company!.name.split(' ').map((l) => l[0]).toList();
    final initialLetters = allInitialLetters[0] + allInitialLetters[1];
    return Scaffold(
      appBar: AppBar(
        title: const Text('Organização'),
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
            accountEmail: Text(user.email),
            accountName: Text(user.company!.name),
            currentAccountPicture: CircleAvatar(
              child: Text(initialLetters),
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
                  builder: (context) => DemandsPage(
                    isLab: false,
                  )),
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
                  builder: (context) => CompanyFormPage(company: user.company),
                )
              );
            },
          ),
        ],
      ),
    ),
    );
  }
}
