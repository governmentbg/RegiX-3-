import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SystemErrorFormComponent } from './system-error-form.component';

describe('SystemErrorFormComponent', () => {
  let component: SystemErrorFormComponent;
  let fixture: ComponentFixture<SystemErrorFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SystemErrorFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SystemErrorFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
