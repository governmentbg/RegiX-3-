import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReturnedCallsComponent } from './returned-calls.component';

describe('ReturnedCallsComponent', () => {
  let component: ReturnedCallsComponent;
  let fixture: ComponentFixture<ReturnedCallsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReturnedCallsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReturnedCallsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
