import { Subject } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BackService {
  public backSubject: Subject<boolean> = new Subject<boolean>();

  public isBackVisible(isVisible: boolean) {
    this.backSubject.next(isVisible);
  }
}
