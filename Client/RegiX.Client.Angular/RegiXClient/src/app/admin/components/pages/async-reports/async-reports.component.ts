import { Component, OnInit, Injector } from '@angular/core';
import { RemoteComponentWithForm} from '@tl/tl-common';
import { GridRemoteFilteringService} from '@tl/tl-common';
import { AsyncReportModel } from 'src/app/core/models/dto/async-report.model';
import { AsyncReportsService } from 'src/app/core/services/rest/async-reports.service';
import { ToastService } from '@tl/tl-common';
import { ROUTES } from 'src/app/admin/routes/static-routes';

@Component({
  selector: 'app-async-reports',
  templateUrl: './async-reports.component.html',
  styleUrls: ['./async-reports.component.scss']
})
export class AsyncReportsComponent extends RemoteComponentWithForm<
  AsyncReportModel,
  AsyncReportsService
> {
title: string;
objectName = 'чакаща услуга';
isPolling = false;
public routes = ROUTES;

constructor(service: AsyncReportsService, injector: Injector) {
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

poll(item: AsyncReportModel, cell?) {
  this.isPolling = true;
  this.service.poll(item.id).subscribe( r => {
    this.isPolling = false;
    const pollResult = new AsyncReportModel(r);
    if (pollResult.receivedOn) {
      // TODO: This code doesn't refresh the cell
      item.receivedOn = pollResult.receivedOn;
      this.toastService.showMessage('Резултатът е готов!');
    } else {
      this.toastService.showMessage('Резултатът все още не е готов!');
    }
  },
  e => {
    this.isPolling = false;
    this.toastService.showMessage('Грешка при извличане на резултат!');
  });
}

onShowMenuSelected(event) {}
}
