import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { AccountsService } from '../core/services/accounts.service';
import { AuthService } from '../core/services/auth.service';

// eslint-disable-next-line @typescript-eslint/no-explicit-any
declare let require: any;

@Injectable({ providedIn: 'root' })
export class AppInitializer {
  constructor(
    private authService: AuthService,
    private accountService: AccountsService
  ) {
    // Nothing
  }

  public async initialize(): Promise<void> {
    this.authService.validateSession();
    this.authService.isExp();
    this.authService.setRoles();
    await firstValueFrom(this.accountService.getCurrentUser());
  }
}
