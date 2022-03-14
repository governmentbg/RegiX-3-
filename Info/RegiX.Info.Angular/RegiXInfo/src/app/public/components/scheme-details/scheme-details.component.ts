import { Component, OnInit, Input } from '@angular/core';
import { HighlightResult } from 'ngx-highlightjs';

@Component({
  selector: 'app-scheme-details',
  templateUrl: './scheme-details.component.html',
  styleUrls: [
    './scheme-details.component.scss',
    '../../../../../node_modules/bootstrap/dist/css/bootstrap.min.css'
  ]
})
export class SchemeDetailsComponent implements OnInit {
  @Input()
  name: string;

  @Input()
  text: string;

  response: HighlightResult;

  constructor() {}

  ngOnInit() {}

  onHighlight(e) {
    this.response = {
      language: e.language,
      r: e.r,
      second_best: '{...}',
      top: '{...}',
      value: '{...}'
    };
  }
}
