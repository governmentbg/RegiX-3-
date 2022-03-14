import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ArrayParameterComponent } from './array-parameter.component';

describe('ArrayParameterComponent', () => {
  let component: ArrayParameterComponent;
  let fixture: ComponentFixture<ArrayParameterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ArrayParameterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ArrayParameterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
