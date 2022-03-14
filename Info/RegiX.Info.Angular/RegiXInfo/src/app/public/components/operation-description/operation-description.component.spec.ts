import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OperationDescriptionComponent } from './operation-description.component';

describe('OperationDescriptionComponent', () => {
  let component: OperationDescriptionComponent;
  let fixture: ComponentFixture<OperationDescriptionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OperationDescriptionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OperationDescriptionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
