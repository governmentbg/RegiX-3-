import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsumerProfileUserComponent } from './consumer-profile-user.component';

describe('ConsumerProfileUserComponent', () => {
  let component: ConsumerProfileUserComponent;
  let fixture: ComponentFixture<ConsumerProfileUserComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsumerProfileUserComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsumerProfileUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
