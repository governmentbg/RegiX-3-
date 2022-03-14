import { Component, OnInit, Input, OnDestroy, AfterViewInit } from '@angular/core';
import { AgencyModel } from 'src/app/core/model/regix/agency.model';
import { RestClientAdministrationsService } from 'src/app/core/services/rest/rest-client-administrations-service';
import { Subscription, Observable, forkJoin } from 'rxjs';
import { AdapterModel } from 'src/app/core/model/regix/adapter.model';
import { RestClientAdapterService } from 'src/app/core/services/rest/rest-client-adapter-service';

@Component({
  selector: 'app-adapters-monitor',
  templateUrl: './adapters-monitor.component.html',
  styleUrls: ['./adapters-monitor.component.scss']
})
export class AdaptersMonitorComponent implements OnInit, OnDestroy {
  subscription: Subscription;
  agencies: AgencyModel[];
  adapters: AdapterModel[] = [];
  isDataLoading = false;
  isDataLoaded = false;

  readonly ADAPTER_REFRESH_TIMER_SECONDS = 60;

  constructor(
    private adapterService: RestClientAdapterService,
    private administrationService: RestClientAdministrationsService
  ) {}

  // ngAfterViewInit() {
  //   this.updateContentDivPanel();
  // }

  // private updateContentDivPanel() {
  //   const content = document.getElementById('content-div');
  //   const header = document.getElementById('app-navbar');
  //   let theHeight = window.innerHeight - header.clientHeight;
  //   content.setAttribute('style', 'display:block;height:' + theHeight + 'px');
  //   content.style.height = theHeight + 'px';
  // }

  ngOnInit() {
    this.refreshAdapterStatus();
  }

  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  private readAdapterData() {
    this.subscription = this.administrationService.retrieveAll().subscribe(
      (data: AgencyModel[]) => {
        this.isDataLoading = true;
        this.agencies = data;
        this.readAdapterDetails();
      },
      err => {
        this.isDataLoaded = true;
        this.isDataLoading = false;
      }
    );
  }

  private readAdapterDetails() {
    if (this.agencies.length === 0) {
      this.isDataLoading = false;
      this.isDataLoaded = true;
      return;
    }
    this.agencies.forEach(agency => {
      agency.registers.forEach(r => {
        const observables: Observable<any>[] = [];
        const adapters = r.adapters;
        if (adapters) {
          adapters.forEach(a => {
            const adapterName = a.name;

            const obj = this.adapterService.retrieveBasicInfoForAdapter(adapterName);
            observables.push(obj);
          });
        }

        forkJoin(observables).subscribe(
          (data: AdapterModel[]) => {
            const adapters = agency.registers.map(r => r.adapters);
            const allAdapters = [].concat.apply([], adapters);

            data.forEach(a => {
              const found = allAdapters.find(r => {
                return r.Name === a.interface;
              });

              if (found) {
                found.update(a);
              }
            });
            this.populateAdaptersTable();
            this.isDataLoading = false;
            this.isDataLoaded = true;
          },
          error => {
            console.log('Грешка при четене на данни за адаптер');
            this.isDataLoading = false;
            this.isDataLoaded = true;
          }
        );
      });
    });
  }

  private populateAdaptersTable() {
    let adaptersList = [];

    if (this.agencies != null) {
      this.agencies.forEach(a => {
        const registers = a.registers;
        if (registers) {
          registers.forEach(r => {
            adaptersList = adaptersList.concat(r.adapters);
          });
        }
      });
    }
    this.adapters = adaptersList;
  }

  private refreshAdapterStatus() {
    this.readAdapterData();
    // setTimeout(
    //   this.refreshAdapterStatus,
    //   this.ADAPTER_REFRESH_TIMER_SECONDS * 1000
    // );
  }
}
