import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsumerProfilesUsersApprovedComponent } from './consumer-profiles-users-approved.component';

describe('ConsumerProfilesUsersApprovedComponent', () => {
  let component: ConsumerProfilesUsersApprovedComponent;
  let fixture: ComponentFixture<ConsumerProfilesUsersApprovedComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsumerProfilesUsersApprovedComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsumerProfilesUsersApprovedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
