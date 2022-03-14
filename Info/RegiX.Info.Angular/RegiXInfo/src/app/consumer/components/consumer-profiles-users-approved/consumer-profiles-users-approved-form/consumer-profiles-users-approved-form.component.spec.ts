import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsumerProfilesUsersApprovedFormComponent } from './consumer-profiles-users-approved-form.component';

describe('ConsumerProfilesUsersApprovedFormComponent', () => {
  let component: ConsumerProfilesUsersApprovedFormComponent;
  let fixture: ComponentFixture<ConsumerProfilesUsersApprovedFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsumerProfilesUsersApprovedFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsumerProfilesUsersApprovedFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
