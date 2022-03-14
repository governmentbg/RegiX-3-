import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { MarkdownModel } from '../../models/markdown.model';
import { ROUTES } from '../../routes/static-routes';
import { MdDescriptionService } from '../../services/md-descripitom.service';
import { ClickerService } from '../services/clicker.service';

@Component({
  selector: 'app-adapter-development-guidelines-new',
  templateUrl: './adapter-development-guidelines-new.component.html',
  styleUrls: ['./adapter-development-guidelines-new.component.scss'],
})
export class AdapterDevelopmentGuidelinesNewComponent implements OnInit {
  adapterDevelopmentRoute = ROUTES.ADAPTER_DEVELOPMENT;
  http: any;
  mdFiles: MarkdownModel[] = [];

  constructor(private mdDescriptionService: MdDescriptionService, private clickerService: ClickerService
    ) {
    this.clickerService.clickEvent.subscribe((item) => {
      this.navigate(item);
     });
  }

  ngOnInit(): void {
    this.mdDescriptionService.getJSON().subscribe((data) => {
      this.mdFiles = data;
    });
  }

  public selected = 'assets/marked/01.RegixInfo.md';

  public navigate(item: string) {
    debugger;
    this.selected = item;
  
  }

  public navigateSub(item: MarkdownModel) {
    this.selected = item.fileName;
  }

  public getJSON(): Observable<any> {
    return this.http.get('./assets/marked/md-description.json');
  }
}
