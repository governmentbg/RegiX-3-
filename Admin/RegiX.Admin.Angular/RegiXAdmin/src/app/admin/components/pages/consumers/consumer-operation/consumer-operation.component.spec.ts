import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsumerOperationComponent } from './consumer-operation.component';

describe('ConsumerOperationComponent', () => {
  let component: ConsumerOperationComponent;
  let fixture: ComponentFixture<ConsumerOperationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsumerOperationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsumerOperationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
