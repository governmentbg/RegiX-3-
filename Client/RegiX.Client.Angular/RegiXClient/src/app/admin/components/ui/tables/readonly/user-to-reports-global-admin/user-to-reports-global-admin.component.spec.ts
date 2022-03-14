import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserToReportsGlobalAdminComponent } from './user-to-reports-global-admin.component';

describe('UserToReportsGlobalAdminComponent', () => {
  let component: UserToReportsGlobalAdminComponent;
  let fixture: ComponentFixture<UserToReportsGlobalAdminComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserToReportsGlobalAdminComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserToReportsGlobalAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
