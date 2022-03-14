import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsumerRequestStatusTableComponent } from './consumer-request-status-table.component';

describe('ConsumerRequestStatusTableComponent', () => {
  let component: ConsumerRequestStatusTableComponent;
  let fixture: ComponentFixture<ConsumerRequestStatusTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsumerRequestStatusTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsumerRequestStatusTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
