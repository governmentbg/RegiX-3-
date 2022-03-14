import { ConsumerCertificatesService } from './../../../../../core/services/rest/consumer-certificates.service';
import { Component, OnInit, ViewChild, Output, EventEmitter } from '@angular/core';
import { FilterComponent, FilterSection } from '@tl/tl-common';
import { map } from 'rxjs/operators';
import { ROUTES } from 'src/app/admin/routes/static-routes';

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

  constructor(protected consumerCertificates: ConsumerCertificatesService) {
    this.filterSections.push(
      new FilterSection(
        'consumerSystemCertificates',
        ROUTES.CERTIFICATES.title,
        ROUTES.CERTIFICATES.icon,
        this.filterSections,
        (fs) =>
          this.consumerCertificates.getAllNoWrap().pipe(
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
        ROUTES.CERTIFICATES.icon,
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
