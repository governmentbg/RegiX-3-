import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportExecutionsComponent } from './report-executions.component';

describe('ReportExecutionsComponent', () => {
  let component: ReportExecutionsComponent;
  let fixture: ComponentFixture<ReportExecutionsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReportExecutionsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReportExecutionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
