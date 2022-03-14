import { DisplayValueFormatService } from './../../../../core/services/display-value-format.service';
import { DatеFormatService } from '../../../../core/services/datе-format.service';
import { Component, OnInit, Injector } from '@angular/core';
import { RemoteComponentWithForm, DisplayValueFilteringOperand } from '@tl/tl-common';
import { GridRemoteFilteringService } from '@tl/tl-common';
import { AuditTableWithDataModel } from 'src/app/core/models/dto/audit-table-with-data.model';
import { AuditTableWithDataService } from 'src/app/core/services/rest/audit-table-with-data.service';
import { ROUTES } from 'src/app/admin/routes/static-routes';

@Component({
  selector: 'app-audit',
  templateUrl: './audit.component.html',
  styleUrls: ['./audit.component.scss']
})
export class AuditComponent extends RemoteComponentWithForm<
  AuditTableWithDataModel,
  AuditTableWithDataService
> {
  title: string;
  objectName = 'одит на таблица';
  public routes = ROUTES;
  public displayValueFilteringOperand = DisplayValueFilteringOperand.instance();

  constructor(
    service: AuditTableWithDataService,
    injector: Injector,
    public dateFormatService: DatеFormatService,
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
      { authority: 'authority.displayName' },
      this.service,
      this.grid,
      this.injector
    );
  }
 
  onShowMenuSelected(event) {}
}
