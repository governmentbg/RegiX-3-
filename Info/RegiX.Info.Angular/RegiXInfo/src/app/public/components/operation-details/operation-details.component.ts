import {
  Component,
  OnInit,
  Input,
  QueryList,
  ViewChildren
} from '@angular/core';
import {
  IExpansionPanelEventArgs,
  IgxExpansionPanelComponent,
  ConnectedPositioningStrategy,
  HorizontalAlignment,
  VerticalAlignment,
  NoOpScrollStrategy
} from 'igniteui-angular';
import { OperationModel } from 'src/app/core/model/regix/operation.model';
import { AdapterModel } from 'src/app/core/model/regix/adapter.model';
import { EOperationType } from 'src/app/core/enums/operation-type.enum';
import { EDownloadDataType } from 'src/app/core/enums/download-data-type.enum';
import { ROUTES } from '../../routes/static-routes';

@Component({
  selector: 'app-operation-details',
  templateUrl: './operation-details.component.html',
  styleUrls: ['./operation-details.component.scss']
})
export class OperationDetailsComponent implements OnInit {

  readonly OPERATION_REQUEST = EOperationType.Request;
  readonly OPERATION_RESPONSE = EOperationType.Response;

  @Input()
  operationDetail: OperationModel;

  @Input()
  adapter: AdapterModel;

  @ViewChildren(IgxExpansionPanelComponent)
  public accordion: QueryList<IgxExpansionPanelComponent>;

  constructor() {}

  ngOnInit() {}

  public onHeaderInteraction(event: IExpansionPanelEventArgs) {
    const expandedPanels = this.accordion.filter(panel => !panel.collapsed);
    expandedPanels.forEach(expandedPanel => {
      if (expandedPanel.id !== event.panel.id) {
        expandedPanel.collapse();
      }
    });
  }
}
