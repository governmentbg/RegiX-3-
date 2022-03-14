import { Component, OnInit, ViewChild, Output, EventEmitter } from '@angular/core';
import { FilterComponent, FilterSection } from '@tl/tl-common';
import { AdministrationsService } from 'src/app/core/services/rest/administration.service';
import { map } from 'rxjs/operators';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { HttpParams } from '@angular/common/http';

@Component({
  selector: 'app-administrations-filter',
  templateUrl: './administrations-filter.component.html',
  styleUrls: ['./administrations-filter.component.scss']
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
    // Hard coded title and icon used because the filter is used in the signup
    // form and the routes are not yet generated.
    this.filterSections.push(
      new FilterSection(
        'administration',
        'Администрации',
        'account_balance',
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
              `contains(name, '${self.filter}') and isMultitenantAuthority eq true`
            );
          } else {
            res = res.append(
              '$filter',
              `isMultitenantAuthority eq true`
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
        'account_balance',
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
