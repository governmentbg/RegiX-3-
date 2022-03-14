import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable, ChangeDetectorRef } from '@angular/core';
import {
  FilteringLogic,
  IForOfState,
  SortingDirection,
  IgxGridComponent,
  ISortingExpression,
  IgxTreeGridComponent,
} from 'igniteui-angular';
import { BehaviorSubject, Observable } from 'rxjs';
import { CrudService } from './crud.service';
import { IGridPagerInputParams } from '../components/grid-pager/grid-pager.component';
import { Injector } from '@angular/core';
import { NGXLogger } from 'ngx-logger';

const EMPTY_STRING = '';
const NULL_VALUE = null;
export enum FILTER_OPERATION {
  CONTAINS = 'contains',
  TRUE = 'true',
  FALSE = 'false',
  STARTS_WITH = 'startswith',
  ENDS_WITH = 'endswith',
  EQUALS = 'eq',
  AND = 'and',
  DOES_NOT_EQUAL = 'ne',
  DOES_NOT_CONTAIN = 'not contains',
  GREATER_THAN = 'gt',
  LESS_THAN = 'lt',
  LESS_THAN_EQUAL = 'le',
  GREATER_THAN_EQUAL = 'ge',
}

export class GridRemoteFilteringService<T, CS extends CrudService<T, number>> {
  public pagerParams: IGridPagerInputParams = {
    page: 0,
    perPage: 4,
    totalCount: 0,
  };
  public isLoading: boolean;
  public httpParams: HttpParams;
  public externalParams: HttpParams;

  public _extRemoteData: BehaviorSubject<T[]>;

  protected _prevRequest: any;
  protected logger: NGXLogger;
  protected _service: CS;
  protected _grid: IgxGridComponent | IgxTreeGridComponent

  constructor(
    private sortKeys: any,
    protected service: CS,
    protected grid: IgxGridComponent | IgxTreeGridComponent,
    private injector: Injector
  ) {
    this._service = service;
    this._grid = grid;
    this._extRemoteData = new BehaviorSubject([]);
    this.logger = this.injector.get<NGXLogger>(NGXLogger);
  }

  protected getData(
    virtualizationArgs?: IForOfState,
    filteringArgs?: any,
    sortingArgs?: ISortingExpression[],
    externalParams?: HttpParams,
    cb?: (any) => void
  ): any {
    this.logger.debug('getData:', virtualizationArgs);

    const tmp = this.buildDataUrl(
      virtualizationArgs,
      filteringArgs,
      sortingArgs,
      externalParams
    );
    // remove filter attribute from external attributes,
    // it should be processed in this.buildDataUrl
    if (externalParams) {
      externalParams = externalParams.delete('$filter');
    }

     this.httpParams = new HttpParams({ fromString: tmp });
    if (externalParams) {
      externalParams.keys().forEach((elem) => {
        this.httpParams = this.httpParams.append(elem, externalParams.get(elem));
      });
    }
    this.logger.debug('httpParams', this.httpParams);
    this.isLoading = true;
    
    return this._service.getAll(this.httpParams).subscribe(
      (data: any) => {
        this.isLoading = false;
        this._extRemoteData.next(data.data);
        if (cb) {
          cb(data);
        }
      },
      (error: any) => {
        this.isLoading = false;
      }
    );
  }

