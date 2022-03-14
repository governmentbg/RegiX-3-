import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MyOperationCallComponent } from './my-operation-call.component';

describe('OperationCallComponent', () => {
  let component: MyOperationCallComponent;
  let fixture: ComponentFixture<MyOperationCallComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MyOperationCallComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MyOperationCallComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
