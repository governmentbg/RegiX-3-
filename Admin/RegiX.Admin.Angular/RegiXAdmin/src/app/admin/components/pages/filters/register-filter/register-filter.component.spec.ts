import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterFilterComponent } from './register-filter.component';

describe('RegisterFilterComponent', () => {
  let component: RegisterFilterComponent;
  let fixture: ComponentFixture<RegisterFilterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RegisterFilterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
