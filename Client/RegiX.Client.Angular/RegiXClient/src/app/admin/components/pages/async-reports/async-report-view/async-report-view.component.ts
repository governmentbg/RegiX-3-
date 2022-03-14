import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AsyncReportsService } from 'src/app/core/services/rest/async-reports.service';
import { ReportResultModel } from 'src/app/core/models/dto/report-result.model';
import { ROUTES } from 'src/app/admin/routes/static-routes';

const b64toBlob2 = (base64, type = 'application/octet-stream') =>
  fetch(`data:${type};base64,${base64}`).then(res => res.blob())

@Component({
  selector: 'app-async-report-view',
  templateUrl: './async-report-view.component.html',
  styleUrls: ['./async-report-view.component.scss']
})
export class AsyncReportViewComponent implements OnInit {

  routes = ROUTES;
  reportResult: ReportResultModel = null;

  constructor(
    protected activatedRoute: ActivatedRoute,
    protected asyncReportsService: AsyncReportsService) { }

  ngOnInit() {
    this.activatedRoute.params.subscribe(params => {
      const asyncID = params['ID'];
      this.asyncReportsService.getReport(asyncID).subscribe( r => {
        this.reportResult = new ReportResultModel(r);
      });
    });
  }
}
