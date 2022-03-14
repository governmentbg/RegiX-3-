import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RegistryModel } from 'src/app/core/models/dto/registry.model';
import { HttpParams } from '@angular/common/http';
import { ReportsForUserService } from 'src/app/core/services/rest/reports-for-user.service';
import { ReportForUserModel } from 'src/app/core/models/dto/report-for-user.model';
import { ToastService, TLRouteReference, TlRouteArguments} from '@tl/tl-common';
import { DisplayValue } from 'src/app/core/models/display-value.model';
import { UsersFavouriteReportService } from 'src/app/core/services/rest/users-favourite-report.service';
import { FavouriteReportModel } from 'src/app/core/models/favourite-report.model';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { NGXLogger } from 'ngx-logger';

export class RegisterInfo extends DisplayValue {
  authorityName: string;
  constructor(init?: Partial<RegisterInfo>) {
    super(init);
    if (init){
      this.authorityName = init.authorityName;
    }
  }
}

@Component({
  selector: 'app-registers',
  templateUrl: './registers.component.html',
  styleUrls: ['./registers.component.scss']
})
export class RegistersComponent implements OnInit {
  registersyRoute = ROUTES.REGISTERS;
  authorityId: string = null;
  registerId: string = null;
  registers: RegisterInfo[] = [];
  operations: any = {};
  hasFilter = false;
  filterTitle = '';
  filterSubTitle = '';
  filterActions: {
    reference: TLRouteReference;
    args?: TlRouteArguments;
    title?: string;
    icon?: string;
    permissions?: string[];
  }[] = [];

  pageTitle = 'Регистри';

  isDataLoading = false;
  isDataLoaded = false;
  errorMessage: string = null;
  changingFavouirteStatus = false;
  changingId: number = null;
  originalData: ReportForUserModel[] = [];
  filter: string = null;
  @Output() favouritesChanged: EventEmitter<boolean> = new EventEmitter();

  constructor(
    private activatedRoute: ActivatedRoute,
    private reportForUserService: ReportsForUserService,
    private toastService: ToastService,
    private userFavouriteService: UsersFavouriteReportService,
    private logger: NGXLogger
  ) {
    // this.authorityId = this.activatedRoute.snapshot.params['ADM_ID'];
    // this.registerId = this.activatedRoute.snapshot.params['REG_ID'];
    // this.readRegisters();

    this.activatedRoute.params.subscribe(params => {
      this.authorityId = params['ADM_ID'];
      this.registerId = params['REG_ID'];
      this.logger.debug(`parameters changed ADM_ID: ${this.authorityId}, REG_ID: ${this.registerId}`);
      this.readRegisters();
    });
  }

  ngOnInit() {}

  private readRegisters() {
    this.registers = [];

    let httpParameters = new HttpParams();
    let authorityFilter = '';
    let registryFilter = '';
    this.hasFilter = false;
    if (this.authorityId && this.authorityId !== '-') {
      authorityFilter = 'authorityId eq ' + this.authorityId;
      this.hasFilter = true;
    }
    if (this.registerId && this.registerId !== '-') {
      registryFilter = 'registerId eq ' + this.registerId;
      this.hasFilter = true;
    }
    if (authorityFilter &&  registryFilter){
      httpParameters = httpParameters.append('$filter', `${authorityFilter} and ${registryFilter}`);
      this.filterTitle =  'Филтри';
      this.filterSubTitle = 'Приложени са филтри по администрация и регистър';
      this.filterActions = [
        {
          reference: ROUTES.REGISTERS,
          args: {':REG_ID': '-', ':ADM_ID': '-'},
          title: 'Премахни всички',
          icon: 'clear'
        },
        {
          reference: ROUTES.REGISTERS,
          args: {':REG_ID': this.registerId, ':ADM_ID': '-'},
          title: 'Премахни филтър по администрация',
          icon: 'account_balance'
        },
        {
          reference: ROUTES.REGISTERS,
          args: {':REG_ID': '-', ':ADM_ID': this.authorityId},
          title: 'Премахни филтър по регистър',
          icon: 'dashboard'
        }
      ];
    } else if ( authorityFilter ) {
      httpParameters = httpParameters.append('$filter', authorityFilter);
      this.filterTitle =  'Филтър';
      this.filterSubTitle = 'Приложен е филтър по администрация';
      this.filterActions = [
        {
          reference: ROUTES.REGISTERS,
          args: {':REG_ID': this.registerId, ':ADM_ID': '-'},
          title: 'Премахни филтър по администрация',
          icon: 'account_balance'
        },
      ];
    } else if ( registryFilter ) {
      httpParameters = httpParameters.append('$filter', registryFilter);
      this.filterTitle =  'Филтри';
      this.filterSubTitle = 'Приложен е филтър по регистър';
      this.filterActions = [
        {
          reference: ROUTES.REGISTERS,
          args: {':REG_ID': '-', ':ADM_ID': this.authorityId},
          title: 'Премахни филтър по регистър',
          icon: 'dashboard'
        }
      ];
    }

    this.isDataLoading = true;
    this.reportForUserService.getAllForUser(httpParameters).subscribe(
      data => {
        this.originalData = [...data];
        this.loadOperationsData(data);
      },
      error => {
        this.isDataLoaded = false;
        this.isDataLoading = false;
        this.errorMessage = 'Грешка при извличане на данни за услуги';
        this.toastService.showMessage(
          'Грешка при извличане на данни за обект!'
        );
      }
    );
      // this.administrationService.find(this.authorityId).subscribe(data => {
      //   this.pageTitle = data.acronym + ' - ' + data.name;
      // });
  }

