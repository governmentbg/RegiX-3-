import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OperationCallsComponent } from './operation-calls.component';

describe('OperationCallsComponent', () => {
  let component: OperationCallsComponent;
  let fixture: ComponentFixture<OperationCallsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OperationCallsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OperationCallsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
