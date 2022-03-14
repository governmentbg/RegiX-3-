import { Component, OnInit, Output, EventEmitter, Input, ViewChild } from '@angular/core';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { AdministrationsService } from 'src/app/core/services/rest/administration.service';
import { map } from 'rxjs/operators';
import { RegistryService } from 'src/app/core/services/rest/registry.service';
import { AdaptersService } from 'src/app/core/services/rest/adapters.service';
import { AdapterOperationsService } from 'src/app/core/services/rest/adapter-operations.service';
import { HttpParams } from '@angular/common/http';
import { FilterSection, FilterComponent } from '@tl/tl-common';

@Component({
  selector: 'app-operation-filter',
  templateUrl: './operation-filter.component.html',
  styleUrls: ['./operation-filter.component.scss'],
})
export class OperationFilterComponent {
  filterSections: FilterSection[] = [];

  @ViewChild('filter')
  filter: FilterComponent;

  @Input()
  lastLevelChoiceOnly = false;
  @Output()
  selectedValues = new EventEmitter<{ id: number; name: string, data: any, key: string}[]>();

  constructor(
    protected administrationService: AdministrationsService,
    protected registersService: RegistryService,
    protected adapterService: AdaptersService,
    protected operationService: AdapterOperationsService
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
        true,
        true
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
        ROUTES.ADAPTERS.icon,
        this.selectedValues,
        false,
        true
      )
    );

    this.filterSections.push(
      new FilterSection(
        'adapter',
        ROUTES.ADAPTERS.title,
        ROUTES.ADAPTERS.icon,
        this.filterSections,
        (fs) => {
          let params = new HttpParams();
          params = params.append('$filter', `register.id eq ${fs.selectedId}`);
          return this.adapterService.getAllNoWrap(params).pipe(
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
        ROUTES.ADAPTERS.icon,
        this.selectedValues,
        false,
        true
      )
    );

    this.filterSections.push(
      new FilterSection(
        'adapterOperation',
        ROUTES.OPERATIONS.title,
        ROUTES.OPERATIONS.icon,
        this.filterSections,
        (fs) => {
          let params = new HttpParams();
          params = params.append(
            '$filter',
            `registerAdapter.id eq ${fs.selectedId}`
          );
          return this.operationService.getAllNoWrap(params).pipe(
            map((arr) =>
              arr.map((a) => {
                return {
                  id: a.id,
                  name: a.description,
                  data: a
                };
              })
            )
          );
        },
        'check',
        this.selectedValues
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
