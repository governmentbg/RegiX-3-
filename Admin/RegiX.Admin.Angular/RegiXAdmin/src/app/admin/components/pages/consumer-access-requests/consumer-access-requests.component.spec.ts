import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsumerAccessRequestsComponent } from './consumer-access-requests.component';

describe('ConsumerAccessRequestsComponent', () => {
  let component: ConsumerAccessRequestsComponent;
  let fixture: ComponentFixture<ConsumerAccessRequestsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsumerAccessRequestsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsumerAccessRequestsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
