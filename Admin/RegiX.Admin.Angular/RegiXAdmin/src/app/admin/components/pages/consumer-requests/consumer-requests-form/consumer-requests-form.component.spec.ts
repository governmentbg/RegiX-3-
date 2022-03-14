import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsumerRequestsFormComponent } from './consumer-requests-form.component';

describe('ConsumerRequestsFormComponent', () => {
  let component: ConsumerRequestsFormComponent;
  let fixture: ComponentFixture<ConsumerRequestsFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsumerRequestsFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsumerRequestsFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
