import 'package:app/companies/company.dart';
import 'package:app/companies/company_form_page.dart';
import 'package:app/companies/company_service.dart';
import 'package:app/demands/demands_page.dart';
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
      body: const Center(
        child: Text("HomePage"),
      ),
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
                  builder: (context) => CompanyFormPage(company: company),
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
