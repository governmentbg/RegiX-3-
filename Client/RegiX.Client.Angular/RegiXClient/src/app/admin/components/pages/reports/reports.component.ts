import { Component, OnInit, ViewChild, Injector } from '@angular/core';
import { RemoteComponentWithForm, DisplayValueFilteringOperand } from '@tl/tl-common';
import { ReportModel } from 'src/app/core/models/dto/report.model';
import { ReportsService } from 'src/app/core/services/rest/reports.service';
import { GridRemoteFilteringService } from '@tl/tl-common';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { DisplayValueFormatService } from 'src/app/core/services/display-value-format.service';

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.scss'],
})
export class ReportsComponent extends RemoteComponentWithForm<
  ReportModel,
  ReportsService
> {
  title: string;
  objectName = 'операция';
  public routes = ROUTES;
  public displayValueFilteringOperand = DisplayValueFilteringOperand.instance();

  constructor(
    service: ReportsService,
    injector: Injector,
    public displayValueService: DisplayValueFormatService
  ) {
    super(service, injector);
  }

  ngOnInitImpl() {
    // this.grid.sortingExpressions = [
    //   { fieldName: 'name', dir: SortingDirection.Asc }
    // ];
  }

  protected createRemoteService() {
    this.remoteService = new GridRemoteFilteringService(
      { adapterOperation: 'adapterOperation.displayName' },
      this.service,
      this.grid,
      this.injector
    );
  }

  onShowMenuSelected(event) {}

  protected excelExportMapItem(item: ReportModel) {
    return {
      // Ид: item.id,
      Администрация: item.authority?.displayName,
      Име: item.name,
      Код: item.code,
      'Операция на адаптер': item.adapterOperation?.displayName,
      Активен: item.isActive
    };
  }
}
