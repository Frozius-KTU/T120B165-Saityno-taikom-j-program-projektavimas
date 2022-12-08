import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/services/auth.service';
import { LoginRequest, User } from 'src/app/core/types/CarPartsShop.types';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  constructor(private authService: AuthService, private router: Router) { }
  public form = new FormGroup({
    userName: new FormControl<string>('',[Validators.required]),
    password: new FormControl<string>('',[Validators.required])
  });
  loginUser(){
    this.authService.login(this.form.value as LoginRequest).subscribe({
      next: ()=>{
        this.router.navigate(['/home']);
      }
    });
  }
}
