import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import {
  LoginRequest,
  LoginResponse,
  RegisterRequest,
} from '../types/CarPartsShop.types';
import { tap } from 'rxjs';
import { Router } from '@angular/router';
import jwt_decode from 'jwt-decode';
@Injectable({
  providedIn: 'root',
})
export class AuthService {
  readonly tokenStorage = 'carShopAuth';
  readonly APIUrl = environment.APIUrl;
  private readonly TokenValidInMinutes: number = 60;
  private readonly LoginPage: string = '/login';
  private readonly DefaultPage: string = '/home';
  constructor(private http: HttpClient, private router: Router) {}
  public isAuthenticated: boolean = false;

  login(req: LoginRequest) {
    return this.http.post<LoginResponse>(this.APIUrl + 'login', req).pipe(
      tap({
        next: (response) => {
          localStorage.setItem(this.tokenStorage, response.accessToken);
          this.isAuthenticated = true;
        },
      })
    );
  }
  logout() {
    localStorage.removeItem(this.tokenStorage);
    this.isAuthenticated = false;
  }

  public getToken(): string | null {
    return localStorage.getItem(this.tokenStorage);
  }
  register(req: RegisterRequest) {
    return this.http.post(this.APIUrl + 'register', req);
  }
  public validateSession(): void {
    const token = this.getToken();
    if (!token) {
      this.isAuthenticated = false;
    } else this.isAuthenticated = true;
  }
  public isExp(): void {
    var token = this.getToken();
    if (token == null) this.isAuthenticated = false;
    else {
      const expiry = JSON.parse(atob(token.split('.')[1])).exp;
      if (Math.floor(new Date().getTime() / 1000) >= expiry) {
        this.router.navigate(['/login']);
        this.isAuthenticated = false;
      } else {
        this.isAuthenticated = true;
      }
    }
  }
}
