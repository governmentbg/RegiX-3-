import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormGroupComponent } from './components/ui/form-group/form-group.component';
import { IgxLayoutModule } from 'igniteui-angular';
import { FormGroupRefDirective } from './directives/form-group-ref.directive';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [FormGroupComponent, FormGroupRefDirective],
  imports: [CommonModule, FormsModule, ReactiveFormsModule, IgxLayoutModule],
  exports: [FormGroupComponent, FormGroupRefDirective]
})
export class SharedModule {}
