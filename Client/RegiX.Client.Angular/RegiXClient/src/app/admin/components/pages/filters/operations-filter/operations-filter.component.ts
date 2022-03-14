import { Component, OnInit, Output, EventEmitter, ViewChild } from '@angular/core';
import { map } from 'rxjs/operators';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { AdapterOperationsService } from 'src/app/core/services/rest/adapter-operations.service';
import { HttpParams } from '@angular/common/http';
import { FilterSection, FilterComponent } from '@tl/tl-common';
import { AdministrationsService } from 'src/app/core/services/rest/administration.service';
import { RegistersService } from 'src/app/core/services/rest/registers.service';

@Component({
  selector: 'app-operations-filter',
  templateUrl: './operations-filter.component.html',
  styleUrls: ['./operations-filter.component.scss']
})
export class OperationsFilterComponent {
  @ViewChild('filter')
  filter: FilterComponent;

  filterSections: FilterSection[] = [];

  @Output()
  selectedValues = new EventEmitter<
    { id: number; name: string; data: any; key: string}[]
  >();

  constructor(
    protected administrationService: AdministrationsService,
    protected registersService: RegistersService,
    protected adapterOperationsService: AdapterOperationsService
  ) {
    this.filterSections.push(
      new FilterSection(
        'administration',
        ROUTES.ADMINISTRATIONS.title,
        ROUTES.ADMINISTRATIONS.icon,
        this.filterSections,
        (fs) =>
          this.administrationService.getAllProvidersNoWrap().pipe(
            map((arr) =>
              arr.map((a) => {
                return {
                  id: a.id,
                  name: a.name,
                  data: undefined,
                };
              })
            )
          ),
        ROUTES.ADMINISTRATIONS.icon,
        this.selectedValues,
        true,
        true
      )
    );

    this.filterSections.push(
      new FilterSection(
        'register',
        ROUTES.REGISTERS.title,
        ROUTES.REGISTERS.icon,
        this.filterSections,
        (fs) => {
          let params = new HttpParams();
          params = params.append(
            '$filter',
            `authority.id eq ${fs.selectedId}`
          );
          return this.registersService.getAllNoWrap(params).pipe(
            map((arr) =>
              arr.map((a) => {
                return {
                  id: a.id,
                  name: `${a.name} - ${a.code}`,
                  data: undefined,
                };
              })
            )
          );
        },
        ROUTES.REGISTERS.icon,
        this.selectedValues,
        true,
        true
      )
    );

    this.filterSections.push(
      new FilterSection(
        'operation',
        ROUTES.ADAPTER_OPERATIONS.title,
        ROUTES.ADAPTER_OPERATIONS.icon,
        this.filterSections,
        (fs) => {
          let params = new HttpParams();
          params = params.append(
            '$filter',
            `register.id eq ${fs.selectedId}`
          );
          return this.adapterOperationsService.getAllNoWrap(params).pipe(
            map((arr) =>
              arr.map((a) => {
                return {
                  id: a.id,
                  name: a.displayOperationName,
                  data: undefined,
                };
              })
            )
          );
        },
        'check',
        this.selectedValues,
        false,
        true
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
