import { StatisticParameters } from '../statistics-params.model';

export class StatisticInParameters {
  public fromDate: Date = null;
  public toDate: Date = null;
  public consumerDescription: string = null;
  public consumerAdministrationId: number = null;
  public consumerId: number = null;
  public registerAdministrationId: number = null;
  public registerId: number = null;
  public adapterId: number = null;
  public certificateId: number = null;
  public adapterOperationId: number = null;

  constructor(init?: Partial<StatisticParameters>) {
    if (init) {
      this.fromDate = init.fromDate;
      this.toDate = init.toDate;
      this.consumerDescription= init.consumerDescription;
      if (init.consumerAdministration) {
        this.consumerAdministrationId = init.consumerAdministration.id;
      }
      if (init.consumer) {
        this.consumerId = init.consumer.id;
      }
      if (init.registerAdministration) {
        this.registerAdministrationId = init.registerAdministration.id;
      }
      if (init.register) {
        this.registerId = init.register.id;
      }
      if (init.certificate) {
        this.certificateId = init.certificate.id;
      }
      if (init.adapter) {
        this.adapterId = init.adapter.id;
      }
      if (init.adapterOperation) {
        this.adapterOperationId = init.adapterOperation.id;
      }
      if (init.certificate) {
        this.certificateId = init.certificate.id;
      }
    }
  }
}
