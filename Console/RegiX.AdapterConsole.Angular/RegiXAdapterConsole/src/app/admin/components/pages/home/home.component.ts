import { Component, OnInit } from '@angular/core';
import { OperationCallModel } from 'src/app/core/models/dto/operation-call.model';
import { MyOperationCallsService } from 'src/app/core/services/rest/my-operation-calls.service';
import { ROUTES } from 'src/app/admin/routes/static-routes';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  public allRoutes = ROUTES;
  operationCalls: OperationCallModel[] = [];
  settings: any[] = [
    {
      reference: ROUTES.USERS,
      title: ROUTES.USERS.title,
    },
    {
      reference: ROUTES.ROLES,
      title: ROUTES.ROLES.title,
    },
  ];

  isDataLoading = false;
  isDataLoaded = false;
  errorMessage: string = null;

  constructor(private myOperationCallsService: MyOperationCallsService) {}

  mapFavouriteReports(data: OperationCallModel[]): any[] {
    return data.map((d) => {
      return {
        reference: ROUTES.MY_OPERATION_CALL_EDIT,
        args: {
          ':ID': d.id + '',
        },
        title: d.adapterOperationName,
      };
    });
  }

  ngOnInit() {
    this.isDataLoading = true;
    this.myOperationCallsService.getAllNoWrap().subscribe(
      (data) => {
        this.operationCalls = this.mapFavouriteReports(data);
        this.isDataLoaded = true;
        this.isDataLoading = false;
        this.errorMessage = null;
      },
      (error) => {
        this.isDataLoaded = true;
        this.isDataLoading = false;
        this.errorMessage = error.message;
      }
    );
  }
}
