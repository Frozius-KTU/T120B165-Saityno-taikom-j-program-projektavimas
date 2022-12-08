import { Injectable } from '@angular/core';
import { from, map } from 'rxjs';
import Swal from 'sweetalert2';

@Injectable({
  providedIn: 'root',
})
export class AlertsService {
  constructor() {}
  public confirm(title: string, tekst: string) {
    return from(
      Swal.fire({
        title: title,
        text: tekst,
        icon: 'warning',
        showCancelButton: true,
      })
    ).pipe(map((x) => x.isConfirmed));
  }
  public error(title: string, tekst: string) {
    return from(
      Swal.fire({
        title: title,
        text: tekst,
        icon: 'error',
      })
    );
  }
}
