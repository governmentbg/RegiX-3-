import { Component, ViewChild, Output, EventEmitter } from '@angular/core';
import { FilterComponent, FilterSection } from '@tl/tl-common';
import { ConsumerSystemCertificatesService } from 'src/app/consumer/services/consumer-system-certificates.service';
import { map } from 'rxjs/operators';
import { CONSUMER_ROUTES } from 'src/app/consumer/routes/consumer-static-routes';
import { HttpParams } from '@angular/common/http';
import { EEnvironmentType } from 'src/app/consumer/enums/environment-type.enum';

@Component({
  selector: 'app-consumer-system-certificates-filter',
  templateUrl: './consumer-system-certificates-filter.component.html',
  styleUrls: ['./consumer-system-certificates-filter.component.scss']
})
export class ConsumerSystemCertificatesFilterComponent {
  @ViewChild('filter')
  filter: FilterComponent;
  filterSections: FilterSection[] = [];
  @Output()
  selectedValues = new EventEmitter<
    { id: number; name: string; data: any; key: string }[]
  >();

  constructor(protected consumerSystemCertificatesService: ConsumerSystemCertificatesService) {
    let params = this.createEnviromentFilter();
    this.filterSections.push(
      new FilterSection(
        'consumer-system-certificates',
        CONSUMER_ROUTES.CERTIFICATES.title,
        CONSUMER_ROUTES.CERTIFICATES.icon,
        this.filterSections,
        () =>
          this.consumerSystemCertificatesService.getAllNoWrap(params).pipe(
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
          CONSUMER_ROUTES.CERTIFICATES.icon,
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

  //get all data with environment "PRODUCTION"
  private createEnviromentFilter(): HttpParams {
    let httpParameters = new HttpParams();
    const filteringParam = 'environment eq ' + "'" +EEnvironmentType.PRODUCTION + "'";
    httpParameters = httpParameters.append('$filter', filteringParam);
    return httpParameters; 
  }
}
