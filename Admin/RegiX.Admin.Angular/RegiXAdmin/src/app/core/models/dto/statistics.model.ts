export class StatisticsModel {
  public id: number = null;
  public consumerAdministration: string = null;
  public consumerName: string = null;
  public registerAdministration: string = null;
  public registerName: string = null;
  public operationName: string = null;

  public recordsCount: number = null;
  public apiServiceId: number = null;
  public consumerId: number = null;
  public apiServiceOperationId: number = null;
  public administrationId: number = null;
  public consumerDescription: string = null;
  public consumerAdministrationId: number = null;
  public registerId: number = null;
  public adapterId: number = null;
  public adapterOperationId: number = null;

  constructor(init?: Partial<StatisticsModel>) {
    if (init) {
      this.consumerAdministration = init.consumerAdministration;
      this.consumerName = init.consumerName;
      this.registerAdministration = init.registerAdministration;
      this.registerName = init.registerName;
      this.operationName = init.operationName;

      this.consumerDescription = init.consumerDescription;
      this.consumerAdministrationId = init.consumerAdministrationId;
      this.consumerId = init.consumerId;
      this.registerId = init.registerId;
      this.adapterId = init.adapterId;
      this.adapterOperationId = init.adapterOperationId;

      this.recordsCount = init.recordsCount;
      this.apiServiceId = init.apiServiceId;
      this.apiServiceOperationId = init.apiServiceOperationId;
      this.administrationId = init.administrationId;
    }
  }
}
