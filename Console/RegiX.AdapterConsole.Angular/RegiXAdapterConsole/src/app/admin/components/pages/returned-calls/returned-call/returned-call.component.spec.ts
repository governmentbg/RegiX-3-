import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReturnedCallComponent } from './returned-call.component';

describe('ReturnedCallComponent', () => {
  let component: ReturnedCallComponent;
  let fixture: ComponentFixture<ReturnedCallComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReturnedCallComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReturnedCallComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
