import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsumerAssessRequestStatusTableComponent } from './consumer-assess-request-status-table.component';

describe('ConsumerAssessRequestStatusTableComponent', () => {
  let component: ConsumerAssessRequestStatusTableComponent;
  let fixture: ComponentFixture<ConsumerAssessRequestStatusTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsumerAssessRequestStatusTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsumerAssessRequestStatusTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