  protected buildDataUrl(
    virtualizationArgs: any,
    filteringArgs: any,
    sortingArgs: ISortingExpression[],
    externalParams: HttpParams
  ): string {
    let baseQueryString = `$count=true`;
    let scrollingQuery = EMPTY_STRING;
    let orderQuery = EMPTY_STRING;
    let filterQuery = EMPTY_STRING;
    let query = EMPTY_STRING;
    let filter = EMPTY_STRING;

    if (sortingArgs) {
      orderQuery = this._buildSortExpression(sortingArgs);
    }

    if (filteringArgs && filteringArgs.length > 0) {
      filteringArgs.forEach((columnFilter) => {
        if (filter !== EMPTY_STRING) {
          filter += ` ${FilteringLogic[FilteringLogic.And].toLowerCase()} `;
        }

        filter += this._buildAdvancedFilterExpression(
          columnFilter.filteringOperands,
          columnFilter.operator
        );
      });

      filterQuery = `$filter=${filter}`;
    }

    if (externalParams) {
      const externalFilter = externalParams.get('$filter');
      if (externalFilter) {
        if (filterQuery === EMPTY_STRING) {
          filterQuery = `$filter=${externalFilter}`;
        } else {
          filterQuery = filterQuery + ' and ' + externalFilter;
        }
      }
    }

    if (virtualizationArgs) {
      scrollingQuery = this._buildScrollExpression(virtualizationArgs);
    }

    query += orderQuery !== EMPTY_STRING ? `&${orderQuery}` : EMPTY_STRING;
    query += filterQuery !== EMPTY_STRING ? `&${filterQuery}` : EMPTY_STRING;
    query +=
      scrollingQuery !== EMPTY_STRING ? `&${scrollingQuery}` : EMPTY_STRING;

    baseQueryString += query;

    return baseQueryString;
  }

  private getGridOperandFieldName(fieldName: string): string {
    return this._service.gridFilteringFields()[fieldName]
      ? this._service.gridFilteringFields()[fieldName]
      : fieldName;
  }

