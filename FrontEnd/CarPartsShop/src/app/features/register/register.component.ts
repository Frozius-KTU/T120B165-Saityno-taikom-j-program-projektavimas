import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/services/auth.service';
import { RegisterRequest } from 'src/app/core/types/CarPartsShop.types';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent {
  constructor(private authService: AuthService, private router: Router) {}
  public form = new FormGroup({
    userName: new FormControl<string>('', [Validators.required]),
    password: new FormControl<string>('', [Validators.required]),
    email: new FormControl<string>('', [Validators.required]),
  });
  registerUser() {
    this.authService.register(this.form.value as RegisterRequest).subscribe({
      next: () => {
        this.router.navigate(['/login']);
      },
    });
  }
}
