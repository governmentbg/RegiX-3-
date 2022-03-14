import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { IgxToastPosition } from 'igniteui-angular';

@Injectable({
  providedIn: 'root'
})
export class ToastService {
  public toastPosition: IgxToastPosition = IgxToastPosition.Middle;

  public toastSubject: Subject<string> = new Subject<string>();

  public showMessage(message: string) {
    this.toastSubject.next(message);
  }
}
