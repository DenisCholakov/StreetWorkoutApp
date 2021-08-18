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

  // after implementing ngRx this will be moved to the store and won't be exposed
  private logger = new BehaviorSubject<boolean>(this.isAuthenticated());
  private role = new BehaviorSubject<string>(
    localStorage.getItem('userRole') ?? ''
  );

  constructor(private http: HttpClient) {}

  login(data: IUserLoginForm): Observable<any> {
    return this.http.post(this.loginPath, data);
  }

  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('userRole');
    this.logger.next(false);
    this.role.next('');
  }

  isLoggedIn(): Observable<boolean> {
    return this.logger.asObservable();
  }

  userRole(): Observable<string> {
    return this.role.asObservable();
  }

  register(data: IUserRegisterForm): Observable<any> {
    return this.http.post(this.registerPath, data);
  }

  saveToken(token: string, role: string): void {
    localStorage.setItem('token', token);
    localStorage.setItem('userRole', role);
    this.logger.next(this.isAuthenticated());
    this.role.next(role);
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

  isAdministrator(): boolean {
    return localStorage.getItem('userRole') === 'Admin';
  }

  isTrainer(): boolean {
    return localStorage.getItem('userRole') === 'Trainer';
  }
}
