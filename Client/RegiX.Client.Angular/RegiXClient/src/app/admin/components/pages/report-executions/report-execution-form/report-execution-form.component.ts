import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ReportExecutionsService } from 'src/app/core/services/rest/report-executions.service';
import { ReportResultModel } from 'src/app/core/models/dto/report-result.model';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { DatePipe } from '@angular/common';
import { ConnectedPositioningStrategy, HorizontalAlignment, NoOpScrollStrategy, VerticalAlignment } from 'igniteui-angular';
import { debug } from 'console';
import { b64toBlob2 } from 'src/app/admin/utility/b64toBlob2';

@Component({
  selector: 'app-report-execution-form',
  templateUrl: './report-execution-form.component.html',
  styleUrls: ['./report-execution-form.component.scss']
})
export class ReportExecutionFormComponent implements OnInit {
  route = ROUTES.REPORT_EXECUTION_VIEW;
  reportResult: ReportResultModel = null;
  subtitle: string;
  isLoading = false;

  public menuOverlaySettings = {
    positionStrategy: new ConnectedPositioningStrategy({
      horizontalDirection: HorizontalAlignment.Left,
      horizontalStartPoint: HorizontalAlignment.Right,
      verticalStartPoint: VerticalAlignment.Top,
      verticalDirection: VerticalAlignment.Top
    }),
    scrollStrategy: new NoOpScrollStrategy()
  };

  constructor(
    protected activatedRoute: ActivatedRoute,
    protected reportExecutionsService: ReportExecutionsService,
    protected datepipe: DatePipe) { }

  ngOnInit() {
    this.activatedRoute.params.subscribe(params => {
      const asyncID = params['ID'];
      this.isLoading = true;
      this.reportExecutionsService.getReport(asyncID).subscribe( r => {
        this.isLoading = false;
        this.reportResult = new ReportResultModel(r);
        this.subtitle = this.datepipe.transform(this.reportResult.createdOn, 'dd.MM.yyyy HH:mm:ss');
      });
    });
  }

  onPrint() {
    const printContents = document.getElementById('report-result').innerHTML;
    const popupWin = window.open('', '_blank');
    const executionDateFormatted = this.datepipe.transform(this.reportResult.createdOn, 'dd.MM.yyyy HH:mm:ss');
    popupWin.document.open();
    popupWin.document.write(`
      <html>
        <head>
          <title></title>
          <style>
          </style>
        </head>
        <body onload="window.print();window.close()">
            <div>${printContents}</div>
            <h4>Дата на изпълнение: ${executionDateFormatted}</h4>
        </body>
      </html>`
    );
    popupWin.document.close();
  }

  onResponseSaveXML(event: any) {
    const blob = new Blob([this.reportResult.responseXml], { type: 'text/xml' });
    const url = window.URL.createObjectURL(blob);
    if (event.newSelection.value === 'Open') {
      window.open(url);
    } else {
      const a = document.createElement('a');
      document.body.appendChild(a);
      a.setAttribute('style', 'display: none');
      a.href = url;
      a.download = 'Response.xml';
      a.click();
      window.URL.revokeObjectURL(url);
      a.remove();
    }
  }

  onRequestSaveXML(event: any) {
    const blob = new Blob([this.reportResult.requestXml], { type: 'text/xml' });
    const url = window.URL.createObjectURL(blob);
    if (event.newSelection.value === 'Open') {
      window.open(url);
    } else {
      const a = document.createElement('a');
      document.body.appendChild(a);
      a.setAttribute('style', 'display: none');
      a.href = url;
      a.download = 'Request.xml';
      a.click();
      window.URL.revokeObjectURL(url);
      a.remove();
    }
  }

  onCertSave(event: any) {
    if (event.newSelection.value === 'Certificate') {
      const blob = new Blob([this.reportResult.signatureCertirifcate], { type: 'application/pkix-cert' });
      const url = window.URL.createObjectURL(blob);
      const a = document.createElement('a');
      document.body.appendChild(a);
      a.setAttribute('style', 'display: none');
      a.href = url;
      a.download = 'Certificate.crt';
      a.click();
      window.URL.revokeObjectURL(url);
      a.remove();
    } else {
      const blob = new Blob([this.reportResult.rawResponseXml], { type: 'text/xml' });
      const url = window.URL.createObjectURL(blob);
      const a = document.createElement('a');
      document.body.appendChild(a);
      a.setAttribute('style', 'display: none');
      a.href = url;
      a.download = 'RawResponse.xml';
      a.click();
      window.URL.revokeObjectURL(url);
      a.remove();
    }
  }

  onPDFSave(event: any) {
    b64toBlob2(this.reportResult.responsePdf, 'application/pdf').then( b => {
      const url = window.URL.createObjectURL(b);
      if (event.newSelection.value === 'Open') {
        window.open(url);
      } else {
        const a = document.createElement('a');
        document.body.appendChild(a);
        a.setAttribute('style', 'display: none');
        a.href = url;
        a.download = 'Response.pdf';
        a.click();
        window.URL.revokeObjectURL(url);
        a.remove();
      }
    });
  }
}
