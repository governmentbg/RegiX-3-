import {
  Component,
  OnInit,
  QueryList,
  ViewChildren,
  OnDestroy,
  ViewChild,
  AfterViewInit
} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import {
  NoOpScrollStrategy,
  ConnectedPositioningStrategy,
  HorizontalAlignment,
  VerticalAlignment,
  IgxExpansionPanelComponent,
  IExpansionPanelEventArgs,
  OverlaySettings,
  IgxSelectComponent,
  PositionSettings,
  AbsoluteScrollStrategy
} from 'igniteui-angular';
import { AgencyModel } from 'src/app/core/model/regix/agency.model';
import { Subscription, Observable, forkJoin } from 'rxjs';
import { RestClientAdministrationsService } from 'src/app/core/services/rest/rest-client-administrations-service';
import { RestClientAdapterService } from 'src/app/core/services/rest/rest-client-adapter-service';
import { AdapterModel } from 'src/app/core/model/regix/adapter.model';
import { OperationModel } from 'src/app/core/model/regix/operation.model';
import { RestClientXmlService } from 'src/app/core/services/rest/rest-client-xml-service';
import { EXmlFileType } from 'src/app/core/enums/xml-file-type.enum';
import { EDownloadDataType } from 'src/app/core/enums/download-data-type.enum';
import { ConfigurationService } from '@tl/tl-common';
import { ROUTES } from '../../routes/static-routes';

@Component({
  selector: 'app-registers',
  templateUrl: './registers.component.html',
  styleUrls: ['./registers.component.scss']
})
export class RegistersComponent implements OnInit, OnDestroy, AfterViewInit {
  agencyId: string;
  agencyModel: AgencyModel = null;
  agencySubscription: Subscription;
  adapterSubscription: Subscription;
  errorMessage = '';
  isAgencyDataLoading = false;

  agencies: AgencyModel[] = [];
  agencySelected: AgencyModel;
  customOverlaySettings: OverlaySettings;

  @ViewChild(IgxSelectComponent, { static: true })
  public igxSelect: IgxSelectComponent;

  readonly OPERATION_SAMPLE_DATA = EDownloadDataType.OPERATION_SAMPLE_DATA;
  readonly OPERATION_XML_SHEME_DATA =
    EDownloadDataType.OPERATION_XML_SHEME_DATA;

  public readonly ADAPTER_SAMPLE_DATA = EDownloadDataType.ADAPTER_SAMPLE_DATA;
  public readonly ADAPTER_XML_SHEME_DATA =
    EDownloadDataType.ADAPTER_XML_SHEME_DATA;

  public overlaySettings = {
    positionStrategy: new ConnectedPositioningStrategy({
      horizontalDirection: HorizontalAlignment.Left,
      horizontalStartPoint: HorizontalAlignment.Right,
      verticalStartPoint: VerticalAlignment.Bottom
    }),
    scrollStrategy: new NoOpScrollStrategy()
  };

  @ViewChildren(IgxExpansionPanelComponent)
  public accordion: QueryList<IgxExpansionPanelComponent>;

  public menuOverlaySettings = {
    positionStrategy: new ConnectedPositioningStrategy({
      horizontalDirection: HorizontalAlignment.Left,
      horizontalStartPoint: HorizontalAlignment.Right,
      verticalStartPoint: VerticalAlignment.Bottom
    }),
    scrollStrategy: new NoOpScrollStrategy()
  };

  constructor(
    private administrationService: RestClientAdministrationsService,
    private adapterService: RestClientAdapterService,
    private xmlService: RestClientXmlService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private configurationService: ConfigurationService
  ) {}

  ngAfterViewInit() {}

  ngOnInit() {
    this.updateInput();
    this.isAgencyDataLoading = true;
    this.activatedRoute.params.subscribe(params => {
      this.agencyId = params['AGENCY_ID'];
      this.readAdapterDetail();
    });
  }

  private updateInput() {
    if (this.igxSelect) {
      const positionSettings: PositionSettings = {
        //closeAnimation: scaleOutBottom,
        horizontalDirection: HorizontalAlignment.Right,
        horizontalStartPoint: HorizontalAlignment.Left,
        //openAnimation: scaleInTop,
        target: this.igxSelect.inputGroup.element.nativeElement,
        verticalDirection: VerticalAlignment.Bottom,
        verticalStartPoint: VerticalAlignment.Bottom
      };
      this.customOverlaySettings = {
        positionStrategy: new ConnectedPositioningStrategy(positionSettings),
        scrollStrategy: new AbsoluteScrollStrategy()
      };
    }
  }

