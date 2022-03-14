import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportsForUserSelectComponent } from './reports-for-user-select.component';

describe('ReportsForUserSelectComponent', () => {
  let component: ReportsForUserSelectComponent;
  let fixture: ComponentFixture<ReportsForUserSelectComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReportsForUserSelectComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReportsForUserSelectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
