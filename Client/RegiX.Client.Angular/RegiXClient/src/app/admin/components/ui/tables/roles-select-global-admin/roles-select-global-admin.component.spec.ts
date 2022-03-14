import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RolesSelectGlobalAdminComponent } from './roles-select-global-admin.component';

describe('RolesSelectGlobalAdminComponent', () => {
  let component: RolesSelectGlobalAdminComponent;
  let fixture: ComponentFixture<RolesSelectGlobalAdminComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RolesSelectGlobalAdminComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RolesSelectGlobalAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
