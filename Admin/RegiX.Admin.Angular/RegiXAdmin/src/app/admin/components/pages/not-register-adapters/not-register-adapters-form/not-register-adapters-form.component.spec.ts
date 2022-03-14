import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NotRegisterAdaptersFormComponent } from './not-register-adapters-form.component';

describe('NotRegisterAdaptersFormComponent', () => {
  let component: NotRegisterAdaptersFormComponent;
  let fixture: ComponentFixture<NotRegisterAdaptersFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NotRegisterAdaptersFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NotRegisterAdaptersFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
