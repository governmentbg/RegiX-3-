import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OperationCallComponent } from './operation-call.component';

describe('OperationCallComponent', () => {
  let component: OperationCallComponent;
  let fixture: ComponentFixture<OperationCallComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OperationCallComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OperationCallComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
