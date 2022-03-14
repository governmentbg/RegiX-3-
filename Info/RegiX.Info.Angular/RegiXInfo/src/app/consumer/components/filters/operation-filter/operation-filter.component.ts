import { Component, OnInit, ViewChild, Input, Output, EventEmitter } from '@angular/core';
import { map } from 'rxjs/operators';
import { HttpParams } from '@angular/common/http';
import { AdministrationsService } from 'src/app/core/services/rest/administrations.service';
import { RegistryService } from 'src/app/core/services/rest/registry.service';
import { AdaptersService } from 'src/app/core/services/rest/adapters.service';
import { AdapterOperationsService } from 'src/app/core/services/rest/adapter.operations.service';
import { FilterComponent, FilterSection } from '@tl/tl-common';

@Component({
  selector: 'app-operation-filter',
  templateUrl: './operation-filter.component.html',
  styleUrls: ['./operation-filter.component.scss']
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
        'Администрации',
        'account_balance',
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
          'dashboard',
        this.selectedValues,
        true,
        true
      )
    );

    this.filterSections.push(
      new FilterSection(
        'register',
        'Регистри',
        'dashboard',
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
        'developer_board',
        this.selectedValues,
        false,
        true
      )
    );

    this.filterSections.push(
      new FilterSection(
        'adapter',
        'Адаптери',
        'developer_board',
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
        'developer_board',
        this.selectedValues,
        false,
        true
      )
    );

    this.filterSections.push(
      new FilterSection(
        'adapterOperation',
        'Операции',
        'receipt',
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
                  data: a.registerObject.id
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
