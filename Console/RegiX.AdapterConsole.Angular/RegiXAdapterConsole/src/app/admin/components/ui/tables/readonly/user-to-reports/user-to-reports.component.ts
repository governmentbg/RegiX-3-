import { Component, Injector } from '@angular/core';
import { UserToReportModel } from 'src/app/core/models/dto/user-to-report.model';
import { UsersToReportService } from 'src/app/core/services/rest/users-to-report.service';
import { RemoteComponentWithForm, EColumnType } from '@tl/tl-common';

@Component({
  selector: 'app-user-to-reports',
  templateUrl: './user-to-reports.component.html',
  styleUrls: ['./user-to-reports.component.scss']
})
export class UserToReportsComponent extends RemoteComponentWithForm<
  UserToReportModel,
  UsersToReportService
  > {

    constructor(
      service: UsersToReportService,
      injector: Injector,
    ) {
      super(service, injector);
    }

    protected getFilterField(): string {
      return 'ID';
    }
  
    protected getFilterColumn(): string {
      return 'userId';
    }
  
    protected getIdColumn(): string {
      return 'id';
    }
  
    protected getFilterColumnType(): EColumnType {
      return EColumnType.DECIMAL;
    }
  }