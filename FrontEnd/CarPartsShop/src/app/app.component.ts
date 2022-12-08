import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './core/services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'CarPartsShop';
  constructor(private authService: AuthService, private router: Router) {}
  logOut() {
    this.authService.logout();
  }
  login() {
    this.router.navigate(['/login']);
  }
  register() {
    this.router.navigate(['/register']);
  }
  getAuth(): Boolean {
    return this.authService.isAuthenticated;
  }
  toCarBrands() {
    this.router.navigate(['/carBrand']);
  }
}
