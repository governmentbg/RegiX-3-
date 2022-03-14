import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportResultDisplayComponent } from './report-result-display.component';

describe('ReportResultDisplayComponent', () => {
  let component: ReportResultDisplayComponent;
  let fixture: ComponentFixture<ReportResultDisplayComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReportResultDisplayComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReportResultDisplayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
