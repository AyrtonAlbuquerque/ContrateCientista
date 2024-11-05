import 'dart:developer';

import 'dart:convert';
import 'package:app/constans.dart';
import 'package:app/match/match.dart';
import 'package:http/http.dart' as http;
import 'package:shared_preferences/shared_preferences.dart';

class ApiMatchService {
  static Future<List<Match>?> getMatches() async {
    try {
      var url = Uri.parse('${ApiConstants.baseUrl}${ApiConstants.matchEndpoint}/list');
      final SharedPreferences prefs = await SharedPreferences.getInstance();
      final String? token = prefs.getString('token');
      var response = await http.get(url, headers: {'Authorization': 'Bearer $token'});
      if (response.statusCode == 200) {
        var body = json.decode(response.body);
        return List<Match>.from(body.map((item) => Match.fromMap(item)));
      }
    } catch (e) {
      log(e.toString());
    }
    return null;
  }

  static Future<Match?> getMatchById(id) async {
    try {
      var url = Uri.parse('${ApiConstants.baseUrl}${ApiConstants.matchEndpoint}/$id');
      final SharedPreferences prefs = await SharedPreferences.getInstance();
      final String? token = prefs.getString('token');
      var response = await http.get(url, headers: {'Authorization': 'Bearer $token'});
      if (response.statusCode == 200) {
        var body = json.decode(response.body);
        return Match.fromMap(body);
      }
    } catch (e) {
      log(e.toString());
    }
    return null;
  }

  static like(id, like) async {
    try {
      var url = Uri.parse('${ApiConstants.baseUrl}${ApiConstants.demandEndpoint}/like');
      final body = { 'id': id, 'like': like };
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
}