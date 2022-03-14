import { Component, OnInit, Injector, Output, Input, EventEmitter } from '@angular/core';
import { AdapterOperationModel } from 'src/app/core/models/dto/adapter-operation.model';
import { AdapterOperationsService } from 'src/app/core/services/rest/adapter-operations.service';
import { RemoteComponentWithForm} from '@tl/tl-common';
import { GridRemoteFilteringService} from '@tl/tl-common';
import { IgxDialogComponent } from 'igniteui-angular';
import { DisplayValue } from 'src/app/core/models/display-value.model';

@Component({
  selector: 'app-adapter-operations',
  templateUrl: './adapter-operations.component.html',
  styleUrls: ['./adapter-operations.component.scss']
})
export class AdapterOperationsComponent  extends RemoteComponentWithForm<
AdapterOperationModel,
AdapterOperationsService
> {
title: string;
objectName = 'операция';

@Input()
selected: DisplayValue  = undefined;

@Output()
selectedChange = new EventEmitter<DisplayValue>();

@Input()
dialog: IgxDialogComponent;


constructor(service: AdapterOperationsService, injector: Injector) {
  super(service, injector);
  this.defaultRowsPerPage = 10;
}

ngOnInitImpl() {
  // this.grid.sortingExpressions = [
  //   { fieldName: 'name', dir: SortingDirection.Asc }
  // ];
}

protected createRemoteService() {
  this.remoteService = new GridRemoteFilteringService(
    { adapterOperation: 'adapterOperation.displayName'
    },
    this.service,
    this.grid,
    this.injector
  );
}

onSelect(selectedId: number, name: string) {
  this.selected = new DisplayValue({id: selectedId, displayName: name});
  this.selectedChange.emit(this.selected);
  this.dialog.close();
}
}
