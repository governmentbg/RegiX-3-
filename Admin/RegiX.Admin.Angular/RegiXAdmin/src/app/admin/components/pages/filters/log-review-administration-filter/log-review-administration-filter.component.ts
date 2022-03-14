import { Component, OnInit, ViewChild, Input, Output, EventEmitter } from '@angular/core';
import { FilterSection, FilterComponent } from '@tl/tl-common';
import { AdministrationsService } from 'src/app/core/services/rest/administration.service';
import { map } from 'rxjs/operators';
import { HttpParams } from '@angular/common/http';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { ConsumersService } from 'src/app/core/services/rest/consumers.service';
import { ConsumerCertificatesService } from 'src/app/core/services/rest/consumer-certificates.service';

@Component({
  selector: 'app-log-review-administration-filter',
  templateUrl: './log-review-administration-filter.component.html',
  styleUrls: ['./log-review-administration-filter.component.scss']
})
export class LogReviewAdministrationFilterComponent {
  filterSections: FilterSection[] = [];

  @ViewChild('filter')
  filter: FilterComponent;

  @Input()
  lastLevelChoiceOnly = false;
  @Output()
  selectedValues = new EventEmitter<{ id: number; name: string, data: any, key: string}[]>();

  constructor(
    protected administrationService: AdministrationsService,
    protected consumersService: ConsumersService,
    protected consumerCertificatesService: ConsumerCertificatesService
  ) {
    this.filterSections.push(
      new FilterSection(
        'administration',
        ROUTES.ADMINISTRATIONS.title,
        ROUTES.ADMINISTRATIONS.icon,
        this.filterSections,
        (_, self) => {
          let res = new HttpParams();
          if (self.perPage) {
            res = res.append('$skip', (self.index * self.perPage) + '');
            res = res.append('$top', self.perPage + '');
            res = res.append('$count', 'true');
            res = res.append('$orderby', 'name asc');
          }
          if (self.filter) {
            res = res.append(
              '$filter',
              `contains(name, '${self.filter}')`
            );
          }
          return this.administrationService.getAll(res).pipe(
            map((arr) => {
              self.total = arr['total'];
              return arr['data'].map((a) => {
                return {
                  id: a.id,
                  name: a.name,
                  data: undefined,
                };
              });
            }
            )
          );
        },
        ROUTES.REGISTRIES.icon,
        this.selectedValues,
        true,
        true,
        true
      )
    );

    this.filterSections.push(
      new FilterSection(
        'consumers',
        ROUTES.CONSUMERS.title,
        ROUTES.CONSUMERS.icon,
        this.filterSections,
        (fs) => {
          let params = new HttpParams();
          params = params.append(
            '$filter',
            `administration.id eq ${fs.selectedId}`
          );
          return this.consumersService.getAllNoWrap(params).pipe(
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
        'certificates',
        ROUTES.CERTIFICATES.title,
        ROUTES.CERTIFICATES.icon,
        this.filterSections,
        (fs) => {
          let params = new HttpParams();
          params = params.append(
            '$filter',
            `apiServiceConsumer.id eq ${fs.selectedId}`
          );
          return this.consumerCertificatesService.getAllNoWrap(params).pipe(
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
