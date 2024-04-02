import 'package:app/home/lab_home_page.dart';
import 'package:flutter/material.dart';

class SigninCompanyPage extends StatelessWidget {
  SigninCompanyPage({Key? key}) : super(key: key);

  final _formKey = GlobalKey<FormState>();
  TextEditingController loginController = TextEditingController();
  TextEditingController passwordController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Registrar Organização'),
        backgroundColor: const Color.fromARGB(255, 255, 166, 0),
      ),
      body: Form(
        key: _formKey,
        child: Align(
          alignment: Alignment.center,
          child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              crossAxisAlignment: CrossAxisAlignment.center,
              children: [
                Padding(
                  padding:
                      const EdgeInsets.symmetric(horizontal: 16, vertical: 16),
                  child: TextFormField(
                    decoration: const InputDecoration(
                        border: OutlineInputBorder(), hintText: 'Login'),
                    controller: loginController,
                    validator: (value) {
                      if (value == null || value.isEmpty) {
                        return 'Por favor, insira seu login';
                      }
                      return null;
                    },
                  ),
                ),
                Padding(
                  padding:
                      const EdgeInsets.symmetric(horizontal: 16, vertical: 16),
                  child: TextFormField(
                    decoration: const InputDecoration(
                        border: OutlineInputBorder(), hintText: 'Senha'),
                    controller: passwordController,
                    obscureText: true,
                    validator: (value) {
                      if (value == null || value.isEmpty) {
                        return 'Por favor, insira sua senha';
                      }
                      return null;
                    },
                  ),
                ),
                Padding(
                  padding:
                      const EdgeInsets.symmetric(horizontal: 16, vertical: 16),
                  child: ElevatedButton(
                    child: const Text('Criar'),
                    onPressed: () {
                      if (_formKey.currentState!.validate()) {
                        // enviar dados
                      } else {
                        ScaffoldMessenger.of(context).showSnackBar(
                          const SnackBar(
                              content:
                                  Text('Por favor, preencha todos os campos')),
                        );
                      }
                    },
                  ),
                ),
              ]),
        ),
      ),
    );
  }
}
