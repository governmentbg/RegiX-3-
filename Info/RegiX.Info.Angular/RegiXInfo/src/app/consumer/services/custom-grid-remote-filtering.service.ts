import { Injectable, Injector } from '@angular/core';
import { GridRemoteFilteringService } from '@tl/tl-common';
import { CertificateOperationAccessModel } from '../models/certificate-operation-access.model';
import { CertificateOperationAccessService } from './certificate-operation-access.service';
import { IForOfState, ISortingExpression } from 'igniteui-angular';
import { HttpParams } from '@angular/common/http';


export class CustomGridRemoteFilteringService extends GridRemoteFilteringService<
  CertificateOperationAccessModel,
  CertificateOperationAccessService
> {
  constructor(
    sortKeys: any,
    service: CertificateOperationAccessService,
    grid: any,
    injector: Injector
  ) {
    super(sortKeys, service, grid, injector);
  }

  protected getDataCerID(
    certId: number,
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

    let httpParams = new HttpParams({ fromString: tmp });
    if (externalParams) {
      externalParams.keys().forEach((elem) => {
        httpParams = httpParams.append(elem, externalParams.get(elem));
      });
    }
    this.logger.debug('httpParams', httpParams);
    this.isLoading = true;
    return this._service.getAllByCertificate(certId, httpParams).subscribe(
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

  /////////////
  processDataCertId(certId: number,externalParams?: HttpParams) {
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

    this._prevRequest = this.getDataCerID(certId,
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
}
