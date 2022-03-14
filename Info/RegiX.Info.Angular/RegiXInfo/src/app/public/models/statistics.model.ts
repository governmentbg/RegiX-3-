import { ABaseModel } from '@tl/tl-common';

export class StatisticsModel extends ABaseModel {
  public consumerAdministration: string;
  public consumerName: string;
  public registerAdministration: string;
  public registerName: string;
  public recordsCount: string;
  public refreshedTime: Date;

  constructor(init?: Partial<StatisticsModel>) {
    super(init);
    if (init) {
      this.consumerAdministration = init.consumerAdministration;
      this.consumerName = init.consumerName;
      this.registerAdministration = init.registerAdministration;
      this.registerAdministration = init.consumerAdministration;
      this.registerName = init.registerName;
      this.recordsCount = init.recordsCount;
      this.refreshedTime = init.refreshedTime;
    }
  }
}
