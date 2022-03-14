import { Component, OnInit, Input, Output, EventEmitter, ViewChild } from '@angular/core';
import { AdministrationsService } from 'src/app/core/services/rest/administration.service';
import { map } from 'rxjs/operators';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { FilterSection, FilterComponent } from '@tl/tl-common';
import { HttpParams } from '@angular/common/http';

@Component({
  selector: 'app-administrations-filter',
  templateUrl: './administrations-filter.component.html',
  styleUrls: ['./administrations-filter.component.scss'],
})
export class AdministrationsFilterComponent {
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
  }

  public loadFirstSection(): void {
    this.filter.loadFirstSection();
  }

  selectedValuesChange($event) {
    this.selectedValues.emit($event);
  }
}
