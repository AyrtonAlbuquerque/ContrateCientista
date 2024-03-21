import 'package:app/signin/signin_company_page copy.dart';
import 'package:app/signin/signin_laboratory_page.dart';
import 'package:flutter/material.dart';

class SigninPage extends StatelessWidget {
  SigninPage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Registrar'),
        backgroundColor: const Color.fromARGB(255, 255, 166, 0),
      ),
      body: Form(
        child: Align(
          alignment: Alignment.center,
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              crossAxisAlignment: CrossAxisAlignment.center,
              children: [
                Padding(
                  padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 16),
                  child: ElevatedButton(
                    child: const Text('Registrar como organização'),
                    onPressed: () {
                      Navigator.push(
                            context,
                            MaterialPageRoute(
                              builder: (context) => SigninCompanyPage()),
                          );
                    },
                  ),
                ),
                Padding(
                  padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 16),
                  child: ElevatedButton(
                    child: const Text('Registrar como laboratório'),
                    onPressed: () {
                      Navigator.push(
                            context,
                            MaterialPageRoute(
                              builder: (context) => SigninLaboratoryPage()),
                          );
                    },
                  ),
                ),
            ]),
          ),
      ),
    );
  }
}
