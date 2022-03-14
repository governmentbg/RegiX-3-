import { ConsumerSystemsService } from './../../../services/consumer-systems.service';
import { Component, ViewChild, Output, EventEmitter } from '@angular/core';
import { FilterComponent, FilterSection } from '@tl/tl-common';
import { CONSUMER_ROUTES } from 'src/app/consumer/routes/consumer-static-routes';
import { map } from 'rxjs/operators';

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

  constructor(protected consumerSystemsService: ConsumerSystemsService) {
    this.filterSections.push(
      new FilterSection(
        'consumer-systems',
        CONSUMER_ROUTES.SYSTEMS.title,
        CONSUMER_ROUTES.SYSTEMS.icon,
        this.filterSections,
        () =>
          this.consumerSystemsService.getAllNoWrap().pipe(
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
          CONSUMER_ROUTES.SYSTEMS.icon,
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
