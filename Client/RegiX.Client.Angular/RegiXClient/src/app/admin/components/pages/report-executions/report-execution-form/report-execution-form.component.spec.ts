import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportExecutionFormComponent } from './report-execution-form.component';

describe('ReportExecutionFormComponent', () => {
  let component: ReportExecutionFormComponent;
  let fixture: ComponentFixture<ReportExecutionFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReportExecutionFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReportExecutionFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
