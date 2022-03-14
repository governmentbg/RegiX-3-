import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AsyncReportViewComponent } from './async-report-view.component';

describe('AsyncReportViewComponent', () => {
  let component: AsyncReportViewComponent;
  let fixture: ComponentFixture<AsyncReportViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AsyncReportViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AsyncReportViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
