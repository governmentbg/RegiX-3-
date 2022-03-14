import { CrudService } from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { ApprovedRequestElementsModel } from '../../models/dto/approved-request-elements.model';

@Injectable({
  providedIn: 'root',
})
export class ApprovedRequestElementsService extends CrudService<
  ApprovedRequestElementsModel,
  number
> {
  constructor(injector: Injector) {
    super(ApprovedRequestElementsModel, injector, 'approved-request-elements');
  }
}