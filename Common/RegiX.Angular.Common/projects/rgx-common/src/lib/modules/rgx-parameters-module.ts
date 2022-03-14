import { NgModule } from '@angular/core';
import { EuLogoComponent } from '../components/eu-logo/eu-logo.component';
import { HeaderComponent } from '../components/header/header.component';
import { IgxButtonModule, IgxCardModule, IgxCheckboxModule, IgxCircularProgressBarComponent, IgxDatePickerModule, IgxIconModule, IgxInputGroupModule, IgxLayoutModule, IgxNavbarModule, IgxProgressBarModule, IgxSelectModule, IgxTimePickerModule } from '@infragistics/igniteui-angular';
import { DividedComponent } from '../components/divided/divided.component';
import { CommonModule } from '@angular/common';
import { ArrayParameterComponent } from '../components/parameters/array-parameter/array-parameter.component';
import { BooleanFieldComponent } from '../components/parameters/boolean-field/boolean-field.component';
import { ComplexParameterComponent } from '../components/parameters/complex-parameter/complex-parameter.component';
import { DateFieldComponent } from '../components/parameters/date-field/date-field.component';
import { DateTimeFieldComponent } from '../components/parameters/date-time-field/date-time-field.component';
import { EnumFieldComponent } from '../components/parameters/enum-field/enum-field.component';
import { EnumWithSourceComponent } from '../components/parameters/enum-with-source/enum-with-source.component';
import { FileComponent } from '../components/parameters/file/file.component';
import { IntFieldComponent } from '../components/parameters/int-field/int-field.component';
import { ParametersControlComponent } from '../components/parameters/parameters-control/parameters-control.component';
import { TextFieldComponent } from '../components/parameters/text-field/text-field.component';
import { DecimalFieldComponent } from '../components/parameters/decimal-field/decimal-field.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TlCommonModule } from '@tl/tl-common';

@NgModule({
    declarations: [
        ArrayParameterComponent,
        BooleanFieldComponent,
        ComplexParameterComponent,
        DateFieldComponent,
        DateTimeFieldComponent,
        DecimalFieldComponent,
        EnumFieldComponent,
        EnumWithSourceComponent,
        FileComponent,
        IntFieldComponent,
        ParametersControlComponent,
        TextFieldComponent
    ],
    imports: [
      FormsModule,      
      ReactiveFormsModule,
      CommonModule,
      TlCommonModule,
      IgxLayoutModule,
      IgxButtonModule,
      IgxCardModule,
      IgxCheckboxModule,
      IgxDatePickerModule,
      IgxInputGroupModule,
      IgxSelectModule,
      IgxProgressBarModule,
      IgxTimePickerModule,
      IgxLayoutModule,
      IgxIconModule
    ],
    exports: [
        ArrayParameterComponent,
        BooleanFieldComponent,
        ComplexParameterComponent,
        DateFieldComponent,
        DateTimeFieldComponent,
        DecimalFieldComponent,
        EnumFieldComponent,
        EnumWithSourceComponent,
        FileComponent,
        IntFieldComponent,
        ParametersControlComponent,
        TextFieldComponent
    ],
    providers:[
    ]
  })
  export class RgxParametersModule { }