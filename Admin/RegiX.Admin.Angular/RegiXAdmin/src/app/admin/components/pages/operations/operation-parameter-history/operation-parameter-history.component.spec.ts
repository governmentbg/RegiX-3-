import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OperationParameterHistoryComponent } from './operation-parameter-history.component';

describe('OperationParameterHistoryComponent', () => {
  let component: OperationParameterHistoryComponent;
  let fixture: ComponentFixture<OperationParameterHistoryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OperationParameterHistoryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OperationParameterHistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
