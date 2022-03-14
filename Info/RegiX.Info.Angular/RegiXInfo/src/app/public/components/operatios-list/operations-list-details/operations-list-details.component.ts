import { RestClientOperationsListService } from 'src/app/core/services/rest/rest-client-operation-list-service';
import { AdapterModel } from 'src/app/core/model/regix/adapter.model';
import {
  Component,
  OnInit,
  Input,
  ViewChildren,
  QueryList,
} from '@angular/core';
import { EOperationType } from 'src/app/core/enums/operation-type.enum';
import { OperationModel } from 'src/app/core/model/regix/operation.model';
import {
  IgxExpansionPanelComponent,
  IExpansionPanelEventArgs,
  ConnectedPositioningStrategy,
  HorizontalAlignment,
  VerticalAlignment,
  NoOpScrollStrategy,
} from 'igniteui-angular';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { OperationDetailsModel } from 'src/app/core/model/operation-details.model';
import { ConfigurationService } from '@tl/tl-common';
import { EDownloadDataType } from 'src/app/core/enums/download-data-type.enum';
import { ROUTES } from 'src/app/public/routes/static-routes';

@Component({
  selector: 'app-operations-list-details',
  templateUrl: './operations-list-details.component.html',
  styleUrls: ['./operations-list-details.component.scss'],
})
export class OperationsListDetailsComponent implements OnInit {
  readonly OPERATION_REQUEST = EOperationType.Request;
  readonly OPERATION_RESPONSE = EOperationType.Response;
  readonly OPERATION = ROUTES.OPERATIONS_VIEW;

  readonly OPERATION_SAMPLE_DATA = EDownloadDataType.OPERATION_SAMPLE_DATA;
  readonly OPERATION_XML_SHEME_DATA =
    EDownloadDataType.OPERATION_XML_SHEME_DATA;

  isDataLoading = false;
  isDataLoaded = false;
  errorMessage: string;
  pageTitle = 'Преглед на операция';

  operationDetail: OperationDetailsModel;
  adapter: AdapterModel = new AdapterModel();

  adapterInterface: string; //interface
  operationName: string; //interface

  // @ViewChildren(IgxExpansionPanelComponent)
  // public accordion: QueryList<IgxExpansionPanelComponent>;

  public overlaySettings = {
    positionStrategy: new ConnectedPositioningStrategy({
      horizontalDirection: HorizontalAlignment.Left,
      horizontalStartPoint: HorizontalAlignment.Right,
      verticalStartPoint: VerticalAlignment.Bottom,
    }),
    scrollStrategy: new NoOpScrollStrategy(),
  };

  public menuOverlaySettings = {
    positionStrategy: new ConnectedPositioningStrategy({
      horizontalDirection: HorizontalAlignment.Left,
      verticalDirection: VerticalAlignment.Top,
      horizontalStartPoint: HorizontalAlignment.Right,
      verticalStartPoint: VerticalAlignment.Top,
    }),
    scrollStrategy: new NoOpScrollStrategy(),
  };

  constructor(
    private activatedRoute: ActivatedRoute,
    private location: Location,
    private operationListService: RestClientOperationsListService,
    private configurationService: ConfigurationService
  ) {
    this.activatedRoute.params.subscribe((params) => {
      this.operationName = params['OPERATION_NAME'];
      this.adapterInterface = params['INTERFACE'];
      //this.pageTitle = this.operationDetail.Description; // "Преглед на операция: " + this.operationName;
      this.adapter.interface = this.adapterInterface;
      if (!this.adapterInterface) {
        this.location.back();
      }
    });

    this.getOperationByName();
  }

  ngOnInit() {

  }

  private getOperationByName() {
    this.isDataLoading = true;
    this.isDataLoaded = false;
    this.operationListService.retrieveByName(this.adapterInterface + '.' + this.operationName).subscribe((data) => {
      this.operationDetail = data;
      this.pageTitle = this.operationDetail.description;
      this.isDataLoaded = true;
      this.isDataLoading = false;
    }, (error) => {
      this.isDataLoaded = false;
      this.isDataLoading = false;
      this.errorMessage = 'Грешка при извличане на данни за операция.';
    });
    ;
  }

  public onRegistryMenuSelected(event: any) {
    this.downloadOperationData(event.newSelection.value);
  }

  private downloadOperationData(
    downloadType: string
  ) {
    let url = this.getServiceDownloadUrl(downloadType);
    url += '/' + this.adapterInterface;
    url += '.' + this.operationName;
    this.downloadFile(url, null);
  }

  private getServiceDownloadUrl(downloadType: string) {
    let url = this.configurationService.getServiceUrl();
    switch (downloadType) {
      case EDownloadDataType.ADAPTER_SAMPLE_DATA:
        url += '/api/download-info/adapters/samples';
        break;
      case EDownloadDataType.ADAPTER_XML_SHEME_DATA:
        url += '/api/download-info/adapters/xsd';
        break;
      case EDownloadDataType.OPERATION_SAMPLE_DATA:
        url += '/api/download-info/operations/samples';
        break;
      case EDownloadDataType.OPERATION_XML_SHEME_DATA:
        url += '/api/download-info/operations/xsd';
        break;
    }
    return url;
  }

  private downloadFile(url: string, filename: string) {
    const a = document.createElement('a');
    a.href = url;
    a.target = '_blank';
    // a.setAttribute("download", filename);
    a.click();
  }

  // public onHeaderInteraction(event: IExpansionPanelEventArgs) {
  //   const expandedPanels = this.accordion.filter((panel) => !panel.collapsed);
  //   expandedPanels.forEach((expandedPanel) => {
  //     if (expandedPanel.id !== event.panel.id) {
  //       expandedPanel.collapse();
  //     }
  //   });
  // }
}
