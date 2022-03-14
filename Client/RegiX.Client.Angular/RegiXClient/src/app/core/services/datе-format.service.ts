import { DatePipe } from '@angular/common';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class DatеFormatService {
  constructor(private datepipe: DatePipe) {}
  public formatDate(val: Date): any {
    const options = {
      year: 'numeric',
      month: 'numeric',
      day: 'numeric',
      hour: 'numeric',
      minute: 'numeric',
      second: 'numeric',
    };
    return new Intl.DateTimeFormat('bg-BG', options).format(val);
  }
  public formatForExport(val: Date): any {
    return this.datepipe.transform(val, 'yyyy.MM.dd HH:mm:ss');
  }
}
