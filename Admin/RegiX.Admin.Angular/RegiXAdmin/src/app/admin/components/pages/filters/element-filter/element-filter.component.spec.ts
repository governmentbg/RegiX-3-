import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ElementFilterComponent } from './element-filter.component';

describe('ElementFilterComponent', () => {
  let component: ElementFilterComponent;
  let fixture: ComponentFixture<ElementFilterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ElementFilterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ElementFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
