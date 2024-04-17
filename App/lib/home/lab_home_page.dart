import 'package:app/demands/demands_page.dart';
import 'package:app/home/user.dart';
import 'package:app/labs/lab.dart';
import 'package:app/labs/lab_form_page.dart';
import 'package:app/settings/settings_page.dart';
import 'package:flutter/material.dart';

class LabHomePage extends StatelessWidget {
  LabHomePage({Key? key, required this.login}) : super(key: key);
  final String login;

  // TODO: busca dados do usuario
  // TODO: busca demandas que o laboratorio logado é elegivel
  // TODO: adicionar menu com dados do laboratorio para edicao
  final User user = User(email: 'test@gmail.com', lab: Lab(name: 'Lab Test', code: 'TST001', responsibleId: '', addressId: '', description: 'Caros amigos, o início da atividade geral de formação de atitudes agrega valor ao estabelecimento da gestão inovadora da qual fazemos parte.', certificates: 'TS T', foundationDate: '12/12/2012'));

  @override
  Widget build(BuildContext context) {
    List<String> allInitialLetters = user.lab!.name.split(' ').map((l) => l[0]).toList();
    final initialLetters = allInitialLetters[0] + allInitialLetters[1];
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
            accountEmail: Text(user.email),
            accountName: Text(user.lab!.name),
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
                  builder: (context) => LabFormPage(lab: user.lab)),
              );
            },
          ),
        ],
      ),
    ),
    );
  }
}
