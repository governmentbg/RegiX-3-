import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';

export interface IGridPagerOutputParams {
  page: number;
  perPage: number;
}

export interface IGridPagerInputParams extends IGridPagerOutputParams {
  totalCount: number;
}

@Component({
  selector: 'tl-grid-pager',
  templateUrl: './grid-pager.component.html',
  styleUrls: ['./grid-pager.component.scss']
})
export class GridPagerComponent implements OnInit {
  public lastPage: boolean;
  public firstPage: boolean;

  private _page = 0;
  private _perPage = 0;
  private _totalCount = 0;

  @Input() public set page(page: number) {
    this._page = page;
    this.buttonDeselection();
  }

  @Input() public set perPage(perPage: number) {
    this._perPage = perPage;
    this.buttonDeselection();
  }

  @Input() public set totalCount(totalCount: number) {
    this._totalCount = totalCount;
    this.buttonDeselection();
  }

  @Output() public pagerChange: EventEmitter<
    IGridPagerOutputParams
  > = new EventEmitter();

  ngOnInit() {}

  get totalPages(): number {
    return Math.ceil(this.totalCount / this.perPage);
  }

  public get page(): number {
    return this._page;
  }

  public get perPage(): number {
    return this._perPage;
  }

  public get totalCount(): number {
    return this._totalCount;
  }

  public paginate(page: number) {
    this._page = page;
    const obj = { page: this.page, perPage: this.perPage };
    this.pagerChange.emit(obj);
    this.buttonDeselection();
  }

  public previousPage() {
    this.paginate(this.page - 1);
  }

  public nextPage() {
    this.paginate(this.page + 1);
  }

  public parseToInt(val) {
    return parseInt(val, 20);
  }

  public selectChange(event) {
    if (this.page > this.totalPages) {
      this.page = this.totalPages - 1;
    }

    this.paginate(this.page);
  }

  private buttonDeselection() {
    if (this.totalPages === 1) {
      this.lastPage = true;
      this.firstPage = true;
    } else if (this.page + 1 >= this.totalPages) {
      this.lastPage = true;
      this.firstPage = false;
    } else if (this.page !== 0 && this.page !== this.totalPages) {
      this.lastPage = false;
      this.firstPage = false;
    } else {
      this.lastPage = false;
      this.firstPage = true;
    }
  }
}
