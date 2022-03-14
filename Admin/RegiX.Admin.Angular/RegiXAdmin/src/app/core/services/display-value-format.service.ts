import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class DisplayValueFormatService {
  constructor() {}
  public formatDisplayValue(value?): any {
    return value?.displayName;
  }
}