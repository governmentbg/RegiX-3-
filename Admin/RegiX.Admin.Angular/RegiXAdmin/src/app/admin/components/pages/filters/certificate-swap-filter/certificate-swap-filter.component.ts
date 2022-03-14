import { HttpParams } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { FilterComponent, FilterSection } from '@tl/tl-common';
import { map } from 'rxjs/operators';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { ConsumerCertificatesService } from 'src/app/core/services/rest/consumer-certificates.service';

@Component({
  selector: 'app-certificate-swap-filter',
  templateUrl: './certificate-swap-filter.component.html',
  styleUrls: ['./certificate-swap-filter.component.scss']
})
export class CertificateSwapFilterComponent  {
  @ViewChild('filter')
  filter: FilterComponent;
  filterSections: FilterSection[] = [];
  @Output()
  selectedValues = new EventEmitter<
    { id: number; name: string; data: any; key: string }[]
  >();

  constructor(protected certificateService: ConsumerCertificatesService) {}

  public loadFirstSection(): void {
    this.filter.loadFirstSection();
  }

  selectedValuesChange($event) {
    this.filter.selectedValues.emit($event);
  }
}
