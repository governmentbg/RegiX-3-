import { Injectable, Injector } from '@angular/core';
import { CrudService } from '@tl/tl-common';
import { MyProfileModel } from '../../models/dto/in/my-profile.model';

@Injectable({
  providedIn: 'root'
})
export class MyProfileService extends CrudService<MyProfileModel, number> {
  constructor(injector: Injector) {
    super(MyProfileModel, injector, 'my-profile');
  }
}
