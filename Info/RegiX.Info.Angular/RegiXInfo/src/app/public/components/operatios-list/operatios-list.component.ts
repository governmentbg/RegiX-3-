import { Component, OnInit } from '@angular/core';
import { OperationListModel } from 'src/app/core/model/operation-list.model';
import { Router, ActivatedRoute } from '@angular/router';
import { RestClientOperationsListService } from 'src/app/core/services/rest/rest-client-operation-list-service';
import { ROUTES } from '../../routes/static-routes';

@Component({
  selector: 'app-operatios-list',
  templateUrl: './operatios-list.component.html',
  styleUrls: ['./operatios-list.component.scss']
})
export class OperationsListComponent implements OnInit {
  public routes = ROUTES;
  isDataLoading = false;
  isDataLoaded = false;

  errorMessage: string;

  operations: OperationListModel[] = [];

  constructor(
    private operationsService: RestClientOperationsListService,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit() {
    this.isDataLoading = true;
    this.isDataLoaded = false;
    this.operationsService.retrieveAll().subscribe(
      (data) => {
        this.operations = data;
        this.isDataLoaded = true;
        this.isDataLoading = false;
      },
      (error) => {
        this.isDataLoaded = false;
        this.isDataLoading = false;
        this.errorMessage = "Грешка при извличане на данни за регистри.";
      }
    );
  }
}
