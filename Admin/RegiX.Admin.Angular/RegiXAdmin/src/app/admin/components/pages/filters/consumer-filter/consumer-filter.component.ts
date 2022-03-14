import { Component, OnInit, Output, EventEmitter, ViewChild } from '@angular/core';
import { AdministrationsService } from 'src/app/core/services/rest/administration.service';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { map } from 'rxjs/operators';
import { ConsumersService } from 'src/app/core/services/rest/consumers.service';
import { HttpParams } from '@angular/common/http';
import { ConsumerCertificatesService } from 'src/app/core/services/rest/consumer-certificates.service';
import { FilterSection, FilterComponent } from '@tl/tl-common';

@Component({
  selector: 'app-consumer-filter',
  templateUrl: './consumer-filter.component.html',
  styleUrls: ['./consumer-filter.component.scss'],
})
export class ConsumerFilterComponent {
  @ViewChild('filter')
  filter: FilterComponent;

  filterSections: FilterSection[] = [];

  @Output()
  selectedValues = new EventEmitter<
    { id: number; name: string; data: any; key: string}[]
  >();

  constructor(
    protected administrationService: AdministrationsService,
    protected consumersService: ConsumersService,
    protected certificateService: ConsumerCertificatesService
  ) {
    this.filterSections.push(
      new FilterSection(
        'consumerAdministration',
        ROUTES.ADMINISTRATIONS.title,
        ROUTES.ADMINISTRATIONS.icon,
        this.filterSections,
        (fs, self) => {
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
        ROUTES.CONSUMERS.icon,
        this.selectedValues,
        true,
        true,
        true
      )
    );

    this.filterSections.push(
      new FilterSection(
        'consumer',
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
                  data: a.oid,
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
