import { Component, Input, OnInit, TemplateRef } from '@angular/core';

@Component({
  selector: 'rgx-divided',
  templateUrl: './divided.component.html',
  styleUrls: ['./divided.component.scss']
})
export class DividedComponent implements OnInit {

  @Input('leftContent')
  leftContent: TemplateRef<any>;
  
  @Input('rightContent')
  rightContent: TemplateRef<any>;

  @Input()
  public applicationName: string;

  constructor() { }

  ngOnInit(): void {
  }

}
