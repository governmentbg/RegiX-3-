import { DisplayValueFormatService } from 'src/app/core/services/display-value-format.service';
import { Component, Injector } from '@angular/core';
import { RemoteComponentWithForm, DisplayValueFilteringOperand } from '@tl/tl-common';
import { UsersService } from 'src/app/core/services/rest/users.service';
import { UsersModel } from 'src/app/core/models/dto/users.model';
import { ETables } from 'src/app/admin/enums/tables.enum';
import { EColumnType } from '@tl/tl-common';
import { AdministrationsService } from 'src/app/core/services/rest/administration.service';
import { GridRemoteFilteringService } from '@tl/tl-common';
import { ROUTES } from 'src/app/admin/routes/static-routes';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent extends RemoteComponentWithForm<
  UsersModel,
  UsersService
> {
  public routes = ROUTES;
  public USERS = ETables.USERS.toLowerCase();
  public displayValueFilteringOperand = DisplayValueFilteringOperand.instance();
  title: string;
  objectName = 'потребител';
  pageTitle = 'Потребители';

  constructor(
    service: UsersService,
    private administrationService: AdministrationsService,
    injector: Injector,
    public displayValueService: DisplayValueFormatService
  ) {
    super(service, injector);
  }
  protected getFilterField() {
    return 'ADM_ID';
  }

  ngOnInitImpl() {
    // this.grid.sortingExpressions = [
    //   { fieldName: 'userName', dir: SortingDirection.Asc }
    // ];
    if (this.filter) {
      if (!this.isIDFilter) {
        this.administrationService
          .find(this.filter.columnValue)
          .subscribe(data => {
            if (data) {
              this.pageTitle = 'Администратори на "' + data.acronym + '"';
            }
          });
      } else {
        this.pageTitle = 'Администратор с ID: ' + this.filter.columnValue;
      }
    } else {
      this.pageTitle = 'Потребители';
    }
  }

  protected createRemoteService() {
    this.remoteService = new GridRemoteFilteringService(
      { administration: 'administration.displayName' },
      this.service,
      this.grid,
      this.injector
    );
  }

  protected getFilterColumn(): string {
    return 'administration.id';
  }

  protected getFilterColumnType(): EColumnType {
    return EColumnType.DECIMAL;
  }

  protected excelExportMapItem(item: UsersModel){
    return {
      // Ид: item.id,
      Име: item.name,
      'Потребителско име': item.userName,
      Емейл: item.email,
      Активен: item.isAdmin,
      Заключен: item.isLockedOut,
    };
  }
}
