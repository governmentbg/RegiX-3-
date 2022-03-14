import { Component, OnInit, Input, Output, EventEmitter, ViewChild } from '@angular/core';
import { AdministrationsService } from 'src/app/core/services/rest/administration.service';
import { RegistryService } from 'src/app/core/services/rest/registry.service';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { map } from 'rxjs/operators';
import { HttpParams } from '@angular/common/http';
import { FilterSection, FilterComponent } from '@tl/tl-common';

@Component({
  selector: 'app-register-filter',
  templateUrl: './register-filter.component.html',
  styleUrls: ['./register-filter.component.scss']
})
export class RegisterFilterComponent {
  @ViewChild('filter')
  filter: FilterComponent;

  filterSections: FilterSection[] = [];

  @Output()
  selectedValues = new EventEmitter<{ id: number; name: string, data: any, key: string}[]>();

  constructor(
    protected administrationService: AdministrationsService,
    protected registersService: RegistryService
  ) {
    this.filterSections.push(
      new FilterSection(
        'registerAdministration',
        ROUTES.ADMINISTRATIONS.title,
        ROUTES.ADMINISTRATIONS.icon,
        this.filterSections,
        (fs) =>
          this.administrationService.GetAllPrimaries().pipe(
            map((arr) =>
              arr.map((a) => {
                return {
                  id: a.id,
                  name: a.name,
                  data: undefined
                };
              })
            )
          ),
        ROUTES.REGISTRIES.icon,
        this.selectedValues,
        false
      )
    );

    this.filterSections.push(
      new FilterSection(
        'register',
        ROUTES.REGISTRIES.title,
        ROUTES.REGISTRIES.icon,
        this.filterSections,
        (fs) => {
          let params = new HttpParams();
          params = params.append(
            '$filter',
            `administration.id eq ${fs.selectedId}`
          );
          return this.registersService.getAllNoWrap(params).pipe(
            map((arr) =>
              arr.map((a) => {
                return {
                  id: a.id,
                  name: a.name,
                  data: undefined
                };
              })
            )
          );
        },
        'check',
        this.selectedValues,
        false
      )
    );
  }

  public loadFirstSection(): void {
    this.filter.loadFirstSection();
  }

  selectedValuesChange($event) {
    this.selectedValues.emit($event);
  }
}
