import 'dart:developer';

import 'dart:convert';
import 'package:app/constans.dart';
import 'package:app/labs/lab.dart';
import 'package:http/http.dart' as http;
import 'package:shared_preferences/shared_preferences.dart';

class ApiLabService {
  static Future<Lab?> getLab() async {
    try {
      var url = Uri.parse(ApiConstants.baseUrl + ApiConstants.labEndpoint);
      final SharedPreferences prefs = await SharedPreferences.getInstance();
      final String? token = prefs.getString('token');
      var response =
          await http.get(url, headers: {'Authorization': 'Bearer $token'});
      if (response.statusCode == 200) {
        var body = json.decode(response.body);
        return Lab.fromMap(body);
      }
    } catch (e) {
      log(e.toString());
    }
    return null;
  }

  static createLab(name, code, description, certificates, foundationDate,
      responsible) async {
    try {
      var url = Uri.parse(
          '${ApiConstants.baseUrl}${ApiConstants.labEndpoint}/register');
      final body = {
        'name': name,
        'code': code,
        'description': description,
        'certificates': certificates,
        'foundationDate': foundationDate,
        'responsible': {
          'name': responsible.name,
          'department': responsible.departament,
          'email': responsible.email,
          'phone': responsible.phone
        }
      };
      print(jsonEncode(body));
      var response = await http.post(url,
          headers: {'Content-Type': 'application/json'},
          body: jsonEncode(body));
      print(response.statusCode);
      print(jsonEncode(response.body));
      if (response.statusCode == 200) {
        var body = json.decode(response.body);
        return body;
      }
    } catch (e) {
      log(e.toString());
    }
    return null;
  }
}
