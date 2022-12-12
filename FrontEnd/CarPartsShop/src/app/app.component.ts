import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountsService } from './core/services/accounts.service';
import { AuthService } from './core/services/auth.service';
import { User } from './core/types/CarPartsShop.types';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  title = 'CarPartsShop';
  constructor(
    private accountService: AccountsService,
    private authService: AuthService,
    private router: Router
  ) {}
  user?: User;
  ngOnInit() {
    this.accountService.currentUser.subscribe({
      next: (val) => {
        if (val) this.user = val;
      },
    });
    if (this.user) console.log(this.user.userName);
  }
  isAdmin(): boolean {
    return this.authService.isAdmin;
  }
  isUser(): boolean {
    return this.authService.isUser;
  }
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
