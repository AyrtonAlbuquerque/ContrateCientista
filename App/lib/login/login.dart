import 'dart:convert';

class LoginResponse {
  String token;
  int userType;

  LoginResponse({required this.token, required this.userType});

  static LoginResponse fromMap(Map<String, dynamic> map) {
    return LoginResponse(token: map['token'], userType: map['userType']);
  }
}
