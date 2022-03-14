import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Input } from '@angular/core';

export class FilterSection {
  sequence: number;
  list: any[];
  originalList: any[];
  selectedId: number;
  selectedName: string;
  selectedData: any;
  actions: any[];
  allSections: FilterSection[];
  sectionIcon: string;
  itemIcon: string;
  sectionName: string;
  isLoading = false;
  allowFiltering = false;
  anyLevelChoice = false;
  key: string;
  // allowAdd = false;
  // addFormVisible = false;
  oDataQueryEnabled: boolean;
  perPage: number;
  index: number;
  total: number;
  filter: string;

  readDataImp: (
    prev: FilterSection,
    self?: FilterSection
  ) => Observable<{ id: number; name: string, data: any }[]>;
  selectedItemsEmitter: EventEmitter<{ id: number; name: string, data: any, key: string }[]>;

  constructor(
    key: string,
    sectionName: string,
    sectionIcon: string,
    allSections: FilterSection[],
    readDataImp: (
      prev: FilterSection,
      self?: FilterSection
    ) => Observable<{ id: number; name: string, data: any }[]>,
    itemIcon: string,
    selectedItemsEmitter: EventEmitter<{ id: number; name: string, data: any, key: string }[]>,
    allowFiltering?: boolean,
    anyLevelChoice?: boolean,
    oDataQueryEnabled?: boolean
  ) {
    this.key = key;
    this.sectionName = sectionName;
    this.sectionIcon = sectionIcon;
    this.allSections = allSections;
    this.sequence = allSections.length;
    this.itemIcon = itemIcon;
    this.readDataImp = readDataImp;
    this.selectedItemsEmitter = selectedItemsEmitter;
    this.allowFiltering = allowFiltering;
    this.anyLevelChoice = anyLevelChoice;
    this.oDataQueryEnabled = oDataQueryEnabled;
    if (oDataQueryEnabled) {
      this.perPage = 10;
      this.index = 0;
    }
  }

  pagerChange(event: any) {
    this.index = event.page;
    this.perPage = event.perPage;
    this.readData();
  }

  clearSearchInput(input: any) {
    input.value = '';
    this.filterChanged('');
  }

  filterChanged(filter: string) {
    if (this.oDataQueryEnabled) {
      if (this.filter !== filter) {
        this.filter = filter;
        this.index = 0;
        this.readData();
      }
    } else {
      if (filter) {
        this.list = this.originalList.filter( l => l.name.toLowerCase().includes(filter.toLowerCase()));
      } else {
        this.list = [...this.originalList];
      }
    }
  }

  public readData(): void {
    this.isLoading = true;
    const prevSection =
      this.sequence !== 0 ? this.allSections[this.sequence - 1] : undefined;
    this.readDataImp(prevSection, this)
      .pipe(
        map((arr) =>
          arr.map((res) => {
            return {
              reference: {
                title: res.name,
                icon: this.itemIcon,
                navigate: (route, args, routeActivated) => {
                  this.navigateImp(res);
                },
              },
              id: res.id,
              name: res.name,
              data: res.data
            };
          })
        )
      )
      .subscribe(
        (res) => {
          this.isLoading = false;
          this.list = [];
          this.list.push(...res);
          this.originalList = [];
          this.originalList.push(...res);
          if (
            this.list.length === 1 &&
            (this.oDataQueryEnabled === undefined ||  (this.oDataQueryEnabled && this.index === 0 )) &&
            this.sequence < this.allSections.length - 1
          ) {
            this.navigateImp(this.list[0]);
          }
        },
        (error) => {
          this.isLoading = false;
        }
      );
  }

  check() {
    this.selectedItemsEmitter.emit(
      this.allSections.filter((s, i) => i <= this.sequence).map((s) => {
        return { id: s.selectedId, name: s.selectedName, data: s.selectedData, key: s.key };
      })
    );
  }

  add() {
    // this.addFormVisible = true;
  }

  navigateImp(res: { id: number; name: string; data: any }) {
    this.selectedId = res.id;
    this.selectedName = res.name;
    this.selectedData = res.data;
    this.list = null;
    if (this.sequence + 1 < this.allSections.length) {
      this.allSections[this.sequence + 1].readData();
    }
    if (this.sequence === this.allSections.length - 1) {
      this.check();
    }
    this.actions = [
      {
        reference: {
          route: [''],
          title: 'Изчисти',
          icon: 'clear',
          permissions: [],
          navigate: (r, a, ac) => {
            this.filter = '';
            this.clear();
            this.readData();
          },
          staticRoute: (a) => [],
          relativeRoute: (a) => [],
        },
      },
    ];
  }

  public clear(): void {
    this.allSections.forEach((fs, index) => {
      if (index >= this.sequence) {
        this.allSections[index].internalClear();
      }
    });
  }
  public internalClear(): void {
    this.selectedId = null;
    this.selectedName = null;
    this.actions = null;
    this.list = null;
  }
}

@Component({
  selector: 'tl-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.scss']
})
export class FilterComponent implements OnInit {
  @Input()
  filterSections: FilterSection[] = [];
  @Input()
  lastLevelChoiceOnly = false;
  @Input()
  displayDensity = 'comfortable';
  @Output()
  selectedValues = new EventEmitter<{ id: number; name: string, data: any, key: string}[]>();

  constructor() { }

  ngOnInit(): void {
    this.filterSections.forEach( s => {
       s.anyLevelChoice = !this.lastLevelChoiceOnly;
    });
  }

  public loadFirstSection(): void {
    if (!this.filterSections[0].selectedId) {
      this.filterSections[0].readData();
    }
  }
}
