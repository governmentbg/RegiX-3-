import { RegisterListModel } from './../../../../core/model/register-list.model';
import { Component, OnInit } from '@angular/core';
import { RestClientRegistersService } from 'src/app/core/services/rest/rest-client-register-service';
import { Router, ActivatedRoute } from '@angular/router';
import { ROUTES } from 'src/app/public/routes/static-routes';
import { RegisterModel } from 'src/app/core/model/regix/register.model';
import { OperationModel } from 'src/app/core/model/regix/operation.model';
import {
  ConnectedPositioningStrategy,
  HorizontalAlignment,
  NoOpScrollStrategy,
  VerticalAlignment,
  IgxIconService,
} from 'igniteui-angular';
import { EDownloadDataType } from 'src/app/core/enums/download-data-type.enum';
import { AdapterModel } from 'src/app/core/model/regix/adapter.model';
import { ConfigurationService, TLRouteReference, TlRouteArguments } from '@tl/tl-common';
import { RestClientAdministrationsService } from 'src/app/core/services/rest/rest-client-administrations-service';

@Component({
  selector: 'app-register-list',
  templateUrl: './register-list.component.html',
  styleUrls: ['./register-list.component.scss'],
})
export class RegisterListComponent implements OnInit {
  isDataLoading = false;
  isDataLoaded = false;

  errorMessage: string;
  pageTitle = 'Регистри';
  admCode: string;
  public administrationName: string;

  filtered = false;
  filterActions: {
    reference: TLRouteReference;
    args?: TlRouteArguments;
    title?: string;
    icon?: string;
    permissions?: string[];
  }[];

  registries: RegisterModel[] = [];
  registriesReference: any[] = [];

  routes = ROUTES;

  public overlaySettings = {
    positionStrategy: new ConnectedPositioningStrategy({
      horizontalDirection: HorizontalAlignment.Left,
      horizontalStartPoint: HorizontalAlignment.Right,
      verticalStartPoint: VerticalAlignment.Bottom,
    }),
    scrollStrategy: new NoOpScrollStrategy(),
  };

  readonly OPERATION_SAMPLE_DATA = EDownloadDataType.OPERATION_SAMPLE_DATA;
  readonly OPERATION_XML_SHEME_DATA =
    EDownloadDataType.OPERATION_XML_SHEME_DATA;

  public readonly ADAPTER_SAMPLE_DATA = EDownloadDataType.ADAPTER_SAMPLE_DATA;
  public readonly ADAPTER_XML_SHEME_DATA =
    EDownloadDataType.ADAPTER_XML_SHEME_DATA;

  constructor(
    private registerService: RestClientRegistersService,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private configurationService: ConfigurationService,
    private administrationService: RestClientAdministrationsService
  ) {
    this.activatedRoute.params.subscribe((params) => {
      this.admCode = params['ADM_CODE'] ? params['ADM_CODE'] : '-';
      if (this.admCode !== '-') {
        this.filtered = true;
        this.filterActions = [{
          reference: this.routes.REGISTRIES,
          args: {':ADM_CODE': '-'},
          title: 'Премахни филтър',
          icon: 'clear'
        }];
        console.log(this.filterActions);
        this.administrationService
          .retrieveByCode(this.admCode)
          .subscribe((r) => {
            this.administrationName = r.name;
          });
      } else {
        this.filtered = false;
      }
      this.readRegisters();
    });
  }

  readRegisters() {
    this.isDataLoading = true;
    this.isDataLoaded = false;
    this.registerService.retrieveByAdministrationCode(this.admCode).subscribe(
      (data) => {
        this.registries = data;
        this.registriesReference = data.map((r) => {
          return {
            Name: r.name,
            Description: r.description,
            Adapters: r.adapters.map((a) => {
              return {
                Interface: a.interface,
                Name: a.name,
                Version: a.version,
                Operations: a.operations.map((o) => {
                  return {
                    reference: this.routes.OPERATIONS_VIEW,
                    args: {
                      ':INTERFACE': a.interface,
                      ':OPERATION_NAME': o.fullName,
                    },
                    title: o.description,
                  };
                }),
              };
            }),
          };
        });
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

  public onRegistryMenuSelected(event: any, adapter: any) {
    this.downloadAdapterData(event.newSelection.value, adapter);
  }

  ngOnInit() {}

  private downloadAdapterData(downloadType: string, adapter: any) {
    let url = this.getServiceDownloadUrl(downloadType);
    url += '/' + adapter.Interface;
    this.downloadFile(url, null);
  }

  private downloadOperationData(
    downloadType: string,
    adapter: AdapterModel,
    operation: OperationModel
  ) {
    let url = this.getServiceDownloadUrl(downloadType);
    url += '/' + adapter.interface;
    url += '.' + operation.fullName;
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
}
