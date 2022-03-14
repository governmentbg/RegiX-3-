import { StatisticsModel } from './statistics.model';
import { ABaseModel } from '@tl/tl-common';

export class Records extends ABaseModel {
  public record: StatisticsModel[];
  public refreshedTime: Date;

  constructor(init?: Partial<Records>) {
    super(init);
    if (init) {
      this.record = init.record;
      this.refreshedTime = init.refreshedTime;
    }
  }
}
