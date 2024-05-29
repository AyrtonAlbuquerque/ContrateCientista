import 'dart:developer';

import 'dart:convert';
import 'package:app/constans.dart';
import 'package:app/login/login.dart';
import 'package:http/http.dart' as http;
import 'package:shared_preferences/shared_preferences.dart';

class ApiLoginService {
  static Future<LoginResponse?> login(email, password) async {
    try {
      var url = Uri.parse(ApiConstants.baseUrl + ApiConstants.loginEndpoint);
      var response = await http.post(url, headers: {"Content-Type": "application/json"}, body: json.encode({'email': email, 'password': password}));
      if (response.statusCode == 200) {
        var body = json.decode(response.body);
        final SharedPreferences prefs = await SharedPreferences.getInstance();
        LoginResponse loginRes = LoginResponse.fromMap(body);
        await prefs.setString('token', loginRes.token);
        return loginRes;
      }
    } catch (e) {
      log(e.toString());
    }
    return null;
  }
}