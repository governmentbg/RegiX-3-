import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EncapsulatedHtmlComponent } from './encapsulated-html.component';

describe('EncapsulatedHtmlComponent', () => {
  let component: EncapsulatedHtmlComponent;
  let fixture: ComponentFixture<EncapsulatedHtmlComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EncapsulatedHtmlComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EncapsulatedHtmlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
