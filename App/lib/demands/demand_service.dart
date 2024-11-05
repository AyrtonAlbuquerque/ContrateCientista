import 'dart:developer';

import 'dart:convert';
import 'package:app/constans.dart';
import 'package:app/demands/demand.dart';
import 'package:http/http.dart' as http;
import 'package:shared_preferences/shared_preferences.dart';

class ApiDemandService {
  static Future<List<Demand>?> getDemand() async {
    try {
      var url = Uri.parse(
          '${ApiConstants.baseUrl}${ApiConstants.demandEndpoint}/list');
      final SharedPreferences prefs = await SharedPreferences.getInstance();
      final String? token = prefs.getString('token');
      var response =
          await http.get(url, headers: {'Authorization': 'Bearer $token'});
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
      var url = Uri.parse(
          '${ApiConstants.baseUrl}${ApiConstants.demandEndpoint}/$id');
      final SharedPreferences prefs = await SharedPreferences.getInstance();
      final String? token = prefs.getString('token');
      var response =
          await http.get(url, headers: {'Authorization': 'Bearer $token'});
      if (response.statusCode == 200) {
        var body = json.decode(response.body);
        return Demand.fromMap(body);
      }
    } catch (e) {
      log(e.toString());
    }
    return null;
  }

  static createDemand(title, description, department, benefits, details,
      restrictions, keywords, responsible) async {
    try {
      var url = Uri.parse(
          '${ApiConstants.baseUrl}${ApiConstants.demandEndpoint}/create');
      final SharedPreferences prefs = await SharedPreferences.getInstance();
      final String? token = prefs.getString('token');
      final body = {
        'title': title,
        'description': description,
        'department': department,
        'benefits': benefits,
        'details': details,
        'restrictions': restrictions,
        'responsible': {
          'name': responsible.name,
          'department': responsible.department,
          'email': responsible.email,
          'phone': responsible.phone
        },
        'keywords': keywords
      };
      var response = await http.post(url,
          headers: {'Content-Type': 'application/json', 'Authorization': 'Bearer $token'},
          body: jsonEncode(body));
      
      if (response.statusCode == 200) {
        var body = json.decode(response.body);
        return Demand.fromMap(body);
      }
    } catch (e) {
      log(e.toString());
    }
    return null;
  }

  static updateDemand(id, title, description, department, benefits, details,
      restrictions, keywords, responsible) async {
    try {
      var url = Uri.parse(
          '${ApiConstants.baseUrl}${ApiConstants.demandEndpoint}/update');
      final SharedPreferences prefs = await SharedPreferences.getInstance();
      final String? token = prefs.getString('token');
      final body = {
        'id': id,
        'title': title,
        'description': description,
        'department': department,
        'benefits': benefits,
        'details': details,
        'restrictions': restrictions,
        'responsible': responsible,
        'keywords': keywords
      };
      print(body);
      var response = await http.put(url,
          headers: {'Content-Type': 'application/json', 'Authorization': 'Bearer $token'},
          body: jsonEncode(body));
      
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
