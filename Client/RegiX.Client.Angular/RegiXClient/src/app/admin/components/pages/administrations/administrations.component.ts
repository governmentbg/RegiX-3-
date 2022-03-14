import { Component, OnInit, Injector, ViewChild } from '@angular/core';
import { AdministrationModel } from 'src/app/core/models/dto/administration.model';
import { AdministrationsService } from 'src/app/core/services/rest/administration.service';
import { RemoteComponentWithForm} from '@tl/tl-common';
import { GridRemoteFilteringService} from '@tl/tl-common';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { IgxDialogComponent } from 'igniteui-angular';

@Component({
  selector: 'app-administrations',
  templateUrl: './administrations.component.html',
  styleUrls: ['./administrations.component.scss']
})
export class AdministrationsComponent extends RemoteComponentWithForm<
  AdministrationModel,
  AdministrationsService
> {
  title: string;
  objectName = 'администрация';
  public routes = ROUTES;
  protected createRolesAndReportsObject: AdministrationModel = null;

  @ViewChild('confirmRoleAndReportsCreationDialog', { read: IgxDialogComponent, static: true })
  public confirmRoleAndReportsCreationDialog: IgxDialogComponent;

  constructor(service: AdministrationsService, injector: Injector) {
    super(service, injector);
  }

  ngOnInitImpl() {
    // this.grid.sortingExpressions = [
    //   { fieldName: 'name', dir: SortingDirection.Asc }
    // ];
  }

  protected createRemoteService() {
    console.log(this.grid);
    this.remoteService = new GridRemoteFilteringService(
      { administrationType: 'administrationType.displayName' },
      this.service,
      this.grid,
      this.injector
    );
  }

  onShowMenuSelected(event) {
  }

  onConfirmRoleAndReportsCreation() {
    this.service.createRolesAndReports(this.createRolesAndReportsObject.id).subscribe(
      data => {
        this.toastService.showMessage('Успешно създаване на роли и услуги!');
        if (this.confirmRoleAndReportsCreationDialog) {
          this.confirmRoleAndReportsCreationDialog.close();
        }
      },
      error => {
        this.toastService.showMessage('Грешка при създаване на роли и услуги!');
        this.logger.error(error);
        if (this.confirmRoleAndReportsCreationDialog) {
          this.confirmRoleAndReportsCreationDialog.close();
        }
      }
    );
    this.createRolesAndReportsObject = null;
  }

  onDismissedRoleAndReportsCreation() {
    this.createRolesAndReportsObject = null;
    this.confirmRoleAndReportsCreationDialog.close();
  }

  generateRolesAndReports(row: AdministrationModel) {
    this.createRolesAndReportsObject = row;
    this.confirmRoleAndReportsCreationDialog.open();
  }

  protected excelExportMapItem(item: AdministrationModel) {
    return {
      // Ид: item.id,
      Име: item.name,
      Акроним: item.acronym,
      Мултитенант: item.isMultitenantAuthority,
      Код: item.code,
      OID: item.oid
    };
  }
}
