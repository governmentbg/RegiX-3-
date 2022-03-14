import { Component, OnInit, ViewChild, Output, EventEmitter } from '@angular/core';
import { FilterComponent, FilterSection } from '@tl/tl-common';
import { AdministrationsService } from 'src/app/core/services/rest/administration.service';
import { ConsumersService } from 'src/app/core/services/rest/consumers.service';
import { ConsumerCertificatesService } from 'src/app/core/services/rest/consumer-certificates.service';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { map } from 'rxjs/operators';
import { HttpParams } from '@angular/common/http';

@Component({
  selector: 'app-certificate-filter',
  templateUrl: './certificate-filter.component.html',
  styleUrls: ['./certificate-filter.component.scss']
})
export class CertificateFilterComponent {
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
                  data: undefined,
                };
              })
            )
          );
        },
        ROUTES.CONSUMERS.icon,
        this.selectedValues,
        false,
        true
      )
    );

    this.filterSections.push(
      new FilterSection(
        'certificate',
        ROUTES.CERTIFICATES.title,
        ROUTES.CERTIFICATES.icon,
        this.filterSections,
        (fs) => {
          let params = new HttpParams();
          params = params.append(
            '$filter',
            `apiServiceConsumer.id eq ${fs.selectedId}`
          );
          return this.certificateService.getAllNoWrap(params).pipe(
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
