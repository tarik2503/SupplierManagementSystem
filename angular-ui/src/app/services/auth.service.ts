import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  baseApiUrl: string = environment.baseApiUrl;
  constructor(private http: HttpClient, private router: Router) {}

  signUp(userObj: any) {
    return this.http.post<any>(this.baseApiUrl + '/api/account', userObj);
  }

  login(loginObj: any) {
    return this.http.post<any>(
      this.baseApiUrl + '/api/account/login',
      loginObj
    );
  }

  logOut() {
    localStorage.clear();
    this.router.navigate(['login']);
  }

  storeToken(tokenValue: string) {
    if (typeof localStorage !== 'undefined') {
      localStorage.setItem('token', tokenValue);
    }
  }

  getToken() {
    if (typeof localStorage !== 'undefined') {
      return localStorage.getItem('token');
    }
    return null;
  }

  isLoggedIn(): boolean {
    return !!this.getToken();
  }
}
