import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsumerProfileUsersTableComponent } from './consumer-profile-users-table.component';

describe('ConsumerProfileUsersComponent', () => {
  let component: ConsumerProfileUsersTableComponent;
  let fixture: ComponentFixture<ConsumerProfileUsersTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsumerProfileUsersTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsumerProfileUsersTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
