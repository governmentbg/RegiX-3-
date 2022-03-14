import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsumerUserRegistrationComponent } from './consumer-user-registration.component';

describe('ConsumerUserRegistrationComponent', () => {
  let component: ConsumerUserRegistrationComponent;
  let fixture: ComponentFixture<ConsumerUserRegistrationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsumerUserRegistrationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsumerUserRegistrationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