  private loadOperationsData(data: ReportForUserModel[]) {
    if (this.filter) {
      data = data.filter(
        entry =>
          entry.authorityAcronym.toLowerCase().includes(this.filter.toLowerCase()) ||
          entry.authorityName.toLowerCase().includes(this.filter.toLowerCase()) ||
          entry.registerName.toLowerCase().includes(this.filter.toLowerCase()) ||
          entry.reportName.toLowerCase().includes(this.filter.toLowerCase())
      );
    }
    this.populateRegisters(data);
    this.populateReportsForRegisters(data);

    this.isDataLoaded = true;
    this.isDataLoading = false;
    this.errorMessage = null;
  }

  private populateReportsForRegisters(data: ReportForUserModel[]) {
    const obj: any = {};
    this.registers.forEach(register => {
      // find all for register
      const operations = data.filter(item => item.registerName === register.displayName);
      // transform to DisplayValue objects
      const arr = operations.map(item => {
        const newObj = new FavouriteReportModel({
          id: item.reportId,
          displayName: item.reportName,
          favourite: item.favourite
        });
        return newObj;
      });
      // sort array
      arr.sort((a, b) => {
        if (a.displayName > b.displayName) {
          return 1;
        }
        if (a.displayName < b.displayName) {
          return -1;
        }
        return 0;
      });
      // store in dictionary
      obj[register.id] = arr;
    });
    this.operations = obj;
  }

  private populateRegisters(data: ReportForUserModel[]) {
    const arr: RegisterInfo[] = [];
    data.forEach(item => {
      const foundItem = arr.find(d => d.displayName === item.registerName);
      if (!foundItem) {
        arr.push(
          new RegisterInfo({
            id: item.registerId,
            displayName: item.registerName,
            authorityName: item.authorityName
          })
        );
      }
    });
    arr.sort((a, b) => {
      if (a.displayName > b.displayName) {
        return 1;
      }
      if (a.displayName < b.displayName) {
        return -1;
      }
      return 0;
    });
    this.registers = arr;
  }

  public addToFavourites(operation: FavouriteReportModel, event: any) {
    event.stopPropagation();
    this.changingFavouirteStatus = true;
    this.changingId = operation.id;
    this.userFavouriteService.change(operation.id, !operation.favourite).subscribe(
      success => {
        this.changingFavouirteStatus = false;
        operation.favourite = !operation.favourite;
        this.changingId = null;
        this.favouritesChanged.emit(true);
      },
      error => {
        this.changingFavouirteStatus = false;
        this.changingId = null;
      }
    );
    console.log('starred');
  }

  getRouterLink(id: string): string[] {
    const res =  ROUTES.OPERATION.staticRoute({':REPORT_ID': id + '', ':ADM_ID': this.authorityId, ':REG_ID': this.registerId});
    return ['/', ...res];
  }
  public search(input: any) {
    this.filter = input.value;
    this.loadOperationsData([...this.originalData]);
  }

  public clearSearch(input: any) {
    input.value = '';
    this.filter = null;
    this.loadOperationsData([...this.originalData]);
  }
}
