import { Injectable } from '@angular/core';
import { AuthService } from '../core/services/auth.service';

// eslint-disable-next-line @typescript-eslint/no-explicit-any
declare let require: any;

@Injectable({ providedIn: 'root' })
export class AppInitializer {
  constructor(private authService: AuthService) {
    // Nothing
  }

  public async initialize(): Promise<void> {
    this.authService.validateSession();
    this.authService.isExp();
  }
}
