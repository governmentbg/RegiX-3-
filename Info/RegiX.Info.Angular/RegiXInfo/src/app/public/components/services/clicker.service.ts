import { EventEmitter } from '@angular/core';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
  })
export class ClickerService {
   clickEvent = new EventEmitter();

   clicked(item) {
     this.clickEvent.emit(item);
   }
}