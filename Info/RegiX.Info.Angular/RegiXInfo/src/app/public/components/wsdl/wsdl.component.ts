import { Component, OnInit } from '@angular/core';
import { HighlightResult } from 'ngx-highlightjs';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-wsdl',
  templateUrl: './wsdl.component.html',
  styleUrls: ['./wsdl.component.scss']
})
export class WsdlComponent implements OnInit {
  text: string = null;
  response: HighlightResult;

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.http
      .get('assets/wsdl.xml', { responseType: 'text' })
      .subscribe(data => {
        this.text = '' + data;
        console.log('text', this.text);
      });
  }

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
