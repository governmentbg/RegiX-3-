import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormGroupComponent } from './components/ui/form-group/form-group.component';
import { IgxLayoutModule } from 'igniteui-angular';
import { FormGroupRefDirective } from './directives/form-group-ref.directive';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AdministrationsFilterComponent } from './components/administrations-filter/administrations-filter.component';
import { FilterComponent, TlCommonModule } from '@tl/tl-common';

@NgModule({
  declarations: [FormGroupComponent, FormGroupRefDirective, AdministrationsFilterComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    IgxLayoutModule,
    TlCommonModule
  ],
  exports: [FormGroupComponent, FormGroupRefDirective, AdministrationsFilterComponent]
})
export class SharedModule {}
