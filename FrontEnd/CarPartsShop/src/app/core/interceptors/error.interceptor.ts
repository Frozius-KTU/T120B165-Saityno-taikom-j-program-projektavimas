import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { AlertsService } from '../services/alerts.service';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private alertService: AlertsService) {}
  public intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      tap({
        error: (error) => {
          console.log(error);
          let title = 'Nezinoma klaida';
          let message = 'Susisiekite su vadminu';
          if (error.error?.status === 403) {
            title = 'Pizda sigucio';
            message = 'Netrink tokiu dalyku kuriu yra daugiau tolimiau';
          }
          if (error.error === 'INCORRECT_CREDENTIALS') {
            title = 'Kazko stobaliai neivedei';
            message = 'Kita kart ivesk nes kestas apvems tave';
          }
          this.alertService.error(title, message);
        },
      })
    );
  }
}
