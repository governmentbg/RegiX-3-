import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InterfaceFormComponent } from './interface-form.component';

describe('InterfaceFormComponent', () => {
  let component: InterfaceFormComponent;
  let fixture: ComponentFixture<InterfaceFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InterfaceFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InterfaceFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
