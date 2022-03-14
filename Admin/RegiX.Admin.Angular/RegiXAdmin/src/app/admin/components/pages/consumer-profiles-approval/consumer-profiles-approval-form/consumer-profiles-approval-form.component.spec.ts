import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsumerProfilesApprovalFormComponent } from './consumer-profiles-approval-form.component';

describe('ConsumerProfilesApprovalFormComponent', () => {
  let component: ConsumerProfilesApprovalFormComponent;
  let fixture: ComponentFixture<ConsumerProfilesApprovalFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsumerProfilesApprovalFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsumerProfilesApprovalFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
