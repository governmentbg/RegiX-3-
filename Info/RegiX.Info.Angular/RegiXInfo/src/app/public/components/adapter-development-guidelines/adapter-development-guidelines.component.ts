import { Input } from '@angular/core';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { MarkdownModel } from '../../models/markdown.model';
import { ROUTES } from '../../routes/static-routes';

@Component({
  selector: 'app-adapter-development-guidelines',
  templateUrl: './adapter-development-guidelines.component.html',
  styleUrls: ['./adapter-development-guidelines.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class AdapterDevelopmentGuidelinesComponent implements OnInit {
  adapterDevelopmentRoute = ROUTES.ADAPTER_DEVELOPMENT;

  @Input()
  source: string;

  constructor() { }

  ngOnInit(): void {
  }

}
