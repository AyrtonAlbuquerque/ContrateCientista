import 'dart:developer';

import 'dart:convert';
import 'package:app/constans.dart';
import 'package:app/demands/demand.dart';
import 'package:http/http.dart' as http;
import 'package:shared_preferences/shared_preferences.dart';

class ApiDemandService {
  static Future<List<Demand>?> getDemand() async {
    try {
      var url = Uri.parse('${ApiConstants.baseUrl}${ApiConstants.demandEndpoint}/list');
      final SharedPreferences prefs = await SharedPreferences.getInstance();
      final String? token = prefs.getString('token');
      var response = await http.get(url, headers: {'Authorization': 'Bearer $token'});
      if (response.statusCode == 200) {
        var body = json.decode(response.body);
        return List<Demand>.from(body.map((item) => Demand.fromMap(item)));
      }
    } catch (e) {
      log(e.toString());
    }
    return null;
  }

  static Future<Demand?> getDemandById(id) async {
    try {
      var url = Uri.parse('${ApiConstants.baseUrl}${ApiConstants.demandEndpoint}/$id');
      final SharedPreferences prefs = await SharedPreferences.getInstance();
      final String? token = prefs.getString('token');
      var response = await http.get(url, headers: {'Authorization': 'Bearer $token'});
      if (response.statusCode == 200) {
        var body = json.decode(response.body);
        return Demand.fromMap(body);
      }
    } catch (e) {
      log(e.toString());
    }
    return null;
  }
}