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
          let title = 'Unknown faut';
          let message = 'Contact admin';
          if (error.error?.status === 403) {
            title = 'Error';
            message = 'Cant delete an object, which is refering to another';
          }
          if (error.error === 'INCORRECT_CREDENTIALS') {
            title = 'Invalid Credentials';
            message = 'Please try again';
          }
          this.alertService.error(title, message);
        },
      })
    );
  }
}
