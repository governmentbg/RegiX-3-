import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DecimalFieldComponent } from './decimal-field.component';

describe('DecimalFieldComponent', () => {
  let component: DecimalFieldComponent;
  let fixture: ComponentFixture<DecimalFieldComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DecimalFieldComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DecimalFieldComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
