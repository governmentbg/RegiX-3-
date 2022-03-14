import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReferenceButtonComponent } from './reference-button.component';

describe('ReferenceButtonComponent', () => {
  let component: ReferenceButtonComponent;
  let fixture: ComponentFixture<ReferenceButtonComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReferenceButtonComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReferenceButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
