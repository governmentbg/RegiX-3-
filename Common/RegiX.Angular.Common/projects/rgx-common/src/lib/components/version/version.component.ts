import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'rgx-version',
  templateUrl: './version.component.html',
  styleUrls: ['./version.component.scss']
})
export class VersionComponent implements OnInit {
  @Input()
  version: string;

  constructor() { }

  ngOnInit(): void {
  }

}