  private _buildAdvancedFilterExpression(operands, operator): string {
    let filterExpression = EMPTY_STRING;
    operands.forEach((operand) => {
      let value = operand.searchVal;
      let isNumberValue = typeof value === 'number' ? true : false;
      this.logger.debug('typeof value', value instanceof Date);
      if (value instanceof Date) {
        const offset = value.getTimezoneOffset();
        value = new Date(value.getTime() - (offset * 60 * 1000));
        value = value.toISOString().split('T')[0];
        isNumberValue = true;
      }
      const filterValue = isNumberValue ? value : `'${value}'`;
      const fieldName = this.getGridOperandFieldName(operand.fieldName);
      let filterString;

      if (filterExpression !== EMPTY_STRING) {
        filterExpression += ` ${FilteringLogic[operator].toLowerCase()} `;
      }

      this.logger.debug('operand.condition.name', operand.condition.name);
      this.logger.debug('fitlerValue', filterValue);

      switch (operand.condition.name) {
        case 'contains': {
          filterString = `${FILTER_OPERATION.CONTAINS}(${fieldName}, ${filterValue})`;
          break;
        }
        case 'true': {
          filterString = `${fieldName} ${FILTER_OPERATION.EQUALS}
           ${FILTER_OPERATION.TRUE}`;
          break;
        }
        case 'false': {
          filterString = `${fieldName} ${FILTER_OPERATION.EQUALS} ${FILTER_OPERATION.FALSE}`;
          break;
        }
        case 'startsWith': {
          filterString = `${FILTER_OPERATION.STARTS_WITH}(${fieldName},${filterValue})`;
          break;
        }
        case 'endsWith': {
          filterString = `${FILTER_OPERATION.ENDS_WITH}(${fieldName},${filterValue})`;
          break;
        }
        case 'today': {
          filterString = `${fieldName} ${FILTER_OPERATION.EQUALS} ${new Date().toJSON().substring(0,10)} `;
          break;
        }
        case 'yesterday': {
          let currentDate = new Date();
          currentDate.setDate(currentDate.getDate() - 1);
          filterString = `${fieldName} ${FILTER_OPERATION.EQUALS} ${currentDate.toJSON().substring(0,10)} `;
          break;
        }
        case 'thisMonth': {
          //0..11
          filterString = `month(${fieldName}) ${FILTER_OPERATION.EQUALS} ${(new Date().getMonth() + 1).toString()} ${FILTER_OPERATION.AND} year(${fieldName}) ${FILTER_OPERATION.EQUALS} ${(new Date().getFullYear()).toString()} `;
          break;
        }
        case 'lastMonth': {
          let month = new Date().getMonth();
          let year = new Date().getFullYear();
          if(month == 0){
            month = 12;
            year = year -1;
          }

          filterString = `month(${fieldName}) ${FILTER_OPERATION.EQUALS} ${month} ${FILTER_OPERATION.AND} year(${fieldName}) ${FILTER_OPERATION.EQUALS} ${year} `;
          break;
        }
        case 'nextMonth': {
          let month = new Date().getMonth() + 2;
          let year = new Date().getFullYear();
          if(month > 12){
            month = 1;
            year = year + 1;
          }

          filterString = `month(${fieldName}) ${FILTER_OPERATION.EQUALS} ${month} ${FILTER_OPERATION.AND} year(${fieldName}) ${FILTER_OPERATION.EQUALS} ${year} `;
          break;
        }
        case 'thisYear': {
          filterString = `year(${fieldName}) ${FILTER_OPERATION.EQUALS} ${(new Date().getFullYear()).toString()} `;
          break;
        }
        case 'lastYear': {
          filterString = `year(${fieldName}) ${FILTER_OPERATION.EQUALS} ${(new Date().getFullYear() - 1).toString()} `;
          break;
        }
        case 'nextYear': {
          filterString = `year(${fieldName}) ${FILTER_OPERATION.EQUALS} ${(new Date().getFullYear() + 1).toString()} `;
          break;
        }
        case 'equals': {
          filterString = `${fieldName} ${FILTER_OPERATION.EQUALS} ${filterValue} `;
          break;
        }
        case 'doesNotEqual': {
          filterString = `${fieldName} ${FILTER_OPERATION.DOES_NOT_EQUAL} ${filterValue} `;
          break;
        }
        case 'doesNotContain': {
          filterString = `${FILTER_OPERATION.DOES_NOT_CONTAIN}(${fieldName},${filterValue})`;
          break;
        }
        case 'greaterThan': {
          filterString = `${fieldName} ${FILTER_OPERATION.GREATER_THAN} ${filterValue} `;
          break;
        }
        case 'after':
        case 'greaterThanOrEqualTo': {
          filterString = `${fieldName} ${FILTER_OPERATION.GREATER_THAN_EQUAL} ${filterValue} `;
          break;
        }
        case 'lessThan': {
          filterString = `${fieldName} ${FILTER_OPERATION.LESS_THAN} ${filterValue} `;
          break;
        }
        case 'before':
        case 'lessThanOrEqualTo': {
          filterString = `${fieldName} ${FILTER_OPERATION.LESS_THAN_EQUAL} ${filterValue} `;
          break;
        }
        case 'empty': {
          filterString = `length(${fieldName}) ${FILTER_OPERATION.EQUALS} 0`;
          break;
        }
        case 'notEmpty': {
          filterString = `length(${fieldName}) ${FILTER_OPERATION.GREATER_THAN} 0`;
          break;
        }
        case 'null': {
          filterString = `${fieldName} ${FILTER_OPERATION.EQUALS} ${NULL_VALUE}`;
          break;
        }
        case 'notNull': {
          filterString = `${fieldName} ${FILTER_OPERATION.DOES_NOT_EQUAL} ${NULL_VALUE}`;
          break;
        }
        case 'Администратор': {
          filterString = `${fieldName} ${FILTER_OPERATION.EQUALS} 2`;
          break;
        }
        case 'Нормална': {
          filterString = `${fieldName} ${FILTER_OPERATION.EQUALS} 0`;
          break;
        }
        case 'Публична': {
          filterString = `${fieldName} ${FILTER_OPERATION.EQUALS} 1`;
          break;
        }
        case 'Чернова': {
          filterString = `${fieldName} ${FILTER_OPERATION.EQUALS} 0`;
          break;
        }
        case 'Нов': {
          filterString = `${fieldName} ${FILTER_OPERATION.EQUALS} 1`;
          break;
        }
        case 'Отхвърлен': {
          filterString = `${fieldName} ${FILTER_OPERATION.EQUALS} 2`;
          break;
        }
        case 'Одобрен': {
          filterString = `${fieldName} ${FILTER_OPERATION.EQUALS} 3`;
          break;
        }
      }

      filterExpression += filterString;
    });

    return filterExpression;
  }

