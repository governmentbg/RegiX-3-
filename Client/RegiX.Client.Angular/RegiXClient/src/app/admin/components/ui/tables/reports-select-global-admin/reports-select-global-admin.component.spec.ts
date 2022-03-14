import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportsSelectGlobalAdminComponent } from './reports-select-global-admin.component';

describe('ReportsSelectGlobalAdminComponent', () => {
  let component: ReportsSelectGlobalAdminComponent;
  let fixture: ComponentFixture<ReportsSelectGlobalAdminComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReportsSelectGlobalAdminComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReportsSelectGlobalAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
