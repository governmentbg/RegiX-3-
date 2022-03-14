import { Component, OnInit, Injector } from '@angular/core';
import { ExceptionModel } from 'src/app/core/models/dto/exception.model';
import { ExceptionsService } from 'src/app/core/services/rest/exceptions.service';
import { RemoteComponentWithForm } from '@tl/tl-common';
import { SortingDirection } from 'igniteui-angular';
import { GridRemoteFilteringService } from '@tl/tl-common';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { DatеFormatService } from 'src/app/core/services/date-format.service';

@Component({
  selector: 'app-system-errors',
  templateUrl: './system-errors.component.html',
  styleUrls: ['./system-errors.component.scss'],
})
export class SystemErrorsComponent extends RemoteComponentWithForm<
  ExceptionModel,
  ExceptionsService
> {
  public routes = ROUTES;

  constructor(
    service: ExceptionsService,
    injector: Injector,
    public dateFormatService: DatеFormatService
  ) {
    super(service, injector);
  }

  ngOnInitImpl() {
    // this.grid.sortingExpressions = [
    //   { fieldName: 'id', dir: SortingDirection.Desc }
    // ];
  }

  protected createRemoteService() {
    this.remoteService = new GridRemoteFilteringService(
      {},
      this.service,
      this.grid,
      this.injector
    );
  }
}
