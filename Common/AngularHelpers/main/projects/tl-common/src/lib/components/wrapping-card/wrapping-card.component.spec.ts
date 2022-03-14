import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WrappingCardComponent } from './wrapping-card.component';

describe('WrappingCardComponent', () => {
  let component: WrappingCardComponent;
  let fixture: ComponentFixture<WrappingCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WrappingCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WrappingCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
