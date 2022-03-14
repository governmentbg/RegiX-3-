import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsumerRequestsApprovalComponent } from './consumer-requests-approval.component';

describe('ConsumerRequestsApprovalComponent', () => {
  let component: ConsumerRequestsApprovalComponent;
  let fixture: ComponentFixture<ConsumerRequestsApprovalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsumerRequestsApprovalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsumerRequestsApprovalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
