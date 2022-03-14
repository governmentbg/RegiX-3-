import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ParametersHistoryFormComponent } from './parameters-history-form.component';

describe('ParametersHistoryFormComponent', () => {
  let component: ParametersHistoryFormComponent;
  let fixture: ComponentFixture<ParametersHistoryFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ParametersHistoryFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ParametersHistoryFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
