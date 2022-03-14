import { Component, OnInit } from '@angular/core';
import { ConfigurationService } from '@tl/tl-common';
import { OperationModel } from 'src/app/core/model/regix/operation.model';
import { RestClientOperationsService } from 'src/app/core/services/rest/rest-client-operations-service';

@Component({
  selector: 'app-operations',
  templateUrl: './operations.component.html',
  styleUrls: ['./operations.component.scss']
})
export class OperationsComponent implements OnInit {
  operations: OperationModel[];
  isDataLoading = false;
  isDataLoaded = false;

  constructor(
    public operationsService: RestClientOperationsService,
    public configurationService: ConfigurationService) { }

  ngOnInit() {
    this.isDataLoading = true;
    this.isDataLoaded = false;
    this.operationsService.allOperations().subscribe(
      data => {
        this.operations = data;
        this.isDataLoading = false;
        this.isDataLoaded = true;
      }
    );
  }

}
