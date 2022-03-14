import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SystemErrorsFormComponent } from './system-errors-form.component';

describe('SystemErrorsFormComponent', () => {
  let component: SystemErrorsFormComponent;
  let fixture: ComponentFixture<SystemErrorsFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SystemErrorsFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SystemErrorsFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
