import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsumerAccessRequestsFormComponent } from './consumer-access-requests-form.component';

describe('ConsumerAccessRequestsFormComponent', () => {
  let component: ConsumerAccessRequestsFormComponent;
  let fixture: ComponentFixture<ConsumerAccessRequestsFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsumerAccessRequestsFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsumerAccessRequestsFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
