import { Component, OnInit, ViewChild, Output, EventEmitter } from '@angular/core';
import { FilterComponent, FilterSection } from '@tl/tl-common';
import { map } from 'rxjs/operators';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { ConsumersService } from 'src/app/core/services/rest/consumers.service';

@Component({
  selector: 'app-consumer-systems-filter',
  templateUrl: './consumer-systems-filter.component.html',
  styleUrls: ['./consumer-systems-filter.component.scss']
})
export class ConsumerSystemsFilterComponent {

  @ViewChild('filter')
  filter: FilterComponent;
  filterSections: FilterSection[] = [];

  @Output()
  selectedValues = new EventEmitter<
    { id: number; name: string; data: any; key: string }[]
  >();

  constructor(protected consumersService: ConsumersService) {
    this.filterSections.push(
      new FilterSection(
        'consumers',
        ROUTES.CONSUMERS.title,
        ROUTES.CONSUMERS.icon,
        this.filterSections,
        (fs) =>
          this.consumersService.getAllNoWrap().pipe(
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
