import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsumerRequestOperationsFormComponent } from './consumer-request-operations-form.component';

describe('ConsumerRequestOperationsFormComponent', () => {
  let component: ConsumerRequestOperationsFormComponent;
  let fixture: ComponentFixture<ConsumerRequestOperationsFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsumerRequestOperationsFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsumerRequestOperationsFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
