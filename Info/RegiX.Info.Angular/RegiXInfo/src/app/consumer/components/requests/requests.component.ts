import { Component, OnInit, Injector, ViewChild } from '@angular/core';
import {
  RemoteComponentWithForm,
  DisplayValueFilteringOperand,
  EColumnType,
} from '@tl/tl-common';
import { ConsumerRequestsModel } from '../../models/consumer-requests.model';
import { ConsumerRequestsService } from '../../services/consumer-requests.service';
import { CONSUMER_ROUTES } from '../../routes/consumer-static-routes';
import { DisplayValueFormatService } from '../../services/display-value-format.service';
import { ConsumerProfilesStatus } from '../../enums/consumer-profiles-status.enum';
import { IgxDialogComponent } from 'igniteui-angular';
import { ConsumerRequestsInModel } from '../../models/in/consumer-request.in.model';
import { IgxRequestEnumFilteringOperand } from './request-status-enum-filter';

@Component({
  selector: 'app-requests',
  templateUrl: './requests.component.html',
  styleUrls: ['./requests.component.scss'],
})
export class RequestsComponent extends RemoteComponentWithForm<
  ConsumerRequestsModel,
  ConsumerRequestsService
> {

  @ViewChild('dialogChangeStatus', { read: IgxDialogComponent, static: true })
  public dialogChangeStatus: IgxDialogComponent;

  public objectForStatusUpdate: any;

  public routes = CONSUMER_ROUTES;
  public displayValueFilteringOperand = DisplayValueFilteringOperand.instance();
  public requestEnumFilter = IgxRequestEnumFilteringOperand.instance();

  public Status: any = {
    0: ConsumerProfilesStatus.DRAFT,
    1: ConsumerProfilesStatus.NEW,
    2: ConsumerProfilesStatus.DECLINED,
    3: ConsumerProfilesStatus.ACCEPTED,
  };

  subtitle: string;

  constructor(
    service: ConsumerRequestsService,
    injector: Injector,
    public displayValueService: DisplayValueFormatService
  ) {
    super(service, injector);
  }

  protected getFilterField(): string {
    return 'SYS_ID';
  }

  protected getFilterColumn(): string {
    return 'consumerSystem.id';
  }

  protected getIdColumn(): string {
    return 'id';
  }

  protected getFilterColumnType(): EColumnType {
    return EColumnType.DECIMAL;
  }

  generateReport(obj: ConsumerRequestsModel) {
    this.service.generateReport(obj.id).subscribe((item) => {
      var fileName = obj.name + 'Report' + '.pdf';
      let decodedData = atob(item);
      this.showPdf(item, fileName);
      //this.saveTextAsPdf(decodedData, fileName);
    });
  }

  showPdf(base64Data: string, fileName: string) {
    const linkSource = 'data:application/pdf;base64,' + base64Data;
    const downloadLink = document.createElement('a');
    //const fileName = "sample.pdf";

    downloadLink.href = linkSource;
    downloadLink.download = fileName;
    downloadLink.click();
  }

   onUpdateStatus(obj: ConsumerRequestsModel){
    let result = new ConsumerRequestsInModel();
    obj.status = 1;
    result.name = obj.name;
    result.id = obj.id;
    result.status = obj.status;
    result.consumerSystemId = obj.consumerSystem.id;
     ;//Status changed from DRAFT(0) to NEW(1)
    this.service.updateStatus(obj.id,result).subscribe(
      (data) => {
        // this.updateRowInUI(data);
        this.logger.debug('object updated, refresh grid or redirect', data);
        this.toastService.showMessage('Обектът е обновен успешно!');
        if (this.dialogChangeStatus) {
          this.dialogChangeStatus.close();
        }
      },
      (error) => {
        this.logger.error(error);
        this.toastService.showMessage('Грешка при обновяване на обект: ' + error.error);
        if (this.dialogChangeStatus) {
          this.dialogChangeStatus.close();
        }
      }
    );
  }

  onUpdateStatusCanceled(){
      this.dialogChangeStatus.close();

  }
  onUpdateStatusConfirmed() {
    this.onUpdateStatus(this.objectForStatusUpdate);
  }

  prepareFoStatusChange(object: any) {
    this.objectForStatusUpdate = object;
    this.dialogChangeStatus.open();
  }

  private saveTextAsPdf(data, filename) {
    if (!data) {
      console.error('Console.save: No data');
      return;
    }

    if (!filename) filename = 'console.json';

    var blob = new Blob([data], { type: 'application/pdf' }),
      e = document.createEvent('MouseEvents'),
      a = document.createElement('a');
    // FOR IE:

    if (window.navigator && window.navigator.msSaveOrOpenBlob) {
      window.navigator.msSaveOrOpenBlob(blob, filename);
    } else {
      var e = document.createEvent('MouseEvents'),
        a = document.createElement('a');

      a.download = filename;
      a.href = window.URL.createObjectURL(blob);
      a.dataset.downloadurl = ['application/pdf', a.download, a.href].join(':');
      e.initEvent('click', true, false);
      a.dispatchEvent(e);
    }
  }
}
