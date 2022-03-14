import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LogReviewPrimaryFilterComponent } from './log-review-primary-filter.component';

describe('LogReviewPrimaryFilterComponent', () => {
  let component: LogReviewPrimaryFilterComponent;
  let fixture: ComponentFixture<LogReviewPrimaryFilterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LogReviewPrimaryFilterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LogReviewPrimaryFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
