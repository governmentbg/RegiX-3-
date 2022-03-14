import { Component, OnInit, Output, EventEmitter, ViewChild } from '@angular/core';
import { AdministrationsService } from 'src/app/core/services/rest/administration.service';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { map } from 'rxjs/operators';
import { FilterSection, FilterComponent } from '@tl/tl-common';

@Component({
  selector: 'app-primary-administration-filter',
  templateUrl: './primary-administration-filter.component.html',
  styleUrls: ['./primary-administration-filter.component.scss']
})
export class PrimaryAdministrationFilterComponent {
  @ViewChild('filter')
  filter: FilterComponent;

  filterSections: FilterSection[] = [];
  @Output()
  selectedValues = new EventEmitter<
    { id: number; name: string; data: any; key: string }[]
  >();

  constructor(protected administrationService: AdministrationsService) {
    this.filterSections.push(
      new FilterSection(
        'administration',
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
                  data: undefined,
                };
              })
            )
          ),
        ROUTES.CONSUMERS.icon,
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
