import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LogReviewAdministrationFilterComponent } from './log-review-administration-filter.component';

describe('LogReviewAdministrationFilterComponent', () => {
  let component: LogReviewAdministrationFilterComponent;
  let fixture: ComponentFixture<LogReviewAdministrationFilterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LogReviewAdministrationFilterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LogReviewAdministrationFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
