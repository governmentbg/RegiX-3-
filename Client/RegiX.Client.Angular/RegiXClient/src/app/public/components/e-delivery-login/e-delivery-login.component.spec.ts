import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EDeliveryLoginComponent } from './e-delivery-login.component';

describe('EDeliveryLoginComponent', () => {
  let component: EDeliveryLoginComponent;
  let fixture: ComponentFixture<EDeliveryLoginComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EDeliveryLoginComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EDeliveryLoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