  setToNull(select: IgxSelectComponent) {
    select.value = null;
  }

  onAgencyChange(event: any) {
    const agency: AgencyModel = new AgencyModel(event.newSelection.value);
    if (agency.acronym) {
      ROUTES.AGENCIES_VIEW.navigate(this.router, {':AGENCY_ID':  agency.acronym }, this.activatedRoute);
    }
  }

  ngOnDestroy() {
    if (this.agencySubscription) {
      this.agencySubscription.unsubscribe();
    }
  }

  private readAdapterDetail() {
    this.errorMessage = '';
    this.agencySubscription = this.administrationService
      .retrieveAll()
      .subscribe(
        (data: AgencyModel[]) => {
          const agencies = data;
          this.agencies = data;
          if (agencies && agencies.length > 0) {
            const found = agencies.find(t => t.acronym === this.agencyId);
            if (found) {
              this.agencyModel = found;
              this.agencySelected = found;
              this.readAdapterData();
              return;
            }
          }
          ROUTES.HOME.navigate(this.router, {}, this.activatedRoute);
        },
        error => {
          this.isAgencyDataLoading = false;
          this.errorMessage = 'Грешка при извличане на данни за администрация.';
          console.log(error);
        }
      );
  }

  private readAdapterData() {
    const observables: Observable<any>[] = [];
    this.agencyModel.registers.forEach(r => {
      const adapters = r.adapters;
      if (adapters) {
        adapters.forEach(a => {
          const adapterName = a.name;

          const obj = this.adapterService.retrieveOne(adapterName);
          observables.push(obj);
        });
      }
    });

    forkJoin(observables).subscribe(
      (data: AdapterModel[]) => {
        this.isAgencyDataLoading = false;

        this.agencyModel.registers.map(r => {
          const currAdapters = r.adapters;
          currAdapters.forEach(a => {
             const adapterName = a.name;
             const adp = data.find(d => d.name == adapterName);
             a.operations = adp.operations;
          })
        });

        const adapters = this.agencyModel.registers.map(r => r.adapters);
        const allAdapters = [].concat.apply([], adapters);

         data.forEach(a => {
          const found = allAdapters.find(r => {
            return r.Name === a.interface;
          });

           if (found) {
            found.update(a);
           }
         });
      },
      error => {
        this.isAgencyDataLoading = false;
        this.errorMessage = 'Грешка при извличане на данни за адаптер.';
        console.log(error);
      }
    );
  }

  public onRegistryMenuSelected(event: any, adapter: AdapterModel) {
    this.downloadAdapterData(event.newSelection.value, adapter);
  }

  public onOperationMenuSelected(
    event: any,
    adapter: AdapterModel,
    operation: OperationModel
  ) {
    this.downloadOperationData(event.newSelection.value, adapter, operation);
  }

  private downloadAdapterData(downloadType: string, adapter: AdapterModel) {
    let url = this.getServiceDownloadUrl(downloadType);
    url += '/' + adapter.interface;
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

  public onMenuOpen(e: any) {
    if (!e) {
      e = window.event;
    }
    // IE9 & Other Browsers
    if (e.stopPropagation) {
      e.stopPropagation();
    } else {
      // IE8 and Lower
      e.cancelBubble = true;
    }
  }

  public onHeaderInteraction(event: IExpansionPanelEventArgs) {
    const expandedPanels = this.accordion.filter(panel => !panel.collapsed);
    expandedPanels.forEach(expandedPanel => {
      if (expandedPanel.id !== event.panel.id) {
        expandedPanel.collapse();
      }
    });
  }

  public onAdapterExpanded(adapter: AdapterModel, operation: OperationModel) {
    if (!operation.isDataLoaded && !operation.isDataLoaded) {
      const identifier = adapter.interface + '.' + operation.fullName;
      const observables: Observable<any>[] = [
        this.xmlService.retrieveOne(identifier, EXmlFileType.RequestXSD),
        this.xmlService.retrieveOne(identifier, EXmlFileType.ResponseXSD),
        this.xmlService.retrieveOne(identifier, EXmlFileType.SampleRequestXML),
        this.xmlService.retrieveOne(identifier, EXmlFileType.SampleResponseXML),
        this.xmlService.retrieveOne(identifier, EXmlFileType.CommonXSD)
      ];

      forkJoin(observables).subscribe(data => {
        operation.xsdRequest = data[0];
        operation.xsdResponse = data[1];
        operation.requestSampleData = data[2];
        operation.responseSampleData = data[3];
        operation.xsdCommon = data[4];

        operation.isDataLoaded = true;
        operation.isDataLoading = false;
      });
    }
  }
}
