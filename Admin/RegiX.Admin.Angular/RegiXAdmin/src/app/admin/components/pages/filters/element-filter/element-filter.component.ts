import { HttpParams } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { FilterComponent, FilterSection } from '@tl/tl-common';
import { map } from 'rxjs/operators';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { AdapterOperationsService } from 'src/app/core/services/rest/adapter-operations.service';
import { AdaptersService } from 'src/app/core/services/rest/adapters.service';
import { AdministrationsService } from 'src/app/core/services/rest/administration.service';
import { RegisterObjectElementsService } from 'src/app/core/services/rest/register-object-elements.service';
import { RegistryService } from 'src/app/core/services/rest/registry.service';

@Component({
  selector: 'app-element-filter',
  templateUrl: './element-filter.component.html',
  styleUrls: ['./element-filter.component.scss']
})
export class ElementFilterComponent {
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
    protected operationService: AdapterOperationsService,
    protected elementsService: RegisterObjectElementsService
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
        ROUTES.OPERATIONS.icon,
        this.selectedValues
      )
    );

    this.filterSections.push(
      new FilterSection(
        'operationElement',
        ROUTES.CERTIFICATE_OPERATION_ELEMENTS_ACCESS.title,
        ROUTES.CERTIFICATE_OPERATION_ELEMENTS_ACCESS.icon,
        this.filterSections,
        (fs) => {
          let params = new HttpParams();
          params = params.append(
            '$filter',
            `registerObject.id eq ${fs.selectedData.registerObject.id}`
          );
          params = params.append(
            '$orderby',
            'pathToRoot asc'
          );
          return this.elementsService.getAllNoWrap(params).pipe(
            map((arr) =>
              arr.map((a) => {
                return {
                  id: a.id,
                  name: `${a.description} - ${a.pathToRoot}`,
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
