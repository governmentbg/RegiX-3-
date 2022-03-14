import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OperationParametersFormComponent } from './operation-parameters-form.component';

describe('OperationParametersFormComponent', () => {
  let component: OperationParametersFormComponent;
  let fixture: ComponentFixture<OperationParametersFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OperationParametersFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OperationParametersFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
