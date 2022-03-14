import { NgModule } from '@angular/core';
import { EuLogoComponent } from '../components/eu-logo/eu-logo.component';
import { HeaderComponent } from '../components/header/header.component';
import { IgxCardModule, IgxCheckboxModule, IgxCircularProgressBarComponent, IgxDatePickerModule, IgxInputGroupModule, IgxLayoutModule, IgxNavbarModule, IgxProgressBarModule, IgxSelectModule } from '@infragistics/igniteui-angular';
import { DividedComponent } from '../components/divided/divided.component';
import { CommonModule } from '@angular/common';
import { VersionComponent } from '../components/version/version.component';

@NgModule({
    declarations: [
      EuLogoComponent,
      HeaderComponent,
      DividedComponent,
      VersionComponent
    ],
    imports: [
      IgxLayoutModule,
      IgxNavbarModule,
      IgxCardModule,
      IgxCheckboxModule,
      IgxDatePickerModule,
      IgxInputGroupModule,
      IgxSelectModule,
      IgxProgressBarModule,
      IgxLayoutModule,
      CommonModule
    ],
    exports: [
      EuLogoComponent,
      HeaderComponent,
      DividedComponent,
      VersionComponent
    ],
    providers:[
    ]
  })
  export class RgxModule { }