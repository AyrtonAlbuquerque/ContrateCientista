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

  static createLab(
      email,
      password,
      name,
      code,
      description,
      certificates,
      foundationDate,
      keywords,
      responsible,
      address,
      socialMedias,
      softwares,
      equipments) async {
    try {
      var url = Uri.parse(
          '${ApiConstants.baseUrl}${ApiConstants.labEndpoint}/register');
      final body = {
        'name': name,
        'code': code,
        'description': description,
        'certificates': certificates,
        'foundationDate': foundationDate,
        'keywords': keywords,
        'responsible': {
          'name': responsible.name,
          'department': responsible.department,
          'phone': responsible.phone,
          'email': email,
          'password': password
        },
        'address': {
          'street': address.street,
          'number': address.number,
          'neighborhood': address.neighborhood,
          'city': address.city,
          'state': address.state,
          'country': address.country,
          'extra': address.extra
        },
        'socialMedias': socialMedias.map((s) { 
          return {
            'type': s.type,
            'link': s.link
          };
        }).toList(),
        'softwares': softwares.map((s) {
          return {
            'name': s.name,
            'description': s.description,
            'area': s.area,
          };
        }).toList(),
        'equipments': equipments.map((s) {
          return {
            'name': s.name,
            'description': s.description,
            'area': s.area,
          };
        }).toList(),
      };
      var response = await http.post(url,
          headers: {
            'Content-Type': 'application/json'
          },
          body: jsonEncode(body));
      if (response.statusCode == 200) {
        var body = json.decode(response.body);
        return body;
      }
    } catch (e) {
      log(e.toString());
    }
    return null;
  }

  static updateLab(
      name,
      code,
      description,
      certificates,
      foundationDate,
      keywords,
      responsible,
      address,
      socialMedias,
      softwares,
      equipments) async {
    try {
      var url = Uri.parse(
          '${ApiConstants.baseUrl}${ApiConstants.labEndpoint}/update');
      final SharedPreferences prefs = await SharedPreferences.getInstance();
      final String? token = prefs.getString('token');
      final body = {
        'name': name,
        'code': code,
        'description': description,
        'certificates': certificates,
        'foundationDate': foundationDate,
        'keywords': keywords,
        'responsible': {
          'name': responsible.name,
          'department': responsible.department,
          'email': responsible.email,
          'phone': responsible.phone
        },
        'address': {
          'street': address.street,
          'number': address.number,
          'neighborhood': address.neighborhood,
          'city': address.city,
          'state': address.state,
          'country': address.country,
          'extra': address.extra
        },
        'socialMedias': socialMedias.map((s) { 
          return {
            'type': s.type,
            'link': s.link
          };
        }).toList(),
        'softwares': softwares.map((s) {
          return {
            'name': s.name,
            'description': s.description,
            'area': s.area,
          };
        }).toList(),
        'equipments': equipments.map((s) {
          return {
            'name': s.name,
            'description': s.description,
            'area': s.area,
          };
        }).toList(),
      };
      var response = await http.put(url,
          headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer $token'
          },
          body: jsonEncode(body));
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
