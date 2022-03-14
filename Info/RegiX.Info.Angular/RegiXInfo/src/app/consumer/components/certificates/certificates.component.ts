import { Component, Injector, AfterViewInit, ChangeDetectorRef } from '@angular/core';
import { RemoteComponentWithForm, GridRemoteFilteringService, EColumnType } from '@tl/tl-common';
import { CertificateModel } from '../../models/certificate.model';
import { CertificateService } from '../../services/certificate.service';
import { CONSUMER_ROUTES } from '../../routes/consumer-static-routes';
import { CertificateIdService } from '../../services/certificate-id.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-certificates',
  templateUrl: './certificates.component.html',
  styleUrls: ['./certificates.component.scss']
})
export class CertificatesComponent extends RemoteComponentWithForm<
CertificateModel,
CertificateService
> {
  public routes = CONSUMER_ROUTES;

  constructor(
    service: CertificateService,
    injector: Injector,
    private certificateIdService: CertificateIdService,
    private route: ActivatedRoute
  ) {
    super(service, injector);
  }
  downloadContent(obj: CertificateModel) {
    //The atob() method decodes a base-64 encoded string.
    var fileText = atob(obj.content);
    var fileName = 'Content.txt';//TODO: Fix file name 
    this.saveTextAsFile(fileText, fileName);
  } 

  protected createRemoteService() {
    this.remoteService = new GridRemoteFilteringService(
      {},
      this.service,
      this.grid,
      this.injector
    );
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
  
  private saveTextAsFile(data, filename) {
    if (!data) {
      console.error('Console.save: No data');
      return;
    }

    if (!filename) filename = 'console.json';

    var blob = new Blob([data], { type: 'text/plain' }),
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
      a.dataset.downloadurl = ['text/plain', a.download, a.href].join(':');
      e.initEvent('click', true, false);
      a.dispatchEvent(e);
    }
  }
}
