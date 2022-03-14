import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OperationParametersComponent } from './operation-parameters.component';

describe('OperationParametersComponent', () => {
  let component: OperationParametersComponent;
  let fixture: ComponentFixture<OperationParametersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OperationParametersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OperationParametersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
