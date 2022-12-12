import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, tap } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../types/CarPartsShop.types';

@Injectable({
  providedIn: 'root',
})
export class AccountsService {
  constructor(private http: HttpClient) {}

  readonly APIUrl = environment.APIUrl;
  private currentUserSubject: BehaviorSubject<User | null> =
    new BehaviorSubject<User | null>(null);

  public get currentUser() {
    return this.currentUserSubject.asObservable();
  }
  public getCurrentUser() {
    return this.http.get<User>(`${this.APIUrl}current`).pipe(
      tap({
        next: (user) => this.currentUserSubject.next(user),
      })
    );
  }
}
