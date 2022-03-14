import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsumerProfilesApprovalComponent } from './consumer-profiles-approval.component';

describe('ConsumerProfilesApprovalComponent', () => {
  let component: ConsumerProfilesApprovalComponent;
  let fixture: ComponentFixture<ConsumerProfilesApprovalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsumerProfilesApprovalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsumerProfilesApprovalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
