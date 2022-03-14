import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';  
import {
  IgxProgressBarModule, IgxIconModule, IgxNavigationDrawerModule, IgxDividerModule, IgxToastModule, IgxNavbarModule, IgxChipsModule, IgxGridModule, IgxLayoutModule, IgxTreeGridModule, IgxListModule, IgxAvatarModule, IgxCardModule, IgxExcelExporterService, IgxBadgeModule
} from 'igniteui-angular';
import { LinearProgressComponent } from '../components/linear-progress/linear-progress.component';
import { DrawerItemComponent } from '../components/drawer-item/drawer-item.component';
import { NgxPermissionsModule } from 'ngx-permissions';
import { RouterModule } from '@angular/router';
import { LayoutComponent } from '../components/layout/layout.component';
import { BreadcrumbsComponent } from '../components/breadcrumbs/breadcrumbs.component';
import { GridPagerComponent } from '../components/grid-pager/grid-pager.component';
import { FormsModule } from '@angular/forms';
import { ReferenceButtonComponent } from '../components/reference-button/reference-button.component';
import { CardComponent } from '../components/card/card.component';
import { ReferenceItemComponent } from '../components/reference-item/reference-item.component';
import { ReferenceListComponent } from '../components/reference-list/reference-list.component';
import { WrappingCardComponent } from '../components/wrapping-card/wrapping-card.component';
import { FilterComponent } from '../components/filter/filter.component';
import { FormGroupComponent } from '../components/form-group/form-group.component';
import { FormGroupRefDirective } from '../directives/form-group-ref.directive';
import { BasicFormComponent } from '../components/basic-form/basic-form.component';
import { TLMarkedComponent } from '../components/marked/marked.component';
import { MarkdownModule, MarkedOptions, MarkedRenderer } from 'ngx-markdown';
import { HttpClient } from '@angular/common/http';
import { AnchorService } from '../services/anchor.service';

export function markedOptionsFactory(anchorService: AnchorService): MarkedOptions {
  const renderer = new MarkedRenderer();

  // fix `href` for absolute link with fragments so that _copy-paste_ urls are correct
  renderer.link = (href, title, text) => {
    return MarkedRenderer.prototype.link.call(renderer, anchorService.normalizeExternalUrl(href), title, text);
  };

  return { renderer };
}

@NgModule({
  declarations: [
    LinearProgressComponent,
    DrawerItemComponent,
    LayoutComponent,
    GridPagerComponent,
    ReferenceButtonComponent,
    CardComponent,
    ReferenceItemComponent,
    ReferenceListComponent,
    BreadcrumbsComponent,
    WrappingCardComponent,
    FilterComponent,
    FormGroupComponent,
    FormGroupRefDirective,
    BasicFormComponent,
    TLMarkedComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    IgxListModule,
    IgxProgressBarModule,
    IgxNavbarModule,
    IgxChipsModule,
    IgxGridModule,
    IgxIconModule,
    IgxCardModule,
    IgxNavigationDrawerModule,
    IgxToastModule,
    IgxLayoutModule,
    IgxDividerModule,
    IgxTreeGridModule,
    IgxAvatarModule,
    IgxBadgeModule,
    RouterModule,
    NgxPermissionsModule.forChild(),
    MarkdownModule.forRoot({
      loader: HttpClient,
      markedOptions: {
        provide: MarkedOptions,
        useFactory: markedOptionsFactory,
        deps: [AnchorService],
      },
    }), 

  ],
  exports: [
    LinearProgressComponent,
    BreadcrumbsComponent,
    LayoutComponent,
    GridPagerComponent,
    CardComponent,
    ReferenceButtonComponent,
    ReferenceItemComponent,
    ReferenceListComponent,
    DrawerItemComponent,
    WrappingCardComponent,
    FilterComponent,
    FormGroupComponent,
    FormGroupRefDirective,
    BasicFormComponent,
    TLMarkedComponent
  ],
  providers:[
    IgxExcelExporterService
  ]
})
export class TlCommonModule { }
