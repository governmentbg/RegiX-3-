import { MyProfileModel } from './../../models/dto/my-profile.model';
import { CrudService } from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MyProfileService extends CrudService<MyProfileModel, number> {
  constructor(injector: Injector) {
    super(MyProfileModel, injector, 'my-profile');
  }
}
