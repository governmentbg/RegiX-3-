import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HealthMonitoringComponent } from './health-monitoring.component';

describe('HealthMonitoringComponent', () => {
  let component: HealthMonitoringComponent;
  let fixture: ComponentFixture<HealthMonitoringComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HealthMonitoringComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HealthMonitoringComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
