import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MyOperationCallsComponent } from './my-operation-calls.component';

describe('OperationCallsComponent', () => {
  let component: MyOperationCallsComponent;
  let fixture: ComponentFixture<MyOperationCallsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MyOperationCallsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MyOperationCallsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
