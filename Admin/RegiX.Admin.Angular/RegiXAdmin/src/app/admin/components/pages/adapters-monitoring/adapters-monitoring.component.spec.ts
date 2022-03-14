import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdaptersMonitoringComponent } from './adapters-monitoring.component';

describe('AdaptersMonitoringComponent', () => {
  let component: AdaptersMonitoringComponent;
  let fixture: ComponentFixture<AdaptersMonitoringComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdaptersMonitoringComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdaptersMonitoringComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
