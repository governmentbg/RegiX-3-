import { FormGroup } from '@angular/forms';
import { ConsumerAccessRequestsService } from './../../../../../core/services/rest/consumer-access-requests.service';
import { Component, Injector } from '@angular/core';
import {
  RemoteComponentWithForm,
  GridRemoteFilteringService,
  DisplayValueFilteringOperand,
} from '@tl/tl-common';
import { ConsumerRequestOperationsModel } from 'src/app/core/models/dto/consumer-request-operations.model';
import { ConsumerRequestOperationsService } from 'src/app/core/services/rest/consumer-request-operations.service';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { DisplayValueFormatService } from 'src/app/core/services/display-value-format.service';
import { HttpParams } from '@angular/common/http';
import { ConsumerAccessRequestsModel } from 'src/app/core/models/dto/consumer-access-requests.model';
import { map, take } from 'rxjs/operators';
import { OidcSecurityService } from 'angular-auth-oidc-client';

@Component({
  selector: 'app-consumer-request-operations',
  templateUrl: './consumer-request-operations.component.html',
  styleUrls: ['./consumer-request-operations.component.scss'],
})
export class ConsumerRequestOperationsComponent extends RemoteComponentWithForm<
  ConsumerRequestOperationsModel,
  ConsumerRequestOperationsService
> {
  public routes = ROUTES;
  public displayValueFilteringOperand = DisplayValueFilteringOperand.instance();
  public subtitle: string;

  consumerSystemCertificateId: number;
  arr: number[];
  currentUserRole: string;

  public Status: any = {
    0: 'Нов',
    1: 'Входиран',
    2: 'Отхвърлен',
    3: 'Съгласуван',
    4: 'Одобрен',
  };

  constructor(
    service: ConsumerRequestOperationsService,
    injector: Injector,
    public displayValueService: DisplayValueFormatService,
    private consumerAccessRequestsService: ConsumerAccessRequestsService,
    private oidcSecurityService: OidcSecurityService,
  ) {
    super(service, injector);
  }

  ngOnInit(): void {

    this.consumerSystemCertificateId = this.activatedRoute.snapshot.params[
      'CON_REQ_ID'
    ];
    let httpParameters = new HttpParams();
    httpParameters = httpParameters.append(
      '$filter',
      `consumerSystemCertificate.id eq ${this.consumerSystemCertificateId}`.toString()
    );
    this.consumerAccessRequestsService
      .getAllNoWrap(httpParameters)
      .pipe(
        map((items: ConsumerAccessRequestsModel[]) => {
          return items.map((item) => {
            return item.id;
          });
        })
      )
      .subscribe((data) => {
        this.arr = data;
        this.createRemoteService();
        this.remoteService._extRemoteData = this.dataBehavior;
        this.remoteService.pagerParams.perPage = this.grid.perPage;
        super.ngOnInit();
      });
  }

  ngOnInitImpl() {
    this.oidcSecurityService.userData$.subscribe((userData) => {
      if (userData) {
        this.currentUserRole = userData.role;
      }
    });
  }

  protected createRemoteService() {
    this.remoteService = new GridRemoteFilteringService(
      {},
      this.service,
      this.grid,
      this.injector
    );
  }

  protected getFilterExpression() {
    let filterOperations = this.arr
      .map((id) => `consumerAccessRequest.id eq ${id}`)
      .join(' or ');

    return filterOperations;
  }
}
