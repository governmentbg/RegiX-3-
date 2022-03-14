import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsumerRequestOperationsComponent } from './consumer-request-operations.component';

describe('ConsumerRequestOperationsComponent', () => {
  let component: ConsumerRequestOperationsComponent;
  let fixture: ComponentFixture<ConsumerRequestOperationsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsumerRequestOperationsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsumerRequestOperationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
