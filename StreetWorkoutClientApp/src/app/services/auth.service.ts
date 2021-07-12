import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { IUserLoginForm, IUserRegisterForm } from '../models';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private loginPath = environment.apiUrl + 'identity/login';
  private registerPath = environment.apiUrl + 'register';

  constructor(private http: HttpClient) {}

  login(data: IUserLoginForm): Observable<any> {
    return this.http.post(this.loginPath, data, {
      headers: { 'content-type': 'application/json' },
    });
  }

  register(data: IUserRegisterForm): Observable<any> {
    return this.http.post(this.registerPath, data);
  }
}
