import { Component, OnInit, Input } from '@angular/core';
import { ReportResultModel } from 'src/app/core/models/dto/report-result.model';

@Component({
  selector: 'app-report-result',
  templateUrl: './report-result.component.html',
  styleUrls: ['./report-result.component.scss']
})
export class ReportResultComponent implements OnInit {

  @Input()
  public result: ReportResultModel = undefined;

  constructor() { }

  ngOnInit() {
  }

}
