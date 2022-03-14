import { Component, OnInit } from '@angular/core';
import { OperationListModel } from 'src/app/core/model/operation-list.model';
import { Router, ActivatedRoute } from '@angular/router';
import { RestClientOperationsListService } from 'src/app/core/services/rest/rest-client-operation-list-service';
import { EDownloadDataType } from 'src/app/core/enums/download-data-type.enum';
import { ConfigurationService } from '@tl/tl-common';
import {
  ConnectedPositioningStrategy,
  HorizontalAlignment,
  VerticalAlignment,
  NoOpScrollStrategy,
} from 'igniteui-angular';
import { ROUTES } from '../../routes/static-routes';

@Component({
  selector: 'app-adapter-detail',
  templateUrl: './adapter-detail.component.html',
  styleUrls: ['./adapter-detail.component.scss'],
})
export class AdapterDetailComponent implements OnInit {
  public readonly ADAPTER_SAMPLE_DATA = EDownloadDataType.ADAPTER_SAMPLE_DATA;
  public readonly ADAPTER_XML_SHEME_DATA =
    EDownloadDataType.ADAPTER_XML_SHEME_DATA;

  public routes = ROUTES;

  isDataLoading = false;
  isDataLoaded = false;

  errorMessage: string;
  adapterName: string;
  adapterInterface: string;
  pageTitle = 'Преглед на операции';

  operations: OperationListModel[] = [];

  constructor(
    private operationService: RestClientOperationsListService,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private configurationService: ConfigurationService
  ) {}

  ngOnInit() {
    this.activatedRoute.params.subscribe((params) => {
      this.adapterName = params['ADAPTER_NAME'];
      this.pageTitle = 'Преглед на операции за: ' + this.adapterName;
    });
    this.getAdaptersByRegister(this.adapterName);
  }

  private getAdaptersByRegister(registerName: string) {
    this.isDataLoading = true;
    this.isDataLoaded = false;
    this.operationService
      .retrieveAllByAdapter({ key: 'adapterName', value: this.adapterName })
      .subscribe(
        (data) => {
          this.operations = data;
          this.adapterInterface = data[0].interface;
          this.isDataLoaded = true;
          this.isDataLoading = false;
        },
        (error) => {
          this.isDataLoaded = false;
          this.isDataLoading = false;
          this.errorMessage = 'Грешка при извличане на данни за регистри.';
        }
      );
  }

  public downloadAdapterData(downloadType: string, adapterInterface: string) {
    let url = this.getServiceDownloadUrl(downloadType);
    url += '/' + adapterInterface;
    this.downloadFile(url, null);
  }

  public onRegistryMenuSelected(event: any) {
    this.downloadAdapterData(event.newSelection.value, this.adapterInterface);
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
}
