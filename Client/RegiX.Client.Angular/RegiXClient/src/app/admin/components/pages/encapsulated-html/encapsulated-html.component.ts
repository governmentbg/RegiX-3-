import { Component, OnInit, ViewEncapsulation, Input } from '@angular/core';

@Component({
  selector: 'app-encapsulated-html',
  templateUrl: './encapsulated-html.component.html',
  styleUrls: [
    './encapsulated-html.component.scss',
  ],
  encapsulation: ViewEncapsulation.None
})
export class EncapsulatedHtmlComponent implements OnInit {

  @Input()
  Html = '';
  constructor() { }

  ngOnInit() {
  }

}
