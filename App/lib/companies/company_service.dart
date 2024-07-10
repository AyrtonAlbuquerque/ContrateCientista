import 'dart:developer';

import 'dart:convert';
import 'package:app/companies/company.dart';
import 'package:app/constans.dart';
import 'package:http/http.dart' as http;
import 'package:shared_preferences/shared_preferences.dart';

class ApiCompanyService {
  static Future<Company?> getCompany() async {
    try {
      var url = Uri.parse(ApiConstants.baseUrl + ApiConstants.companyEndpoint);
      final SharedPreferences prefs = await SharedPreferences.getInstance();
      final String? token = prefs.getString('token');
      var response = await http.get(url, headers: {'Authorization': 'Bearer $token'});
      if (response.statusCode == 200) {
        var body = json.decode(response.body);
        return Company.fromMap(body);
      }
    } catch (e) {
      log(e.toString());
    }
    return null;
  }

  static createCompany(name, cnpj, email, password, description) async {
    try {
      var url = Uri.parse('${ApiConstants.baseUrl}${ApiConstants.companyEndpoint}/register');
      final body = { 'name': name, 'cnpj': cnpj, 'email': email, 'password': password, 'description': description };
      var response = await http.post(url, headers: {'Content-Type': 'application/json'}, body: jsonEncode(body));
      if (response.statusCode == 200) {
        var body = json.decode(response.body);
        return body;
      }
    } catch (e) {
      log(e.toString());
    }
    return null;
  }

  static updateCompany(name, cnpj, email, password, description) async {
    try {
      var url = Uri.parse('${ApiConstants.baseUrl}${ApiConstants.companyEndpoint}/update');
      final body = { 'name': name, 'cnpj': cnpj, 'email': email, 'password': password, 'description': description };
      final SharedPreferences prefs = await SharedPreferences.getInstance();
      final String? token = prefs.getString('token');
      var response = await http.put(url, headers: {'Authorization': 'Bearer $token', 'Content-Type': 'application/json'}, body: jsonEncode(body));
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