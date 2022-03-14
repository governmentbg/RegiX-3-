import { HttpParams } from '@angular/common/http';
import { ETables } from './../../../enums/tables.enum';
import {
  Component,
  OnInit,
  Injector,
  ViewChild,
  EventEmitter,
} from '@angular/core';
import { ConsumerCertificateModel } from 'src/app/core/models/dto/consumer-certificate.model';
import { ConsumerCertificatesService } from 'src/app/core/services/rest/consumer-certificates.service';
import { RemoteComponentWithForm, FilterSection } from '@tl/tl-common';
import { EColumnType } from '@tl/tl-common';
import { ConsumersService } from 'src/app/core/services/rest/consumers.service';
import { GridRemoteFilteringService } from '@tl/tl-common';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { DatеFormatService } from 'src/app/core/services/date-format.service';
import { AdminPermissions } from 'src/app/admin/permissions';
import { IgxDialogComponent } from 'igniteui-angular';
import { CertificateSwapFilterComponent } from '../filters/certificate-swap-filter/certificate-swap-filter.component';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-certificates',
  templateUrl: './certificates.component.html',
  styleUrls: ['./certificates.component.scss'],
})
export class CertificatesComponent extends RemoteComponentWithForm<
  ConsumerCertificateModel,
  ConsumerCertificatesService
> {
  @ViewChild('certificatesSwapFilterDialog')
  certificatesSwapFilterDialog: IgxDialogComponent;
  @ViewChild('certificateSwapFilter')
  certificateSwapFilter: CertificateSwapFilterComponent;

  public routes = ROUTES;
  public CONSUMER_CERTIFICATES = ETables.CONSUMER_CERTIFICATES.toLowerCase();
  public globalAdmin = AdminPermissions.GLOBAL_ADMIN;
  public isFilteredByConsumer: boolean = true;
  public destinationCertificateId: number;

  pageTitle = ROUTES.CERTIFICATES.title;
  subtitle: string;

  constructor(
    service: ConsumerCertificatesService,
    private consumerService: ConsumersService,
    injector: Injector,
    public dateFormatService: DatеFormatService
  ) {
    super(service, injector);
  }

  ngOnInitImpl() {
    // this.grid.sortingExpressions = [
    //   { fieldName: 'name', dir: SortingDirection.Asc }
    // ];
    if (this.filter) {
      if (!this.isIDFilter) {
        this.consumerService.find(this.filter.columnValue).subscribe((data) => {
          if (data) {
            this.pageTitle = 'Сертификати за консуматор "' + data.name + '"';
            this.subtitle = this.pageTitle;
          }
        });
      } else {
        this.pageTitle = 'Сертификат с ID: "' + this.filter.columnValue + '"';
        this.subtitle = this.pageTitle;
      }
    } else {
      this.pageTitle = 'Сертификати';
      this.subtitle = null;
    }
    if (this.activatedRoute.snapshot.params['CON_ID'] === '-') {
      this.isFilteredByConsumer = false;
    }
  }

  protected createRemoteService() {
    this.remoteService = new GridRemoteFilteringService(
      {},
      this.service,
      this.grid,
      this.injector
    );
  }

  protected getFilterField(): string {
    return 'CON_ID';
  }

  protected getFilterColumn(): string {
    return 'apiServiceConsumer.id';
  }

  protected getFilterColumnType(): EColumnType {
    return EColumnType.DECIMAL;
  }

  protected excelExportMapItem(item: ConsumerCertificateModel) {
    return {
      // Ид: item.id,
      Име: item.name,
      Описание: item.description,
      thumbprint: item.thumbprint,
      'Валиден от': this.dateFormatService.formatForExport(item.validFrom),
      'Валиден до': this.dateFormatService.formatForExport(item.validTo),
      Активен: item.active,
      OID: item.oid,
      Съдържание: item.content,
    };
  }

  showCertificates(destinationCertificate: ConsumerCertificateModel) {
    this.destinationCertificateId = destinationCertificate.id;
    this.certificatesSwapFilterDialog.open();
    this.certificateSwapFilter.filter.filterSections = this.createNewFilterSection(this.destinationCertificateId);
    this.certificateSwapFilter.loadFirstSection();
  }

  certificateSelected(
    selectedItems: { id: number; name: string; data: any; key: string }[]
  ) {
    this.certificatesSwapFilterDialog.close();
    this.service.swapCertificates(selectedItems[0].id,this.destinationCertificateId)
    .subscribe(
      (data) => {
        //this.logger.debug('object inserted, refresh form or redirect', data);
        this.toastService.showMessage('Правата са успешно прехвърлени!');
      },
      (error) => {
        this.toastService.showMessage(
          'Грешка при прехвърляне на правата!'
        );
      }
    );
  }

  private createNewFilterSection(
    destinationCertificateId: number
  ): FilterSection[] {
    let result: FilterSection[] = [];

    result.push(
      new FilterSection(
        'certificate',
        ROUTES.CERTIFICATES.title,
        ROUTES.CERTIFICATES.icon,
        result,
        (fs, self) => {
          let res = new HttpParams();
          if (self.perPage) {
            res = res.append('$skip', self.index * self.perPage + '');
            res = res.append('$top', self.perPage + '');
            res = res.append('$count', 'true');
            res = res.append('$orderby', 'name asc');
          }
          res = res.append(
            '$filter',
            `${this.getFilterColumn()} eq ${
              this.activatedRoute.snapshot.params[this.getFilterField()]
            } and id ne ${destinationCertificateId}`
          );

          return this.service.getAll(res).pipe(
            map((arr) => {
              self.total = arr['total'];
              return arr['data'].map((a) => {
                return {
                  id: a.id,
                  name: a.name,
                  data: undefined,
                };
              });
            })
          );
        },
        ROUTES.CERTIFICATES.icon,
        this.certificateSwapFilter.selectedValues,
        true,
        true,
        true
      )
    );

    return result;
  }
}
