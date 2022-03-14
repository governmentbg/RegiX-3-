import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ElementAccessComponent } from './element-access.component';

describe('ElementAccessComponent', () => {
  let component: ElementAccessComponent;
  let fixture: ComponentFixture<ElementAccessComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ElementAccessComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ElementAccessComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
