import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NotRegisterAdaptersComponent } from './not-register-adapters.component';

describe('NotRegisterAdaptersComponent', () => {
  let component: NotRegisterAdaptersComponent;
  let fixture: ComponentFixture<NotRegisterAdaptersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NotRegisterAdaptersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NotRegisterAdaptersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
