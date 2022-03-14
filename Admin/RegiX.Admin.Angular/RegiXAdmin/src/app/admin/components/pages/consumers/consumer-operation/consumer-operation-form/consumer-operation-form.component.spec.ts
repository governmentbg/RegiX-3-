import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsumerOperationFormComponent } from './consumer-operation-form.component';

describe('ConsumerOperationFormComponent', () => {
  let component: ConsumerOperationFormComponent;
  let fixture: ComponentFixture<ConsumerOperationFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsumerOperationFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsumerOperationFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
