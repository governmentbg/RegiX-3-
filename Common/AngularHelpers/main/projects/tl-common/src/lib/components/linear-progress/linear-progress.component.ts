import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'tl-linear-progress',
  templateUrl: './linear-progress.component.html',
  styleUrls: ['./linear-progress.component.scss']
})
export class LinearProgressComponent {

  @Input()
  public visible = false;
  
    constructor() { }

}
