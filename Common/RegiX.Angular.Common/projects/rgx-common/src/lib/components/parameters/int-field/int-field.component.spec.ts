import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IntFieldComponent } from './int-field.component';

describe('IntFieldComponent', () => {
  let component: IntFieldComponent;
  let fixture: ComponentFixture<IntFieldComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IntFieldComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IntFieldComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
