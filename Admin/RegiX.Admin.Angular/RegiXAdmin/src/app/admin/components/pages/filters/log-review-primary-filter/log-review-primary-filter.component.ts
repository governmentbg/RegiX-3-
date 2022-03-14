import { Component, ViewChild, Input, Output, EventEmitter } from '@angular/core';
import { FilterSection, FilterComponent } from '@tl/tl-common';
import { AdministrationsService } from 'src/app/core/services/rest/administration.service';
import { map } from 'rxjs/operators';
import { HttpParams } from '@angular/common/http';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { ApiServiceService } from 'src/app/core/services/rest/api-service.service';
import { ApiServiceOperationService } from 'src/app/core/services/rest/api-service-operation.service';

@Component({
  selector: 'app-log-review-primary-filter',
  templateUrl: './log-review-primary-filter.component.html',
  styleUrls: ['./log-review-primary-filter.component.scss']
})
export class LogReviewPrimaryFilterComponent {
  filterSections: FilterSection[] = [];

  @ViewChild('filter')
  filter: FilterComponent;

  @Input()
  lastLevelChoiceOnly = false;
  @Output()
  selectedValues = new EventEmitter<{ id: number; name: string, data: any, key: string}[]>();

  constructor(
    protected administrationService: AdministrationsService,
    protected apiServiceService: ApiServiceService,//interfaces
    protected apiServiceOperationService: ApiServiceOperationService//operations
  ) {
    this.filterSections.push(
      new FilterSection(
        'registerAdministration',
        ROUTES.ADMINISTRATIONS.title,
        ROUTES.ADMINISTRATIONS.icon,
        this.filterSections,
        () =>
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
        'apiService',
        ROUTES.INTERFACES.title,
        ROUTES.INTERFACES.icon,
        this.filterSections,
        (fs) => {
          let params = new HttpParams();
          params = params.append(
            '$filter',
            `administration.id eq ${fs.selectedId}`
          );
          return this.apiServiceService.getAllNoWrap(params).pipe(
            map((arr) =>
              arr.map((a) => {
                return {
                  id: a.id,
                  name: a.name,
                  data: undefined,
                };
              })
            )
          );
        },
        ROUTES.ADMINISTRATIONS.icon,
        this.selectedValues,
        true,
        true
      )
    );

    this.filterSections.push(
      new FilterSection(
        'apiServiceOperation',
        'Операции',
        'receipt',
        this.filterSections,
        (fs) => {
          let params = new HttpParams();
          params = params.append(
            '$filter',
            `apiService.id eq ${fs.selectedId}`
          );
          return this.apiServiceOperationService.getAllNoWrap(params).pipe(
            map((arr) =>
              arr.map((a) => {
                return {
                  id: a.id,
                  name: a.name,
                  data: undefined,
                };
              })
            )
          );
        },
        'check',
        this.selectedValues,
        true,
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
