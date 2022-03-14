import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsumerProfileUsersComponent } from './consumer-profile-users.component';

describe('ConsumerProfileUsersComponent', () => {
  let component: ConsumerProfileUsersComponent;
  let fixture: ComponentFixture<ConsumerProfileUsersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsumerProfileUsersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsumerProfileUsersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
