import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';

import { environment } from '../../../environments/environment';
import { IUserLoginForm, IUserRegisterForm } from '../../models';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private loginPath = environment.apiUrl + 'identity/login';
  private registerPath = environment.apiUrl + 'identity/register';

  private logger = new BehaviorSubject<boolean>(this.isAuthenticated());

  constructor(private http: HttpClient) {}

  login(data: IUserLoginForm): Observable<any> {
    return this.http.post(this.loginPath, data);
  }

  logout() {
    localStorage.removeItem('token');
    this.logger.next(false);
  }

  isLoggedIn(): Observable<boolean> {
    return this.logger.asObservable();
  }

  register(data: IUserRegisterForm): Observable<any> {
    return this.http.post(this.registerPath, data);
  }

  saveToken(token: string): void {
    localStorage.setItem('token', token);
    this.logger.next(this.isAuthenticated());
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  isAuthenticated(): boolean {
    if (this.getToken()) {
      return true;
    }

    return false;
  }
}