  private _buildSortExpression(sortingArgs: ISortingExpression[]): string {
    this.logger.debug('sortingArgs:', sortingArgs);
    const sortingExpressions: string[] = [];
    if (sortingArgs && sortingArgs.length > 0) {
      sortingArgs.forEach((expr) => {
        const str = this.getSortingExpression(expr);
        sortingExpressions.push(str);
      });

      return '$orderby=' + sortingExpressions.join(', ');
    }
    return '';
  }

  private getSortingExpression(sortingArgs: ISortingExpression): string {
    let sortingDirection: string;
    switch (sortingArgs.dir) {
      case SortingDirection.None: {
        sortingDirection = EMPTY_STRING;
        break;
      }
      default: {
        sortingDirection = SortingDirection[sortingArgs.dir].toLowerCase();
        break;
      }
    }
    let fieldName = sortingArgs.fieldName;
    if (this.sortKeys[sortingArgs.fieldName]) {
      fieldName = this.sortKeys[sortingArgs.fieldName];
    }
    return `${fieldName} ${sortingDirection}`;
  }

  private _buildScrollExpression(virtualizationArgs?: IForOfState): string {    
    return `$skip=${virtualizationArgs.startIndex}&$top=${virtualizationArgs.chunkSize}`;
  }

  public excelExportMaxRows = 10000;

  public getExcelExportParams(externalParams?: HttpParams): HttpParams {
    externalParams = this.externalParams;

    const filteringExpr = this._grid.filteringExpressionsTree.filteringOperands;
    const sortingExpr = this._grid.sortingExpressions;
    const tmp = this.buildDataUrl(
      {
        chunkSize: this.excelExportMaxRows,
        startIndex: 0,
      },
      filteringExpr,
      sortingExpr,
      externalParams
    );
    if (externalParams) {
      externalParams = externalParams.delete('$filter');
    }
    let result = new HttpParams({ fromString: tmp });
    if (externalParams) {
      externalParams.keys().forEach((elem) => {
        result = this.httpParams.append(elem, externalParams.get(elem));
      });
    }
    return result;
  }

  /////////////
  public processData(externalParams?: HttpParams) {
    this.externalParams = externalParams;
    
    this.logger.debug('PROCESS DATA', externalParams);
    if (this._prevRequest) {
      this._prevRequest.unsubscribe();
    }

    const filteringExpr = this._grid.filteringExpressionsTree.filteringOperands;
    this.logger.debug(
      'this._grid.sortingExpressions',
      this._grid.sortingExpressions
    );

    const sortingExpr = this._grid.sortingExpressions;

    this._prevRequest = this.getData(
      {
        chunkSize: this.pagerParams.perPage,
        startIndex: this.pagerParams.page * this.pagerParams.perPage,
      },
      filteringExpr,
      sortingExpr,
      externalParams,
      (data) => {
        const obj = Object(data);
        this._grid['totalItemCount'] = obj.data.length;
        this._grid.perPage = obj.perPage;

        this.pagerParams.page = obj.currentPage - 1;
        this.pagerParams.perPage = obj.perPage;
        this.pagerParams.totalCount = obj.total;

        this.setSelectedRows();
      }
    );
  }

  protected setSelectedRows() {
    const selection = this._grid.selectedRows();
    // this._grid.selectRows(this._grid.selectedRows(), true);
    this._grid.deselectAllRows();
    this._grid.selectRows(selection, true);
    this.logger.debug('setSelectedRows', this._grid.selectedRows());
  }

  public formatNumber(value: number) {
    return value.toFixed(2);
  }

  public formatCurrency(value: number) {
    return '$' + value.toFixed(2);
  }

  public ngOnDestroy() {
    if (this._prevRequest) {
      this._prevRequest.unsubscribe();
    }
  }
}
