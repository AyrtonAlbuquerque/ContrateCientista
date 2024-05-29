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
}