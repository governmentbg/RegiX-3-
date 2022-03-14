import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsumerProfileUsersFormComponent } from './consumer-profile-users-form.component';

describe('ConsumerProfileUsersFormComponent', () => {
  let component: ConsumerProfileUsersFormComponent;
  let fixture: ComponentFixture<ConsumerProfileUsersFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsumerProfileUsersFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsumerProfileUsersFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
