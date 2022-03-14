import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UsersSelectGlobalAdminComponent } from './users-select-global-admin.component';

describe('UsersSelectGlobalAdminComponent', () => {
  let component: UsersSelectGlobalAdminComponent;
  let fixture: ComponentFixture<UsersSelectGlobalAdminComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UsersSelectGlobalAdminComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UsersSelectGlobalAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
