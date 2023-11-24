import 'package:flutter/material.dart';

class Demand {
  String title;
  String company;
  String description;
  String department;
  String benefits;
  String details;
  String restrictions;
  String keywords;

  Demand({required this.title, required this.company, required this.description, required this.department, required this.benefits, required this.details, required this.restrictions, required this.keywords});
}


class DemandDetailsPage extends StatelessWidget {
  DemandDetailsPage({Key? key, required this.demand, required this.isLab}) : super(key: key);
  final Demand demand;
  final bool isLab;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Detalhes'),
        backgroundColor: const Color.fromARGB(255, 255, 166, 0),
      ),
      body: Center(
        child: ListView(
          children: [
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 0),
              child: Text(demand.title, style: const TextStyle(fontSize: 24, fontWeight: FontWeight.bold),),
            ),
            if (isLab) ...[Padding(
                padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 16),
                child: ElevatedButton(
                  child: const Text('Responder demanda'),
                  onPressed: () {
                  }),
            )],
            const Padding(
              padding: EdgeInsets.symmetric(horizontal: 16, vertical: 16),
              child: Text('Descrição', style: TextStyle(fontWeight: FontWeight.bold),),
              ),
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 0),
              child: Text(demand.description),
            ),
            Row(
              children: [
                Column(
                  children: [
                    const Padding(
                      padding: EdgeInsets.symmetric(horizontal: 16, vertical: 16),
                      child: Text('Organização', style: TextStyle(fontWeight: FontWeight.bold),),
                      ),
                    Padding(
                      padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 0),
                      child: Text(demand.company),
                    ),
                ],),
                const Spacer(),
                Column(
                  children: [
                    const Padding(
                      padding: EdgeInsets.symmetric(horizontal: 16, vertical: 16),
                      child: Text('Departamento', style: TextStyle(fontWeight: FontWeight.bold),),
                      ),
                    Padding(
                      padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 0),
                      child: Text(demand.department),
                    ),
                ],)
              ],
            ),
            const Padding(
              padding: EdgeInsets.symmetric(horizontal: 16, vertical: 16),
              child: Text('Benfícios', style: TextStyle(fontWeight: FontWeight.bold),),
              ),
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 0),
              child: Text(demand.benefits),
            ),
            const Padding(
              padding: EdgeInsets.symmetric(horizontal: 16, vertical: 16),
              child: Text('Detalhes', style: TextStyle(fontWeight: FontWeight.bold),),
              ),
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 0),
              child: Text(demand.details),
            ),
            const Padding(
              padding: EdgeInsets.symmetric(horizontal: 16, vertical: 16),
              child: Text('Restrições', style: TextStyle(fontWeight: FontWeight.bold),),
              ),
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 0),
              child: Text(demand.restrictions),
            ),
            const Padding(
              padding: EdgeInsets.symmetric(horizontal: 16, vertical: 16),
              child: Text('Palavras-chave', style: TextStyle(fontWeight: FontWeight.bold),),
              ),
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 0),
              child: Text(demand.keywords),
            ),
            const SizedBox(height: 50),
          ]
          ),
      ),
    );
  }
}
